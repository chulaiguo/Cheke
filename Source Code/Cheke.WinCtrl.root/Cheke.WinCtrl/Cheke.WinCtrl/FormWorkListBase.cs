using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraEditors;

namespace Cheke.WinCtrl
{
    public partial class FormWorkListBase : FormWorkBase
    {
        private MarqueeProgressBarControl _progressBar = null;

        public FormWorkListBase()
        {
            InitializeComponent();
        }

        public FormWorkListBase(string userid, Control parent)
            : base(userid, parent)
        {
            this.InitializeComponent();
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.DataBinding();
            this.UpdateUI(false);
       }

        protected virtual bool AddNewable
        {
            get { return false; }
        }

        protected virtual bool Deletable
        {
            get { return false; }
        }

        protected override bool IsDirty
        {
            get
            {
                List<BusinessCollectionBase> list = FormUtil.GetListData(this);
                foreach (BusinessCollectionBase item in list)
                {
                    if (item.IsDirty)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        protected override bool Editable
        {
            get
            {
                List<BusinessCollectionBase> list = FormUtil.GetListData(this);
                foreach (BusinessCollectionBase item in list)
                {
                    if (FormMainBase.Instance.HasEditPrivilege(item.TableName))
                    {
                        return true;
                    }
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
            List<BusinessCollectionBase> srcList = FormUtil.GetListData(this);
            this.SaveWithProgress(srcList);
        }

        protected override void UpdateUI(bool isDirty)
        {
            base.UpdateUI(isDirty);

            this.btnNew.Visible = !isDirty && this.AddNewable;
            this.btnDelete.Visible = !isDirty && this.Deletable;
        }

        private void btnNew_Click(object sender, System.EventArgs e)
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

        protected override List<BusinessCollectionBase> GetImportDataList()
        {
            return FormUtil.GetListData(this);
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            List<BusinessCollectionBase> list = FormUtil.GetListData(this);
            foreach (BusinessCollectionBase item in list)
            {
                EntityUtility.ReplaceList(item, entity);
            }
        }

        protected void ReplaceParent(BusinessBase entity)
        {
            List<BusinessCollectionBase> list = FormUtil.GetListData(this);
            foreach (BusinessCollectionBase item in list)
            {
                EntityUtility.ReplaceListParent(item, entity);
            }
        }

        protected override void DataBinding()
        {
            if(this._progressBar != null && this._progressBar.Visible)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.pnlButtons.Enabled = false;
            if (this._progressBar == null)
            {
                this._progressBar = new MarqueeProgressBarControl();
                this.pnlContent.Controls.Add(this._progressBar);
                this._progressBar.Size = new System.Drawing.Size(500, 35);
                int x = (this.pnlContent.Width - this._progressBar.Width) / 2;
                int y = (this.pnlContent.Height - this._progressBar.Height) / 2;
                this._progressBar.Location = new System.Drawing.Point(x, y);
                this._progressBar.Text = "Loading...";
                this._progressBar.Properties.ShowTitle = true;
                this._progressBar.BringToFront();
            }

            this._progressBar.Visible = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        protected virtual void LoadingData()
        {
        }

        protected virtual void AfterLoadingData()
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LoadingData();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                base.ShowErrorMessage(e.Error.Message);
            }
            else
            {
                this.AfterLoadingData();
                this.pnlButtons.Enabled = true;
                this.UpdateUI(false);
            }

            this._progressBar.Visible = false;
            this.Cursor = Cursors.Default;
        }
    }
}