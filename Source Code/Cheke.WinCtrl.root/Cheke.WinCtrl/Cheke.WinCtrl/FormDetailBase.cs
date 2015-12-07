using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;

namespace Cheke.WinCtrl
{
    public partial class FormDetailBase : FormBase
    {
        private bool _isRefreshData = false;
        private BusinessCollectionBase _parentList = null;

        public FormDetailBase()
        {
            InitializeComponent();
        }

        public FormDetailBase(string userid)
            : base(userid)
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;

            if (Translation.Translator.Instance.IsGatherString)
            {
                string key = string.Format("{0}|{1}", this.GetType().Name, this.btnClose.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);

                key = string.Format("{0}|{1}", this.GetType().Name, this.btnSave.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);
            }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.btnSave.Text = UIStringManager.SaveButton_Caption;
            this.btnClose.Text = UIStringManager.CloseButton_Caption;
        }

        protected bool IsRefreshData
        {
            get { return _isRefreshData; }
        }

        protected bool Saveable
        {
            get { return this.btnSave.Enabled; }
            set { this.btnSave.Enabled = value; }
        }

        protected virtual bool AddNewable
        {
            get { return true; }
        }

        protected virtual bool Editable
        {
            get { return true; }
        }

        protected virtual bool Deletable
        {
            get { return true; }
        }

        public BusinessCollectionBase ParentList
        {
            get { return this._parentList; }
            set { this._parentList = value; }
        }

        protected virtual void UpdateUI(bool isDirty)
        {
            if (this._parentList != null)
            {
                this.btnSave.Text = UIStringManager.OKButton_Caption;
                this.btnClose.Text = UIStringManager.CancelButton_Caption;

                this.btnNew.Visible = false;
                this.btnEdit.Visible = false;
                this.btnDelete.Visible = false;

                return;
            }

            if (isDirty)
            {
                this.btnNew.Visible = false;
                this.btnEdit.Visible = false;
                this.btnDelete.Visible = false;
                this.btnSave.Visible = true;

                this.btnClose.Text = UIStringManager.CancelButton_Caption;
                this.SetReadOnly(false);
            }
            else
            {
                this.btnNew.Visible = this.AddNewable;
                this.btnEdit.Visible = this.Editable;
                this.btnDelete.Visible = this.Deletable;
                this.btnSave.Visible = false;

                if (!this.AddNewable && !this.Editable && !this.Deletable)
                {
                    this.btnNew.Visible = false;
                    this.btnEdit.Visible = false;
                    this.btnDelete.Visible = false;
                    this.btnSave.Visible = false;
                }

                this.btnClose.Text = UIStringManager.CloseButton_Caption;
                this.SetReadOnly(true);
            }
        }

        protected virtual bool Save()
        {
            return true;
        }

        protected virtual void SaveToList(BusinessCollectionBase list)
        {
        }

        protected virtual bool IsDirty
        {
            get { return false; }
        }

        protected virtual bool ValidateData()
        {
            return true;
        }

        protected void DataBinding()
        {
            this.Cursor = Cursors.WaitCursor;
            this.DataBindingEntity();
            this.DataBindingChildren();
            this.Cursor = Cursors.Default;
        }

        protected virtual void DataBindingEntity()
        {
        }

        protected virtual void DataBindingChildren()
        {
            List<XtraTabControl> list = FormUtil.GetTabControl(this);
            if (list.Count > 0)
            {
                XtraTabControl mainCtrl = list[0];
                foreach (XtraTabControl control in list)
                {
                    if (control.Parent == this.pnlContent)
                    {
                        mainCtrl = control;
                        break;
                    }
                }

                mainCtrl.Select();
                if (mainCtrl.SelectedTabPage != null)
                {
                    mainCtrl.SelectedTabPage.Select();
                }
            }
        }

        protected virtual void ClearDataBinding()
        {
            List<XtraTabControl> list = FormUtil.GetTabControl(this);
            foreach (XtraTabControl tabControl in list)
            {
                foreach (XtraTabPage item in tabControl.TabPages)
                {
                    item.Tag = null;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this._parentList != null)
            {
                this.SaveToList(this._parentList);
                this.Saveable = false;
                this.Close();
                return;
            }

            if (!this.IsDirty)
            {
                this.EndEdit();
                return;
            }

            if(!this.ValidateData())
                return;

            if (this.Save())
            {
                this.EndEdit();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this._parentList != null)
            {
                this.Saveable = false;
                if (this.BeforeClose())
                {
                    this.Close();
                }
                return;
            }

            if (this.btnClose.Text == UIStringManager.CloseButton_Caption)
            {
                if (this.BeforeClose())
                {
                    this.Close();
                }
            }
            else
            {
                if (!this.IsDirty || DialogResult.Yes == base.ShowCancelDataWarning())
                {
                    this.CancelEdit();
                }
            }
        }

        protected virtual bool BeforeClose()
        {
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.AddNew();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!this.CanDelete)
                return;

            this.Delete();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Edit();
            this.Cursor = Cursors.Default;
        }

        protected virtual void Edit()
        {
        }

        protected virtual void AddNew()
        {
        }

        protected virtual bool CanDelete
        {
            get { return DialogResult.Yes == base.ShowDeleteDataWarning(); }
        }

        protected virtual void Delete()
        {
        }

        protected virtual void BeginEdit()
        {
        }

        protected virtual void EndEdit()
        {
        }

        protected virtual void CancelEdit()
        {
        }

        public override void RefrshGridViewData(GridView view)
        {
            if (view.IsDetailView)
                return;

            this._isRefreshData = true;

            XtraTabControl xtraTabControl = FormUtil.GetParentTabControl(view.GridControl);
            if (xtraTabControl != null)
            {
                xtraTabControl.SelectedTabPage.Tag = null;
                xtraTabControl.Focus();

                xtraTabControl.Select();
                xtraTabControl.SelectedTabPage.Select();
            }
            else
            {
                this.DataBindingChildren();
            }

            this._isRefreshData = false;
        }

        private void FormDialogBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                this.ProcessTabKey(true);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!this.Saveable || !this.IsDirty)
                return;

            if (!this.ValidateData())
                return;

            if (DialogResult.Yes == base.ShowSaveDataWarning())
            {
                if (!this.Save())
                {
                    e.Cancel = true;
                }
            }
        }

        protected bool ShowNewButton
        {
            get
            {
                return this.btnNew.Visible && this.AddNewable;
            }
            set
            {
                if (!this.AddNewable)
                    return;

                this.btnNew.Visible = value;
            }
        }

        protected bool ShowDeleteButton
        {
            get
            {
                return this.btnDelete.Visible && this.Deletable;
            }
            set
            {
                if (!this.Deletable)
                    return;

                this.btnDelete.Visible = value;
            }
        }

        protected DevExpress.XtraEditors.SimpleButton SaveButton
        {
            get { return this.btnSave; }
        }

        protected DevExpress.XtraEditors.SimpleButton NewButton
        {
            get { return this.btnNew; }
        }

        protected DevExpress.XtraEditors.SimpleButton DeleteButton
        {
            get { return this.btnDelete; }
        }

        protected DevExpress.XtraEditors.SimpleButton EditButton
        {
            get { return this.btnEdit; }
        }
    }
}