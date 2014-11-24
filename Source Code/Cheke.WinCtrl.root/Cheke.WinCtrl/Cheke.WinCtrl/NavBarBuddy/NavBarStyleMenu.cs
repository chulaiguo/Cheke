using Cheke.WinCtrl.StringManager;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;

namespace Cheke.WinCtrl.NavBarBuddy
{
    internal class NavBarStyleMenu
    {
        private NavBarControl _navBar = null;
        private string _userId = string.Empty;

        internal NavBarStyleMenu(string userId, NavBarControl navBar)
        {
            this._userId = userId;
            this._navBar = navBar;
        }

        internal void AppendStyleMenu(PopupMenu menu)
        {
            //Styles
            BarSubItem styleItems = new BarSubItem(menu.Manager, NavBarStringManager.ViewStyleMenu);
            menu.ItemLinks.Add(styleItems, menu.ItemLinks.Count > 0);
            foreach (BaseViewInfoRegistrator item in this._navBar.AvailableNavBarViews)
            {
                BarButtonItem barStyleItem = new BarButtonItem();
                barStyleItem.Caption = item.ToString();
                barStyleItem.Tag = item;
                barStyleItem.ItemClick += barStyleItem_ItemClick;

                menu.Manager.Items.Add(barStyleItem);
                styleItems.ItemLinks.Add(barStyleItem);
            }

            //Reset Style
            BarButtonItem barResetStyleItem = new BarButtonItem(menu.Manager, NavBarStringManager.ResetViewStyleMenu);
            barResetStyleItem.ItemClick += barResetStyleItem_ItemClick;
            menu.ItemLinks.Add(barResetStyleItem, true);
        }

        internal void RestoreStyle()
        {
            NavBarStyleCommand.Restore(this._userId, this._navBar);
        }

        internal void SaveStyle()
        {
            NavBarStyleCommand.SaveStyle(this._userId, this._navBar);
        }

        private void barResetStyleItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavBarStyleCommand.ResetStyle(this._userId, this._navBar);
        }

        private void barStyleItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this._navBar.View = e.Item.Tag as BaseViewInfoRegistrator;
            this._navBar.ResetStyles();
        }
    }
}