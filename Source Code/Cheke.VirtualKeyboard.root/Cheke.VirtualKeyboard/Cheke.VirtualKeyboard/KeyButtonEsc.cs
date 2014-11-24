using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonEsc), "Resources.VK_ESCAPE.gif")]
    public partial class KeyButtonEsc : KeyButtonBase
    {
        public KeyButtonEsc()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_ESCAPE;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_ESCAPE);
        }
    }
}