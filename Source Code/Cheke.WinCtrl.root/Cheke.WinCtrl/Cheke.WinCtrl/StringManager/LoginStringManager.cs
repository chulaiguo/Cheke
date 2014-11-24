using System.Reflection;
using Cheke.Translation;

namespace Cheke.WinCtrl.StringManager
{
    internal class LoginStringManager : StringManagerBase
    {
        private const string _FormLogin_InvalidUser = "The UserId/Password is not valid. Please try it again.";
        private const string _FormLogin_PasswordExpired = "Your password has been expired.  You must change the password.";
        private const string _FormLogin_PasswordWillBeExpired = "Your password will be expired in {0} days,would you like to change it?";

        private const string _FormRecoverPassword_Success = "Your password has been sent to you by email successfully.";
        private const string _FormRecoverPassword_Failed = "Sending password failed, please try it again later.";

        private const string _FormChangePassword_Success = "Your password has been changed successfully.";
        private const string _FormChangePassword_Failed = "Your confirmed password doesn't match the new password. Please re-enter the new password";

        public static string FormRecoverPassword_Success
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormRecoverPassword_Success); }
        }
        public static string FormRecoverPassword_Failed
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormRecoverPassword_Failed); }
        }

        public static string FormChangePassword_Success
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormChangePassword_Success); }
        }

        public static string FormChangePassword_Failed
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormChangePassword_Failed); }
        }

        public static string FormLogin_InvalidUser
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormLogin_InvalidUser); }
        }

        public static string FormLogin_PasswordExpired
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormLogin_PasswordExpired); }
        }

        public static string FormLogin_PasswordWillBeExpired
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FormLogin_PasswordWillBeExpired); }
        }

        public static void GetTranslateString()
        {
            GetTranslateString(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}