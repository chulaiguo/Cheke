using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{    
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonAlt), "Resources.VK_MENU.gif")]
    public partial class KeyButtonAlt : KeyButtonBase
    {
        private bool _isPressed = false;

        public KeyButtonAlt()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_MENU;
        }

        protected override bool IsAnimated
        {
            get { return false; }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            if(this._isPressed)
            {
                Keyboard.ReleaseControlKey(VirtualKeys.VK_MENU);

                this.BackColor = SystemColors.AppWorkspace;
                this._isPressed = false;
                base.ZoomIn(3);
            }
            else
            {
                Keyboard.PressControlKey(VirtualKeys.VK_MENU);

                this.BackColor = Color.Red;
                this._isPressed = true;
                base.ZoomOut(3);
            }
        }
    }
}