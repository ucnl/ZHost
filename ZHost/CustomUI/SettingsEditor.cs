using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using UCNLUI.Dialogs;
using ZLibrary;

namespace ZHost.CustomUI
{
    public partial class SettingsEditor : Form
    {
        #region Properties

        string moniker = "Settings";
        public string Moniker
        {
            get { return moniker; }
            set
            {
                moniker = value;
                this.Text = string.Format("{0} - {1}", hostMoniker, moniker);
            }
        }

        string hostMoniker = string.Empty;
        public string HostMoniker
        {
            set
            {
                hostMoniker = value;
                this.Text = string.Format("{0} - {1}", hostMoniker, moniker);
            }
            get
            {
                return hostMoniker;
            }
        }

        public SettingsContainer Value
        {
            get
            {
                SettingsContainer result = new SettingsContainer();

                result.AntennaAdjustAngle = delta;
                result.AntennaDx = dX;
                result.AntennaDy = dY;
                result.AUX1PortBaudrate = aux1PortBaudRate;
                result.AUX1PortName = aux1PortName;
                result.AUX2PortBaudrate = aux2PortBaudRate;
                result.AUX2PortName = aux2PortName;
                result.DataObsoleteThreshold_sec = dataObsoleteThreshold;
                result.IsAutoSoundSpeed = isAutocalculateSoundSpeed;
                result.IsAUX1 = isUseAUX1;
                result.IsAUX2 = isUseAUX2;
                result.IsCoarseDepth = isRoughDepth;
                result.IsOutputSave = isOutputPortSaveSeparately;
                result.IsUseOutputPort = isUseOutputPort;
                result.IsUseVTGAsHeadingSource = isUseVTGAsHeadingSource;
                result.MaxDistance_m = maxDistance;
                result.OutputPortBaudrate = outputPortBaudrate;
                result.OutputPortName = outputPortName;
                result.OutputPortResponderAddress = outputPortResponderAddress;
                result.RespondersInUseAddresses = usedResponderAddresses.ToArray();
                result.Salinity_PSU = salinity;
                result.SoundSpeed = soundSpeed;
                result.ZPortBaudrate = zmaBaudRate;
                result.ZPortName = zmaPortName;
                result.IsHeadingFixed = isHeadingFixed;
                result.IsSaveAUXToLog = isSaveAUXToLog;

                result.IsCalBuoy = isUseCalBuoy;
                result.CalBuoyPortName = calBuoyPortName;
                result.CalBuoyPortBaudrate = calBuoyPortBaudRate;
                result.CalBuoyResponderAddress = calBuoyResponderAddress;
                result.CalPointsNumber = calPointsNumber;

                return result;
            }
            set
            {
                delta = value.AntennaAdjustAngle;
                dX = value.AntennaDx;
                dY = value.AntennaDy;
                aux1PortBaudRate = value.AUX1PortBaudrate;
                aux1PortName = value.AUX1PortName;
                aux2PortBaudRate = value.AUX2PortBaudrate;
                aux2PortName = value.AUX2PortName;
                dataObsoleteThreshold = value.DataObsoleteThreshold_sec;
                isAutocalculateSoundSpeed = value.IsAutoSoundSpeed;
                isUseAUX1 = value.IsAUX1;
                isUseAUX2 = value.IsAUX2;
                isRoughDepth = value.IsCoarseDepth;
                isOutputPortSaveSeparately = value.IsOutputSave;
                isUseOutputPort = value.IsUseOutputPort;
                isUseVTGAsHeadingSource = value.IsUseVTGAsHeadingSource;
                maxDistance = value.MaxDistance_m;
                outputPortBaudrate = value.OutputPortBaudrate;
                outputPortName = value.OutputPortName;
                outputPortResponderAddress = value.OutputPortResponderAddress;
                usedResponderAddresses = new List<ZAddress>(value.RespondersInUseAddresses);
                salinity = value.Salinity_PSU;
                soundSpeed = value.SoundSpeed;
                zmaBaudRate = value.ZPortBaudrate;
                zmaPortName = value.ZPortName;
                isHeadingFixed = value.IsHeadingFixed;
                isSaveAUXToLog = value.IsSaveAUXToLog;

                isUseCalBuoy = value.IsCalBuoy;
                calBuoyPortName = value.CalBuoyPortName;
                calBuoyPortBaudRate = value.CalBuoyPortBaudrate;
                calBuoyResponderAddress = value.CalBuoyResponderAddress;
                calPointsNumber = value.CalPointsNumber;
            }
        }

        #region CONNECTION Tab

        string zmaPortName
        {
            get { return UIUtils.TryGetCbxItem(zmaPortNameCbx); }
            set { UIUtils.TrySetCbxItem(zmaPortNameCbx, value); }
        }

