using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonDelete), "Resources.VK_DELETE.gif")]
    public partial class KeyButtonDelete : KeyButtonBase
    {
        public KeyButtonDelete()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_DELETE;
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            Keyboard.SendKey(VirtualKeys.VK_DELETE);
        }
    }
}