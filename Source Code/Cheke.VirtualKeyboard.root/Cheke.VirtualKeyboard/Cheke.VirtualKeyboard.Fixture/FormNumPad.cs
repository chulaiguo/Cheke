using System.Windows.Forms;

namespace Cheke.VirtualKeyboard.Fixture
{
    public partial class FormNumPad : Form
    {
        public FormNumPad()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    case Keys.Separator:
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                }
            }
            return false;
        }
    }
}