using System;
using System.Windows.Forms;
using Cheke.WinCtrl.Utils;

namespace Cheke.WinCtrl
{
    public partial class FormMiscBase : Form
    {
        public FormMiscBase()
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
                this.GetTranslateString();
            }
            if (Translation.Translator.Instance.IsTranslate)
            {
                this.TranslateForm();
            }

            this.InitializeForm();
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

        protected void ShowMessage(string message)
        {
            MessageBoxUtil.ShowMessage(message, this.Text);
        }

        protected void ShowWarningMessage(string warning)
        {
            MessageBoxUtil.ShowWarningMessage(warning, this.Text);
        }

        protected void ShowErrorMessage(string error)
        {
            MessageBoxUtil.ShowErrorMessage(error, this.Text);
        }

        protected DialogResult ShowQuestion(string question)
        {
            return MessageBoxUtil.ShowQuestion(question, this.Text);
        }
    }
}