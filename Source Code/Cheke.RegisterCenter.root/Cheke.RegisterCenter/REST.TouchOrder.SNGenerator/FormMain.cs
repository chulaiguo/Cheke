using System.Windows.Forms;
using REST.TouchOrder.SNGenerator.Core;

namespace REST.TouchOrder.SNGenerator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if(this.DesignMode)
                return;

            this.cmbStoreType.Items.Add("Fast Food");
            this.cmbStoreType.Items.Add("Dine In");
            this.cmbStoreType.SelectedIndex = 0;
        }

        private void txtMachineName_TextChanged(object sender, System.EventArgs e)
        {
            this.UpdateUI();
        }

        private void txtStoreName_TextChanged(object sender, System.EventArgs e)
        {
            this.UpdateUI();
        }

        private void UpdateUI()
        {
            string machineName = this.txtMachineName.Text.Trim();
            string storeName = this.txtStoreName.Text.Trim();
            if(machineName.Length > 0 && storeName.Length > 0)
            {
                string prefix = this.cmbStoreType.SelectedIndex == 0 ? "F" : "D";
                this.txtKey.Text = string.Format("{0}-{1}-{2}", prefix, machineName, storeName);
            }
            else
            {
                this.txtKey.Text = string.Empty;
            }
        }

        private void txtKey_TextChanged(object sender, System.EventArgs e)
        {
            string key = this.txtKey.Text.Trim();
            this.btnGenerateAuthcode.Enabled = key.Length > 0;
        }

        private void btnGenerateAuthcode_Click(object sender, System.EventArgs e)
        {
            string key = this.txtKey.Text.Trim();
            this.txtAuthcode.Text = Encryption.GetMD5(key);
        }
    }
}