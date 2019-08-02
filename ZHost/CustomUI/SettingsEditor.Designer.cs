namespace ZHost.CustomUI
{
    partial class SettingsEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditor));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.connectionTabPage = new System.Windows.Forms.TabPage();
            this.isUseOutputPortChb = new System.Windows.Forms.CheckBox();
            this.outputPortGroup = new System.Windows.Forms.GroupBox();
            this.isOutputPortSaveSeparatelyChb = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.outputPortResponderAddressCbx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.outputPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.outputPortNameCbx = new System.Windows.Forms.ComboBox();
            this.isUseAUX2Chb = new System.Windows.Forms.CheckBox();
            this.aux2PortGoup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.aux2PortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.aux2PortNameCbx = new System.Windows.Forms.ComboBox();
            this.isUseAUX1Chb = new System.Windows.Forms.CheckBox();
            this.aux1PortGoup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.aux1PortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.aux1PortNameCbx = new System.Windows.Forms.ComboBox();
            this.zmaPortGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zmaPortBaudrateCbx = new System.Windows.Forms.ComboBox();
            this.zmaPortNameCbx = new System.Windows.Forms.ComboBox();
            this.commonTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isRedPhoneModeChb = new System.Windows.Forms.CheckBox();
            this.isRoughDepthChb = new System.Windows.Forms.CheckBox();
            this.soundSpeedGroup = new System.Windows.Forms.GroupBox();
            this.soundSpeedLink = new System.Windows.Forms.LinkLabel();
            this.soundSpeedEdit = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isAutocalculateSoundSpeedChb = new System.Windows.Forms.CheckBox();
            this.salinityGroup = new System.Windows.Forms.GroupBox();
            this.salinityLink = new System.Windows.Forms.LinkLabel();
            this.salinityEdit = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.timingsGroup = new System.Windows.Forms.GroupBox();
            this.maxDistanceEdit = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.dataObsoleteThresholdEdit = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.usedRespondersGroup = new System.Windows.Forms.GroupBox();
            this.respondersToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectAllBtn = new System.Windows.Forms.ToolStripButton();
            this.deselectAllBtn = new System.Windows.Forms.ToolStripButton();
            this.usedRespondersChl = new System.Windows.Forms.CheckedListBox();
            this.miscTabPage = new System.Windows.Forms.TabPage();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.isUseVTGAsHeadingSourceChb = new System.Windows.Forms.CheckBox();
            this.deltaEdit = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.dXEdit = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.dYEdit = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.setDefaultsBtn = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.connectionTabPage.SuspendLayout();
            this.outputPortGroup.SuspendLayout();
            this.aux2PortGoup.SuspendLayout();
            this.aux1PortGoup.SuspendLayout();
            this.zmaPortGroup.SuspendLayout();
            this.commonTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.soundSpeedGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).BeginInit();
            this.salinityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).BeginInit();
            this.timingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataObsoleteThresholdEdit)).BeginInit();
            this.usedRespondersGroup.SuspendLayout();
            this.respondersToolStrip.SuspendLayout();
            this.miscTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dXEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            resources.ApplyResources(this.mainTabControl, "mainTabControl");
            this.mainTabControl.Controls.Add(this.connectionTabPage);
            this.mainTabControl.Controls.Add(this.commonTabPage);
            this.mainTabControl.Controls.Add(this.miscTabPage);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            // 
            // connectionTabPage
            // 
            resources.ApplyResources(this.connectionTabPage, "connectionTabPage");
            this.connectionTabPage.Controls.Add(this.isUseOutputPortChb);
            this.connectionTabPage.Controls.Add(this.outputPortGroup);
            this.connectionTabPage.Controls.Add(this.isUseAUX2Chb);
            this.connectionTabPage.Controls.Add(this.aux2PortGoup);
            this.connectionTabPage.Controls.Add(this.isUseAUX1Chb);
            this.connectionTabPage.Controls.Add(this.aux1PortGoup);
            this.connectionTabPage.Controls.Add(this.zmaPortGroup);
            this.connectionTabPage.Name = "connectionTabPage";
            this.connectionTabPage.UseVisualStyleBackColor = true;
            // 
            // isUseOutputPortChb
            // 
            resources.ApplyResources(this.isUseOutputPortChb, "isUseOutputPortChb");
            this.isUseOutputPortChb.Name = "isUseOutputPortChb";
            this.isUseOutputPortChb.UseVisualStyleBackColor = true;
            this.isUseOutputPortChb.CheckedChanged += new System.EventHandler(this.isUseOutputPortChb_CheckedChanged);
            // 
            // outputPortGroup
            // 
            resources.ApplyResources(this.outputPortGroup, "outputPortGroup");
            this.outputPortGroup.Controls.Add(this.isOutputPortSaveSeparatelyChb);
            this.outputPortGroup.Controls.Add(this.label9);
            this.outputPortGroup.Controls.Add(this.outputPortResponderAddressCbx);
            this.outputPortGroup.Controls.Add(this.label7);
            this.outputPortGroup.Controls.Add(this.label8);
            this.outputPortGroup.Controls.Add(this.outputPortBaudrateCbx);
            this.outputPortGroup.Controls.Add(this.outputPortNameCbx);
            this.outputPortGroup.Name = "outputPortGroup";
            this.outputPortGroup.TabStop = false;
            // 
            // isOutputPortSaveSeparatelyChb
            // 
            resources.ApplyResources(this.isOutputPortSaveSeparatelyChb, "isOutputPortSaveSeparatelyChb");
            this.isOutputPortSaveSeparatelyChb.Name = "isOutputPortSaveSeparatelyChb";
            this.isOutputPortSaveSeparatelyChb.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // outputPortResponderAddressCbx
            // 
            resources.ApplyResources(this.outputPortResponderAddressCbx, "outputPortResponderAddressCbx");
            this.outputPortResponderAddressCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputPortResponderAddressCbx.FormattingEnabled = true;
            this.outputPortResponderAddressCbx.Name = "outputPortResponderAddressCbx";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // outputPortBaudrateCbx
            // 
            resources.ApplyResources(this.outputPortBaudrateCbx, "outputPortBaudrateCbx");
            this.outputPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputPortBaudrateCbx.FormattingEnabled = true;
            this.outputPortBaudrateCbx.Name = "outputPortBaudrateCbx";
            // 
            // outputPortNameCbx
            // 
            resources.ApplyResources(this.outputPortNameCbx, "outputPortNameCbx");
            this.outputPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputPortNameCbx.FormattingEnabled = true;
            this.outputPortNameCbx.Name = "outputPortNameCbx";
            this.outputPortNameCbx.SelectedIndexChanged += new System.EventHandler(this.outputPortNameCbx_SelectedIndexChanged);
            // 
            // isUseAUX2Chb
            // 
            resources.ApplyResources(this.isUseAUX2Chb, "isUseAUX2Chb");
            this.isUseAUX2Chb.Name = "isUseAUX2Chb";
            this.isUseAUX2Chb.UseVisualStyleBackColor = true;
            this.isUseAUX2Chb.CheckedChanged += new System.EventHandler(this.isUseAUX2Chb_CheckedChanged);
            // 
            // aux2PortGoup
            // 
            resources.ApplyResources(this.aux2PortGoup, "aux2PortGoup");
            this.aux2PortGoup.Controls.Add(this.label5);
            this.aux2PortGoup.Controls.Add(this.label6);
            this.aux2PortGoup.Controls.Add(this.aux2PortBaudrateCbx);
            this.aux2PortGoup.Controls.Add(this.aux2PortNameCbx);
            this.aux2PortGoup.Name = "aux2PortGoup";
            this.aux2PortGoup.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // aux2PortBaudrateCbx
            // 
            resources.ApplyResources(this.aux2PortBaudrateCbx, "aux2PortBaudrateCbx");
            this.aux2PortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux2PortBaudrateCbx.FormattingEnabled = true;
            this.aux2PortBaudrateCbx.Name = "aux2PortBaudrateCbx";
            // 
            // aux2PortNameCbx
            // 
            resources.ApplyResources(this.aux2PortNameCbx, "aux2PortNameCbx");
            this.aux2PortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux2PortNameCbx.FormattingEnabled = true;
            this.aux2PortNameCbx.Name = "aux2PortNameCbx";
            this.aux2PortNameCbx.SelectedIndexChanged += new System.EventHandler(this.aux2PortNameCbx_SelectedIndexChanged);
            // 
            // isUseAUX1Chb
            // 
            resources.ApplyResources(this.isUseAUX1Chb, "isUseAUX1Chb");
            this.isUseAUX1Chb.Name = "isUseAUX1Chb";
            this.isUseAUX1Chb.UseVisualStyleBackColor = true;
            this.isUseAUX1Chb.CheckedChanged += new System.EventHandler(this.isUseAUX1Chb_CheckedChanged);
            // 
            // aux1PortGoup
            // 
            resources.ApplyResources(this.aux1PortGoup, "aux1PortGoup");
            this.aux1PortGoup.Controls.Add(this.label3);
            this.aux1PortGoup.Controls.Add(this.label4);
            this.aux1PortGoup.Controls.Add(this.aux1PortBaudrateCbx);
            this.aux1PortGoup.Controls.Add(this.aux1PortNameCbx);
            this.aux1PortGoup.Name = "aux1PortGoup";
            this.aux1PortGoup.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // aux1PortBaudrateCbx
            // 
            resources.ApplyResources(this.aux1PortBaudrateCbx, "aux1PortBaudrateCbx");
            this.aux1PortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux1PortBaudrateCbx.FormattingEnabled = true;
            this.aux1PortBaudrateCbx.Name = "aux1PortBaudrateCbx";
            // 
            // aux1PortNameCbx
            // 
            resources.ApplyResources(this.aux1PortNameCbx, "aux1PortNameCbx");
            this.aux1PortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aux1PortNameCbx.FormattingEnabled = true;
            this.aux1PortNameCbx.Name = "aux1PortNameCbx";
            this.aux1PortNameCbx.SelectedIndexChanged += new System.EventHandler(this.aux1PortNameCbx_SelectedIndexChanged);
            // 
            // zmaPortGroup
            // 
            resources.ApplyResources(this.zmaPortGroup, "zmaPortGroup");
            this.zmaPortGroup.Controls.Add(this.label2);
            this.zmaPortGroup.Controls.Add(this.label1);
            this.zmaPortGroup.Controls.Add(this.zmaPortBaudrateCbx);
            this.zmaPortGroup.Controls.Add(this.zmaPortNameCbx);
            this.zmaPortGroup.Name = "zmaPortGroup";
            this.zmaPortGroup.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // zmaPortBaudrateCbx
            // 
            resources.ApplyResources(this.zmaPortBaudrateCbx, "zmaPortBaudrateCbx");
            this.zmaPortBaudrateCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zmaPortBaudrateCbx.FormattingEnabled = true;
            this.zmaPortBaudrateCbx.Name = "zmaPortBaudrateCbx";
            // 
            // zmaPortNameCbx
            // 
            resources.ApplyResources(this.zmaPortNameCbx, "zmaPortNameCbx");
            this.zmaPortNameCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zmaPortNameCbx.FormattingEnabled = true;
            this.zmaPortNameCbx.Name = "zmaPortNameCbx";
            this.zmaPortNameCbx.SelectedIndexChanged += new System.EventHandler(this.zmaPortNameCbx_SelectedIndexChanged);
            // 
            // commonTabPage
            // 
            resources.ApplyResources(this.commonTabPage, "commonTabPage");
            this.commonTabPage.Controls.Add(this.groupBox2);
            this.commonTabPage.Controls.Add(this.soundSpeedGroup);
            this.commonTabPage.Controls.Add(this.isAutocalculateSoundSpeedChb);
            this.commonTabPage.Controls.Add(this.salinityGroup);
            this.commonTabPage.Controls.Add(this.timingsGroup);
            this.commonTabPage.Controls.Add(this.usedRespondersGroup);
            this.commonTabPage.Name = "commonTabPage";
            this.commonTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.isRedPhoneModeChb);
            this.groupBox2.Controls.Add(this.isRoughDepthChb);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // isRedPhoneModeChb
            // 
            resources.ApplyResources(this.isRedPhoneModeChb, "isRedPhoneModeChb");
            this.isRedPhoneModeChb.Name = "isRedPhoneModeChb";
            this.isRedPhoneModeChb.UseVisualStyleBackColor = true;
            // 
            // isRoughDepthChb
            // 
            resources.ApplyResources(this.isRoughDepthChb, "isRoughDepthChb");
            this.isRoughDepthChb.Name = "isRoughDepthChb";
            this.isRoughDepthChb.UseVisualStyleBackColor = true;
            // 
            // soundSpeedGroup
            // 
            resources.ApplyResources(this.soundSpeedGroup, "soundSpeedGroup");
            this.soundSpeedGroup.Controls.Add(this.soundSpeedLink);
            this.soundSpeedGroup.Controls.Add(this.soundSpeedEdit);
            this.soundSpeedGroup.Controls.Add(this.label13);
            this.soundSpeedGroup.Controls.Add(this.groupBox1);
            this.soundSpeedGroup.Name = "soundSpeedGroup";
            this.soundSpeedGroup.TabStop = false;
            // 
            // soundSpeedLink
            // 
            resources.ApplyResources(this.soundSpeedLink, "soundSpeedLink");
            this.soundSpeedLink.ActiveLinkColor = System.Drawing.Color.Black;
            this.soundSpeedLink.LinkColor = System.Drawing.Color.Black;
            this.soundSpeedLink.Name = "soundSpeedLink";
            this.soundSpeedLink.TabStop = true;
            this.soundSpeedLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.soundSpeedLink_LinkClicked);
            // 
            // soundSpeedEdit
            // 
            resources.ApplyResources(this.soundSpeedEdit, "soundSpeedEdit");
            this.soundSpeedEdit.DecimalPlaces = 1;
            this.soundSpeedEdit.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.soundSpeedEdit.Minimum = new decimal(new int[] {
            1300,
            0,
            0,
            0});
            this.soundSpeedEdit.Name = "soundSpeedEdit";
            this.soundSpeedEdit.Value = new decimal(new int[] {
            1450,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // isAutocalculateSoundSpeedChb
            // 
            resources.ApplyResources(this.isAutocalculateSoundSpeedChb, "isAutocalculateSoundSpeedChb");
            this.isAutocalculateSoundSpeedChb.Checked = true;
            this.isAutocalculateSoundSpeedChb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isAutocalculateSoundSpeedChb.Name = "isAutocalculateSoundSpeedChb";
            this.isAutocalculateSoundSpeedChb.UseVisualStyleBackColor = true;
            this.isAutocalculateSoundSpeedChb.CheckedChanged += new System.EventHandler(this.isAutocalculateSoundSpeedChb_CheckedChanged);
            // 
            // salinityGroup
            // 
            resources.ApplyResources(this.salinityGroup, "salinityGroup");
            this.salinityGroup.Controls.Add(this.salinityLink);
            this.salinityGroup.Controls.Add(this.salinityEdit);
            this.salinityGroup.Controls.Add(this.label12);
            this.salinityGroup.Name = "salinityGroup";
            this.salinityGroup.TabStop = false;
            // 
            // salinityLink
            // 
            resources.ApplyResources(this.salinityLink, "salinityLink");
            this.salinityLink.ActiveLinkColor = System.Drawing.Color.Black;
            this.salinityLink.LinkColor = System.Drawing.Color.Black;
            this.salinityLink.Name = "salinityLink";
            this.salinityLink.TabStop = true;
            this.salinityLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.salinityLink_LinkClicked);
            // 
            // salinityEdit
            // 
            resources.ApplyResources(this.salinityEdit, "salinityEdit");
            this.salinityEdit.DecimalPlaces = 1;
            this.salinityEdit.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.salinityEdit.Name = "salinityEdit";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // timingsGroup
            // 
            resources.ApplyResources(this.timingsGroup, "timingsGroup");
            this.timingsGroup.Controls.Add(this.maxDistanceEdit);
            this.timingsGroup.Controls.Add(this.label11);
            this.timingsGroup.Controls.Add(this.dataObsoleteThresholdEdit);
            this.timingsGroup.Controls.Add(this.label10);
            this.timingsGroup.Name = "timingsGroup";
            this.timingsGroup.TabStop = false;
            // 
            // maxDistanceEdit
            // 
            resources.ApplyResources(this.maxDistanceEdit, "maxDistanceEdit");
            this.maxDistanceEdit.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maxDistanceEdit.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.maxDistanceEdit.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.maxDistanceEdit.Name = "maxDistanceEdit";
            this.maxDistanceEdit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // dataObsoleteThresholdEdit
            // 
            resources.ApplyResources(this.dataObsoleteThresholdEdit, "dataObsoleteThresholdEdit");
            this.dataObsoleteThresholdEdit.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.dataObsoleteThresholdEdit.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.dataObsoleteThresholdEdit.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.dataObsoleteThresholdEdit.Name = "dataObsoleteThresholdEdit";
            this.dataObsoleteThresholdEdit.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // usedRespondersGroup
            // 
            resources.ApplyResources(this.usedRespondersGroup, "usedRespondersGroup");
            this.usedRespondersGroup.Controls.Add(this.respondersToolStrip);
            this.usedRespondersGroup.Controls.Add(this.usedRespondersChl);
            this.usedRespondersGroup.Name = "usedRespondersGroup";
            this.usedRespondersGroup.TabStop = false;
            // 
            // respondersToolStrip
            // 
            resources.ApplyResources(this.respondersToolStrip, "respondersToolStrip");
            this.respondersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllBtn,
            this.deselectAllBtn});
            this.respondersToolStrip.Name = "respondersToolStrip";
            // 
            // selectAllBtn
            // 
            resources.ApplyResources(this.selectAllBtn, "selectAllBtn");
            this.selectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // deselectAllBtn
            // 
            resources.ApplyResources(this.deselectAllBtn, "deselectAllBtn");
            this.deselectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deselectAllBtn.Name = "deselectAllBtn";
            this.deselectAllBtn.Click += new System.EventHandler(this.deselectAllBtn_Click);
            // 
            // usedRespondersChl
            // 
            resources.ApplyResources(this.usedRespondersChl, "usedRespondersChl");
            this.usedRespondersChl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usedRespondersChl.FormattingEnabled = true;
            this.usedRespondersChl.Name = "usedRespondersChl";
            this.usedRespondersChl.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.usedRespondersChl_ItemCheck);
            // 
            // miscTabPage
            // 
            resources.ApplyResources(this.miscTabPage, "miscTabPage");
            this.miscTabPage.Controls.Add(this.pbRight);
            this.miscTabPage.Controls.Add(this.pbLeft);
            this.miscTabPage.Controls.Add(this.isUseVTGAsHeadingSourceChb);
            this.miscTabPage.Controls.Add(this.deltaEdit);
            this.miscTabPage.Controls.Add(this.label16);
            this.miscTabPage.Controls.Add(this.dXEdit);
            this.miscTabPage.Controls.Add(this.label15);
            this.miscTabPage.Controls.Add(this.dYEdit);
            this.miscTabPage.Controls.Add(this.label14);
            this.miscTabPage.Name = "miscTabPage";
            this.miscTabPage.UseVisualStyleBackColor = true;
            // 
            // pbRight
            // 
            resources.ApplyResources(this.pbRight, "pbRight");
            this.pbRight.Name = "pbRight";
            this.pbRight.TabStop = false;
            // 
            // pbLeft
            // 
            resources.ApplyResources(this.pbLeft, "pbLeft");
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.TabStop = false;
            // 
            // isUseVTGAsHeadingSourceChb
            // 
            resources.ApplyResources(this.isUseVTGAsHeadingSourceChb, "isUseVTGAsHeadingSourceChb");
            this.isUseVTGAsHeadingSourceChb.Name = "isUseVTGAsHeadingSourceChb";
            this.isUseVTGAsHeadingSourceChb.UseVisualStyleBackColor = true;
            // 
            // deltaEdit
            // 
            resources.ApplyResources(this.deltaEdit, "deltaEdit");
            this.deltaEdit.DecimalPlaces = 1;
            this.deltaEdit.Maximum = new decimal(new int[] {
            3599,
            0,
            0,
            65536});
            this.deltaEdit.Name = "deltaEdit";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // dXEdit
            // 
            resources.ApplyResources(this.dXEdit, "dXEdit");
            this.dXEdit.DecimalPlaces = 3;
            this.dXEdit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.dXEdit.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.dXEdit.Name = "dXEdit";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // dYEdit
            // 
            resources.ApplyResources(this.dYEdit, "dYEdit");
            this.dYEdit.DecimalPlaces = 3;
            this.dYEdit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.dYEdit.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.dYEdit.Name = "dYEdit";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // setDefaultsBtn
            // 
            resources.ApplyResources(this.setDefaultsBtn, "setDefaultsBtn");
            this.setDefaultsBtn.Name = "setDefaultsBtn";
            this.setDefaultsBtn.UseVisualStyleBackColor = true;
            this.setDefaultsBtn.Click += new System.EventHandler(this.setDefaultsBtn_Click);
            // 
            // SettingsEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.setDefaultsBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.mainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsEditor";
            this.mainTabControl.ResumeLayout(false);
            this.connectionTabPage.ResumeLayout(false);
            this.connectionTabPage.PerformLayout();
            this.outputPortGroup.ResumeLayout(false);
            this.outputPortGroup.PerformLayout();
            this.aux2PortGoup.ResumeLayout(false);
            this.aux2PortGoup.PerformLayout();
            this.aux1PortGoup.ResumeLayout(false);
            this.aux1PortGoup.PerformLayout();
            this.zmaPortGroup.ResumeLayout(false);
            this.zmaPortGroup.PerformLayout();
            this.commonTabPage.ResumeLayout(false);
            this.commonTabPage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.soundSpeedGroup.ResumeLayout(false);
            this.soundSpeedGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundSpeedEdit)).EndInit();
            this.salinityGroup.ResumeLayout(false);
            this.salinityGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salinityEdit)).EndInit();
            this.timingsGroup.ResumeLayout(false);
            this.timingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDistanceEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataObsoleteThresholdEdit)).EndInit();
            this.usedRespondersGroup.ResumeLayout(false);
            this.usedRespondersGroup.PerformLayout();
            this.respondersToolStrip.ResumeLayout(false);
            this.respondersToolStrip.PerformLayout();
            this.miscTabPage.ResumeLayout(false);
            this.miscTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deltaEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dXEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dYEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage connectionTabPage;
        private System.Windows.Forms.TabPage commonTabPage;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TabPage miscTabPage;
        private System.Windows.Forms.CheckBox isUseOutputPortChb;
        private System.Windows.Forms.GroupBox outputPortGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox outputPortBaudrateCbx;
        private System.Windows.Forms.ComboBox outputPortNameCbx;
        private System.Windows.Forms.CheckBox isUseAUX2Chb;
        private System.Windows.Forms.GroupBox aux2PortGoup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox aux2PortBaudrateCbx;
        private System.Windows.Forms.ComboBox aux2PortNameCbx;
        private System.Windows.Forms.CheckBox isUseAUX1Chb;
        private System.Windows.Forms.GroupBox aux1PortGoup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox aux1PortBaudrateCbx;
        private System.Windows.Forms.ComboBox aux1PortNameCbx;
        private System.Windows.Forms.GroupBox zmaPortGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox zmaPortBaudrateCbx;
        private System.Windows.Forms.ComboBox zmaPortNameCbx;
        private System.Windows.Forms.CheckBox isOutputPortSaveSeparatelyChb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox outputPortResponderAddressCbx;
        private System.Windows.Forms.GroupBox usedRespondersGroup;
        private System.Windows.Forms.CheckedListBox usedRespondersChl;
        private System.Windows.Forms.GroupBox timingsGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox isRedPhoneModeChb;
        private System.Windows.Forms.CheckBox isRoughDepthChb;
        private System.Windows.Forms.GroupBox soundSpeedGroup;
        private System.Windows.Forms.NumericUpDown soundSpeedEdit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox isAutocalculateSoundSpeedChb;
        private System.Windows.Forms.GroupBox salinityGroup;
        private System.Windows.Forms.LinkLabel salinityLink;
        private System.Windows.Forms.NumericUpDown salinityEdit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown maxDistanceEdit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown dataObsoleteThresholdEdit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox isUseVTGAsHeadingSourceChb;
        private System.Windows.Forms.NumericUpDown deltaEdit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown dXEdit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown dYEdit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel soundSpeedLink;
        private System.Windows.Forms.ToolStrip respondersToolStrip;
        private System.Windows.Forms.ToolStripButton selectAllBtn;
        private System.Windows.Forms.ToolStripButton deselectAllBtn;
        private System.Windows.Forms.Button setDefaultsBtn;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.PictureBox pbRight;
    }
}