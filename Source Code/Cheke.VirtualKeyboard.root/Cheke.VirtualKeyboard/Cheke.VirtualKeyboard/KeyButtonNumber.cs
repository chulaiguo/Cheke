using System.ComponentModel;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    public partial class KeyButtonNumber : KeyButtonBase
    {
        private byte _number;

        public KeyButtonNumber()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public byte Number
        {
            get
            {
                 return this._number;
            }
            set
            {
                 this._number = value;

                 switch (this._number)
                 {
                     case 1:
                         base.PictureBox.Image = ResourceNumber.N1;
                         break;
                     case 2:
                         base.PictureBox.Image = ResourceNumber.N2;
                         break;
                     case 3:
                         base.PictureBox.Image = ResourceNumber.N3;
                         break;
                     case 4:
                         base.PictureBox.Image = ResourceNumber.N4;
                         break;
                     case 5:
                         base.PictureBox.Image = ResourceNumber.N5;
                         break;
                     case 6:
                         base.PictureBox.Image = ResourceNumber.N6;
                         break;
                     case 7:
                         base.PictureBox.Image = ResourceNumber.N7;
                         break;
                     case 8:
                         base.PictureBox.Image = ResourceNumber.N8;
                         break;
                     case 9:
                         base.PictureBox.Image = ResourceNumber.N9;
                         break;
                     case 0:
                         base.PictureBox.Image = ResourceNumber.N0;
                         break;
                     default:
                         break;
                 }
            }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            switch (this.Number)
            {
                case 1:
                    Keyboard.SendKey(VirtualKeys.VK_NUM1);
                    break;
                case 2:
                    Keyboard.SendKey(VirtualKeys.VK_NUM2);
                    break;
                case 3:
                    Keyboard.SendKey(VirtualKeys.VK_NUM3);
                    break;
                case 4:
                    Keyboard.SendKey(VirtualKeys.VK_NUM4);
                    break;
                case 5:
                    Keyboard.SendKey(VirtualKeys.VK_NUM5);
                    break;
                case 6:
                    Keyboard.SendKey(VirtualKeys.VK_NUM6);
                    break;
                case 7:
                    Keyboard.SendKey(VirtualKeys.VK_NUM7);
                    break;
                case 8:
                    Keyboard.SendKey(VirtualKeys.VK_NUM8);
                    break;
                case 9:
                    Keyboard.SendKey(VirtualKeys.VK_NUM9);
                    break;
                case 0:
                    Keyboard.SendKey(VirtualKeys.VK_NUM0);
                    break;
                default:
                    break;
            }
        }
    }
}