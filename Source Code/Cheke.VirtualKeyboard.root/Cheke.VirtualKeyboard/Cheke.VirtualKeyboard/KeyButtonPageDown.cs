using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonPageDown), "Resources.VK_NEXT.gif")]
    public partial class KeyButtonPageDown : KeyButtonBase
    {
        public KeyButtonPageDown()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_NEXT;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_NEXT);
        }
    }
}