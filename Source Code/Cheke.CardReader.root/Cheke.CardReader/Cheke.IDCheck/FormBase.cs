using System;
using System.Windows.Forms;
using Cheke.CardData;

namespace Cheke.IDCheck
{
    public delegate void ProcessDriverLicensesHandler(DriverLicenseData data);

    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        public FormBase(Control parent)
        {
            this.InitializeComponent();

            this.SetParent(parent);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(this.DesignMode)
                return;

            this.Initialize();
        }

        protected virtual bool Initialize()
        {
            return true;
        }

        private void SetParent(Control panel)
        {
            if (this.DesignMode)
                return;

            if (panel == null)
            {
                this.TopLevel = true;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.TopLevel = false;
                this.Parent = panel;
                this.Dock = DockStyle.Fill;
            }
        }

        protected void ShowErrorMessage(string error)
        {
            MessageBox.Show(error, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
