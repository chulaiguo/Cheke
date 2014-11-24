using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Common;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraGrid;

namespace Cheke.WinCtrl
{
    public partial class FormWorkSearchBase : FormWorkBase
    {
        private Guid _taskID = Guid.NewGuid();
        private readonly CollectionBlock _block = new CollectionBlock();
        private ProgressLoadingCtrl _loadingCtrl = null;
        private List<BusinessCollectionBase> _loadingList = null;

        public FormWorkSearchBase()
        {
            InitializeComponent();
        }

        public FormWorkSearchBase(string userId, Control parent)
            : base(userId, parent)
        {
            InitializeComponent();
        }

        protected GridControl GridControl
        {
            get { return this.gridControl1; }
        }

        protected virtual bool AddNewable
        {
            get { return this.Editable; }
        }

        protected virtual bool Deletable
        {
            get { return false; }
        }

        protected CollectionBlock Block
        {
            get { return this._block; }
        }

        protected Guid TaskID
        {
            get { return this._taskID; }
        }

        protected virtual bool LargeDataMode
        {
            get{ return false; }
        }

        private bool IsLastBlock
        {
            get
            {
                if(this._block.Index == -1 || this._block.Count == 0)
                    return true;

                return this._block.Index == this._block.Count - 1;
            }
        }

        protected override void SetReadOnly(bool readOnly)
        {
            this.gridControl1.UseEmbeddedNavigator = !readOnly;
            this.gridView1.OptionsBehavior.Editable = !readOnly;
            this.gridView1.OptionsSelection.MultiSelect = !readOnly;
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            if(this.LargeDataMode)
            {
                this.btnLoadNextPage.Visible = true;
                this.btnLoadAll.Visible = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GridControlDecorator decorator = FormUtil.GetGridDecorator(this);
            if (decorator == null || decorator.DataSource == null)
                return;

            decorator.AddNewRecord();
        }


        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            GridControlDecorator decorator = FormUtil.GetGridDecorator(this);
            if (decorator == null || decorator.DataSource == null)
                return;

            FormDeleteWarning dlg = new FormDeleteWarning(decorator.GridView);
            dlg.ShowDialog();
        }

        protected override void UpdateUI(bool isDirty)
        {
            base.UpdateUI(isDirty);

            this.btnNew.Visible = !isDirty && this.AddNewable;
            this.btnDelete.Visible = !isDirty && this.Deletable;

            if (this.Block == null)
                return;

            if (this.IsLastBlock)
            {
                this.btnLoadNextPage.Enabled = false;
                this.btnLoadAll.Enabled = false;
            }
            else
            {
                this.btnLoadNextPage.Enabled = !isDirty;
                this.btnLoadAll.Enabled = !isDirty;
            }
        }

        protected override bool IsDirty
        {
            get
            {
                BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
                if (list != null)
                {
                    return list.IsDirty;
                }

                return false;
            }
        }

        protected override void CancelEdit()
        {
            if (DialogResult.Yes != base.ShowCancelDataWarning())
                return;

            this.RefreshAllData();
        }

        protected override void Save()
        {
            BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            List<BusinessCollectionBase> srcList = new List<BusinessCollectionBase>();
            srcList.Add(list);
            this.SaveWithProgress(srcList);
        }

        protected override bool Editable
        {
            get
            {
                BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
                if (list == null)
                    return false;

                return FormMainBase.Instance.HasEditPrivilege(list.TableName);
            }
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            EntityUtility.ReplaceList(list, entity);
        }

        protected void ReplaceParent(BusinessBase entity)
        {
            BusinessCollectionBase list = this.GridControl.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            EntityUtility.ReplaceListParent(list, entity);
        }

        protected void Search()
        {
            if (this.IsDirty)
            {
                if (base.ShowSaveDataWarning() == DialogResult.Yes)
                {
                    this.Save();
                    if (this.SaveResult != null && !this.SaveResult.OK)
                        return;
                }
            }

            this.Cursor = Cursors.WaitCursor;
            //WaitDialogForm dlg = this.CreateWaitDialog(this.Text, UIStringManager.SearchDataWaiting);
            this._taskID = Guid.NewGuid();
            this.DataBinding();
            this.UpdateUI(false);
            //this.CloseWaitDialog(dlg);
            this.Cursor = Cursors.Default;
            this.gridControl1.Select();
        }

