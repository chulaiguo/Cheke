using System.Windows.Forms;
using MedStab.Manager.SNGenerator.Core;

namespace MedStab.Manager.SNGenerator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void txtMachineID_TextChanged(object sender, System.EventArgs e)
        {
            this.UpdateUI();
        }

        private void txtProductName_TextChanged(object sender, System.EventArgs e)
        {
            this.UpdateUI();
        }

        private void UpdateUI()
        {
            string machineID = this.txtMachineID.Text.Trim();
            string productName = this.txtProductName.Text.Trim();
            this.btnGenerateAuthcode.Enabled = machineID.Length > 0 && productName.Length > 0;
        }

        private void btnGenerateAuthcode_Click(object sender, System.EventArgs e)
        {
            string key = string.Format("{0}|{1}", this.txtMachineID.Text.Trim(), this.txtProductName.Text.Trim().ToUpper());
            this.txtAuthcode.Text = Encryption.GetMD5(key);
        }
    }
}