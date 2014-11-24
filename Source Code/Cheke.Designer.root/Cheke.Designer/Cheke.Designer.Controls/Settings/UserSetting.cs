namespace Cheke.Designer.Controls.Settings
{
    public class UserSetting
    {
        private static readonly IsolatedUserSetting _Storage = new IsolatedUserSetting("UserSetting.dat", false);
        private static UserSetting _Setting = null;

        private bool _useDefaultPrinter = false;
        private bool _rememberChoosedPrinter = true;
        private string _printerName = string.Empty;

        private UserSetting()
        {
        }

        public bool UseDefaultPrinter
        {
            get { return _useDefaultPrinter; }
            set { _useDefaultPrinter = value; }
        }

        public bool RememberChoosedPrinter
        {
            get { return _rememberChoosedPrinter; }
            set { _rememberChoosedPrinter = value; }
        }

        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        public void Save()
        {
            UserSetting._Storage.SaveSetting(this);
        }

        public static UserSetting LoadSetting()
        {
            if (UserSetting._Setting == null)
            {
                UserSetting._Setting = new UserSetting();
                UserSetting._Storage.LoadSetting(UserSetting._Setting);
            }

            return UserSetting._Setting;
        }
    }
}