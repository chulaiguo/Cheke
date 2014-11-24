using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.StringManager;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Design;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    public class GridMenuFacade
    {
        private readonly GridControlDecorator _decorator = null;

        public GridMenuFacade(GridControlDecorator decorator)
        {
            this._decorator = decorator;
        }

        #region Preview
        public void ShowPreview()
        {
            Cursor.Current = Cursors.WaitCursor;
            this._decorator.GridControl.ShowPrintPreview();
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Save & Refresh

        public void RefreshData(GridView view)
        {
            GridDataCommand.RefreshData(view);
        }

        public static void RefreshData(GridView view, Control parent)
        {
            GridDataCommand.RefreshData(view, parent);
        }

        public static DialogResult ShowRefreshWarning()
        {
            return GridDataCommand.ShowRefreshWarning();
        }
      
        public void SaveChanges(GridView view)
        {
            GridDataCommand.SaveChanges(view);
        }

        public void RecoverDeletedItems(GridView view)
        {
            GridDataCommand.RecoverDeletedItems(view);
        }

        #endregion

        #region Export
        public void ExportToHTML(GridView view)
        {
            GridExportCommand.ExportToHTML(view);
        }

        public void ExportToPDF(GridView view)
        {
            GridExportCommand.ExportToPDF(view);
        }

        public void ExportToRTF(GridView view)
        {
            GridExportCommand.ExportToRTF(view);
        }

        public void ExportToMHT(GridView view)
        {
            GridExportCommand.ExportToHTML(view);
        }

        public void ExportToTXT(GridView view)
        {
            GridExportCommand.ExportToTXT(view);
        }

        public void ExportToXLS(GridView view)
        {
            GridExportCommand.ExportToXLS(view);
        }

        public void ExportToXLSX(GridView view)
        {
            GridExportCommand.ExportToXLSX(view);
        }

        public void ExportToCSV(GridView view)
        {
            GridExportCommand.ExportToCSV(view);
        }
        #endregion

        #region History
        public void ShowEditEvents(GridView view)
        {
            this._decorator.ShowEditEvents(view);
        }

        public void ShowDeleteEvents(GridView view)
        {
            this._decorator.ShowDeleteEvents(view);
        }
        #endregion

        #region Edit

        public List<DXMenuItem> CreateEditMenus(GridView view)
        {
            return this._decorator.CreateEditMenus(view);
        }

        #endregion

        #region Application

        public void CreateApplicationMenus(DXMenuItemCollection menus, GridView view)
        {
            this._decorator.CreateApplicationMenus(menus, view);
        }

        #endregion

        #region Layout

        public static void RestoreLayoutFromFile(string userId, GridControl gridControl, GridView view)
        {
            GridLayoutCommand.RestoreLayoutFromFile(userId, gridControl, view);
        }

        public static void ApplyDefaultLayout(string userId, GridControl gridControl)
        {
            GridLayoutCommand.ApplyDefaultLayout(userId, gridControl);
        }

        public void SaveLayoutToFile()
        {
            GridLayoutCommand.SaveLayoutToFile(this._decorator.UserId, this._decorator.GridControl);
        }

        public void ApplyDefaultLayout()
        {
            GridLayoutCommand.ApplyDefaultLayout(this._decorator.UserId, this._decorator.GridControl);
        }

        public void DeleteLayoutFile(GridView view)
        {
            GridLayoutCommand.DeleteLayoutFile(this._decorator.UserId, this._decorator.GridControl, view);
        }

        public void ConfigureLayout(GridView view)
        {
            this._decorator.ConfigureLayout(view);
        }
       
        #endregion

        #region Style

        public static void SaveStyleToFile(string userid)
        {
            GridStyleCommand.SaveStyleToFile(userid);
        }

        public static void RestoreStyleFromFile(string userid)
        {
            GridStyleCommand.RestoreStyleFromFile(userid);
        }

        public static void ApplyApplicationStyle()
        {
            GridStyleCommand.ApplyApplicationStyle();
        }

        public static void ApplyGridStyle(GridControl gridControl)
        {
            GridStyleCommand.ApplyStyle(gridControl);
        }

        public static void ApplySkineName(string skinName)
        {
            GridStyleCommand._SkinName = skinName;

            WaitDialogForm dlg = CreateWaitDialog(string.Empty, UIStringManager.ApplyStyleWaiting);
            GridStyleCommand.ApplyStyleAll();
            CloseWaitDialog(dlg);
        }

        public void ApplyStyleAll()
        {
            WaitDialogForm dlg = CreateWaitDialog(string.Empty, UIStringManager.ApplyStyleWaiting);
            GridStyleCommand.ApplyStyleAll();
            CloseWaitDialog(dlg);
        }

        public string StyleFormatName
        {
            get { return GridStyleCommand._StyleFormatName; }
            set { GridStyleCommand._StyleFormatName = value; }
        }

        public string PaintStyleName
        {
            get { return GridStyleCommand._PaintStyleName; }
            set { GridStyleCommand._PaintStyleName = value; }
        }

        public string SkinName
        {
            get { return GridStyleCommand._SkinName; }
            set { GridStyleCommand._SkinName = value; }
        }

        public string BackgroundImageName
        {
            get { return GridStyleCommand._BackgroundImageName; }
            set { GridStyleCommand._BackgroundImageName = value; }
        }

        public XAppearances XAppearances
        {
            get { return GridStyleCommand.XAppearances; }
        }
        #endregion

        #region Helper
        public void ShowRecordCount(GridView view, string caption)
        {
            string count = string.Empty;

            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list != null)
            {
                CollectionBlock block = list.Block;
                if (block.Index < 0)
                {
                    count = string.Format("{0:n0}", list.Count);
                }
                else
                {
                    count = string.Format("{0:n0}/{1:n0}", list.Count, block.Records);
                }
            }
            else
            {
                IList dataSource = view.DataSource as IList;
                if(dataSource != null)
                {
                    count = string.Format("{0:n0}", dataSource.Count);
                }
            }

            if (string.IsNullOrEmpty(count))
                return;

            XtraMessageBox.Show(string.Format(UIStringManager.TotalRecordsFormat, count), caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion

        #region Wait Dialog
        private static WaitDialogForm CreateWaitDialog(string caption, string title)
        {
            Cursor.Current = Cursors.WaitCursor;
            return new WaitDialogForm(caption, title);
        }

        private static void CloseWaitDialog(WaitDialogForm dlg)
        {
            if (dlg != null)
            {
                dlg.Close();
                dlg.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}