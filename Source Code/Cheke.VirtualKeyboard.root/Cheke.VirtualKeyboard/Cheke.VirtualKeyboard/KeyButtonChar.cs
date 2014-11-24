using System.ComponentModel;
using Cheke.VirtualKeyboard.Properties;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(true)]
    public partial class KeyButtonChar : KeyButtonBase
    {
        private char _key;

        public KeyButtonChar()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public char Key
        {
            get
            {
                 return this._key;
            }
            set
            {
                 this._key = char.ToUpper(value);

                 switch (this._key)
                 {
                     case 'Q':
                         base.PictureBox.Image = ResourceChar.Q;
                         break;
                     case 'W':
                         base.PictureBox.Image = ResourceChar.W;
                         break;
                     case 'E':
                         base.PictureBox.Image = ResourceChar.E;
                         break;
                     case 'R':
                         base.PictureBox.Image = ResourceChar.R;
                         break;
                     case 'T':
                         base.PictureBox.Image = ResourceChar.T;
                         break;
                     case 'Y':
                         base.PictureBox.Image = ResourceChar.Y;
                         break;
                     case 'U':
                         base.PictureBox.Image = ResourceChar.U;
                         break;
                     case 'I':
                         base.PictureBox.Image = ResourceChar.I;
                         break;
                     case 'O':
                         base.PictureBox.Image = ResourceChar.O;
                         break;
                     case 'P':
                         base.PictureBox.Image = ResourceChar.P;
                         break;
                     case 'A':
                         base.PictureBox.Image = ResourceChar.A;
                         break;
                     case 'S':
                         base.PictureBox.Image = ResourceChar.S;
                         break;
                     case 'D':
                         base.PictureBox.Image = ResourceChar.D;
                         break;
                     case 'F':
                         base.PictureBox.Image = ResourceChar.F;
                         break;
                     case 'G':
                         base.PictureBox.Image = ResourceChar.G;
                         break;
                     case 'H':
                         base.PictureBox.Image = ResourceChar.H;
                         break;
                     case 'J':
                         base.PictureBox.Image = ResourceChar.J;
                         break;
                     case 'K':
                         base.PictureBox.Image = ResourceChar.K;
                         break;
                     case 'L':
                         base.PictureBox.Image = ResourceChar.L;
                         break;
                     case 'Z':
                         base.PictureBox.Image = ResourceChar.Z;
                         break;
                     case 'X':
                         base.PictureBox.Image = ResourceChar.X;
                         break;
                     case 'C':
                         base.PictureBox.Image = ResourceChar.C;
                         break;
                     case 'V':
                         base.PictureBox.Image = ResourceChar.V;
                         break;
                     case 'B':
                         base.PictureBox.Image = ResourceChar.B;
                         break;
                     case 'N':
                         base.PictureBox.Image = ResourceChar.N;
                         break;
                     case 'M':
                         base.PictureBox.Image = ResourceChar.M;
                         break;
                     default:
                         break;
                 }
            }
        }

        protected override void KeyPressed(object sender, System.EventArgs e)
        {
            switch (this.Key)
            {
                case 'Q':
                    Keyboard.SendKey(VirtualKeys.VK_Q);
                    break;
                case 'W':
                    Keyboard.SendKey(VirtualKeys.VK_W);
                    break;
                case 'E':
                    Keyboard.SendKey(VirtualKeys.VK_E);
                    break;
                case 'R':
                    Keyboard.SendKey(VirtualKeys.VK_R);
                    break;
                case 'T':
                    Keyboard.SendKey(VirtualKeys.VK_T);
                    break;
                case 'Y':
                    Keyboard.SendKey(VirtualKeys.VK_Y);
                    break;
                case 'U':
                    Keyboard.SendKey(VirtualKeys.VK_U);
                    break;
                case 'I':
                    Keyboard.SendKey(VirtualKeys.VK_I);
                    break;
                case 'O':
                    Keyboard.SendKey(VirtualKeys.VK_O);
                    break;
                case 'P':
                    Keyboard.SendKey(VirtualKeys.VK_P);
                    break;
                case 'A':
                    Keyboard.SendKey(VirtualKeys.VK_A);
                    break;
                case 'S':
                    Keyboard.SendKey(VirtualKeys.VK_S);
                    break;
                case 'D':
                    Keyboard.SendKey(VirtualKeys.VK_D);
                    break;
                case 'F':
                    Keyboard.SendKey(VirtualKeys.VK_F);
                    break;
                case 'G':
                    Keyboard.SendKey(VirtualKeys.VK_G);
                    break;
                case 'H':
                    Keyboard.SendKey(VirtualKeys.VK_H);
                    break;
                case 'J':
                    Keyboard.SendKey(VirtualKeys.VK_J);
                    break;
                case 'K':
                    Keyboard.SendKey(VirtualKeys.VK_K);
                    break;
                case 'L':
                    Keyboard.SendKey(VirtualKeys.VK_L);
                    break;
                case 'Z':
                    Keyboard.SendKey(VirtualKeys.VK_Z);
                    break;
                case 'X':
                    Keyboard.SendKey(VirtualKeys.VK_X);
                    break;
                case 'C':
                    Keyboard.SendKey(VirtualKeys.VK_C);
                    break;
                case 'V':
                    Keyboard.SendKey(VirtualKeys.VK_V);
                    break;
                case 'B':
                    Keyboard.SendKey(VirtualKeys.VK_B);
                    break;
                case 'N':
                    Keyboard.SendKey(VirtualKeys.VK_N);
                    break;
                case 'M':
                    Keyboard.SendKey(VirtualKeys.VK_M);
                    break;
                default:
                    break;
            }
        }
    }
}