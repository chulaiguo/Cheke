using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormBatchAppend : FormBatchEditBase
    {
        public FormBatchAppend()
        {
            InitializeComponent();
        }

        public FormBatchAppend(GridView batchEditView)
            : base(batchEditView)
        {
            InitializeComponent();
        }

        protected override Dictionary<int, object> GetEditedList()
        {
            BusinessCollectionBase dataSource = base.BatchEditView.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return null;

            int count = this.GetAppendCount();
            if (count <= 0)
                return null;

            ArrayList list = new ArrayList();
            for (int i = 0; i < count; i++)
            {
                object obj = Activator.CreateInstance(dataSource.GetItemType());
                if (obj == null)
                    continue;

                dataSource.Add(obj);
                list.Add(obj);
            }

            return this.SelectList(base.BatchEditView, list);
        }

        private int GetAppendCount()
        {
            int appendCount;
            bool result = int.TryParse(this.txtAppendCount.Text, out appendCount);
            if (!result || appendCount <= 0)
            {
                MessageBox.Show(string.Format(GridStringManager.AppendRecordsWarning, appendCount),this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            return appendCount;
        }


        private Dictionary<int, object> SelectList(GridView view, ArrayList list)
        {
            Dictionary<int, object> retList = new Dictionary<int, object>();
            for (int i = 0; i < view.DataRowCount; i++)
            {
                object obj = view.GetRow(i);
                if (obj == null)
                    continue;

                if (this.IsExist(list, obj))
                {
                    view.SelectRow(i);
                    retList.Add(i, obj);
                }
                else
                {
                    view.UnselectRow(i);
                }
            }

            return retList;
        }

        private bool IsExist(ArrayList list, object obj)
        {
            foreach (object item in list)
            {
                if (item.Equals(obj))
                    return true;
            }

            return false;
        }
    }
}