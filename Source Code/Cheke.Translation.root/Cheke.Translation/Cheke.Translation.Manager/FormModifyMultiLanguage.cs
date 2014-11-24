using System;
using System.Windows.Forms;

namespace Cheke.Translation.Manager
{
    public partial class FormModifyMultiLanguage : Form
    {
        private string _key = string.Empty;
        private string _english = string.Empty;
        private string _other = string.Empty;

        public FormModifyMultiLanguage()
        {
            InitializeComponent();
        }

        public FormModifyMultiLanguage(string key, string english, string other)
        {
            InitializeComponent();

            this._key = key;
            this._english = english;
            this._other = other;
        }

        public string English
        {
            get { return _english; }
        }

        public string Other
        {
            get { return _other; }
        }

        public string Key
        {
            get { return _key; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
                return;

            this.txtKey.Text = this.Key;
            this.txtEnglish.Text = this.English;
            this.txtOther.Text = this.Other;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._key = this.txtKey.Text.Trim();
            if(this._key.Length == 0)
            {
                this.txtKey.Focus();
                return;
            }

            this._english = this.txtEnglish.Text.Trim();
            if (this._english.Length == 0)
            {
                this.txtEnglish.Focus();
                return;
            }

            this._other = this.txtOther.Text.Trim();
            if (this._other.Length == 0)
            {
                this.txtOther.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}