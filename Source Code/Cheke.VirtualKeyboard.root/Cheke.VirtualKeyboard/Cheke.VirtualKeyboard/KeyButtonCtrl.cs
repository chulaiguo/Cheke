using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{    
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonCtrl), "Resources.VK_CONTROL.gif")]
    public partial class KeyButtonCtrl : KeyButtonBase
    {
        private bool _isPressed = false;

        public KeyButtonCtrl()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_CONTROL;
        }

        protected override bool IsAnimated
        {
            get { return false; }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            if(this._isPressed)
            {
                Keyboard.ReleaseControlKey(VirtualKeys.VK_CONTROL);

                this.BackColor = SystemColors.AppWorkspace;
                this._isPressed = false;
                base.ZoomIn(3);
            }
            else
            {
                Keyboard.PressControlKey(VirtualKeys.VK_CONTROL);

                this.BackColor = Color.Red;
                this._isPressed = true;
                base.ZoomOut(3);
            }
        }
    }
}