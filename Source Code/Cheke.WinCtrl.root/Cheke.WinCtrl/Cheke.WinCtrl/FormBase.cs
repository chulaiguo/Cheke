using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.GridControlCommand;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl
{
    public partial class FormBase : Form, ISaveGridViewData, IRefreshGridViewData, ILocalDataProcesser
    {
        private readonly string _userId = string.Empty;

        public FormBase()
        {
            InitializeComponent();
        }

        public FormBase(string userId)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.InitializeComponent();
            this._userId = userId;
        }

        [Browsable(false)]
        public string UserId
        {
            get { return _userId; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;

            this.InitializeDecorator();
            if (Translation.Translator.Instance.IsGatherString)
            {
                this.GetTranslateString();
            }
            if (Translation.Translator.Instance.IsTranslate)
            {
                this.TranslateForm();
            }
            
            this.InitializeForm();

            if(FormMainBase.Instance != null)
            {
                FormMainBase.Instance.OnFormLoaded(this);
            }
            Cursor.Current = Cursors.Default;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (FormMainBase.Instance != null)
            {
                FormMainBase.Instance.OnFormClosed(this);
            }
        }

        protected virtual void InitializeDecorator()
        {
        }

        protected virtual void InitializeForm()
        {
        }

        public virtual void TranslateForm()
        {
           Translation.Translator.Instance.TranslateForm(this);
        }

        public virtual void GetTranslateString()
        {
            Translation.Translator.Instance.GetTranslateString(this);
        }

        protected virtual void SetReadOnly(bool readOnly)
        {
            FormUtil.SetFormReadOnly(this, readOnly);
        }

        protected void SetChildrenReadOnly(Control parent, bool readOnly)
        {
            FormUtil.SetChildrenReadOnly(parent, readOnly);
        }

        #region Save data

        protected Result SaveItem(BusinessBase item)
        {
            return this.SaveItem(item, Identity.Token);
        }

        protected Result SaveItem(BusinessBase item, SecurityToken token)
        {
            Cursor.Current = Cursors.WaitCursor;
            Result result = this.SaveItemOffEcho(item, token);
            Cursor.Current = Cursors.Default;

            if (!result.OK)
            {
                this.ShowSaveDataError(result);
            }

            return result;
        }

        protected Result SaveItemOffEcho(BusinessBase item)
        {
            return this.SaveItemOffEcho(item, Identity.Token);
        }

        protected Result SaveItemOffEcho(BusinessBase item, SecurityToken token)
        {
            EntityOperation processor = new EntityOperation(this, token, this.ModifiedBy, this.ModifiedAt);
            return processor.SaveItem(item);
        }

        protected Result SaveList(BusinessCollectionBase list)
        {
            return this.SaveList(list, Identity.Token);
        }

        protected Result SaveList(BusinessCollectionBase list, SecurityToken token)
        {
            Cursor.Current = Cursors.WaitCursor;
            Result result = this.SaveListOffEcho(list, token);
            Cursor.Current = Cursors.Default;

            if (!result.OK)
            {
                this.ShowSaveDataError(result);
            }

            return result;
        }

        protected Result SaveListOffEcho(BusinessCollectionBase list)
        {
            return this.SaveListOffEcho(list, Identity.Token);
        }

        protected Result SaveListOffEcho(BusinessCollectionBase list, SecurityToken token)
        {
            EntityOperation processor = new EntityOperation(this, token, this.ModifiedBy, this.ModifiedAt);
            return processor.SaveList(list);
        }

        protected virtual void ShowSaveDataError(Result result)
        {
            string error;
            if (FormMainBase.Instance != null)
            {
                error = FormMainBase.Instance.GetSaveDataErrorMessage(result);
            }
            else
            {
                error = result.ToString();
            }
              
            this.ShowErrorMessage(error);
        }

        private string ModifiedBy
        {
            get { return this.UserId; }
        }

        private DateTime ModifiedAt
        {
            get
            {
                if (FormMainBase.Instance != null)
                {
                    return FormMainBase.Instance.Now;
                }

                return DateTime.Now;
            }
        }

        #endregion

        #region Wait Dialog

        protected WaitDialogForm CreateWaitDialog(string caption, string title)
        {
            Cursor.Current = Cursors.WaitCursor;
            return new WaitDialogForm(caption, title);
        }

        protected void CloseWaitDialog(WaitDialogForm dlg)
        {
            if (dlg != null)
            {
                dlg.Close();
                dlg.Dispose();
            }

            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region MessageBoxs

        protected void ShowMessage(string info)
        {
            if (string.IsNullOrEmpty(info))
                return;

            MessageBoxUtil.ShowMessage(info, this.Text);
        }

        protected void ShowWarningMessage(string warningMsg)
        {
            if (string.IsNullOrEmpty(warningMsg))
                return;

            MessageBoxUtil.ShowWarningMessage(warningMsg, this.Text);
        }

        protected void ShowErrorMessage(string error)
        {
            if (string.IsNullOrEmpty(error))
                return;

            MessageBoxUtil.ShowErrorMessage(error, this.Text);
        }

        //protected void ShowErrorMessage(Result result)
        //{
        //    this.ShowErrorMessage(result.ToString());
        //}

        protected DialogResult ShowQuestion(string question)
        {
            return MessageBoxUtil.ShowQuestion(question, this.Text);
        }

        protected DialogResult ShowSaveDataWarning()
        {
            return MessageBoxUtil.ShowSaveDataWarning(this.Text);
        }

        protected DialogResult ShowDeleteDataWarning()
        {
            return MessageBoxUtil.ShowDeleteDataWarning(this.Text);
        }

        protected void ShowDeleteDataOKInfo()
        {
            MessageBoxUtil.ShowDeleteDataOKInfo(this.Text);
        }


        protected DialogResult ShowRefreshDataWarning()
        {
            return MessageBoxUtil.ShowRefreshAllWarning(this.Text);
        }

        protected DialogResult ShowCancelDataWarning()
        {
            return MessageBoxUtil.ShowCancelDataWarning(this.Text);
        }

        protected void ShowNoAddNewPrivilegeWarning()
        {
            MessageBoxUtil.ShowNoAddNewPrivilegeWarning(this.Text);
        }

        protected void ShowNoDeletePrivilegeWarning()
        {
            MessageBoxUtil.ShowNoDeletePrivilegeWarning(this.Text);
        }

        protected void ShowNoEditPrivilegeWarning()
        {
            MessageBoxUtil.ShowNoEditPrivilegeWarning(this.Text);
        }

        protected void ShowNoViewPrivilegeWarning()
        {
            MessageBoxUtil.ShowNoViewPrivilegeWarning(this.Text);
        }

        #endregion

        #region ISaveGridViewData Members

        public virtual void SaveGridViewData(GridView view)
        {
            this.SaveList(view.DataSource as BusinessCollectionBase);
        }

        #endregion

        #region IRefreshGridViewData Members

        public virtual void RefrshGridViewData(GridView view)
        {
            MessageBox.Show(UIStringManager.NotImplementedWarning);
        }

        #endregion

        #region ILocalDataProcesser Members

        public void UpdateLocalData(List<BusinessBase> list)
        {
            foreach (BusinessBase entity in list)
            {
                ArrayList forms = new ArrayList(Application.OpenForms);
                foreach (Form item in forms)
                {
                    FormBase frm = item as FormBase;
                    if (frm == null)
                        continue;

                    if (frm == this && !this.IsReplaceSelfData)
                        continue;

                    frm.ReplaceData(entity);
                }
            }
        }

        protected virtual void ReplaceData(BusinessBase entity)
        {
        }

        protected virtual bool IsReplaceSelfData
        {
            get { return false; }
        }

        #endregion
    }
}