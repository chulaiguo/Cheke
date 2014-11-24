using System.Drawing;
using System.Windows.Forms;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.GridControlCommand;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public class GridMenuController
    {
        private readonly GridControlDecorator _decorator = null;
        private readonly GridMenuOptions _menuOptions = null;

        public GridMenuController(GridControlDecorator decorator)
        {
            this._decorator = decorator;
            this._decorator.GridControl.Tag = decorator.UserId;

            this._menuOptions = new GridMenuOptions();
        }

        public GridMenuOptions MenuOptions
        {
            get { return _menuOptions; }
        }

        public void RegisterContextMenu()
        {
            this._decorator.GridControl.MouseUp -= new MouseEventHandler(GridControl_MouseUp);
            this._decorator.GridControl.MouseUp += new MouseEventHandler(GridControl_MouseUp);
        }

        private void GridControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            GridControl gridControl = sender as GridControl;
            if (gridControl == null || gridControl.DataSource == null)
                return;

            GridView view = gridControl.FocusedView as GridView;
            if (view == null)
                return;

            GridHitInfo hi = view.CalcHitInfo(new Point(e.X, e.Y));
            switch (hi.HitTest)
            {
                case GridHitTest.RowIndicator:
                case GridHitTest.RowCell:
                case GridHitTest.EmptyRow:
                case GridHitTest.Row:
                case GridHitTest.RowEdge:
                case GridHitTest.RowPreview:
                    if (this.MenuOptions.ShowBasicMenu)
                    {
                        GridViewBasicMenu basicMenu = this.CreateBasicMenu(view);
                        basicMenu.Init(hi);
                        basicMenu.Show(hi.HitPoint);
                    }
                    break;
                case GridHitTest.ColumnButton:
                    if (this.MenuOptions.ShowColumnMenu && view.Columns.Count > 0)
                    {
                        GridViewColumnButtonMenu columnMenu = this.CreateColumnMenu(view);
                        columnMenu.Init(hi);
                        columnMenu.Show(hi.HitPoint);
                    }
                    break;
            }
        }

        private GridViewBasicMenu CreateBasicMenu(GridView view)
        {
            GridMenuFacade menuFacade = new GridMenuFacade(this._decorator);
            return new GridViewBasicMenu(menuFacade, this._menuOptions, view);
        }

        private GridViewColumnButtonMenu CreateColumnMenu(GridView view)
        {
            return new GridViewColumnButtonMenu(view);
        }
    }
}
