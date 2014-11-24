using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{    
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonCapsLock), "Resources.VK_CAPITAL.gif")]
    public partial class KeyButtonCapsLock : KeyButtonBase
    {
        private bool _isPressed = false;

        public KeyButtonCapsLock()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_CAPITAL;
        }

        protected override bool IsAnimated
        {
            get { return false; }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            if(this._isPressed)
            {
                Keyboard.SendKey(VirtualKeys.VK_CAPITAL);

                this.BackColor = SystemColors.AppWorkspace;
                this._isPressed = false;
                base.ZoomIn(3);
            }
            else
            {
                Keyboard.SendKey(VirtualKeys.VK_CAPITAL);

                this.BackColor = Color.Red;
                this._isPressed = true;
                base.ZoomOut(3);
            }
        }
    }
}