using System;

namespace Cheke.WinCtrl.Wizard
{
    public partial class FormWizardPageBase : FormBase
    {
        private WizardEntity _entity = null;

        public FormWizardPageBase()
        {
            InitializeComponent();
        }

        public FormWizardPageBase(string userId)
            : base(userId)
        {
            InitializeComponent();
        }

        protected internal WizardEntity Entity
        {
            get { return this._entity; }
            set { this._entity = value; }
        }

        public virtual string Title
        {
            get { return this.Text; }
        }

        public virtual Type BackPageType
        {
            get { return null; }
        }

        public virtual Type NextPageType
        {
            get { return null; }
        }

        public virtual bool IsValidPage
        {
            get { return true; }
        }

        public virtual void EnteringPage()
        {
        }

        public virtual void LeavingPage()
        {
        }
    }
}