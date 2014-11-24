using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormBatchEdit : FormBatchEditBase
    {
        public FormBatchEdit()
        {
            InitializeComponent();
        }

        public FormBatchEdit(GridView batchEditView)
            : base(batchEditView)
        {
            InitializeComponent();
        }

        protected override Dictionary<int, object> GetEditedList()
        {
            int[] rowHandles = this.BatchEditView.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0)
                return null;

            Dictionary<int, object> list = new Dictionary<int, object>();
            for (int i = 0; i < rowHandles.Length; i++)
            {
                object obj = base.BatchEditView.GetRow(rowHandles[i]);
                if (obj == null)
                    continue;

                list.Add(rowHandles[i], obj);
            }

            return list;
        }
    }
}