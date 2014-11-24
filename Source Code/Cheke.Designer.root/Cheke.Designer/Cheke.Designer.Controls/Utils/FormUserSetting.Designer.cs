namespace Cheke.Designer.Controls.Utils
{
    partial class FormUserSetting
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUseDefaultPrinter = new System.Windows.Forms.CheckBox();
            this.chkRememberPrinter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(53, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkUseDefaultPrinter
            // 
            this.chkUseDefaultPrinter.AutoSize = true;
            this.chkUseDefaultPrinter.Location = new System.Drawing.Point(44, 23);
            this.chkUseDefaultPrinter.Name = "chkUseDefaultPrinter";
            this.chkUseDefaultPrinter.Size = new System.Drawing.Size(112, 17);
            this.chkUseDefaultPrinter.TabIndex = 3;
            this.chkUseDefaultPrinter.Text = "Use default printer";
            this.chkUseDefaultPrinter.UseVisualStyleBackColor = true;
            this.chkUseDefaultPrinter.CheckedChanged += new System.EventHandler(this.chkUseDefaultPrinter_CheckedChanged);
            // 
            // chkRememberPrinter
            // 
            this.chkRememberPrinter.AutoSize = true;
            this.chkRememberPrinter.Location = new System.Drawing.Point(44, 71);
            this.chkRememberPrinter.Name = "chkRememberPrinter";
            this.chkRememberPrinter.Size = new System.Drawing.Size(163, 17);
            this.chkRememberPrinter.TabIndex = 4;
            this.chkRememberPrinter.Text = "Remember my chosen printer";
            this.chkRememberPrinter.UseVisualStyleBackColor = true;
            // 
            // FormUserSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 168);
            this.Controls.Add(this.chkRememberPrinter);
            this.Controls.Add(this.chkUseDefaultPrinter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUserSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printer Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkUseDefaultPrinter;
        private System.Windows.Forms.CheckBox chkRememberPrinter;
    }
}