using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UCNLDrivers;
using UCNLKML;
using UCNLNav;
using UCNLUI.Dialogs;
using ZHost.CustomUI;
using ZLibrary;

namespace ZHost
{
    public partial class MainForm : Form
    {
        #region Properties

        ZCore zcore;
        TSLogProvider logger;
        TSLogProvider outputPortLogger;
        SimpeSettingsProviderXML<SettingsContainer> settingsProvider;

        string settingsFileName;
        string logPath;
        string logFileName;
        string snapshotsPath;

        Dictionary<string, List<GeoPoint3DTm>> tracks;
        bool isTracksEmpty;
        bool IsTracksEmpty
        {
            get { return isTracksEmpty; }
            set
            {
                if (value != isTracksEmpty)
                {
                    isTracksEmpty = value;

                    InvokeSetEnabledState(mainToolStrip, trackSaveAsBtn, !isTracksEmpty);
                    InvokeSetEnabledState(mainToolStrip, trackClearBtn, !isTracksEmpty);
                }
            }
        }

        bool isRestart = false;
        bool isAutoSnapshot = false;
        bool isRespondersTreeViewCollapsed = true;

        DateTime respondersUpdateTS;
        DateTime stationInfoUpdateTS;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();                     

            #region paths & filenames

            DateTime startTime = DateTime.Now;
            settingsFileName = Path.ChangeExtension(Application.ExecutablePath, "settings");
            logPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
            logFileName = StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "log", true);
            snapshotsPath = StrUtils.GetTimeDirTree(startTime, Application.ExecutablePath, "SNAPSHOTS", false);

            #endregion

            #region logger

            logger = new TSLogProvider(logFileName);
            logger.WriteStart();
            logger.Write(string.Format("{0} v{1}", Application.ProductName, Assembly.GetExecutingAssembly().GetName().Version.ToString()));

            #endregion

            #region Custom string resources

