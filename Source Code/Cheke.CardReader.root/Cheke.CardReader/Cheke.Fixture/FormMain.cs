using System;
using System.Windows.Forms;

namespace Cheke.Fixture
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnTestIDCheck_Click(object sender, EventArgs e)
        {
            Cheke.IDCheck.FormDriverLicenses dlg = new Cheke.IDCheck.FormDriverLicenses();
            dlg.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTestScanShell_Click(object sender, EventArgs e)
        {
            Cheke.ScanShell.FormScanDLByOCR dlg = new Cheke.ScanShell.FormScanDLByOCR();
            dlg.ShowDialog();
        }

        private void btnScanPassPort_Click(object sender, EventArgs e)
        {
            Cheke.ScanShell.FormScanPassport dlg = new Cheke.ScanShell.FormScanPassport();
            dlg.ShowDialog();
        }
    }
}