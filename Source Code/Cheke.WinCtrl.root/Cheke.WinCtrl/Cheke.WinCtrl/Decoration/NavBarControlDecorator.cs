using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.NavBarBuddy;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;

namespace Cheke.WinCtrl.Decoration
{
    public class NavBarControlDecorator : DecoratorBase
    {
        protected NavBarControl _navBar = null;
        protected string _userId = string.Empty;
        protected NavBarMenuController _menuController = null;

        public NavBarControlDecorator(string userId, NavBarControl navBar)
        {
            this._userId = userId;
            this._navBar = navBar;

            this._menuController = new NavBarMenuController(this._userId, this._navBar);
        }

        public override void Initialize()
        {
        }

        public void AppendStyleMenu(PopupMenu menu)
        {
            this._menuController.AppendStyleMenu(menu);
        }

        public void RestoreViewStyle()
        {
            this._menuController.RestoreStyle();
        }

        public void SaveStyle()
        {
            this._menuController.SaveStyle();
        }


        public NavBarGroup GetNavBarGroup(string groupName)
        {
            foreach (NavBarGroup item in this._navBar.Groups)
            {
                if (item.Name == groupName)
                {
                    return item;
                }
            }

            return null;
        }

        public NavBarItem GetNavBarItem(string itemName)
        {
            foreach (NavBarGroup item in this._navBar.Groups)
            {
                foreach (NavBarItemLink link in item.ItemLinks)
                {
                    if (link.Item.Name == itemName)
                        return link.Item;
                }
            }

            return null;
        }

        public bool IsItemExist(NavBarGroup barGroup, NavBarItemLink item)
        {
            foreach (NavBarItemLink link in barGroup.ItemLinks)
            {
                if (link.Item.Name == item.Item.Name)
                    return true;
            }

            return false;
        }

        public bool IsGroupExist(NavBarGroup barGroup)
        {
            foreach (NavBarGroup item in this._navBar.Groups)
            {
                if (item.Name == barGroup.Name)
                    return true;
            }

            return false;
        }



        public NavBarGroup GetNavBarGroup(BusinessBase entity)
        {
            return this.GetNavBarGroup(entity.ToString());
        }

        public NavBarGroup AddNavBarGroup(BusinessBase entity, string caption)
        {
            NavBarGroup navBarGroup = this.GetNavBarGroup(entity);
            if (navBarGroup == null)
            {
                navBarGroup = this._navBar.Groups.Add();
                navBarGroup.Name = entity.ToString();
                navBarGroup.Tag = entity;
                navBarGroup.Caption = caption;
                navBarGroup.Hint = caption;
                navBarGroup.Expanded = true;
            }

            return navBarGroup;
        }

        public void RemoveNavBarGroup(NavBarGroup navBarGroup)
        {
            if (navBarGroup == null)
                return;

            navBarGroup.ItemLinks.Clear();
            this._navBar.Groups.Remove(navBarGroup);
            navBarGroup.Dispose();
        }

        public void SetNavBarGroupCaption(BusinessBase entity, string caption)
        {
            NavBarGroup navBarGroup = this.GetNavBarGroup(entity);
            if (navBarGroup != null)
            {
                navBarGroup.Tag = entity;
                navBarGroup.Caption = caption;
                navBarGroup.Hint = caption;
            }
        }

        public NavBarItem GetNavBarItem(BusinessBase entity)
        {
            return this.GetNavBarItem(entity.ToString());
        }

        public NavBarItem AddDefaultNavBarItem(NavBarGroup group, string caption)
        {
            if(group == null)
                return null;

            BusinessBase entity = group.Tag as BusinessBase;
            if(entity == null)
                return null;

            NavBarItem barItem = this._navBar.Items.Add();
            barItem.Name = string.Format("{0}_{1}", entity.ToString(), caption);
            barItem.Tag = entity;
            barItem.Caption = caption;
            barItem.Hint = caption;
            group.ItemLinks.Add(barItem);

            return barItem;
        }

        public NavBarItem AddNavBarItem(NavBarGroup group, BusinessBase entity, string caption)
        {
            NavBarItem barItem = this.GetNavBarItem(entity);
            if (barItem == null)
            {
                barItem = this._navBar.Items.Add();
                barItem.Name = entity.ToString();
                barItem.Tag = entity;
                barItem.Caption = caption;
                barItem.Hint = caption;
                group.ItemLinks.Add(barItem);
            }

            return barItem;
        }

        public void RemoveNavBarItem(NavBarGroup group, NavBarItem barItem)
        {
            if (group == null || barItem == null)
                return;

            group.ItemLinks.Remove(barItem);
            barItem.Dispose();
        }

        public void SetNavBarItemCaption(BusinessBase entity, string caption)
        {
            NavBarItem barItem = this.GetNavBarItem(entity);
            if (barItem != null)
            {
                barItem.Tag = entity;
                barItem.Caption = caption;
                barItem.Hint = caption;
            }
        }

        public void CloseItemForm(NavBarItem navBarItem)
        {
            Form child = FormMainBase.Instance.GetChildByField(navBarItem);
            if (child != null)
            {
                child.Close();
            }
        }

        public void CloseGroupForms(NavBarGroup navBarGroup)
        {
            List<FormWorkBase> list = FormMainBase.Instance.GetChildrenByField(navBarGroup);
            foreach (FormWorkBase child in list)
            {
                child.Close();
            }
        }
    }
}