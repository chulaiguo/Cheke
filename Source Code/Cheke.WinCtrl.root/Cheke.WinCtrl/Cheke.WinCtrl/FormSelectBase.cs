using System;
using System.Windows.Forms;
using Cheke.WinCtrl.GridControlBuddy;
using Cheke.WinCtrl.StringManager;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Cheke.WinCtrl.Common;
using System.Collections;

namespace Cheke.WinCtrl
{
    public partial class FormSelectBase : FormBase
    {
        private object _defaultEntity = null;
        private bool _multiSelect = true;
        private object _selectedEntity = null;
        private IList _selectedList = null;

        public FormSelectBase()
        {
            InitializeComponent();
        }

        public FormSelectBase(string userId)
            : base(userId)
        {
            InitializeComponent();
        }

        protected object SelectedEntity
        {
            get { return _selectedEntity; }
        }

        protected IList SelectedList
        {
            get { return this._selectedList; }
        }

        protected GridControl GridControl
        {
            get { return this.gridControl1; }
        }

        public bool MultiSelect
        {
            get { return this._multiSelect; }
            set { this._multiSelect = value; }
        }

        public object DefaultEntity
        {
            get { return _defaultEntity; }
            set { _defaultEntity = value; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.btnCancel.Enabled = !this.DisableCancel;
            this.gridView1.OptionsSelection.MultiSelect = this.MultiSelect;
            this.gridView1.OptionsBehavior.Editable = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._selectedEntity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (this._selectedEntity == null)
            {
                base.ShowWarningMessage(UIStringManager.UnselectWarning);
                return;
            }

            this._selectedList = this.GetSelectedList(this.gridView1);
            if(this._selectedList.Count == 0)
            {
                this._selectedList.Add(this._selectedEntity);
            }

            if (this.MultiSelect)
            {
                FormSelectWarning warningDlg = new FormSelectWarning(this.gridView1, this._selectedList);
                this.DialogResult = warningDlg.ShowDialog();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this._selectedEntity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (this._selectedEntity != null)
            {
                this.ShowDetail();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.DataBinding();
        }

        protected virtual void ShowDetail()
        {
        }

        protected virtual void DataBinding()
        {

        }

        protected virtual void DataFilter()
        {

        }

        protected virtual bool EnterForFilter
        {
            get { return false; }
        }

        protected virtual bool DisableCancel
        {
            get { return false; }
        }

        public override void RefrshGridViewData(GridView view)
        {
            this.DataBinding();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if(!this.btnCancel.Enabled && this.DialogResult != DialogResult.OK)
                e.Cancel = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this._selectedEntity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
            if (this._selectedEntity != null)
            {
                this._selectedList = this.GetSelectedList(this.gridView1);
                if (this._selectedList.Count == 0)
                {
                    this._selectedList.Add(this._selectedEntity);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            IList list = this.gridControl1.DataSource as IList;
            if (list == null || list.Count == 0)
            {
                this.btnOK.Enabled = false;
                this.btnDetail.Enabled = false;
            }
            else
            {
                this.btnOK.Enabled = true;
                this.btnDetail.Enabled = true;
                this.FocusOnDefaultEntity(list);
            }
        }

        private void FormSelectBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl is EditorBase)
            {
                if (this.EnterForFilter)
                {
                    this.DataFilter();
                }
                else
                {
                    this.DataBinding();
                }
            }
        }

        private IList GetSelectedList(GridView view)
        {
            if (view.DataSource == null)
                return null;

            IList list = Activator.CreateInstance(view.DataSource.GetType()) as IList;
            if (list == null)
                return null;

            int[] rowHandles = view.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0)
                return list;

            for (int i = 0; i < rowHandles.Length; i++)
            {
                object entity = view.GetRow(rowHandles[i]);
                if (entity == null)
                    continue;

                list.Add(entity);
            }

            return list;
        }

        private void FocusOnDefaultEntity(IList list)
        {
            int dataSourceIndex = this.GetDefaultDataSourceIndex(list);
            if(dataSourceIndex < 0)
                return;

            int rowhandle = this.gridView1.GetRowHandle(dataSourceIndex);
            if(rowhandle < 0)
                return;

            this.gridView1.FocusedRowHandle = rowhandle;
            this.gridControl1.ForceInitialize();
            this.gridView1.MakeRowVisible(rowhandle, false);
        }

        protected virtual int GetDefaultDataSourceIndex(IList list)
        {
            if (this.DefaultEntity == null)
                return -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Equals(this.DefaultEntity))
                    continue;

                return i;
            }

            return -1;
        }

        protected void ShowDetailButton(bool visible)
        {
            this.btnDetail.Visible = visible;
        }
    }
}