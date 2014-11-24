using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.StringManager;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.Warnings
{
    public partial class FormDirtyList : Form
    {
        public FormDirtyList()
        {
            InitializeComponent();
        }

        public FormDirtyList(GridControlDecorator decorator, ArrayList updateList, ArrayList insertList, ArrayList deletedList)
        {
            InitializeComponent();

            if(updateList.Count > 0)
            {
                this.SetColumns(decorator, this.grdUpdaingListView);
                this.grdUpdaingList.DataSource = updateList;
            }
            else
            {
                this.xtraTabControl1.TabPages.Remove(this.tabUpdatingList);
            }

            if (insertList.Count > 0)
            {
                this.SetColumns(decorator, this.grdInsertingListView);
                this.grdInsertingList.DataSource = insertList;
            }
            else
            {
                this.xtraTabControl1.TabPages.Remove(this.tabInsertingList);
            }

            if (deletedList.Count > 0)
            {
                this.SetColumns(decorator, this.grdDeletingListView);
                this.grdDeletingList.DataSource = deletedList;
            }
            else
            {
                this.xtraTabControl1.TabPages.Remove(this.tabDeletingList);
            }

            this.tabDeletingList.Text = UIStringManager.Common_DeleteList;
            this.tabInsertingList.Text = UIStringManager.Common_InsertList;
            this.tabUpdatingList.Text = UIStringManager.Common_UpdateList;
            this.Text = string.Format("{0} / {1} / {2}", this.tabInsertingList.Text, this.tabUpdatingList.Text, this.tabDeletingList.Text);

            this.btnClose.Text = UIStringManager.CloseButton_Caption;
        }

        private void SetColumns(GridControlDecorator decorator, GridView view)
        {
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsBehavior.Editable = false;
            view.OptionsDetail.EnableMasterViewMode = false;
            view.Columns.Clear();

            SortedList<int, ArrayList> sortedList = new SortedList<int, ArrayList>();
            foreach (GridColumn item in decorator.GridView.Columns)
            {
                if (!item.OptionsColumn.ShowInCustomizationForm)
                    continue;

                if (!item.Visible)
                    continue;

                if (!sortedList.ContainsKey(item.VisibleIndex))
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
                    col.VisibleIndex = view.Columns.Count;
                    view.Columns.Add(col);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}