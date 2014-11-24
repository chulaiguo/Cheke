using System.ComponentModel;
using System.Drawing;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{    
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KeyButtonShift), "Resources.VK_SHIFT.gif")]
    public partial class KeyButtonShift : KeyButtonBase
    {
        private bool _isPressed = false;

        public KeyButtonShift()
        {
            InitializeComponent();
        }

        protected override void Initialize()
        {
            base.Initialize();

            base.PictureBox.Image = Resources.VK_SHIFT;
        }

        protected override bool IsAnimated
        {
            get { return false; }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            if(this._isPressed)
            {
                Keyboard.ReleaseControlKey(VirtualKeys.VK_SHIFT);

                this.BackColor = SystemColors.AppWorkspace;
                this._isPressed = false;
                base.ZoomIn(3);
            }
            else
            {
                Keyboard.PressControlKey(VirtualKeys.VK_SHIFT);

                this.BackColor = Color.Red;
                this._isPressed = true;
                base.ZoomOut(3);
            }
        }
    }
}