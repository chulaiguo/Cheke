using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cheke.WinCtrl.Login
{
    public partial class FormLogin : FormLoginBase
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public FormLogin(ILogin login)
            : base(login)
        {
            InitializeComponent();
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            if (this.Login.LoginImage == null)
            {
                this.Height -= this.pictureBox1.Height;
                this.pictureBox1.Visible = false;
            }
            else
            {
                this.pictureBox1.Image = this.Login.LoginImage;
            }
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void cboEdUserName_EditValueChanged(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = this.cboUserName.Text.Trim();
            string password = this.txtPassword.Text;

            this.SignIn(userId, password);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelSignIn();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ShowRecoverPassword();
        }

        protected override void LoadLoginName()
        {
            List<string> list = base.LoadLoginHistory();
            this.cboUserName.Properties.Items.AddRange(list);
        }

        protected override void SaveLoginName()
        {
            if (!this.cboUserName.Properties.Items.Contains(this.cboUserName.Text))
            {
                this.cboUserName.Properties.Items.Add(this.cboUserName.Text);
            }

            List<string> list = new List<string>();
            for (int i = 0; i < this.cboUserName.Properties.Items.Count; i++)
            {
                list.Add(this.cboUserName.Properties.Items[i].ToString());
            }

            base.SaveLoginHistory(list);
        }

        #region Helper functions

        private void UpdateUI()
        {
            if (this.txtPassword.Text.Length > 0 && this.cboUserName.Text.Length > 0)
            {
                this.btnLogin.Enabled = true;
            }
            else
            {
                this.btnLogin.Enabled = false;
            }
        }

        #endregion
    }
}