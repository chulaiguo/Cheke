using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonOEMCOMMA), "Resources.VK_OEM_COMMA.gif")]
    public partial class KeyButtonOEMCOMMA : KeyButtonBase
    {
        public KeyButtonOEMCOMMA()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_OEM_COMMA;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_OEM_COMMA);
        }
    }
}