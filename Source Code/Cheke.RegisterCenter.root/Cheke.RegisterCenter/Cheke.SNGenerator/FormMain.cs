using System.Windows.Forms;
using Cheke.SNGenerator.Core;

namespace Cheke.SNGenerator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void txtMachineID_TextChanged(object sender, System.EventArgs e)
        {
            this.btnGenerateAuthcode.Enabled = this.txtMachineID.Text.Trim().Length > 0;
        }

        private void btnGenerateAuthcode_Click(object sender, System.EventArgs e)
        {
            Encryption enc = new Encryption();
            this.txtAuthcode.Text = enc.GetAuthcode(this.txtMachineID.Text.Trim());

            Clipboard.SetData(DataFormats.Text, this.txtAuthcode.Text);
        }
    }
}