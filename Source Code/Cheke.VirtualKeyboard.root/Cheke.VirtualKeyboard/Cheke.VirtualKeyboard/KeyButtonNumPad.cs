using System.ComponentModel;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    public partial class KeyButtonNumPad : KeyButtonBase
    {
        private string _numPad =string.Empty;

        public KeyButtonNumPad()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public string NumPad
        {
            get
            {
                return this._numPad;
            }
            set
            {
                this._numPad = value;

                switch (this._numPad)
                 {
                     case "1":
                         base.PictureBox.Image = ResourceNumPad.NumPad1;
                         break;
                     case "2":
                         base.PictureBox.Image = ResourceNumPad.NumPad2;
                         break;
                     case "3":
                         base.PictureBox.Image = ResourceNumPad.NumPad3;
                         break;
                     case "4":
                         base.PictureBox.Image = ResourceNumPad.NumPad4;
                         break;
                     case "5":
                         base.PictureBox.Image = ResourceNumPad.NumPad5;
                         break;
                     case "6":
                         base.PictureBox.Image = ResourceNumPad.NumPad6;
                         break;
                     case "7":
                         base.PictureBox.Image = ResourceNumPad.NumPad7;
                         break;
                     case "8":
                         base.PictureBox.Image = ResourceNumPad.NumPad8;
                         break;
                     case "9":
                         base.PictureBox.Image = ResourceNumPad.NumPad9;
                         break;
                     case "0":
                         base.PictureBox.Image = ResourceNumPad.NumPad0;
                         break;
                     case ".":
                         base.PictureBox.Image = ResourceNumPad.NumPadDecimal;
                         break;
                     case "+":
                         base.PictureBox.Image = ResourceNumPad.NumPadAdd;
                         break;
                     case "-":
                         base.PictureBox.Image = ResourceNumPad.NumPadSubtract;
                         break;
                     case "*":
                         base.PictureBox.Image = ResourceNumPad.NumPadMultiply;
                         break;
                     case "/":
                         base.PictureBox.Image = ResourceNumPad.NumPadDivide;
                         break;
                     case "Enter":
                         base.PictureBox.Image = ResourceNumPad.NumPadEnter;
                         break;
                     default:
                         break;
                 }
            }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            switch (this.NumPad)
            {
                case "1":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD1);
                    break;
                case "2":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD2);
                    break;
                case "3":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD3);
                    break;
                case "4":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD4);
                    break;
                case "5":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD5);
                    break;
                case "6":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD6);
                    break;
                case "7":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD7);
                    break;
                case "8":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD8);
                    break;
                case "9":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD9);
                    break;
                case "0":
                    Keyboard.SendKey(VirtualKeys.VK_NUMPAD0);
                    break;
                case ".":
                    Keyboard.SendKey(VirtualKeys.VK_DECIMAL);
                    break;
                case "+":
                    Keyboard.SendKey(VirtualKeys.VK_ADD);
                    break;
                case "-":
                    Keyboard.SendKey(VirtualKeys.VK_SUBTRACT);
                    break;
                case "*":
                    Keyboard.SendKey(VirtualKeys.VK_NULTIPLY);
                    break;
                case "/":
                    Keyboard.SendKey(VirtualKeys.VK_DIVIDE);
                    break;
                case "Enter":
                    Keyboard.SendKey(VirtualKeys.VK_SEPARATOR);
                    break;
                default:
                    break;
            }
        }
    }
}