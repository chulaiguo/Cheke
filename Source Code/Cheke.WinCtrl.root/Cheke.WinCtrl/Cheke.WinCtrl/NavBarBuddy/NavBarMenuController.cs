using DevExpress.XtraBars;
using DevExpress.XtraNavBar;

namespace Cheke.WinCtrl.NavBarBuddy
{
    public class NavBarMenuController
    {
        private NavBarControl _navBar = null;
        private string _userId = string.Empty;

        public NavBarMenuController(string userId, NavBarControl navBar)
        {
            this._userId = userId;
            this._navBar = navBar;
        }

        public void AppendStyleMenu(PopupMenu menu)
        {
            NavBarStyleMenu styleMenu = new NavBarStyleMenu(this._userId, this._navBar);
            styleMenu.AppendStyleMenu(menu);
        }

        public void RestoreStyle()
        {
            NavBarStyleMenu styleMenu = new NavBarStyleMenu(this._userId, this._navBar);
            styleMenu.RestoreStyle();
        }

        public void SaveStyle()
        {
            NavBarStyleMenu styleMenu = new NavBarStyleMenu(this._userId, this._navBar);
            styleMenu.SaveStyle();
        }
    }
}