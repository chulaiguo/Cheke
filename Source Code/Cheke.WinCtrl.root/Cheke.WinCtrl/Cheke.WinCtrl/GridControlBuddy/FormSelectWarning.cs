using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormSelectWarning : FormMiscBase
    {
        private readonly GridView _view = null;
        private readonly IList _dataSource = null;

        public FormSelectWarning()
        {
            InitializeComponent();
        }

        public FormSelectWarning(GridView view, IList dataSource)
        {
            InitializeComponent();

            this._view = view;
            this._dataSource = dataSource;
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.FocusRectStyle = DrawFocusRectStyle.None;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;

            this.SetColumns(this._view);
            this.SetDataSource(this._dataSource);
        }

        private void SetColumns(GridView view)
        {
            this.gridView1.Columns.Clear();

            SortedList<int, ArrayList> sortedList = new SortedList<int, ArrayList>();
            foreach (GridColumn item in view.Columns)
            {
                if (!item.OptionsColumn.ShowInCustomizationForm)
                    continue;

                if (!item.Visible)
                    continue;

                if(!sortedList.ContainsKey(item.VisibleIndex))
                {
                    sortedList.Add(item.VisibleIndex, new ArrayList());
                }

                sortedList[item.VisibleIndex].Add(item);
            }

            foreach (KeyValuePair<int, ArrayList> item in sortedList)
            {
                foreach (object obj in item.Value)
                {
                    GridColumn srcColumn = obj as GridColumn;
                    if (srcColumn == null)
                        continue;

                    GridColumn col = new GridColumn();
                    col.Caption = srcColumn.Caption;
                    col.FieldName = srcColumn.FieldName;
                    col.Width = srcColumn.Width;
                    col.VisibleIndex = this.gridView1.Columns.Count;
                    this.gridView1.Columns.Add(col);
                }
            }
        }

        private void SetDataSource(IList list)
        {
            int totalHeight = list.Count*25 + 100;
            if(totalHeight > 230)
            {
                if (totalHeight > Screen.PrimaryScreen.WorkingArea.Height)
                    totalHeight = Screen.PrimaryScreen.WorkingArea.Height;

                this.Height = totalHeight;
                this.Top -= (totalHeight - 230) / 2;
            }

            this.gridControl1.DataSource = list;
        }
    }
}