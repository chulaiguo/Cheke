using System;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Utils;

namespace Cheke.WinCtrl
{
    public partial class FormWorkEditorBase : FormWorkBase
    {
        private BusinessBase _entity = null;
        private BusinessBase _originalNewEntity = null;

        public FormWorkEditorBase()
        {
            InitializeComponent();
        }

        public FormWorkEditorBase(string userid, Control parent, BusinessBase entity)
            : base(userid, parent)
        {
            this.InitializeComponent();

            this._entity = entity;
            if (entity.IsNew)
            {
                this._originalNewEntity = entity.Clone() as BusinessBase;
            }
        }

        protected BusinessBase Entity
        {
            get { return this._entity; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.DataBinding();
            this.UpdateUI(this._entity.IsDirty);
        }

        protected virtual bool AddNewable
        {
            get { return FormMainBase.Instance.HasAddNewPrivilege(this.Entity.TableName); }
        }

        protected override bool Editable
        {
            get { return FormMainBase.Instance.HasEditPrivilege(this.Entity.TableName); }
        }

        protected virtual bool Deletable
        {
            get { return FormMainBase.Instance.HasDeletePrivilege(this.Entity.TableName); }
        }

        protected override void UpdateUI(bool isDirty)
        {
            base.UpdateUI(isDirty);

            if (isDirty)
            {
                this.btnNew.Visible = false;
                this.btnDelete.Visible = false;
            }
            else
            {
                this.btnNew.Visible = this.AddNewable;
                this.btnDelete.Visible = this.Deletable;
            }
        }

        protected override bool IsDirty
        {
            get { return this._entity.IsDirty; }
        }

        protected override bool ValidateData()
        {
            if (!this._entity.IsValid)
            {
                base.ShowErrorMessage(this._entity.GetBrokenRulesInfo());
                return false;
            }

            return true;
        }

        protected override void Save()
        {
            this.SaveResult = base.SaveItem(this._entity);
            if (this.SaveResult.OK)
            {
                this.EndEdit();
            }
        }

        //for grid save
        protected override void AfterSave()
        {
            this.EndEdit();
            if (!this.SaveResult.OK)
            {
                base.ShowSaveDataError(this.SaveResult);
            }
            this.BeginEdit();
        }

        protected override void BeginEdit()
        {
            this._entity.EndEdit();
            this._entity.BeginEdit();
            this.UpdateUI(true);
        }

        protected override void EndEdit()
        {
            this._entity.EndEdit();
            this.UpdateUI(false);
        }

        protected override void CancelEdit()
        {
            if(!this.CanCancelData())
                return;

            if (this._entity.IsNew)
            {
                this.IsDeletedForm = true;
                this.Close();
            }
            else
            {
                this._entity.CancelEdit();

                this.ClearDataBinding();
                this.DataBinding();
                this.UpdateUI(false);
            }
        }

        private bool CanCancelData()
        {
            if (this._entity.IsNew || !EntityUtility.IsEntityDataEqual(this._entity, this._originalNewEntity))
            {
                return DialogResult.Yes == base.ShowCancelDataWarning();
            }

            return true;
        }

        protected override void RefreshAllData()
        {
            if (this._entity.IsNew)
            {
                base.IsDeletedForm = true;
                this.Close();
            }
            else
            {
                this._entity = this.RefreshEntity();
                if (this._entity == null)
                {
                    this.pnlContent.Enabled = false;
                    this.pnlButtons.Enabled = false;
                }
                else
                {
                    base.RefreshAllData();
                }
            }
        }

        protected virtual BusinessBase RefreshEntity()
        {
            throw new NotImplementedException();
        }

        protected virtual BusinessBase NewEntity()
        {
            BusinessBase entity = Activator.CreateInstance(this.Entity.GetType()) as BusinessBase;
            EntityUtility.SynchronizeParentData(this.Entity, entity);
            return entity;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!this.CanDelete)
                return;

            this.Delete();
        }

        protected virtual void Delete()
        {
            this.Cursor = Cursors.WaitCursor;
            base.IsDeletedForm = true;
            if (!this._entity.IsNew)
            {
                this._entity.Delete();
                this.Save();
            }

            this.Close();
            this.Cursor = Cursors.Default;
        }

        protected virtual bool CanDelete
        {
            get { return DialogResult.Yes == base.ShowDeleteDataWarning(); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           this.AddNew();
        }

        protected virtual void AddNew()
        {
            this.Cursor = Cursors.WaitCursor;

            BusinessBase newEntity = this.NewEntity();
            if (newEntity == null)
            {
                this.Cursor = Cursors.Default;
                return;
            }

            this._entity = newEntity;
            this._originalNewEntity = this._entity.Clone() as BusinessBase;

            this.ClearDataBinding();
            this.DataBinding();
            this.BeginEdit();

            this.Cursor = Cursors.Default;
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            if (entity.GetType() == this._entity.GetType())
            {
                if (!entity.Equals(this._entity))
                    return;

                if (entity.IsDeleted)
                {
                    this.IsDeletedForm = true;
                    this.Close();
                }
                else
                {
                    this._entity.CopyFrom(entity, true);
                    this.RefreshEditorDataBinding();
                    this.UpdateUI(entity.IsDirty);
                }
            }
            else
            {
                EntityUtility.ReplaceItem(this._entity, entity);
            }
        }

        protected void RefreshEditorDataBinding()
        {
            FormUtil.RefreshEditorDataBinding(this);
        }

        public override bool Contains(object obj)
        {
            BusinessBase item = obj as BusinessBase;
            if (item == null)
                return false;

            return this._entity.Equals(item);
        }

        public override bool IsChildForm(BusinessBase parent)
        {
            return EntityUtility.IsEntityParent(this._entity, parent);
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
    }
}