            logger.Write("Loading resources...");
            try
            {
                LocStringManager.Init("ZHost.CustomUI.LocStringResources", Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            #endregion

            #region settings

            settingsProvider = new SimpeSettingsProviderXML<SettingsContainer>();
            settingsProvider.isSwallowExceptions = false;

            logger.Write(string.Format("Loading settings from {0}", settingsFileName));

            try
            {
                settingsProvider.Load(settingsFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            logger.Write("Settings:");
            logger.Write(settingsProvider.Data.ToString());

            #endregion            

            #region Misc

            tracks = new Dictionary<string, List<GeoPoint3DTm>>();
            IsTracksEmpty = true;

            #endregion

            #region zcore

            zcore = new ZCore(new SerialPortSettings(settingsProvider.Data.ZPortName, settingsProvider.Data.ZPortBaudrate,
                System.IO.Ports.Parity.None, DataBits.dataBits8, System.IO.Ports.StopBits.One, System.IO.Ports.Handshake.None),
                settingsProvider.Data.IsRedPhoneCompatibilityMode);
            
            zcore.LogEventHandler += (o, e) => logger.Write(string.Format("{0}: {1}", e.EventType, e.LogString));
            zcore.ZPortStateChangedEventHandler += (o, e) => InvokeSetText(mainStatusStrip, zmaStateLbl, string.Format("ZMA: {0}", zcore.ZPortState));

            zcore.GNSSPortStateChangedEventHandler += (o, e) => InvokeSetText(mainStatusStrip, gnssStateLbl, string.Format("GNSS: {0}", zcore.GNSSPortState));
            zcore.HDGPortStateChangedEventHandler += (o, e) => InvokeSetText(mainStatusStrip, hdgStateLbl, string.Format("HDG: {0}", zcore.HDGPortState));
            zcore.GeoLocationUpdatedEventHandler += (o, e) => TracksWritePoint(e.ItemName, new GeoPoint3DTm(e.Latitude, e.Longitude, e.Depth, e.TimeStamp));
            zcore.OutPortStateChangedEventHandler += (o, e) => InvokeSetText(mainStatusStrip, outPortStateLbl, string.Format("OUT: {0}", zcore.OutPortState));

            if (settingsProvider.Data.IsAUX1 || settingsProvider.Data.IsAUX2)
            {
                List<SerialPortSettings> auxPortsSettings = new List<SerialPortSettings>();

                if (settingsProvider.Data.IsAUX1)
                    auxPortsSettings.Add(new SerialPortSettings(settingsProvider.Data.AUX1PortName, settingsProvider.Data.AUX1PortBaudrate,
                        System.IO.Ports.Parity.None, DataBits.dataBits8, System.IO.Ports.StopBits.One, System.IO.Ports.Handshake.None));

                if (settingsProvider.Data.IsAUX2)
                    auxPortsSettings.Add(new SerialPortSettings(settingsProvider.Data.AUX2PortName, settingsProvider.Data.AUX2PortBaudrate,
                        System.IO.Ports.Parity.None, DataBits.dataBits8, System.IO.Ports.StopBits.One, System.IO.Ports.Handshake.None));

                try
                {
                    zcore.AUXSourcesInit(auxPortsSettings.ToArray());
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }                
            }

            if (settingsProvider.Data.IsUseOutputPort)
            {                
                try
                {
                    zcore.OutPortInit(new SerialPortSettings(settingsProvider.Data.OutputPortName, settingsProvider.Data.OutputPortBaudrate,
                     System.IO.Ports.Parity.None, DataBits.dataBits8, System.IO.Ports.StopBits.One, System.IO.Ports.Handshake.None),
                     settingsProvider.Data.OutputPortResponderAddress);
                }
                catch (Exception ex)
                {
                    ProcessException(ex, true);
                }                

                outputPortLogger = new TSLogProvider(StrUtils.GetTimeDirTreeFileName(startTime, Application.ExecutablePath, "LOG", "olog", true));
                zcore.WrittenToOutputPortEventHandler += (o, e) => outputPortLogger.Write(e.Value);
            }

            zcore.StationUpdatedEventHandler += new EventHandler(zcore_StationUpdatedEventHandler);
            zcore.RespondersUpdatedEventHandler += new EventHandler(zcore_RespondersUpdatedEventHandler);

            zcore.IsStationDeviceInfoUpdatedChangedEventHandler += (o, e) =>
                {
                    InvokeSetEnabledState(mainToolStrip, stationViewInfoBtn, zcore.IsStationDeviceInfoUpdated);

                    responderRemoteCommandSendBtn.Enabled = !zcore.IsAutoQuery && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
                    responderChangeAddressBtn.Enabled = !zcore.IsAutoQuery && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
                    responderZeroDepthAdjustBtn.Enabled = !zcore.IsAutoQuery && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
                };
            zcore.RemoteActionProgessEventHandler += (o, e) => InvokeSetText(mainStatusStrip, remoteActionLbl, e.Value);
            zcore.On1PPSEventHandler += new EventHandler(zcore_On1PPSEventHandler);

            zcore.IsRoughDepth = settingsProvider.Data.IsCoarseDepth;
            zcore.MaxDistance_m = settingsProvider.Data.MaxDistance_m;
            zcore.StationAdjustAngle = settingsProvider.Data.AntennaAdjustAngle;
            zcore.StationOffsetX = settingsProvider.Data.AntennaDx;
            zcore.StationOffsetY = settingsProvider.Data.AntennaDy;
            zcore.WaterSalinity_PSU = settingsProvider.Data.Salinity_PSU;
            zcore.IsUseVTGAsHeadingSource = settingsProvider.Data.IsUseVTGAsHeadingSource;
            zcore.IsHeadingFixed = settingsProvider.Data.IsHeadingFixed;
                        
            OnZCoreRunningStatedChanged(false);

            foreach (var item in settingsProvider.Data.RespondersInUseAddresses)
                zcore.AddResponder(item);

            #endregion
        }

        #endregion

        #region Methods

        #region UI Invokers

        private void InvokeSetText(StatusStrip strip, ToolStripStatusLabel lbl, string text)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { lbl.Text = text; });
            else
                lbl.Text = text;
        }

        private void InvokeSetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Text = text; });
            else
                ctrl.Text = text;
        }

        private void InvokeSetEnabledState(Control ctrl, bool isEnabled)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Enabled = isEnabled; });
            else
                ctrl.Enabled = isEnabled;
        }

        private void InvokeSetEnabledState(ToolStrip strip, ToolStripItem item, bool isEnabled)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { item.Enabled = isEnabled; });
            else
                item.Enabled = isEnabled;
        }

        private void InvokeSetBackColor(StatusStrip strip, ToolStripStatusLabel lbl, Color backColor)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { lbl.BackColor = backColor; });
            else
                lbl.BackColor = backColor;
        }

        #endregion

        private void UpdateRespondersView()
        {
            foreach (var item in zcore.Responders)
            {
                if (item.Value.DistanceProjection.IsInitialized &&
                    item.Value.Azimuth.IsInitialized)

                    ppiView.SetTarget(((int)item.Value.ID).ToString(),
                        item.Value.DistanceProjection.Value,
                        item.Value.Azimuth.Value,
                        !item.Value.IsTimeout.IsInitialized || item.Value.IsTimeout.Value);
            }

            ppiView.Invalidate();
        }
        
        private void OnRespondersUpdated()
        {
            UpdateRespondersTree();
            UpdateRespondersView();      
            respondersUpdateTS = DateTime.Now;

            if (isAutoSnapshot)
                SaveFullSnapshot();
        }

        private void OnSystemStateUpdated()
        {
            stationZeroDepthAdjustmentBtn.Enabled = zcore.Depth.IsInitializedAndNotObsolete;

            ppiView.LeftUpperCornerText = zcore.GetStationStateDescription(StationDataID.TRX | 
                StationDataID.DPT | StationDataID.TMP, 
                true);

            ppiView.LeftBottomLine = zcore.GetStationStateDescription(StationDataID.LAT |
                StationDataID.LON | StationDataID.SPD |
                StationDataID.VTG | StationDataID.AZM | 
                StationDataID.PTC | StationDataID.ROL,
                true);

            if (zcore.Azimuth.IsInitializedAndNotObsolete)
                ppiView.Heading = zcore.Azimuth.Value;
            else
                ppiView.Heading = double.NaN;

            if (zcore.isDepthLessThanAllowed)
                ppiView.RightTopLine = LocStringManager.StationDepthIsNotEnough_str;
            else
                ppiView.RightTopLine = string.Empty;

            ppiView.Invalidate();

            stationInfoUpdateTS = DateTime.Now;
        }

        private void SaveFullSnapshot()
        {
            Bitmap target = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(target, this.DisplayRectangle);

            try
            {
                if (!Directory.Exists(snapshotsPath))
                    Directory.CreateDirectory(snapshotsPath);

                target.Save(Path.Combine(snapshotsPath, string.Format("{0}.{1}", StrUtils.GetHMSString(), ImageFormat.Png)));
            }
            catch
            {
                //
            }
        }

        private void ProcessException(Exception ex, bool isShowMessageBox)
        {
            logger.Write(ex);

            if (isShowMessageBox)
                MessageBox.Show(ex.Message, LocStringManager.Error_str, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnZCoreRunningStatedChanged(bool newState)
        {
            settingsBtn.Enabled = !newState;

            stationViewInfoBtn.Enabled = false;
            stationZeroDepthAdjustmentBtn.Enabled = false;

            responderRemoteCommandSendBtn.Enabled = false;
            responderChangeAddressBtn.Enabled = false;
            responderZeroDepthAdjustBtn.Enabled = false;

            isAutoQueryBtn.Enabled = newState;
            connectionBtn.Checked = newState;

            logAnalyzeBtn.Enabled = !newState;
            logAnalyzeCurrentBtn.Enabled = !newState;

            logger.Write(string.Format("IsRunning = {0}", zcore.IsRunning));
        }

        private void OnZCoreAutoQueryStateChanged(bool newState)
        {
            responderRemoteCommandSendBtn.Enabled = !newState && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
            responderChangeAddressBtn.Enabled = !newState && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
            responderZeroDepthAdjustBtn.Enabled = !newState && zcore.IsRunning && zcore.IsStationDeviceInfoUpdated;
            logger.Write(string.Format("IsAutoQuery = {0}", zcore.IsAutoQuery));
        }

        private void TracksWritePoint(string key, GeoPoint3DTm point)
        {
            if (!tracks.ContainsKey(key))
                tracks.Add(key, new List<GeoPoint3DTm>());

            tracks[key].Add(point);

            if (isTracksEmpty)
                IsTracksEmpty = false;
        }

        private void TracksClear()
        {
            tracks.Clear();
            IsTracksEmpty = true;
        }

        private void UpdateRespondersTree()
        {
            foreach (var responder in zcore.Responders)
            {
                string rKey = responder.Value.ToString();
                var rItems = responder.Value.ToStrings(true);
                TreeNode bNode;

                if (!respondersTreeView.Nodes.ContainsKey(rKey))
                {
                    bNode = respondersTreeView.Nodes.Add(rKey, rKey);
                }
                else
                {
                    bNode = respondersTreeView.Nodes[rKey];
                }

                // Remove entries from the tree ctrl, which are not present in rItems
                for (int i = bNode.Nodes.Count - 1; i >= 0; i--)
                {
                    if (!rItems.ContainsKey(bNode.Nodes[i].Name))
                        bNode.Nodes.RemoveByKey(bNode.Nodes[i].Name);
                }

                foreach (var rItem in rItems)
                {
                    if (!bNode.Nodes.ContainsKey(rItem.Key))
                    {
                        bNode.Nodes.Add(rItem.Key, string.Format("{0}: {1}", rItem.Key, rItem.Value));
                    }
                    else
                    {
                        bNode.Nodes[rItem.Key].Text = string.Format("{0}: {1}", rItem.Key, rItem.Value);
                    }
                }
            }

            respondersTreeView.Invalidate();
        }

        private bool SaveTracksAsKML(string fileName)
        {
            KMLData data = new KMLData(fileName, "Generated by ZHost application");
            List<KMLLocation> kmlTrack;

            foreach (var item in tracks)
            {
                kmlTrack = new List<KMLLocation>();
                foreach (var point in item.Value)
                    kmlTrack.Add(new KMLLocation(point.Longitude, point.Latitude, -point.Depth));

                data.Add(new KMLPlacemark(string.Format("{0} track", item.Key), "", kmlTrack.ToArray()));
            }

            bool isOk = false;
            try
            {
                TinyKML.Write(data, fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private bool SaveTracksAsCSV(string fileName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var track in tracks)
            {
                sb.AppendFormat("\r\nTrack name: {0}\r\n", track.Key);
                sb.Append("HH:MM:SS;LAT;LON;DPT;\r\n");

                foreach (var point in track.Value)
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture,
                        "{0:00};{1:00};{2:00};{3:F06};{4:F06};{5:F03}\r\n",
                        point.TimeStamp.Hour,
                        point.TimeStamp.Minute,
                        point.TimeStamp.Second,
                        point.Latitude,
                        point.Longitude,
                        point.Depth);
                }
            }

            bool isOk = false;
            try
            {
                File.WriteAllText(fileName, sb.ToString());
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }

            return isOk;
        }

        private void AnalyzeLog(string fileName)
        {
            string[] lines = null;
            bool isOk = false;

            try
            {
                lines = File.ReadAllLines(fileName);
                isOk = true;
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
            
            if (isOk)
            {
                // Disable controls
                mainToolStrip.Enabled = false;

                foreach (var line in lines)
                {
                    int stIdx = line.IndexOf('$');
                    if (stIdx >= 0)
                    {
                        var str = line.Substring(stIdx) + "\r\n";
                        zcore.EmulationInput(str);                        
                        Application.DoEvents();                        
                    }
                }

                MessageBox.Show(string.Format("{0} '{1}' {2}", 
                    LocStringManager.AnalysissOf_str,
                    Path.GetFileNameWithoutExtension(fileName),
                    LocStringManager.IsComplete_str), 
                    LocStringManager.Information_str,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                mainToolStrip.Enabled = true;
                // enable controls
            }
        }

        #endregion

        #region Handlers

        #region UI

        #region mainToolStrip

        #region connection

        private void connectionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (zcore.IsRunning)
                    zcore.Stop();
                else
                    zcore.Start();
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }            

            OnZCoreRunningStatedChanged(zcore.IsRunning);
            OnZCoreAutoQueryStateChanged(zcore.IsAutoQuery);
        }

        #endregion

        #region station

        private void stationViewInfoBtn_Click(object sender, EventArgs e)
        {
            using (InfoWindow iDialog = new InfoWindow())
            {
                iDialog.HostMoniker = Application.ProductName;
                iDialog.Moniker = LocStringManager.StationInfo_str;

                iDialog.InfoText = string.Format("System: {0}\nCore: {1}\nS/N: {2}", 
                    zcore.StationSystemDescription,
                    zcore.StationCoreDescription, 
                    zcore.StationSerialNumber);

                iDialog.ShowDialog();            }
        }

        private void stationZeroDepthAdjustmentBtn_Click(object sender, EventArgs e)
        {
            using (NumEditDialog nDialog = new NumEditDialog())
            {
                nDialog.Title = string.Format("{0} - {1}", Application.ProductName, LocStringManager.SetActualStationDepth_str);
                nDialog.Caption = LocStringManager.ActualDepth_str;
                nDialog.DecimalPlaces = 3;
                nDialog.Minimum = 0;
                nDialog.Maximum = 99;
                nDialog.SetButtonsCaseStyle(true);

                if (nDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        zcore.SetActualDepth(nDialog.Value);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        #endregion

        #region responder

        private void responderRemoteCommandSendBtn_Click(object sender, EventArgs e)
        {
            using (RemoteCommandDialog rDialog = new RemoteCommandDialog())
            {
                rDialog.HostMoniker = Application.ProductName;
                rDialog.Moniker = LocStringManager.RemoteCommand_str;

                if (rDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        zcore.RemoteCommand(rDialog.TargetAddress, rDialog.RemoteCmdID);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void responderChangeAddressBtn_Click(object sender, EventArgs e)
        {
            using (RemoteAddressChangeDialog rDialog = new RemoteAddressChangeDialog())
            {
                rDialog.HostMoniker = Application.ProductName;
                rDialog.Moniker = LocStringManager.RemoteAddressChange_str;

                if (rDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        zcore.RemoteAddressChange(rDialog.CurrentTargetAddress, rDialog.NewTargetAddress);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }
        }

        private void responderZeroDepthAdjustBtn_Click(object sender, EventArgs e)
        {
            using (RemoteCommandDialog rDialog = new RemoteCommandDialog())
            {
                rDialog.HostMoniker = Application.ProductName;
                rDialog.Moniker = LocStringManager.ResponderZeroDepthAdjust_str;
                rDialog.SetCommandsList(new CDS_NODE_CMD_Enum[] { CDS_NODE_CMD_Enum.CDS_CMD_ZDPT_ADJ });

                if (rDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {                        
                        zcore.RemoteCommand(rDialog.TargetAddress, rDialog.RemoteCmdID);
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }
            }            
        }

        #endregion

        #region log

        private void logViewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(logFileName);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void logAnalyzeCurrentBtn_Click(object sender, EventArgs e)
        {
            AnalyzeLog(logFileName);
        }

        private void logAnalyzeBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDoialog = new OpenFileDialog())
            {
                oDoialog.Title = LocStringManager.SelectALogFileToEmulate_str;
                oDoialog.Filter = string.Format("{0} (*.log)|*.log", LocStringManager.LogFiles_str);

                if (oDoialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    AnalyzeLog(oDoialog.FileName);
                }
            }
        }

        private void logRestartCurrentBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocStringManager.RestartLogPrompt_str, LocStringManager.Warning_str, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                logger.Restart();
                MessageBox.Show(LocStringManager.LogRestarted_str,
                                LocStringManager.Information_str,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }           
        }

        private void logClearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocStringManager.ClearLogsPrompt_str,
                                LocStringManager.Question_str, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string logRootPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "LOG");
                var dirs = Directory.GetDirectories(logRootPath);
                int dirNum = 0;
                foreach (var item in dirs)
                {
                    try
                    {
                        Directory.Delete(item, true);
                        dirNum++;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }
                }

                MessageBox.Show(string.Format("{0} {1}", dirNum, LocStringManager.EntriesWereDeleted_str), 
                    LocStringManager.Information_str, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        #endregion

        #region track

        private void trackSaveAsBtn_Click(object sender, EventArgs e)
        {
            bool isSaved = false;

            using (SaveFileDialog sDilog = new SaveFileDialog())
            {
                sDilog.Title = LocStringManager.SaveTracksAs_str;
                sDilog.Filter = "Google KML (*.kml)|*.kml|CSV (*.csv)|*.csv";
                sDilog.FileName = string.Format("ZHost_tracks_{0}", StrUtils.GetHMSString());

                if (sDilog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sDilog.FilterIndex == 1)
                        isSaved = SaveTracksAsKML(sDilog.FileName);
                    else if (sDilog.FilterIndex == 2)
                        isSaved = SaveTracksAsCSV(sDilog.FileName);
                }
            }

            if (isSaved &&
                MessageBox.Show(LocStringManager.ClearTracksAfterSavePrompt_str, //"Tracks saved, do you want to clear all tracks data?", 
                LocStringManager.Question_str, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            TracksClear();
        }

        private void trackClearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocStringManager.ClearTracksPrompt_str,
                                LocStringManager.Question_str, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tracks.Clear();
        }

        #endregion

        #region settings

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            using (SettingsEditor sEditor = new SettingsEditor())
            {
                sEditor.HostMoniker = Application.ProductName;
                sEditor.Moniker = LocStringManager.Settings_str;
                sEditor.Value = settingsProvider.Data;

                if (sEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bool isSaved = false;
                    settingsProvider.Data = sEditor.Value;

                    try
                    {
                        settingsProvider.Save(settingsFileName);
                        isSaved = true;
                    }
                    catch (Exception ex)
                    {
                        ProcessException(ex, true);
                    }

                    if ((isSaved) && (MessageBox.Show(LocStringManager.SettingsSavedRestartPrompt_str,
                        LocStringManager.Question_str,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))                    
                    {
                        isRestart = true;
                        Application.Restart();
                    }
                }
            }
        }

        #endregion

        #region info

        private void infoBtn_Click(object sender, EventArgs e)
        {
            using (AboutBox aDialog = new AboutBox())
            {
                aDialog.ApplyAssembly(Assembly.GetExecutingAssembly());
                aDialog.Weblink = "www.unavlab.com";
                aDialog.ShowDialog();
            }
        }

        #endregion

        #endregion

        #region mainToolStripEx

        private void isAutoQueryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                zcore.IsAutoQuery = !zcore.IsAutoQuery;
                OnZCoreAutoQueryStateChanged(zcore.IsAutoQuery);
            }
            catch (Exception ex)
            {
                ProcessException(ex, true);
            }
        }

        private void isAutoSnapshotBtn_Click(object sender, EventArgs e)
        {
            isAutoSnapshot = !isAutoSnapshot;
            isAutoSnapshotBtn.Checked = isAutoSnapshot;
        }

        #endregion

        #region respondersToolStrip

        private void respondersTreeExpandBtn_Click(object sender, EventArgs e)
        {
            if (isRespondersTreeViewCollapsed)
            {
                respondersTreeView.ExpandAll();
                respondersTreeExpandBtn.Text = "◤";
                respondersTreeExpandBtn.ToolTipText = LocStringManager.Collapse_str;
            }
            else
            {
                respondersTreeView.CollapseAll();
                respondersTreeExpandBtn.Text = "◢";
                respondersTreeExpandBtn.ToolTipText = LocStringManager.Expand_str;
            }

            isRespondersTreeViewCollapsed = !isRespondersTreeViewCollapsed;
        }

        #endregion

        #region mainForm

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !isRestart && (MessageBox.Show(string.Format("{0} {1}?", LocStringManager.Close_str, Application.ProductName),
                                                      LocStringManager.Question_str,
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes);            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (zcore.IsRunning)
            {
                try
                {
                    zcore.Stop();
                }
                catch (Exception ex)
                {
                    ProcessException(ex, false);
                }
            }

            zcore.Dispose();

            if (outputPortLogger != null)
            {
                outputPortLogger.FinishLog();
                outputPortLogger.Flush();
            }

            logger.FinishLog();
            logger.Flush();
        }

        #endregion

        #endregion

        #region zCore

        private void zcore_StationUpdatedEventHandler(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { OnSystemStateUpdated(); });
            else
                OnSystemStateUpdated();
        }

        private void zcore_RespondersUpdatedEventHandler(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { OnRespondersUpdated(); });
            else
                OnRespondersUpdated();            
        }

        private void zcore_On1PPSEventHandler(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (now.Subtract(stationInfoUpdateTS).TotalSeconds > 1)
                zcore_StationUpdatedEventHandler(this, e);

            if (now.Subtract(respondersUpdateTS).TotalSeconds > 1)
                zcore_RespondersUpdatedEventHandler(this, e);
        }

        #endregion

        #endregion
    }
}