        UCNLDrivers.BaudRate zmaBaudRate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), UIUtils.TryGetCbxItem(zmaPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(zmaPortBaudrateCbx, value.ToString()); }
        }


        bool isUseOutputPort
        {
            get { return isUseOutputPortChb.Checked; }
            set { isUseOutputPortChb.Checked = value; }
        }

        string outputPortName
        {
            get { return UIUtils.TryGetCbxItem(outputPortNameCbx); }
            set { UIUtils.TrySetCbxItem(outputPortNameCbx, value); }
        }

        UCNLDrivers.BaudRate outputPortBaudrate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), UIUtils.TryGetCbxItem(outputPortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(outputPortBaudrateCbx, value.ToString()); }
        }

        ZAddress outputPortResponderAddress
        {
            get { return (ZAddress)Enum.Parse(typeof(ZAddress), UIUtils.TryGetCbxItem(outputPortResponderAddressCbx)); }
            set { UIUtils.TrySetCbxItem(outputPortResponderAddressCbx, value.ToString()); }
        }

        bool isOutputPortSaveSeparately
        {
            get { return isOutputPortSaveSeparatelyChb.Checked; }
            set { isOutputPortSaveSeparatelyChb.Checked = value; }
        }



        bool isUseAUX1
        {
            get { return isUseAUX1Chb.Checked; }
            set { isUseAUX1Chb.Checked = value; }
        }

        string aux1PortName
        {
            get { return UIUtils.TryGetCbxItem(aux1PortNameCbx); }
            set { UIUtils.TrySetCbxItem(aux1PortNameCbx, value); }
        }

        UCNLDrivers.BaudRate aux1PortBaudRate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), UIUtils.TryGetCbxItem(aux1PortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(aux1PortBaudrateCbx, value.ToString()); }
        }



        bool isUseAUX2
        {
            get { return isUseAUX2Chb.Checked; }
            set { isUseAUX2Chb.Checked = value; }
        }

        string aux2PortName
        {
            get { return UIUtils.TryGetCbxItem(aux2PortNameCbx); }
            set { UIUtils.TrySetCbxItem(aux2PortNameCbx, value); }
        }

        UCNLDrivers.BaudRate aux2PortBaudRate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), UIUtils.TryGetCbxItem(aux2PortBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(aux2PortBaudrateCbx, value.ToString()); }
        }


        bool isUseCalBuoy
        {
            get { return isUseCalBouyChb.Checked; }
            set { isUseCalBouyChb.Checked = value; }
        }

        string calBuoyPortName
        {
            get { return UIUtils.TryGetCbxItem(calBuoyPortNameCbx); }
            set { UIUtils.TrySetCbxItem(calBuoyPortNameCbx, value); }
        }

        UCNLDrivers.BaudRate calBuoyPortBaudRate
        {
            get { return (UCNLDrivers.BaudRate)Enum.Parse(typeof(UCNLDrivers.BaudRate), UIUtils.TryGetCbxItem(calBuoyBaudrateCbx)); }
            set { UIUtils.TrySetCbxItem(calBuoyBaudrateCbx, value.ToString()); }
        }

        ZAddress calBuoyResponderAddress
        {
            get { return (ZAddress)Enum.Parse(typeof(ZAddress), UIUtils.TryGetCbxItem(calBuoyResponderAddressCbx)); }
            set { UIUtils.TrySetCbxItem(calBuoyResponderAddressCbx, value.ToString()); }
        }

        int calPointsNumber
        {
            get { return Convert.ToInt32(UIUtils.TryGetCbxItem(calPointsNumCbx)); }
            set { UIUtils.TrySetCbxItem(calPointsNumCbx, value.ToString()); }
        }

        #endregion

        #region COMMON Tab

        int usedRespondersCount
        {
            get { return usedRespondersChl.CheckedItems.Count; }
        }

        List<ZAddress> usedResponderAddresses
        {
            get
            {
                List<ZAddress> result = new List<ZAddress>();
                foreach (var item in usedRespondersChl.CheckedItems)
                    result.Add((ZAddress)Enum.Parse(typeof(ZAddress), item.ToString()));

                return result;
            }
            set
            {
                for (int i = 0; i < usedRespondersChl.Items.Count; i++)
                {
                    ZAddress addr = (ZAddress)Enum.Parse(typeof(ZAddress), usedRespondersChl.Items[i].ToString());
                    usedRespondersChl.SetItemChecked(i, value.Contains(addr));
                }
            }
        }

        int dataObsoleteThreshold
        {
            get { return Convert.ToInt32(dataObsoleteThresholdEdit.Value); }
            set { UIUtils.TrySetNEditValue(dataObsoleteThresholdEdit, value); }
        }

        int maxDistance
        {
            get { return Convert.ToInt32(maxDistanceEdit.Value); }
            set { UIUtils.TrySetNEditValue(maxDistanceEdit, value); }
        }

        double salinity
        {
            get { return Convert.ToDouble(salinityEdit.Value); }
            set { UIUtils.TrySetNEditValue(salinityEdit, value); }
        }


        bool isAutocalculateSoundSpeed
        {
            get { return isAutocalculateSoundSpeedChb.Checked; }
            set { isAutocalculateSoundSpeedChb.Checked = value; }
        }

        double soundSpeed
        {
            get { return Convert.ToDouble(soundSpeedEdit.Value); }
            set { UIUtils.TrySetNEditValue(soundSpeedEdit, value); }
        }       

        bool isRoughDepth
        {
            get { return isRoughDepthChb.Checked; }
            set { isRoughDepthChb.Checked = value; }
        }

        bool isHeadingFixed
        {
            get { return isHeadingFixedChb.Checked; }
            set { isHeadingFixedChb.Checked = value; }
        }

        bool isSaveAUXToLog
        {
            get { return isSaveAUXToLogChb.Checked; }
            set { isSaveAUXToLogChb.Checked = value; }
        }

        #endregion

        #region MISC. Tab

        double dY
        {
            get { return Convert.ToDouble(dYEdit.Value); }
            set { UIUtils.TrySetNEditValue(dYEdit, value); }
        }

        double dX
        {
            get { return Convert.ToDouble(dXEdit.Value); }
            set { UIUtils.TrySetNEditValue(dXEdit, value); }
        }

        double delta
        {
            get { return Convert.ToDouble(deltaEdit.Value); }
            set { UIUtils.TrySetNEditValue(deltaEdit, value); }
        }

        bool isUseVTGAsHeadingSource
        {
            get { return isUseVTGAsHeadingSourceChb.Checked; }
            set { isUseVTGAsHeadingSourceChb.Checked = value; }
        }

        #endregion

        #endregion

        #region Constructor

        public SettingsEditor()
        {
            InitializeComponent();

            var portNames = SerialPort.GetPortNames();

            if (portNames.Length > 0)
            {

                zmaPortNameCbx.Items.AddRange(portNames);
                aux1PortNameCbx.Items.AddRange(portNames);
                aux2PortNameCbx.Items.AddRange(portNames);
                outputPortNameCbx.Items.AddRange(portNames);
                calBuoyPortNameCbx.Items.AddRange(portNames);

                zmaPortNameCbx.SelectedIndex = 0;
                aux1PortNameCbx.SelectedIndex = 0;
                aux2PortNameCbx.SelectedIndex = 0;
                outputPortNameCbx.SelectedIndex = 0;
                calBuoyPortNameCbx.SelectedIndex = 0;

                var baudRates = Enum.GetNames(typeof(UCNLDrivers.BaudRate));
                zmaPortBaudrateCbx.Items.AddRange(baudRates);
                aux1PortBaudrateCbx.Items.AddRange(baudRates);
                aux2PortBaudrateCbx.Items.AddRange(baudRates);
                outputPortBaudrateCbx.Items.AddRange(baudRates);
                calBuoyBaudrateCbx.Items.AddRange(baudRates);

                zmaBaudRate = UCNLDrivers.BaudRate.baudRate9600;
                aux1PortBaudRate = UCNLDrivers.BaudRate.baudRate9600;
                aux2PortBaudRate = UCNLDrivers.BaudRate.baudRate9600;
                outputPortBaudrate = UCNLDrivers.BaudRate.baudRate9600;
                calBuoyPortBaudRate = UCNLDrivers.BaudRate.baudRate9600;

                var zaddressesList = new List<string>(Enum.GetNames(typeof(ZAddress)));
                zaddressesList.RemoveAt(zaddressesList.Count - 1);
                var zaddresses = zaddressesList.ToArray();

                outputPortResponderAddressCbx.Items.AddRange(zaddresses);
                calBuoyResponderAddressCbx.Items.AddRange(zaddresses);
                usedRespondersChl.Items.AddRange(zaddresses);

                outputPortResponderAddress = ZAddress.Responder_1;
                calBuoyResponderAddress = ZAddress.Responder_1;
            }

            isUseAUX1 = false;
            isUseAUX2 = false;
            isUseOutputPort = false;
            isAutocalculateSoundSpeed = true;

            CheckSettingsValidity();
        }

        #endregion

        #region Methods

        private void CheckSettingsValidity()
        {
            bool result = false;

            result = (!string.IsNullOrEmpty(zmaPortName)) &&
                     (!isUseOutputPort || !string.IsNullOrEmpty(outputPortName)) &&
                     (!isUseAUX1 || !string.IsNullOrEmpty(aux1PortName)) &&
                     (!isUseAUX2 || !string.IsNullOrEmpty(aux2PortName)) &&
                     (!isUseCalBuoy || !string.IsNullOrEmpty(calBuoyPortName)) &&
                     (usedRespondersCount > 0) &&
                     (!isUseOutputPort || !isUseCalBuoy || (calBuoyResponderAddress != outputPortResponderAddress));
                     
            if (result)
            {
                List<string> ports = new List<string>();
                ports.Add(zmaPortName);

                if (isUseOutputPort)
                {
                    if (ports.Contains(outputPortName))
                        result = false;
                    else
                        ports.Add(outputPortName);
                }

                if (result)
                {
                    if (isUseAUX1)
                    {
                        if (ports.Contains(aux1PortName))
                            result = false;
                        else
                            ports.Add(aux1PortName);
                    }

                    if (result)
                    {
                        if (isUseAUX2)
                        {
                            if (ports.Contains(aux2PortName))
                                result = false;
                            else
                                ports.Add(aux2PortName);
                        }

                        if (result)
                        {
                            if (isUseCalBuoy)
                            {
                                if (ports.Contains(calBuoyPortName))
                                    result = false;
                                else
                                    ports.Add(calBuoyPortName);
                            }
                        }
                    }
                }
            }

            okBtn.Enabled = result;
        }

        private void CheckAUXSettings()
        {
            isSaveAUXToLogChb.Enabled = isUseAUX1 || isUseAUX2;
            if (!isSaveAUXToLogChb.Enabled)
                isSaveAUXToLog = false;

            isUseCalBouyChb.Enabled = isUseAUX1 || isUseAUX2;
            if (!isUseCalBouyChb.Enabled)
                isUseCalBuoy = false;
        }

        #endregion

        #region Handlers

        private void zmaPortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        private void isUseOutputPortChb_CheckedChanged(object sender, EventArgs e)
        {
            outputPortGroup.Enabled = isUseOutputPort;
            CheckSettingsValidity();
        }

        private void outputPortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        private void isUseAUX1Chb_CheckedChanged(object sender, EventArgs e)
        {
            aux1PortGoup.Enabled = isUseAUX1;
            CheckAUXSettings();
            CheckSettingsValidity();
        }

        private void aux1PortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        private void isUseAUX2Chb_CheckedChanged(object sender, EventArgs e)
        {
            aux2PortGoup.Enabled = isUseAUX2;
            CheckAUXSettings();
            CheckSettingsValidity();
        }

        private void aux2PortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        private void isAutocalculateSoundSpeedChb_CheckedChanged(object sender, EventArgs e)
        {
            soundSpeedGroup.Enabled = !isAutocalculateSoundSpeed;
        }

        private void salinityLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SalinityDialog sDialog = new SalinityDialog())
            {
                sDialog.Title = string.Format("{0} - {1}", this.Text, LocStringManager.Salinity_str);

                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    salinity = sDialog.Salinity;
                }
            }
        }

        private void soundSpeedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SoundSpeedDialog sDialog = new SoundSpeedDialog())
            {
                sDialog.Title = string.Format("{0} - {1}", this.Text, LocStringManager.SoundSpeed_str);
                sDialog.Salinity = salinity;

                if (salinity > 0)
                    sDialog.Preset = SoundSpeedDialog.presets.seaWater;

                if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    soundSpeed = sDialog.SpeedOfSound;
                }
            }
        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < usedRespondersChl.Items.Count; i++)
                usedRespondersChl.SetItemChecked(i, true);
        }

        private void deselectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < usedRespondersChl.Items.Count; i++)
                usedRespondersChl.SetItemChecked(i, false);
        }

        private void setDefaultsBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LocStringManager.ResetToDefaultSettingsPrompt_str, //"Reset to default settings?", 
                LocStringManager.Question_str, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Value = new SettingsContainer();
            }
        }

        private void usedRespondersChl_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var chb = (CheckedListBox)sender;
            chb.ItemCheck -= usedRespondersChl_ItemCheck;
            chb.SetItemCheckState(e.Index, e.NewValue);
            chb.ItemCheck += usedRespondersChl_ItemCheck;

            CheckSettingsValidity();
        }

        private void isUseCalBouyChb_CheckedChanged(object sender, EventArgs e)
        {
            calBuoyGroup.Enabled = isUseCalBuoy;
            CheckSettingsValidity();
        }

        private void calBuoyPortNameCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        private void calBuoyResponderAddressCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckSettingsValidity();
        }

        #endregion                
    }
}
