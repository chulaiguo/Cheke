using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl.Wizard
{
    public partial class FormWizardBase : FormBase
    {
        private List<FormWizardPageBase> _pageList = null;
        private FormWizardPageBase _currentPage = null;
        private WizardEntity _entity = null;

        public FormWizardBase()
        {
            InitializeComponent();
        }

        public FormWizardBase(string userId, WizardEntity entity)
            : base(userId)
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
                string key = string.Format("{0}|{1}", this.GetType().Name, this.btnNext.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);
            }
        }

        private void FormWizardBase_Shown(object sender, EventArgs e)
        {
            if (this.CurrentPage == null)
            {
                this.pnlButtons.Enabled = false;
            }
            else
            {
                this.ShowPage(this.CurrentPage);
            }
        }

        private List<FormWizardPageBase> PageList
        {
            get
            {
                if (this._pageList == null)
                {
                    this._pageList = new List<FormWizardPageBase>();
                }

                return this._pageList;
            }
        }

        protected FormWizardPageBase CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        protected WizardEntity Entity
        {
            get { return this._entity; }
        }

        public void AddPage(FormWizardPageBase page)
        {
            page.TopLevel = false;
            page.Parent = this.pnlClient;
            page.Dock = DockStyle.Fill;
            page.Entity = this.Entity;

            this.PageList.Add(page);

            if(page.BackPageType == null)
            {
                this.CurrentPage = page;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.CurrentPage.LeavingPage();

            FormWizardPageBase backPage = this.GetBackPage();
            if (backPage == null)
                return;

            this.ShowPage(backPage);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPage.LeavingPage();
            if (!this.CurrentPage.IsValidPage)
                return;

            FormWizardPageBase nextPage = this.GetNextPage();
            if (nextPage == null)
            {
                this.Finish();
            }
            else
            {
                this.ShowPage(nextPage);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(DialogResult.No == base.ShowQuestion(UIStringManager.CancelWizardWarning))
                return;

            this.Cancel();
        }

        public void GoNext()
        {
            if(!this.btnNext.Enabled)
                return;

            this.btnNext.PerformClick();
        }

        protected virtual void Finish()
        {
            this.CloseWizard();
        }

        protected virtual void Cancel()
        {
            this.CloseWizard();
        }

        protected virtual void ShowingPage()
        {
            
        }

        protected void CloseWizard()
        {
            this.CloseAllPage();
            this.Close();
        }

        #region Helper functions

        private void ShowPage(FormWizardPageBase page)
        {
            this.CurrentPage = page;
            this.ShowingPage();

            this.lblTitle.Text = page.Title;
            this.btnBack.Enabled = page.BackPageType != null;
            this.btnNext.Text = page.NextPageType == null ? UIStringManager.FinishButton_Caption : UIStringManager.NextButton_Caption;

            this.HideAllPage();
            page.Show();
            page.EnteringPage();
        }

        private void HideAllPage()
        {
            foreach (FormWizardPageBase item in this.PageList)
            {
                item.Hide();
            }
        }

        private void CloseAllPage()
        {
            foreach (FormWizardPageBase item in this.PageList)
            {
                item.Close();
                item.Dispose();
            }
        }

        private FormWizardPageBase GetBackPage()
        {
            if (this.CurrentPage.BackPageType == null)
                return null;

            foreach (FormWizardPageBase item in this.PageList)
            {
                if (this.CurrentPage.BackPageType == item.GetType())
                    return item;
            }

            return null;
        }

        private FormWizardPageBase GetNextPage()
        {
            if (this.CurrentPage.NextPageType == null)
                return null;

            foreach (FormWizardPageBase item in this.PageList)
            {
                if (this.CurrentPage.NextPageType == item.GetType())
                    return item;
            }

            return null;
        }

        #endregion
    }
}