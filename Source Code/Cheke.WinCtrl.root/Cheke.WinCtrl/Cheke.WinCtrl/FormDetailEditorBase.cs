using System;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Utils;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl
{
    public partial class FormDetailEditorBase : FormDetailBase
    {
        private BusinessBase _entity = null;

        public FormDetailEditorBase()
        {
            InitializeComponent();
        }

        public FormDetailEditorBase(string userid, BusinessBase entity)
            : base(userid)
        {
            InitializeComponent();

            this._entity = entity;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;

            if (Translation.Translator.Instance.IsGatherString)
            {
                string key = string.Format("{0}|{1}", this.GetType().Name, this.lblCreatedNotes.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);

                key = string.Format("{0}|{1}", this.GetType().Name, this.lblModifiedNotes.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);
            }
        }

        protected BusinessBase Entity
        {
            get { return this._entity; }
        }

        protected override bool AddNewable
        {
            get { return FormMainBase.Instance.HasAddNewPrivilege(this.Entity.TableName); }
        }

        protected override bool Editable
        {
            get { return FormMainBase.Instance.HasEditPrivilege(this.Entity.TableName); }
        }

        protected override bool Deletable
        {
            get { return FormMainBase.Instance.HasDeletePrivilege(this.Entity.TableName); }
        }

        protected override bool IsDirty
        {
            get { return this.Entity.IsDirty; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.DataBinding();
            this.UpdateUI(this._entity.IsDirty);
        }

        protected override void UpdateUI(bool isDirty)
        {
            base.UpdateUI(isDirty);

            this.SetModifiedTag();
        }

        protected override bool Save()
        {
            return base.SaveItem(this.Entity).OK;
        }

        protected override void SaveToList(BusinessCollectionBase list)
        {
            this.Entity.EndEdit();
            foreach (BusinessBase item in list)
            {
                if (item.Equals(this.Entity))
                {
                    item.CopyFrom(this.Entity, true);
                    return;
                }
            }

            list.Add(this.Entity);
        }

        protected virtual BusinessBase NewEntity()
        {
            BusinessBase entity = Activator.CreateInstance(this.Entity.GetType()) as BusinessBase;
            EntityUtility.SynchronizeParentData(this.Entity, entity);
            return entity;
        }

        private bool RefeshEntity()
        {
            if (this.Entity.IsNew)
                return true;

            BusinessBase entity = FormMainBase.Instance.GetEntityFromDB(this._entity);
            if (entity == null)
            {
                base.ShowWarningMessage(UIStringManager.DataNotExistWarning);
                return false;
            }

            if (this._entity == entity)
                return true;

            if(!entity.IsActive)
            {
                if (System.Windows.Forms.DialogResult.Yes != base.ShowQuestion(UIStringManager.DataInactiveQuestion))
                    return false;
            }

            this._entity = entity;
            this.ClearDataBinding();
            this.DataBinding();
            return true;
        }

        protected override void Edit()
        {
            if(!this.RefeshEntity())
            {
                this.Saveable = false;
                this.Close();
                return;
            }
            
            this.BeginEdit();
        }

        protected override void BeginEdit()
        {
            this.Entity.EndEdit();
            this.Entity.BeginEdit();
            this.UpdateUI(true);
        }

        protected override void EndEdit()
        {
            this.Entity.EndEdit();
            this.UpdateUI(false);
        }

        protected override void CancelEdit()
        {
            if (this.Entity.IsNew)
            {
                this.Saveable = false;
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

        protected override void Delete()
        {
            bool canCloseForm = this.Entity.IsNew;
            if (!this.Entity.IsNew)
            {
                this.Entity.Delete();
                canCloseForm = this.Save();
                if (canCloseForm)
                {
                    base.ShowDeleteDataOKInfo();
                }
            }

            if (canCloseForm)
            {
                this.Saveable = false;
                this.Close();
            }
        }

        protected override void AddNew()
        {
            //if (this.Entity.IsDirty && DialogResult.Yes == base.ShowSaveDataWarning())
            //{
            //    if (!this.Save())
            //        return;
            //}

            BusinessBase entity = this.NewEntity();
            if (entity != null)
            {
                this._entity = entity;
                this.ClearDataBinding();
                this.DataBinding();
                this.BeginEdit();
            }
            else
            {
                base.ShowNoAddNewPrivilegeWarning();
            }
        }

        protected virtual void ChangeEntity(BusinessBase entity)
        {
            if (entity == null)
                return;

            this._entity = entity;
            this.ClearDataBinding();
            this.DataBinding();
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            if (entity.GetType() == this._entity.GetType())
            {
                if (!entity.Equals(this._entity))
                    return;

                if (entity.IsDeleted)
                {
                    this.Saveable = false;
                    this.Close();
                }
                else
                {
                    this._entity.CopyFrom(entity, true);
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

        private void SetModifiedTag()
        {
            if (this._entity.IsNew)
            {
                this._entity.CreatedBy = base.UserId;
                this._entity.CreatedOn = DateTime.Now;
                this._entity.ModifiedBy = base.UserId;
                this._entity.ModifiedOn = DateTime.Now;
            }

            this.lblCreatedNotes.Text = string.Format(UIStringManager.CreatedTag, this._entity.CreatedBy, this._entity.CreatedOn);
            this.lblModifiedNotes.Text = string.Format(UIStringManager.ModifiedTag, this._entity.ModifiedBy, this._entity.ModifiedOn);

            this.pnlCreatedTag.Visible = this._entity.CreatedBy.Length > 0;
            this.pnlModifiedTag.Visible = this._entity.ModifiedBy.Length > 0;
        }
    }
}