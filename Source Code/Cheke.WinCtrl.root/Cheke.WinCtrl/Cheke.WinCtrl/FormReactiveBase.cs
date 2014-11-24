using System;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Cheke.BusinessEntity;

namespace Cheke.WinCtrl
{
    public partial class FormReactiveBase : FormBase
    {
        public FormReactiveBase()
        {
            InitializeComponent();
        }

        public FormReactiveBase(string userid)
            : base(userid)
        {
            this.InitializeComponent();
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.DataBinding();
            this.UpdateUI();
        }

        private void UpdateUI()
        {
            if(this.gridView1.FocusedRowHandle > -1)
            {
                this.btnOK.Enabled = true;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnOK.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        protected virtual void DataBinding()
        {
           
        }

        public override void RefrshGridViewData(GridView view)
        {
            this.DataBinding();
            this.UpdateUI();
        }

        protected GridControl GridControl
        {
            get { return this.gridControl1; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BusinessBase entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as BusinessBase;
            if (entity == null)
                return;

            PropertyInfo markAsDeleted = entity.GetType().GetProperty("MarkAsDeleted");
            if (markAsDeleted == null)
                return;

            markAsDeleted.SetValue(entity, false, null);
            Result result = base.SaveItem(entity);
            if (!result.OK)
            {
                markAsDeleted.SetValue(entity, true, null);
                entity.AcceptChanges();
                base.ShowSaveDataError(result);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BusinessBase entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as BusinessBase;
            if(entity == null)
                return;

           if(System.Windows.Forms.DialogResult.Yes != base.ShowDeleteDataWarning())
                return;

            entity.Delete();
            Result result = base.SaveItem(entity);
            if(!result.OK)
            {
                entity.AcceptChanges();
                base.ShowSaveDataError(result);
            }
            else
            {
                BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
                if (list != null)
                {
                    list.Remove(entity);
                    list.AcceptChanges();
                }

                this.UpdateUI();
            }
        }
    }
}