        private void FormWorkSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.ActiveControl is EditorBase)
            {
                this.Search();
            }
        }

        protected override List<BusinessCollectionBase> GetImportDataList()
        {
            List<BusinessCollectionBase> list = new List<BusinessCollectionBase>();
            BusinessCollectionBase data = this.GridControl.DataSource as BusinessCollectionBase;
            if (data != null)
            {
                list.Add(data);
            }

            return list;
        }

        protected virtual CollectionBlock LoadBlockData(BusinessCollectionBase list)
        {
            return null;
        }

        private void btnLoadNextPage_Click(object sender, EventArgs e)
        {
            if (this.Block == null)
                return;

            BusinessCollectionBase dataSource = this.GridControl.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.LoadNextPage(dataSource);
            this.Cursor = Cursors.Default;

            if (this.IsLastBlock)
            {
                this.btnLoadNextPage.Enabled = false;
                this.btnLoadAll.Enabled = false;
            }
        }

        private void LoadNextPage(BusinessCollectionBase list)
        {
            if(list == null)
                return;

            this.Block.Index++;
            this.LoadBlockData(list);

            list.Block.Index = this.Block.Index;
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            this.LoadAll();
        }

        protected void LoadAll()
        {
            if (this._loadingCtrl != null && this._loadingCtrl.Visible)
                return;

            if (this.Block == null || this.IsLastBlock)
                return;

            BusinessCollectionBase dataSource = this.GridControl.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.pnlSearchCriteria.Enabled = false;
            this.pnlButtons.Enabled = false;

            if (this._loadingCtrl == null)
            {
                this._loadingCtrl = new ProgressLoadingCtrl();
                this.pnlContent.Controls.Add(this._loadingCtrl);
                this._loadingCtrl.Size = new System.Drawing.Size(500, 68);
                int x = (this.pnlContent.Width - this._loadingCtrl.Width) / 2;
                int y = (this.pnlContent.Height - this._loadingCtrl.Height) / 2;
                this._loadingCtrl.Location = new System.Drawing.Point(x, y);
                this._loadingCtrl.PercentView = true;
                this._loadingCtrl.ShowTitle = true;
                this._loadingCtrl.BringToFront();

                this._loadingCtrl.ProgressLoadingStart += loadingCtrl_DoWork;
                this._loadingCtrl.ProgressLoadingCompleted += loadingCtrl_RunWorkerCompleted;
            }

            this._loadingCtrl.Visible = true;
            this._loadingCtrl.Minimum = 0;
            this._loadingCtrl.Maximum = this.Block.Count;
            this._loadingCtrl.Step = 1;
            this._loadingCtrl.EditValue = this.Block.Index + 1;

            this._loadingList = new List<BusinessCollectionBase>();
            ArrayList list = new ArrayList();
            list.Add(dataSource.GetType());
            list.Add(this._loadingList);
            this._loadingCtrl.RunWorkerAsync(list);
        }

        private void loadingCtrl_DoWork(object sender, DoWorkEventArgs e)
        {
            ArrayList list = e.Argument as ArrayList;
            if (list == null || list.Count != 2)
                return;

            Type dataSourceType = list[0] as Type;
            if(dataSourceType == null)
                return;

            List<BusinessCollectionBase> loadingList = list[1] as List<BusinessCollectionBase>;
            if (loadingList == null)
                return;

            while (!this.IsLastBlock)
            {
                if (this._loadingCtrl.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                BusinessCollectionBase data = Activator.CreateInstance(dataSourceType) as BusinessCollectionBase;
                if(data == null)
                    continue;

                this.LoadNextPage(data);
                loadingList.Add(data);

                Thread.Sleep(1000);
                this._loadingCtrl.ReportProgress(0);
            }
        }

        private void loadingCtrl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                base.ShowErrorMessage(e.Error.Message);
            }
            else
            {
                BusinessCollectionBase dataSource = this.GridControl.DataSource as BusinessCollectionBase;
                if (dataSource != null)
                {
                    foreach (BusinessCollectionBase item in this._loadingList)
                    {
                        dataSource.AddRange(item);
                    }
                }

                this.pnlSearchCriteria.Enabled = true;
                this.pnlButtons.Enabled = true;

                if (!e.Cancelled)
                {
                    this.btnLoadNextPage.Enabled = false;
                    this.btnLoadAll.Enabled = false;
                }
            }

            this._loadingCtrl.Visible = false;
            this.Cursor = Cursors.Default;
        }
    }
}