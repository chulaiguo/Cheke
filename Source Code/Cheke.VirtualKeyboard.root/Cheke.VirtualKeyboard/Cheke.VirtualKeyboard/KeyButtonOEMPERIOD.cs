using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonOEMPERIOD), "Resources.VK_OEM_PERIOD.gif")]
    public partial class KeyButtonOEMPERIOD : KeyButtonBase
    {
        public KeyButtonOEMPERIOD()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_OEM_PERIOD;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_OEM_PERIOD);
        }
    }
}