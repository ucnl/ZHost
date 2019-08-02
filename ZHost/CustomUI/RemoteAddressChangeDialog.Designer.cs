namespace ZHost.CustomUI
{
    partial class RemoteAddressChangeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteAddressChangeDialog));
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentTargetAddressCbx = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newTargetAddressCbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // currentTargetAddressCbx
            // 
            resources.ApplyResources(this.currentTargetAddressCbx, "currentTargetAddressCbx");
            this.currentTargetAddressCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currentTargetAddressCbx.FormattingEnabled = true;
            this.currentTargetAddressCbx.Name = "currentTargetAddressCbx";
            this.currentTargetAddressCbx.SelectedIndexChanged += new System.EventHandler(this.targetAddressCbx_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // newTargetAddressCbx
            // 
            resources.ApplyResources(this.newTargetAddressCbx, "newTargetAddressCbx");
            this.newTargetAddressCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.newTargetAddressCbx.FormattingEnabled = true;
            this.newTargetAddressCbx.Name = "newTargetAddressCbx";
            this.newTargetAddressCbx.SelectedIndexChanged += new System.EventHandler(this.targetAddressCbx_SelectedIndexChanged);
            // 
            // RemoteAddressChangeDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newTargetAddressCbx);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentTargetAddressCbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoteAddressChangeDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox currentTargetAddressCbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox newTargetAddressCbx;
    }
}