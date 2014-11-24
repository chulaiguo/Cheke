using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl.Login
{
    public partial class FormChangePassword : FormMiscBase
    {
        private ILogin _login = null;
        private string _userId = string.Empty;

        public FormChangePassword()
        {
            InitializeComponent();
        }

        public FormChangePassword(string userId, ILogin login) 
        {
            InitializeComponent();

            this._login = login;
            this._userId = userId;
        }

        public string UserId
        {
            get { return _userId; }
        }

        public FormChangePassword(string userId, string oldPassword, ILogin login)
        {
            InitializeComponent();

            this._userId = userId;
            this.txtOldPassword.Text = oldPassword;
            this._login = login;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (this._login == null)
                return;

            if (this.txtNewPassword.Text != this.txtConfirmNewPassword.Text)
            {
                base.ShowErrorMessage(LoginStringManager.FormChangePassword_Failed);
                this.txtNewPassword.Text = string.Empty;
                this.txtConfirmNewPassword.Text = string.Empty;
                this.txtNewPassword.Focus();
                return;
            }

            Result result = this.ChangePassword();
            if (!result.OK)
            {
                base.ShowErrorMessage(result.ToString());
            }
            else
            {
                base.ShowMessage(LoginStringManager.FormChangePassword_Success);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            } 
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private Result ChangePassword()
        {
            this.Cursor = Cursors.WaitCursor;
            Result result = this._login.ChangePassword(this.UserId, this.txtOldPassword.Text, this.txtNewPassword.Text);
            this.Cursor = Cursors.Default;

            return result;
        }

        private void txtOldPassword_EditValueChanged(object sender, System.EventArgs e)
        {
            this.btnOK.Enabled = this.UpdateUI();
        }

        private void txtNewPassword_EditValueChanged(object sender, System.EventArgs e)
        {
            this.btnOK.Enabled = this.UpdateUI();
        }

        private void txtConfirmNewPassword_EditValueChanged(object sender, System.EventArgs e)
        {
            this.btnOK.Enabled = this.UpdateUI();
        }

        private bool UpdateUI()
        {
            if (this.txtOldPassword.Text.Length == 0 || this.txtNewPassword.Text.Length == 0
                || this.txtConfirmNewPassword.Text.Length == 0)
            {
                return false;
            }

            if(this.txtNewPassword.Text != this.txtConfirmNewPassword.Text)
                return false;

            if (this.txtOldPassword.Text == this.txtNewPassword.Text)
                return false;

            return true;
        }
    }
}