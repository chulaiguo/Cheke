using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonUp), "Resources.VK_UP.gif")]
    public partial class KeyButtonUp : KeyButtonBase
    {
        public KeyButtonUp()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_UP;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_UP);
        }
    }
}