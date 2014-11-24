using System;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl.Login
{
    public partial class FormRecoverPassword : FormMiscBase
    {
        private ILogin _login = null;

        public FormRecoverPassword()
        {
            InitializeComponent();
        }

        public FormRecoverPassword(ILogin login)
        {
            InitializeComponent();
            this._login = login;
        }

        private void btnSendByEmail_Click(object sender, EventArgs e)
        {
            if (this._login == null)
                return;

            Result r = this.RecoverPassword();
            if (r.OK)
            {
                base.ShowMessage(LoginStringManager.FormRecoverPassword_Success);
            }
            else
            {
                base.ShowErrorMessage(LoginStringManager.FormRecoverPassword_Failed);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_EditValueChanged(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        private void UpdateUI()
        {
            string userName = this.txtUserName.Text.Trim();
            if (userName.Length > 0)
            {
                this.btnSendByEmail.Enabled = true;
            }
            else
            {
                this.btnSendByEmail.Enabled = false;
            }
        }

        private Result RecoverPassword()
        {
            this.Cursor = Cursors.WaitCursor;
            Result result = this._login.RecoverPassword(this.txtUserName.Text.Trim());
            this.Cursor = Cursors.Default;

            return result;
        }
    }
}