using System;
using System.Windows.Forms;

namespace Cheke.VirtualKeyboard
{
    public partial class NumPadCtrl : UserControl
    {
        public NumPadCtrl()
        {
            InitializeComponent();
        }

        private void NumPadCtrl_Load(object sender, EventArgs e)
        {
            //use NumLock
            if (!Keyboard.GetState(VirtualKeys.VK_NUMLOCK))
            {
                Keyboard.SendKey(VirtualKeys.VK_NUMLOCK);
            }
        }
    }
}