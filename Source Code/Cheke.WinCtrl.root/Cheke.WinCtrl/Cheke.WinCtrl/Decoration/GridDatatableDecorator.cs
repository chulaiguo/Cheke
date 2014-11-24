using System;
using System.Data;
using Cheke.WinCtrl.GridControlBuddy;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.Decoration
{
    public class GridDatatableDecorator : GridControlDecorator
    {
        public GridDatatableDecorator(string userId, GridControl gridControl)
            : base(userId, gridControl)
        {
        }

        protected override void SetProperties()
        {
            base.SetProperties();

            base.GridView.OptionsView.ShowGroupPanel = false;
            base.MenuController.MenuOptions.ShowHistoryMenu = false;
            base.MenuController.MenuOptions.ShowRefreshMenu = false;
            base.MenuController.MenuOptions.ShowLayoutMenu = false;
            
            base.GridView.OptionsView.RowAutoHeight = true;
        }

        protected override void SetDisplayColumns(GridView view)
        {
        }

        public void AddColumns(DataTable table)
        {
            GridView view = this.GridView;
            view.Columns.Clear();

            foreach (DataColumn column in table.Columns)
            {
                if (column.DataType == typeof (byte[]))
                {
                    if (column.Caption.ToLower().Contains("photo"))
                    {
                        GridColumn colPhoto = new GridColumn();
                        colPhoto.Caption = column.Caption;
                        colPhoto.FieldName = column.ColumnName;
                        RepositoryItemPictureEdit editor = new RepositoryItemPictureEdit();
                        editor.ShowMenu = false;
                        editor.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                        editor.CustomHeight = 72;
                        colPhoto.ColumnEdit = editor;
                        colPhoto.Width = 96;
                        colPhoto.VisibleIndex = view.Columns.Count;
                        view.Columns.Add(colPhoto);
                    }

                    continue;
                }

                if (column.DataType == typeof (DateTime))
                {
                    GridColumn colDateTime = new GridColumn();
                    colDateTime.Caption = column.Caption;
                    colDateTime.FieldName = column.ColumnName;
                    colDateTime.VisibleIndex = view.Columns.Count;
                    colDateTime.DisplayFormat.FormatType = FormatType.DateTime;
                    colDateTime.DisplayFormat.FormatString = "MM/dd/yyyy HH:mm:ss";
                    view.Columns.Add(colDateTime);

                    continue;
                }

                GridColumn colText = new GridColumn();
                colText.Caption = column.Caption;
                colText.FieldName = column.ColumnName;
                colText.VisibleIndex = view.Columns.Count;
                view.Columns.Add(colText);
            }
        }

        protected override void NavigatorEditClick(GridView view, NavigatorButtonClickEventArgs e)
        {
            e.Handled = true;
          
            DataRowView entity = view.GetRow(view.FocusedRowHandle) as DataRowView;
            if (entity == null)
                return;

            FormDatatableItem dlg = new FormDatatableItem(entity.Row);
            dlg.ShowDialog();
        }
    }
}