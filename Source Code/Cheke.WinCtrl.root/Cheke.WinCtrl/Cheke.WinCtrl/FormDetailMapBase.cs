using System;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;

namespace Cheke.WinCtrl
{
    public partial class FormDetailMapBase : FormBase
    {
        private readonly BusinessBase _entity = null;
        private readonly bool _isEditMode = false;

        public FormDetailMapBase()
        {
            InitializeComponent();
        }

        public FormDetailMapBase(string userid, BusinessBase entity, bool isEditMode)
            : base(userid)
        {
            InitializeComponent();

            this._entity = entity;
            this._isEditMode = isEditMode;
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

                key = string.Format("{0}|{1}", this.GetType().Name, this.lblCreatedNotes.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);

                key = string.Format("{0}|{1}", this.GetType().Name, this.lblModifiedNotes.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);
            }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.SetModifiedTag();
            this.DataBinding();

            this.btnSave.Text = UIStringManager.SaveButton_Caption;
            this.btnClose.Text = UIStringManager.CloseButton_Caption;

            if (FormUtil.IsReadOnly(this))
            {
                this.btnEdit.Visible = false;
                this.btnSave.Visible = false;
                return;
            }

            if (this.IsLocked)
            {
                this.SetReadOnly(true);
                this.btnEdit.Visible = false;
                this.btnSave.Visible = false;
                return;
            }

            if (this.IsEditMode)
            {
                this.btnEdit.Visible = false;
                this.btnSave.Text = UIStringManager.OKButton_Caption;
                this.btnClose.Text = UIStringManager.CancelButton_Caption;
            }
            else
            {
                this.UpdateUI(false);
            }
        }

        protected BusinessBase Entity
        {
            get { return _entity; }
        }

        protected virtual bool IsSavable
        {
            get { return true; }
        }

        protected virtual bool IsLocked
        {
            get { return false; }
        }

        public bool IsEditMode
        {
            get { return _isEditMode; }
        }

       

        protected void UpdateUI(bool editable)
        {
            this.SetReadOnly(!editable);

            if (this.IsSavable)
            {
                this.btnEdit.Enabled = !editable;
                this.btnSave.Enabled = editable;
                this.btnClose.Text = editable ? UIStringManager.CancelButton_Caption : UIStringManager.CloseButton_Caption;
            }
            else
            {
                this.btnEdit.Visible = false;
                this.btnSave.Visible = false;
                this.btnClose.Text = UIStringManager.CloseButton_Caption;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.UpdateUI(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateData())
                return;

            if(this.btnSave.Text == UIStringManager.OKButton_Caption)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            
            this.Save();
        }

        protected virtual bool ValidateData()
        {
            return true;
        }

        protected virtual void Save()
        {
            if(base.SaveItem(this._entity).OK)
            {
                this.UpdateUI(false);
            }
        }

        protected virtual void DataBinding()
        {
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
        }
    }
}