using System;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Common;

namespace Cheke.WinCtrl
{
    public partial class FormDetailListBase : FormDetailBase
    {
        private BusinessBase _focusedEntity = null;
        private BusinessCollectionBase _entityList = null;
        private BusinessBase _deletedEntity = null;

        public FormDetailListBase()
        {
            InitializeComponent();
        }

        public FormDetailListBase(string userid, BusinessBase focusedEntity, BusinessCollectionBase list)
            : base(userid)
        {
            InitializeComponent();

            this._focusedEntity = focusedEntity;
            this._entityList = list;
        }

        protected BusinessBase FocusedEntity
        {
            get { return this._focusedEntity; }
        }

        protected BusinessCollectionBase EntityList
        {
            get { return this._entityList; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.LookUpEdit.EditValueChanged += new EventHandler(LookUpEdit_EditValueChanged);
            this.LookUpEdit.Tag = 1;

            this.btnCopyNew.Enabled = true;
            this.ShowCopyNewButton = true;

            this._focusedEntity = this.GetFirstFocusedEntity();
            this.DataBinding();
            this.UpdateUI(this._focusedEntity.IsNew);
        }

        protected override void UpdateUI(bool isDirty)
        {
            base.UpdateUI(isDirty);

            this.btnCopyNew.Enabled = !isDirty;
            this.LookUpEdit.Properties.ReadOnly = isDirty;
        }

        protected override bool Save()
        {
            if (this._deletedEntity != null)
            {
                this._deletedEntity.Delete();
                return base.SaveItem(this._deletedEntity).OK;
            }
            else
            {
                return base.SaveItem(this.FocusedEntity).OK;
            }
        }

        protected override bool IsDirty
        {
            get
            {
                if (this._deletedEntity != null)
                {
                    return true;
                }
                else
                {
                    return this.FocusedEntity.IsDirty;
                }
            }
        }

        protected virtual BusinessBase CreateNewEntity()
        {
            return Activator.CreateInstance(this.EntityList.GetItemType()) as BusinessBase;
        }

        protected virtual BusinessBase CopyNewEntity()
        {
            return Activator.CreateInstance(this.EntityList.GetItemType()) as BusinessBase;
        }

        protected override void Edit()
        {
            this.BeginEdit();
        }

        protected override void BeginEdit()
        {
            this.FocusedEntity.EndEdit();
            this.FocusedEntity.BeginEdit();
            this.UpdateUI(true);
        }

        protected override void EndEdit()
        {
            this._deletedEntity = null;
            if (this.EntityList.Count == 0)
            {
                this.Saveable = false;
                this.Close();
            }
            else
            {
                this.FocusedEntity.EndEdit();
                this.UpdateUI(false);
            }
        }

        protected override void CancelEdit()
        {
            if (this._deletedEntity != null)
            {
                this._deletedEntity.AcceptChanges();
                this.EntityList.AcceptChanges(this._deletedEntity.ObjectID);
                this.EntityList.Add(this._deletedEntity);

                this.LookUpEdit.EditValue = this._deletedEntity;

                this.UpdateUI(false);
                this._deletedEntity = null;
            }
            else
            {
                if (this.FocusedEntity.IsNew)
                {
                    BusinessBase nextEntity = this.GetNextFocusedEntity();
                    this.EntityList.Remove(this.FocusedEntity);
                    this.EntityList.AcceptChanges(this.FocusedEntity.ObjectID);
                    if (this.EntityList.Count == 0)
                    {
                        this.Saveable = false;
                        this.Close();
                    }
                    else
                    {
                        this.LookUpEdit.EditValue = nextEntity;
                    }
                }
                else
                {
                    this.FocusedEntity.CancelEdit();
                    this.DataBinding();
                }

                this.UpdateUI(false);
            }
        }

        protected override void Delete()
        {
            this._deletedEntity = this.FocusedEntity;
            BusinessBase nextEntity = this.GetNextFocusedEntity();
            this.EntityList.Remove(this._deletedEntity);
            this.LookUpEdit.EditValue = nextEntity;

            this.UpdateUI(true);
            base.SetReadOnly(true);
        }

        protected override void AddNew()
        {
            BusinessBase entity = this.CreateNewEntity();
            if (entity == null)
                return;

            this.EntityList.Add(entity);
            this.LookUpEdit.EditValue = entity;
            this.UpdateUI(true);
        }

        private void btnCopyNew_Click(object sender, EventArgs e)
        {
            BusinessBase entity = this.CopyNewEntity();
            if (entity == null)
                return;

            this.EntityList.Add(entity);
            this.LookUpEdit.EditValue = entity;
            this.UpdateUI(true);
        }

        protected virtual LookUpEditEx LookUpEdit
        {
            get { throw new NotImplementedException(); }
        }

        private void LookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            BusinessBase entity = this.LookUpEdit.EditValue as BusinessBase;
            if (entity != null)
            {
                this._focusedEntity = entity;
                this.DataBinding();
            }
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            if (entity.GetType() == this.EntityList.GetItemType())
            {
                if (entity.IsDeleted && entity.Equals(this.FocusedEntity))
                {
                    BusinessBase nextEntity = this.GetNextFocusedEntity();
                    this.EntityList.Remove(this.FocusedEntity);
                    this.EntityList.AcceptChanges(this.FocusedEntity.ObjectID);
                    if (this.EntityList.Count == 0)
                    {
                        this.Saveable = false;
                        this.Close();
                    }
                    else
                    {
                        this.LookUpEdit.EditValue = nextEntity;
                    }

                    return;
                }
            }

            foreach (BusinessCollectionBase item in this.EntityList)
            {
                EntityUtility.ReplaceList(item, entity);
            }

            this.DataBinding();
        }

        protected bool ShowCopyNewButton
        {
            get { return this.btnCopyNew.Visible; }
            set { this.btnCopyNew.Visible = value; }
        }

        private BusinessBase GetFirstFocusedEntity()
        {
            int index = this.EntityList.IndexOf(this.FocusedEntity);
            if (index > -1)
            {
                return this.EntityList[index] as BusinessBase;
            }
            else
            {
                this.EntityList.Add(this.FocusedEntity);
                return this.FocusedEntity;
            }
        }

        private BusinessBase GetNextFocusedEntity()
        {
            BusinessBase entity = null;
            if (this.EntityList.Count > 1)
            {
                int index = this.EntityList.IndexOf(this.FocusedEntity);
                if (index == 0)
                {
                    entity = this.EntityList[1] as BusinessBase;
                }
                else
                {
                    entity = this.EntityList[index - 1] as BusinessBase;
                }
            }

            return entity;
        }
    }
}