using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl.Login
{
    public partial class FormLoginBase : FormMiscBase
    {
        private const string _FileName = "LoginUserList";
        private byte _totalTry = 0;

        private ILogin _login = null;
        private string _userId = string.Empty;
        private string _password = string.Empty;

        public FormLoginBase()
        {
            InitializeComponent();
        }

        public FormLoginBase(ILogin login)
        {
            InitializeComponent();
            this._login = login;
        }

        public string UserId
        {
            get { return _userId; }
        }

        public string Password
        {
            get { return _password; }
        }

        protected ILogin Login
        {
            get { return _login; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.Login.PrepareLogin();
            this.LoadLoginName();
        }

        protected void SignIn(string userId, string password)
        {
            if(this.Login == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            Result result = this.Login.Login(userId, password);
            this.Cursor = Cursors.Default;
            if (this.HasFatalError(result))
                return;

            if (!this.IsValidUser(result))
                return;

            this.SaveLoginName();
            if (!this.ChangeExpiredPassword(userId, password, result))
                return;

            this._userId = userId;
            this._password = password;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        protected void CancelSignIn()
        {
            this._userId = string.Empty;
            this._password = string.Empty;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected virtual void LoadLoginName()
        {
        }

        protected virtual void SaveLoginName()
        {
        }

        private bool ChangeExpiredPassword(string userId, string password, Result result)
        {
            if ((int)result.Tag > 14)
                return true;

            //Password Expired
            if ((int)result.Tag <= 0)
            {
                base.ShowWarningMessage(LoginStringManager.FormLogin_PasswordExpired);
                if (this.ShowChangePassword(userId, password) != DialogResult.OK)
                {
                    this.CancelSignIn();
                    return false;
                }

                return true;
            }

            //password will be expired
            if (base.ShowQuestion(string.Format(LoginStringManager.FormLogin_PasswordWillBeExpired, (int)result.Tag)) == DialogResult.Yes)
            {
                this.ShowChangePassword(userId, password);
            }

            return true;
        }

        protected virtual DialogResult ShowChangePassword(string userId, string password)
        {
            FormChangePassword dlg = new FormChangePassword(userId, password, this.Login);
            return dlg.ShowDialog();
        }

        protected virtual DialogResult ShowRecoverPassword()
        {
            FormRecoverPassword dlg = new FormRecoverPassword(this.Login);
            return dlg.ShowDialog();
        }

        #region Helper functions

        private bool HasFatalError(Result result)
        {
            if (!result.OK)
            {
                base.ShowErrorMessage(result.ToString());
                return true;
            }

            return false;
        }

        private bool IsValidUser(Result result)
        {
            if ((int) result.Tag == 1000)
            {
                this._totalTry++;
                if (this._totalTry > this.Login.MaxTryCount)
                {
                    this.CancelSignIn();
                }
                else
                {
                    base.ShowWarningMessage(LoginStringManager.FormLogin_InvalidUser);
                }

                return false;
            }

            return true;
        }

        protected List<string> LoadLoginHistory()
        {
            List<string> list = new List<string>();
            using (SerializableObjectStorage storage =
                    new SerializableObjectStorage(_FileName, IsolatedStorageFile.GetUserStoreForDomain()))
            {
                string[] nameList = storage.Read() as string[];
                if (nameList != null)
                {
                    list.AddRange(nameList);
                }
                storage.Dispose();
            }

            return list;
        }

        protected void SaveLoginHistory(List<string> list)
        {
            using (SerializableObjectStorage storage =
                    new SerializableObjectStorage(_FileName, IsolatedStorageFile.GetUserStoreForDomain()))
            {
                storage.Save(list.ToArray());
                storage.Dispose();
            }
        }

        #endregion
    }
}