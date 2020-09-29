namespace ZHost.CustomUI
{
    partial class InfoWindow
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
            this.okBtn = new System.Windows.Forms.Button();
            this.infoTxb = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Location = new System.Drawing.Point(236, 221);
            this.okBtn.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(99, 35);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // infoTxb
            // 
            this.infoTxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoTxb.Location = new System.Drawing.Point(12, 12);
            this.infoTxb.Name = "infoTxb";
            this.infoTxb.ReadOnly = true;
            this.infoTxb.Size = new System.Drawing.Size(323, 199);
            this.infoTxb.TabIndex = 11;
            this.infoTxb.Text = "";
            // 
            // InfoWindow
            // 
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 272);
            this.Controls.Add(this.infoTxb);
            this.Controls.Add(this.okBtn);            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoWindow";
            this.Text = "InfoWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.RichTextBox infoTxb;
    }
}