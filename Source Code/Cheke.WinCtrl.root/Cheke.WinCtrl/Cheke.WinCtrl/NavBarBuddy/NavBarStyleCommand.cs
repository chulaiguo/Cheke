using Cheke.WinCtrl.Storage;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;

namespace Cheke.WinCtrl.NavBarBuddy
{
    internal static class NavBarStyleCommand
    {
        internal static BaseViewInfoRegistrator _DefaultViewStyle = new StandardSkinNavigationPaneViewInfoRegistrator("Caramel");

        internal static void ResetStyle(string userId, NavBarControl navBar)
        {
            navBar.View = _DefaultViewStyle;
            SaveStyle(userId, navBar);
        }

        internal static void SaveStyle(string userId, NavBarControl navBar)
        {
            using (StyleStorage storage = new StyleStorage(GetFileName(userId)))
            {
                storage.Save(navBar.View.ViewName);
                storage.Dispose();
            }
        }

        internal static void Restore(string userId, NavBarControl navBar)
        {
            using (StyleStorage storage = new StyleStorage(GetFileName(userId)))
            {
                object viewName = storage.Read();
                if (viewName != null)
                {
                    navBar.View = GetViewStyle(viewName.ToString(), navBar);
                    navBar.ResetStyles();
                } 
            }
        }

        internal static string GetFileName(string userId)
        {
            return string.Format("{0}.NavBarStyle.style", userId);
        }

        private static BaseViewInfoRegistrator GetViewStyle(string viewName, NavBarControl navBar)
        {
            foreach (BaseViewInfoRegistrator item in navBar.AvailableNavBarViews)
            {
               if(item.ViewName == viewName)
                   return item;
            }

            return _DefaultViewStyle;
        }
    }
}