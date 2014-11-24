using System;
using System.Windows.Forms;
using Cheke.WinCtrl.StringManager;
using DevExpress.XtraEditors;

namespace Cheke.WinCtrl
{
    public partial class FormPickupBase : FormMiscBase
    {
        public FormPickupBase()
        {
            InitializeComponent();
        }

        protected bool CanPickup
        {
            get { return this.btnOK.Enabled; }
            set { this.btnOK.Enabled = value; }
        }

        protected CheckedListBoxControl ListBox
        {
            get { return this.listBox; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Pickup();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        protected virtual void Pickup()
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        protected void CheckedAll()
        {
            int i = 0;
            while (this.listBox.GetItem(i) != null)
            {
                this.listBox.SetItemCheckState(i, CheckState.Checked);
                i++;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            while (this.listBox.GetItem(i) != null)
            {
                this.listBox.SetItemCheckState(i, this.chkSelectAll.CheckState);
                i++;
            }
        }
    }
}