using System;
using System.Windows.Forms;

namespace Cheke.VirtualKeyboard
{
    public partial class KeyboardCtrl : UserControl
    {
        public KeyboardCtrl()
        {
            InitializeComponent();
        }

        private void KeyboardCtrl_Load(object sender, EventArgs e)
        {
            //don't use NumLock
            if (Keyboard.GetState(VirtualKeys.VK_NUMLOCK))
            {
                Keyboard.SendKey(VirtualKeys.VK_NUMLOCK);
            }
        }
    }
}