using System.Windows.Forms;

namespace Cheke.VirtualKeyboard.Fixture
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnVirtualKeyboard_Click(object sender, System.EventArgs e)
        {
            FormVirtualkeyboard dlg = new FormVirtualkeyboard();
            dlg.ShowDialog();
        }

        private void btnNumPad_Click(object sender, System.EventArgs e)
        {
            FormNumPad dlg = new FormNumPad();
            dlg.ShowDialog();
        }
    }
}