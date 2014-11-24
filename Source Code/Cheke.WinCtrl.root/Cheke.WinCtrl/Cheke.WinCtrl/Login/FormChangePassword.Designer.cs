namespace Cheke.WinCtrl.Login
{
    partial class FormChangePassword
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
            this.txtOldPassword = new Cheke.WinCtrl.Common.TextEditEx();
            this.txtNewPassword = new Cheke.WinCtrl.Common.TextEditEx();
            this.txtConfirmNewPassword = new Cheke.WinCtrl.Common.TextEditEx();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(81, 20);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.ReadOnly = false;
            this.txtOldPassword.Size = new System.Drawing.Size(215, 20);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.Title = "Old Password";
            this.txtOldPassword.EditValueChanged += new System.EventHandler(this.txtOldPassword_EditValueChanged);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(76, 62);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.ReadOnly = false;
            this.txtNewPassword.Size = new System.Drawing.Size(220, 20);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.Title = "New Password";
            this.txtNewPassword.EditValueChanged += new System.EventHandler(this.txtNewPassword_EditValueChanged);
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(40, 105);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtConfirmNewPassword.Properties.PasswordChar = '*';
            this.txtConfirmNewPassword.ReadOnly = false;
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(256, 20);
            this.txtConfirmNewPassword.TabIndex = 2;
            this.txtConfirmNewPassword.Title = "Confim New Password";
            this.txtConfirmNewPassword.EditValueChanged += new System.EventHandler(this.txtConfirmNewPassword_EditValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(81, 156);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.txtNewPassword);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.txtOldPassword);
            this.pnlClient.Controls.Add(this.btnOK);
            this.pnlClient.Controls.Add(this.txtConfirmNewPassword);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(351, 201);
            this.pnlClient.TabIndex = 5;
            // 
            // FormChangePassword
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(351, 201);
            this.Controls.Add(this.pnlClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cheke.WinCtrl.Common.TextEditEx txtOldPassword;
        private Cheke.WinCtrl.Common.TextEditEx txtNewPassword;
        private Cheke.WinCtrl.Common.TextEditEx txtConfirmNewPassword;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl pnlClient;
    }
}
