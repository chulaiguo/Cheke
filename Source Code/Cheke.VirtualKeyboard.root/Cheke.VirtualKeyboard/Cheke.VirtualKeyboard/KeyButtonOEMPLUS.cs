using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonOEMPLUS), "Resources.VK_OEM_PLUS.gif")]
    public partial class KeyButtonOEMPLUS : KeyButtonBase
    {
        public KeyButtonOEMPLUS()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_OEM_PLUS;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_OEM_PLUS);
        }
    }
}