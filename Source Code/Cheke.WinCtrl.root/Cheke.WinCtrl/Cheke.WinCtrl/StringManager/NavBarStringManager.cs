using System.Reflection;
using Cheke.Translation;

namespace Cheke.WinCtrl.StringManager
{
    internal class NavBarStringManager : StringManagerBase
    {
        private const string _ResetViewStyleMenu = "&Reset Style";
        private const string _ViewStyleMenu = "&Style";

        public static string ResetViewStyleMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ResetViewStyleMenu); }
        }

        public static string ViewStyleMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ViewStyleMenu); }
        }

        public static void GetTranslateString()
        {
            GetTranslateString(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}