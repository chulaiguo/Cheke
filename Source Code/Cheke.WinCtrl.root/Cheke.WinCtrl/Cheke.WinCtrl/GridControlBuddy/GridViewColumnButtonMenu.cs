using System;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlBuddy
{
    internal class GridViewColumnButtonMenu : GridViewMenu
    {
        public GridViewColumnButtonMenu(GridView view)
            : base(view)
        {
        }

        protected override void CreateItems()
        {
            Items.Clear();
            foreach (GridColumn column in View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                {
                    Items.Add(CreateMenuCheckItem(column.Caption, column.VisibleIndex >= 0, null, column, true));
                }
            }
        }

        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (RaiseClickEvent(sender, null))
            {
                return;
            }

            DXMenuItem item = sender as DXMenuItem;
            if (item == null || item.Tag == null)
                return;

            GridColumn column = item.Tag as GridColumn;
            if (column != null)
            {
                column.VisibleIndex = column.VisibleIndex >= 0 ? -1 : View.VisibleColumns.Count;
            }
        }
    }
}