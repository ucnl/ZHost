namespace ZHost
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.connectionBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stationMenuBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.stationViewInfoBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.stationZeroDepthAdjustmentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.responderMenuBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.responderRemoteCommandSendBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.responderChangeAddressBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.responderZeroDepthAdjustBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.logMenuBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.logViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.logAnalyzeCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logAnalyzeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.logRestartCurrentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.logClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.trackMenuBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.trackSaveAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.trackClearBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.infoBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx = new System.Windows.Forms.ToolStrip();
            this.isAutoQueryBtn = new System.Windows.Forms.ToolStripButton();
            this.isAutoSnapshotBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.zmaStateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.hdgStateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.gnssStateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.outPortStateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.remoteActionLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ppiViewGroup = new System.Windows.Forms.GroupBox();
            this.ppiView = new ZHost.ppiView();
            this.ppiToolStrip = new System.Windows.Forms.ToolStrip();
            this.respondersGroup = new System.Windows.Forms.GroupBox();
            this.respondersTreeView = new System.Windows.Forms.TreeView();
            this.respondersToolStrip = new System.Windows.Forms.ToolStrip();
            this.respondersTreeExpandBtn = new System.Windows.Forms.ToolStripButton();
            this.mainToolStrip.SuspendLayout();
            this.toolStripEx.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.ppiViewGroup.SuspendLayout();
            this.respondersGroup.SuspendLayout();
            this.respondersToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            resources.ApplyResources(this.mainToolStrip, "mainToolStrip");
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionBtn,
            this.toolStripSeparator1,
            this.stationMenuBtn,
            this.responderMenuBtn,
            this.toolStripSeparator2,
            this.logMenuBtn,
            this.trackMenuBtn,
            this.toolStripSeparator3,
            this.settingsBtn,
            this.infoBtn});
            this.mainToolStrip.Name = "mainToolStrip";
            // 
            // connectionBtn
            // 
            resources.ApplyResources(this.connectionBtn, "connectionBtn");
            this.connectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectionBtn.Name = "connectionBtn";
            this.connectionBtn.Click += new System.EventHandler(this.connectionBtn_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // stationMenuBtn
            // 
            resources.ApplyResources(this.stationMenuBtn, "stationMenuBtn");
            this.stationMenuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stationMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stationViewInfoBtn,
            this.stationZeroDepthAdjustmentBtn});
            this.stationMenuBtn.Name = "stationMenuBtn";
            // 
            // stationViewInfoBtn
            // 
            resources.ApplyResources(this.stationViewInfoBtn, "stationViewInfoBtn");
            this.stationViewInfoBtn.Name = "stationViewInfoBtn";
            this.stationViewInfoBtn.Click += new System.EventHandler(this.stationViewInfoBtn_Click);
            // 
            // stationZeroDepthAdjustmentBtn
            // 
            resources.ApplyResources(this.stationZeroDepthAdjustmentBtn, "stationZeroDepthAdjustmentBtn");
            this.stationZeroDepthAdjustmentBtn.Name = "stationZeroDepthAdjustmentBtn";
            this.stationZeroDepthAdjustmentBtn.Click += new System.EventHandler(this.stationZeroDepthAdjustmentBtn_Click);
            // 
            // responderMenuBtn
            // 
            resources.ApplyResources(this.responderMenuBtn, "responderMenuBtn");
            this.responderMenuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.responderMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.responderRemoteCommandSendBtn,
            this.responderChangeAddressBtn,
            this.responderZeroDepthAdjustBtn});
            this.responderMenuBtn.Name = "responderMenuBtn";
            // 
            // responderRemoteCommandSendBtn
            // 
            resources.ApplyResources(this.responderRemoteCommandSendBtn, "responderRemoteCommandSendBtn");
            this.responderRemoteCommandSendBtn.Name = "responderRemoteCommandSendBtn";
            this.responderRemoteCommandSendBtn.Click += new System.EventHandler(this.responderRemoteCommandSendBtn_Click);
            // 
            // responderChangeAddressBtn
            // 
            resources.ApplyResources(this.responderChangeAddressBtn, "responderChangeAddressBtn");
            this.responderChangeAddressBtn.Name = "responderChangeAddressBtn";
            this.responderChangeAddressBtn.Click += new System.EventHandler(this.responderChangeAddressBtn_Click);
            // 
            // responderZeroDepthAdjustBtn
            // 
            resources.ApplyResources(this.responderZeroDepthAdjustBtn, "responderZeroDepthAdjustBtn");
            this.responderZeroDepthAdjustBtn.Name = "responderZeroDepthAdjustBtn";
            this.responderZeroDepthAdjustBtn.Click += new System.EventHandler(this.responderZeroDepthAdjustBtn_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // logMenuBtn
            // 
            resources.ApplyResources(this.logMenuBtn, "logMenuBtn");
            this.logMenuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewBtn,
            this.toolStripSeparator5,
            this.logAnalyzeCurrentBtn,
            this.logAnalyzeBtn,
            this.toolStripSeparator6,
            this.logRestartCurrentBtn,
            this.logClearBtn});
            this.logMenuBtn.Name = "logMenuBtn";
            // 
            // logViewBtn
            // 
            resources.ApplyResources(this.logViewBtn, "logViewBtn");
            this.logViewBtn.Name = "logViewBtn";
            this.logViewBtn.Click += new System.EventHandler(this.logViewBtn_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // logAnalyzeCurrentBtn
            // 
            resources.ApplyResources(this.logAnalyzeCurrentBtn, "logAnalyzeCurrentBtn");
            this.logAnalyzeCurrentBtn.Name = "logAnalyzeCurrentBtn";
            this.logAnalyzeCurrentBtn.Click += new System.EventHandler(this.logAnalyzeCurrentBtn_Click);
            // 
            // logAnalyzeBtn
            // 
            resources.ApplyResources(this.logAnalyzeBtn, "logAnalyzeBtn");
            this.logAnalyzeBtn.Name = "logAnalyzeBtn";
            this.logAnalyzeBtn.Click += new System.EventHandler(this.logAnalyzeBtn_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // logRestartCurrentBtn
            // 
            resources.ApplyResources(this.logRestartCurrentBtn, "logRestartCurrentBtn");
            this.logRestartCurrentBtn.Name = "logRestartCurrentBtn";
            this.logRestartCurrentBtn.Click += new System.EventHandler(this.logRestartCurrentBtn_Click);
            // 
            // logClearBtn
            // 
            resources.ApplyResources(this.logClearBtn, "logClearBtn");
            this.logClearBtn.Name = "logClearBtn";
            this.logClearBtn.Click += new System.EventHandler(this.logClearBtn_Click);
            // 
            // trackMenuBtn
            // 
            resources.ApplyResources(this.trackMenuBtn, "trackMenuBtn");
            this.trackMenuBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.trackMenuBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackSaveAsBtn,
            this.toolStripSeparator7,
            this.trackClearBtn});
            this.trackMenuBtn.Name = "trackMenuBtn";
            // 
            // trackSaveAsBtn
            // 
            resources.ApplyResources(this.trackSaveAsBtn, "trackSaveAsBtn");
            this.trackSaveAsBtn.Name = "trackSaveAsBtn";
            this.trackSaveAsBtn.Click += new System.EventHandler(this.trackSaveAsBtn_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // trackClearBtn
            // 
            resources.ApplyResources(this.trackClearBtn, "trackClearBtn");
            this.trackClearBtn.Name = "trackClearBtn";
            this.trackClearBtn.Click += new System.EventHandler(this.trackClearBtn_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // settingsBtn
            // 
            resources.ApplyResources(this.settingsBtn, "settingsBtn");
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // infoBtn
            // 
            resources.ApplyResources(this.infoBtn, "infoBtn");
            this.infoBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // toolStripEx
            // 
            resources.ApplyResources(this.toolStripEx, "toolStripEx");
            this.toolStripEx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isAutoQueryBtn,
            this.isAutoSnapshotBtn,
            this.toolStripSeparator4});
            this.toolStripEx.Name = "toolStripEx";
            // 
            // isAutoQueryBtn
            // 
            resources.ApplyResources(this.isAutoQueryBtn, "isAutoQueryBtn");
            this.isAutoQueryBtn.CheckOnClick = true;
            this.isAutoQueryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isAutoQueryBtn.Name = "isAutoQueryBtn";
            this.isAutoQueryBtn.Click += new System.EventHandler(this.isAutoQueryBtn_Click);
            // 
            // isAutoSnapshotBtn
            // 
            resources.ApplyResources(this.isAutoSnapshotBtn, "isAutoSnapshotBtn");
            this.isAutoSnapshotBtn.CheckOnClick = true;
            this.isAutoSnapshotBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isAutoSnapshotBtn.Name = "isAutoSnapshotBtn";
            this.isAutoSnapshotBtn.Click += new System.EventHandler(this.isAutoSnapshotBtn_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // mainStatusStrip
            // 
            resources.ApplyResources(this.mainStatusStrip, "mainStatusStrip");
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmaStateLbl,
            this.hdgStateLbl,
            this.gnssStateLbl,
            this.outPortStateLbl,
            this.remoteActionLbl});
            this.mainStatusStrip.Name = "mainStatusStrip";
            // 
            // zmaStateLbl
            // 
            resources.ApplyResources(this.zmaStateLbl, "zmaStateLbl");
            this.zmaStateLbl.Name = "zmaStateLbl";
            // 
            // hdgStateLbl
            // 
            resources.ApplyResources(this.hdgStateLbl, "hdgStateLbl");
            this.hdgStateLbl.Name = "hdgStateLbl";
            // 
            // gnssStateLbl
            // 
            resources.ApplyResources(this.gnssStateLbl, "gnssStateLbl");
            this.gnssStateLbl.Name = "gnssStateLbl";
            // 
            // outPortStateLbl
            // 
            resources.ApplyResources(this.outPortStateLbl, "outPortStateLbl");
            this.outPortStateLbl.Name = "outPortStateLbl";
            // 
            // remoteActionLbl
            // 
            resources.ApplyResources(this.remoteActionLbl, "remoteActionLbl");
            this.remoteActionLbl.Name = "remoteActionLbl";
            // 
            // ppiViewGroup
            // 
            resources.ApplyResources(this.ppiViewGroup, "ppiViewGroup");
            this.ppiViewGroup.Controls.Add(this.ppiView);
            this.ppiViewGroup.Controls.Add(this.ppiToolStrip);
            this.ppiViewGroup.Name = "ppiViewGroup";
            this.ppiViewGroup.TabStop = false;
            // 
            // ppiView
            // 
            resources.ApplyResources(this.ppiView, "ppiView");
            this.ppiView.BackColor = System.Drawing.Color.Black;
            this.ppiView.Heading = double.NaN;
            this.ppiView.LeftBottomLine = "";
            this.ppiView.LeftUpperCornerText = "";
            this.ppiView.Name = "ppiView";
            this.ppiView.OwnLat = double.NaN;
            this.ppiView.OwnLon = double.NaN;
            this.ppiView.RightTopLine = "";
            // 
            // ppiToolStrip
            // 
            resources.ApplyResources(this.ppiToolStrip, "ppiToolStrip");
            this.ppiToolStrip.Name = "ppiToolStrip";
            // 
            // respondersGroup
            // 
            resources.ApplyResources(this.respondersGroup, "respondersGroup");
            this.respondersGroup.Controls.Add(this.respondersTreeView);
            this.respondersGroup.Controls.Add(this.respondersToolStrip);
            this.respondersGroup.Name = "respondersGroup";
            this.respondersGroup.TabStop = false;
            // 
            // respondersTreeView
            // 
            resources.ApplyResources(this.respondersTreeView, "respondersTreeView");
            this.respondersTreeView.FullRowSelect = true;
            this.respondersTreeView.Name = "respondersTreeView";
            // 
            // respondersToolStrip
            // 
            resources.ApplyResources(this.respondersToolStrip, "respondersToolStrip");
            this.respondersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.respondersTreeExpandBtn});
            this.respondersToolStrip.Name = "respondersToolStrip";
            // 
            // respondersTreeExpandBtn
            // 
            resources.ApplyResources(this.respondersTreeExpandBtn, "respondersTreeExpandBtn");
            this.respondersTreeExpandBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.respondersTreeExpandBtn.Name = "respondersTreeExpandBtn";
            this.respondersTreeExpandBtn.Click += new System.EventHandler(this.respondersTreeExpandBtn_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.respondersGroup);
            this.Controls.Add(this.ppiViewGroup);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.toolStripEx);
            this.Controls.Add(this.mainToolStrip);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.toolStripEx.ResumeLayout(false);
            this.toolStripEx.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ppiViewGroup.ResumeLayout(false);
            this.ppiViewGroup.PerformLayout();
            this.respondersGroup.ResumeLayout(false);
            this.respondersGroup.PerformLayout();
            this.respondersToolStrip.ResumeLayout(false);
            this.respondersToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton connectionBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton stationMenuBtn;
        private System.Windows.Forms.ToolStripDropDownButton responderMenuBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton logMenuBtn;
        private System.Windows.Forms.ToolStripDropDownButton trackMenuBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripButton infoBtn;
        private System.Windows.Forms.ToolStrip toolStripEx;
        private System.Windows.Forms.ToolStripButton isAutoQueryBtn;
        private System.Windows.Forms.ToolStripButton isAutoSnapshotBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel zmaStateLbl;
        private System.Windows.Forms.ToolStripStatusLabel hdgStateLbl;
        private System.Windows.Forms.ToolStripStatusLabel gnssStateLbl;
        private System.Windows.Forms.GroupBox ppiViewGroup;
        private System.Windows.Forms.GroupBox respondersGroup;
        private System.Windows.Forms.ToolStrip respondersToolStrip;
        private System.Windows.Forms.ToolStripButton respondersTreeExpandBtn;
        private System.Windows.Forms.ToolStripMenuItem stationViewInfoBtn;
        private System.Windows.Forms.ToolStripMenuItem stationZeroDepthAdjustmentBtn;
        private System.Windows.Forms.ToolStripMenuItem responderRemoteCommandSendBtn;
        private System.Windows.Forms.ToolStripMenuItem responderChangeAddressBtn;
        private System.Windows.Forms.ToolStripMenuItem responderZeroDepthAdjustBtn;
        private System.Windows.Forms.ToolStripMenuItem logViewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem logAnalyzeCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logAnalyzeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem logRestartCurrentBtn;
        private System.Windows.Forms.ToolStripMenuItem logClearBtn;
        private System.Windows.Forms.ToolStripMenuItem trackSaveAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem trackClearBtn;
        private System.Windows.Forms.ToolStripStatusLabel outPortStateLbl;
        private System.Windows.Forms.TreeView respondersTreeView;
        private System.Windows.Forms.ToolStripStatusLabel remoteActionLbl;
        private System.Windows.Forms.ToolStrip ppiToolStrip;
        private ppiView ppiView;
    }
}

