namespace Cheke.WinCtrl.Login
{
    partial class FormLogin
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
            this.cboUserName = new Cheke.WinCtrl.Common.ComboBoxEditEx();
            this.txtPassword = new Cheke.WinCtrl.Common.TextEditEx();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUserName
            // 
            this.cboUserName.EditValue = null;
            this.cboUserName.Location = new System.Drawing.Point(84, 28);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.cboUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUserName.Properties.Sorted = true;
            this.cboUserName.ReadOnly = false;
            this.cboUserName.Size = new System.Drawing.Size(207, 20);
            this.cboUserName.TabIndex = 0;
            this.cboUserName.Title = "User Name";
            this.cboUserName.EditValueChanged += new System.EventHandler(this.cboEdUserName_EditValueChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.ReadOnly = false;
            this.txtPassword.Size = new System.Drawing.Size(201, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Title = "Password";
            this.txtPassword.EditValueChanged += new System.EventHandler(this.txtPassword_EditValueChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(136, 106);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(237, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Location = new System.Drawing.Point(37, 111);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(86, 13);
            this.lnkForgotPassword.TabIndex = 4;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot Password";
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lnkForgotPassword);
            this.pnlClient.Controls.Add(this.cboUserName);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.txtPassword);
            this.pnlClient.Controls.Add(this.btnLogin);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 60);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(380, 159);
            this.pnlClient.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 60);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 219);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.cboUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cheke.WinCtrl.Common.ComboBoxEditEx cboUserName;
        private Cheke.WinCtrl.Common.TextEditEx txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private DevExpress.XtraEditors.PanelControl pnlClient;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
