using System;
using System.Collections.Generic;
using Cheke.WinCtrl.GridControlCommand;
using Cheke.WinCtrl.StringManager;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Menu;
using DevExpress.Utils.WXPaint;
using DevExpress.XtraGrid.Design;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlBuddy
{
    internal class GridViewBasicMenu : GridViewMenu
    {
        private readonly GridMenuFacade _menuFacade = null;
        private readonly  GridMenuOptions _menuOptions = null;

        public GridViewBasicMenu(GridMenuFacade facade, GridMenuOptions options, GridView view)
            : base(view)
        {
            this._menuFacade = facade;
            this._menuOptions = options;
        }

        protected override void CreateItems()
        {
            base.Items.Clear();

            this.CreateRecordCountMenus(base.Items);

            if (this._menuOptions.ShowPreviewMenu)
            {
                this.CreatePreviewMenus(base.Items);
            }

            if (this._menuOptions.ShowRefreshMenu)
            {
                this.CreateRefreshMenu(base.Items);
            }

            if (this._menuOptions.ShowSaveMenu)
            {
                this.CreateSaveMenu(base.Items);
            }

            if (this._menuOptions.ShowRecoverDeletedItemsMenu)
            {
                this.CreateRecoverDeletedItemsMenu(base.Items);
            }

            if (this._menuOptions.ShowApplicationMenu)
            {
                this.CreateApplicationMenus(base.Items);
            }

            if (this._menuOptions.ShowExportMenu)
            {
                this.CreateExportMenus(base.Items);
            }

            if (this._menuOptions.ShowHistoryMenu && FormMainBase.Instance.ShowHistory)
            {
                this.CreateHistoryMenus(base.Items);
            }

            if (this._menuOptions.ShowEditMenu)
            {
                this.CreateEditMenus(base.Items);
            }

            if (this._menuOptions.ShowLayoutMenu)
            {
                this.CreateLayoutMenus(base.Items);
            }

            if (this._menuOptions.ShowGridStyleMenu)
            {
                this.CreateLookAndFeelMenus(base.Items);
                this.CreateBackgroundMenus(base.Items);
                this.CreateStyleMenus(base.Items);
            }
        }

        #region RecordCount Menu

        private void CreateRecordCountMenus(DXMenuItemCollection menus)
        {
            DXMenuItem item = this.CreateMenu(GridStringManager.RecordCountMenu);
            item.Enabled = base.View.RowCount > 0;
            item.Click += RecordCountMenu_Click;
            menus.Add(item);
        }

        #endregion

        #region Preview Menus

        private void CreatePreviewMenus(DXMenuItemCollection menus)
        {
            if (!base.View.GridControl.IsPrintingAvailable)
                return;

            DXMenuItem item = this.CreateMenu(GridStringManager.PreviewMenu);
            item.Enabled = base.View.RowCount > 0;
            if (menus.Count > 0)
            {
                item.BeginGroup = true;
            }
            item.Click += PreviewMenu_Click;

            menus.Add(item);
        }

        #endregion

        #region Refresh & Save Menus

        private void CreateRefreshMenu(DXMenuItemCollection menus)
        {
            DXMenuItem item = this.CreateMenu(GridStringManager.RefreshMenu);
            item.Click += RefreshMenu_Click;
            if (menus.Count > 0)
            {
                item.BeginGroup = true;
            }
            menus.Add(item);
        }

        private void CreateSaveMenu(DXMenuItemCollection menus)
        {
            if (!base.View.Editable)
                return;

            DXMenuItem item = this.CreateMenu(GridStringManager.SaveMenu);
            item.Click += SaveMenu_Click;
            if (!this._menuOptions.ShowRefreshMenu)
            {
                item.BeginGroup = true;
            }
            menus.Add(item);
        }

        private void CreateRecoverDeletedItemsMenu(DXMenuItemCollection menus)
        {
            if (!base.View.Editable)
                return;

            DXMenuItem item = this.CreateMenu(GridStringManager.RecoverDeletedItemMenu);
            item.Click += RecoverDeletedItemMenu_Click;
            if (!this._menuOptions.ShowRefreshMenu)
            {
                item.BeginGroup = true;
            }
            menus.Add(item);
        }

        #endregion

        #region Export Menus

        private void CreateExportMenus(DXMenuItemCollection menus)
        {
            DXSubMenuItem menuParent = new DXSubMenuItem(GridStringManager.ExportMenu);
            menuParent.BeginGroup = true;
            menus.Add(menuParent);

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToCSV)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToCSVMenu);
                item.Click += ExportToCSVMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToXLS)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToXLSMenu);
                item.Click += ExportToXLSMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToXLSX)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToXLSXMenu);
                item.Click += ExportToXLSXMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToPDF)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToPDFMenu);
                item.Click += ExportToPDFMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToTXT)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToTXTMenu);
                item.Click += ExportToTXTMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToRTF)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToRTFMenu);
                item.Click += ExportToRTFMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToMHT)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToMHTMenu);
                item.Click += ExportToMHTMenu_Click;
                menuParent.Items.Add(item);
            }

            if (FormMainBase.Instance != null && FormMainBase.Instance.ExportToHTML)
            {
                DXMenuItem item = this.CreateMenu(GridStringManager.ExportToHTMLMenu);
                item.Click += ExportToHTMLMenu_Click;
                menuParent.Items.Add(item);
            }
        }

        #endregion

        #region History Menus

        private void CreateHistoryMenus(DXMenuItemCollection menus)
        {
            DXSubMenuItem menuParent = new DXSubMenuItem(GridStringManager.HistoryMenu);
            menus.Add(menuParent);

            DXMenuItem item = this.CreateMenu(GridStringManager.EditEventsMenu);
            item.Enabled = base.View.RowCount > 0;
            item.Click += EditEventsMenu_Click;
            menuParent.Items.Add(item);

            item = this.CreateMenu(GridStringManager.DeleteEventsMenu);
            item.Click += DeleteEventsMenu_Click;
            menuParent.Items.Add(item);
        }

        #endregion

        #region Edit Menus

        private void CreateEditMenus(DXMenuItemCollection menus)
        {
            if (!base.View.Editable)
                return;

            DXSubMenuItem menuParent = new DXSubMenuItem(GridStringManager.EditMenu);
            menuParent.BeginGroup = true;
            menus.Add(menuParent);

            List<DXMenuItem> list = this._menuFacade.CreateEditMenus(base.View);
            foreach (DXMenuItem item in list)
            {
                menuParent.Items.Add(item);
            }
        }

        #endregion

        #region Application Menus

        private void CreateApplicationMenus(DXMenuItemCollection menus)
        {
            this._menuFacade.CreateApplicationMenus(menus, base.View);
        }

        #endregion

        #region ViewLayout Menus

        private void CreateLayoutMenus(DXMenuItemCollection menus)
        {
            DXMenuItem item = this.CreateMenu(GridStringManager.SaveLayoutMenu);
            item.Click += SaveLayoutMenu_Click;
            if (Items.Count > 0)
            {
                item.BeginGroup = true;
            }
            menus.Add(item);

            item = this.CreateMenu(GridStringManager.RestoreLayoutMenu);
            item.Click += RestoreLayoutMenu_Click;
            menus.Add(item);

            item = this.CreateMenu(GridStringManager.DeleteLayoutMenu);
            item.Click += DeleteLayoutMenu_Click;
            menus.Add(item);

            if (FormMainBase.Instance != null && FormMainBase.Instance.CustomizeGridViewFullLayout)
            {
                item = this.CreateMenu(GridStringManager.ConfigureLayoutMenu);
                item.Click += ConfigureLayoutMenu_Click;
                menus.Add(item);
            }
        }

        #endregion

        #region Look & Feel Menu

        private void CreateLookAndFeelMenus(DXMenuItemCollection menus)
        {
            DXSubMenuItem menuParent = new DXSubMenuItem(GridStringManager.LookAndFeelMenu);
            menuParent.BeginGroup = true;
            menus.Add(menuParent);

            string[] styleNames = new string[]
                {
                    LookAndFeelStyle.Flat.ToString(),
                    LookAndFeelStyle.Office2003.ToString(),
                    LookAndFeelStyle.Style3D.ToString(),
                    LookAndFeelStyle.UltraFlat.ToString()
                };

            foreach (string item in styleNames)
            {
                DXMenuCheckItem childMenu = new DXMenuCheckItem(item);
                childMenu.Click += ViewLookAndFeelMenu_Click;
                if (this._menuFacade.PaintStyleName == item)
                {
                    childMenu.Checked = true;
                }
                menuParent.Items.Add(childMenu);
            }

            if (Painter.ThemesEnabled)
            {
                //WindowsXP
                DXMenuCheckItem childXPMenu = new DXMenuCheckItem("&XP");
                childXPMenu.Click += ViewLookAndFeelMenu_Click;
                if (this._menuFacade.PaintStyleName == "&XP")
                {
                    childXPMenu.Checked = true;
                }
                menuParent.Items.Add(childXPMenu);
            }

            //Skins
            if (base.View.GridControl.LookAndFeel.Style == LookAndFeelStyle.Skin
                && !base.View.GridControl.LookAndFeel.UseDefaultLookAndFeel
                && !base.View.GridControl.LookAndFeel.UseWindowsXPTheme)
            {
                DXSubMenuItem menuSkin = new DXSubMenuItem(GridStringManager.SkinMenu);
                menuParent.Items.Add(menuSkin);

                foreach (SkinContainer skin in SkinManager.Default.Skins)
                {
                    DXMenuCheckItem childMenu = new DXMenuCheckItem(skin.SkinName);
                    childMenu.Click += ViewSkinMenu_Click;
                    if (this._menuFacade.SkinName == skin.SkinName)
                    {
                        childMenu.Checked = true;
                    }
                    menuSkin.Items.Add(childMenu);
                }
            }

            if (Painter.ThemesEnabled)
            {
                //MixedXP
                DXMenuCheckItem childMixedXPMenu = new DXMenuCheckItem("MixedXP");
                childMixedXPMenu.BeginGroup = true;
                childMixedXPMenu.Click += ViewLookAndFeelMenu_Click;
                if (this._menuFacade.PaintStyleName == "MixedXP")
                {
                    childMixedXPMenu.Checked = true;
                }
                menuParent.Items.Add(childMixedXPMenu);
            }
        }

        #endregion

        #region Background Images Menu

        private void CreateBackgroundMenus(DXMenuItemCollection menus)
        {
            DXSubMenuItem menuParent = new DXSubMenuItem(GridStringManager.BackgroundImagesMenu);
            menus.Add(menuParent);

            //None
            DXMenuCheckItem childMenu = new DXMenuCheckItem(GridStringManager.NoneBackgroundMenu);
            childMenu.Tag = GridStyleCommand.NoBackgroundImage;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.NoBackgroundImage)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //Blue
            childMenu = new DXMenuCheckItem(GridStringManager.BlueBackgroundMenu);
            childMenu.Tag = GridStyleCommand.BlueBackground;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.BlueBackground)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //Green
            childMenu = new DXMenuCheckItem(GridStringManager.GreenBackgroundMenu);
            childMenu.Tag = GridStyleCommand.GreenBackground;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.GreenBackground)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //Pink
            childMenu = new DXMenuCheckItem(GridStringManager.PinkBackgroundMenu);
            childMenu.Tag = GridStyleCommand.PinkBackground;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.PinkBackground)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //Yellow
            childMenu = new DXMenuCheckItem(GridStringManager.YellowBackgroundMenu);
            childMenu.Tag = GridStyleCommand.YellowBackground;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.YellowBackground)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //World
            childMenu = new DXMenuCheckItem(GridStringManager.WorldBackgroundMenu);
            childMenu.Tag = GridStyleCommand.WorldBackground;
            childMenu.Click += ViewBackgroundMenu_Click;
            if (this._menuFacade.BackgroundImageName == GridStyleCommand.WorldBackground)
            {
                childMenu.Checked = true;
            }
            menuParent.Items.Add(childMenu);

            //User defined
            foreach (KeyValuePair<string, string> item in GridStyleCommand._UserDefinedBackgroundImages)
            {
                childMenu = new DXMenuCheckItem(item.Key);
                childMenu.Tag = item.Key;
                childMenu.Click += ViewBackgroundMenu_Click;
                if (this._menuFacade.BackgroundImageName == item.Key)
                {
                    childMenu.Checked = true;
                }
                menuParent.Items.Add(childMenu);
            }
        }

        #endregion

        #region Style Menu

        private void CreateStyleMenus(DXMenuItemCollection menus)
        {
            XAppearances xAppearances = this._menuFacade.XAppearances;
            if (xAppearances == null)
                return;

            DXSubMenuItem mnuStyles = new DXSubMenuItem(GridStringManager.StyleSchemaMenu);
            menus.Add(mnuStyles);

            foreach (object obj in xAppearances.FormatNames)
            {
                DXMenuCheckItem childMenu = new DXMenuCheckItem(obj.ToString());
                childMenu.Click += ViewStyleMenu_Click;
                if (this._menuFacade.StyleFormatName == obj.ToString())
                {
                    childMenu.Checked = true;
                }
                mnuStyles.Items.Add(childMenu);
            }
        }

        #endregion

        #region Event Handler

        private void RecordCountMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ShowRecordCount(base.View, clicked.Caption);
        }

        private void PreviewMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ShowPreview();
        }

        private void EditEventsMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ShowEditEvents(base.View);
        }

        private void DeleteEventsMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ShowDeleteEvents(base.View);
        }

        private void RefreshMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.RefreshData(base.View);
        }

        private void SaveMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.SaveChanges(base.View);
        }

        private void RecoverDeletedItemMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.RecoverDeletedItems(base.View);
        }

        private void SaveLayoutMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.SaveLayoutToFile();
        }

        private void RestoreLayoutMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ApplyDefaultLayout();
        }

        private void DeleteLayoutMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.DeleteLayoutFile(this.View);
        }

        private void ConfigureLayoutMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ConfigureLayout(this.View);
        }

        private void ViewStyleMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.StyleFormatName = clicked.Caption;
            this._menuFacade.ApplyStyleAll();
        }

        private void ViewLookAndFeelMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.PaintStyleName = clicked.Caption;
            this._menuFacade.SkinName = string.Empty;
            this._menuFacade.ApplyStyleAll();
        }

        private void ViewSkinMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.SkinName = clicked.Caption;
            this._menuFacade.PaintStyleName = GridStyleCommand.DefaultPaintStyle;
            this._menuFacade.ApplyStyleAll();
        }

        private void ViewBackgroundMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null || clicked.Tag == null)
                return;

            this._menuFacade.BackgroundImageName = clicked.Tag.ToString();
            this._menuFacade.ApplyStyleAll();
        }

        private void ExportToHTMLMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ExportToHTML(base.View);
        }

        private void ExportToTXTMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ExportToTXT(base.View);
        }

        private void ExportToXLSMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ExportToXLS(base.View);
        }

        private void ExportToCSVMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ExportToCSV(base.View);
        }

        private void ExportToXLSXMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;

            this._menuFacade.ExportToXLSX(base.View);
        }

        private void ExportToPDFMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;


            this._menuFacade.ExportToPDF(base.View);
        }

        private void ExportToMHTMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;


            this._menuFacade.ExportToMHT(base.View);
        }

        private void ExportToRTFMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem clicked = sender as DXMenuItem;
            if (clicked == null)
                return;


            this._menuFacade.ExportToRTF(base.View);
        }

        #endregion

        #region Helper Functions

        private DXMenuItem CreateMenu(string caption)
        {
            DXMenuItem menu = new DXMenuItem();
            menu.Caption = caption;
            return menu;
        }

        #endregion
    }
}