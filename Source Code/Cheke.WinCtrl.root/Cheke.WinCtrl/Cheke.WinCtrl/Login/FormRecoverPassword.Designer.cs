namespace Cheke.WinCtrl.Login
{
    partial class FormRecoverPassword
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
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new Cheke.WinCtrl.Common.TextEditEx();
            this.btnSendByEmail = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblRequestMail = new DevExpress.XtraEditors.LabelControl();
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(16, 42);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(288, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Your password will be sent to your e-mail address of record.";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(27, 86);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtUserName.ReadOnly = false;
            this.txtUserName.Size = new System.Drawing.Size(248, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Title = "User Name";
            this.txtUserName.EditValueChanged += new System.EventHandler(this.txtUserName_EditValueChanged);
            // 
            // btnSendByEmail
            // 
            this.btnSendByEmail.Enabled = false;
            this.btnSendByEmail.Location = new System.Drawing.Point(27, 141);
            this.btnSendByEmail.Name = "btnSendByEmail";
            this.btnSendByEmail.Size = new System.Drawing.Size(102, 23);
            this.btnSendByEmail.TabIndex = 2;
            this.btnSendByEmail.Text = "&Retrieve Password";
            this.btnSendByEmail.Click += new System.EventHandler(this.btnSendByEmail_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(173, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRequestMail
            // 
            this.lblRequestMail.Location = new System.Drawing.Point(16, 9);
            this.lblRequestMail.Name = "lblRequestMail";
            this.lblRequestMail.Size = new System.Drawing.Size(135, 13);
            this.lblRequestMail.TabIndex = 4;
            this.lblRequestMail.Text = "Request Password by E-mail";
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lblInfo);
            this.pnlClient.Controls.Add(this.lblRequestMail);
            this.pnlClient.Controls.Add(this.txtUserName);
            this.pnlClient.Controls.Add(this.btnClose);
            this.pnlClient.Controls.Add(this.btnSendByEmail);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(315, 199);
            this.pnlClient.TabIndex = 5;
            // 
            // FormRecoverPassword
            // 
            this.AcceptButton = this.btnSendByEmail;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(315, 199);
            this.Controls.Add(this.pnlClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRecoverPassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recover Password";
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInfo;
        private Cheke.WinCtrl.Common.TextEditEx txtUserName;
        private DevExpress.XtraEditors.SimpleButton btnSendByEmail;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRequestMail;
        private DevExpress.XtraEditors.PanelControl pnlClient;
    }
}
