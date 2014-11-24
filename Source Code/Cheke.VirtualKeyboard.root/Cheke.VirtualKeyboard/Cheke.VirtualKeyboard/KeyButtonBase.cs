using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cheke.VirtualKeyboard
{
    [ToolboxItem(false)]
    [DefaultProperty("Image")]
    [DefaultEvent("KeyClick")]
    public partial class KeyButtonBase : UserControl
    {
        public KeyButtonBase()
        {
            InitializeComponent();
        }

        protected PictureBox PictureBox
        {
            get { return this.pictureBox1; }
        }

        protected virtual bool IsAnimated
        {
            get { return true; }
        }

        private void KeyButtonBase_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        protected virtual void Initialize()
        {
            this.TabStop = false;
        }

        protected virtual void KeyPressed(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.KeyPressed(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.IsAnimated)
            {
                this.ZoomOut(3);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsAnimated)
            {
                this.ZoomIn(3);
            }
        }

        protected void ZoomIn(int size)
        {
            this.Width += size*2;
            this.Height += size*2;
            this.Left -= size;
            this.Top -= size;
        }

        protected void ZoomOut(int size)
        {
            this.Width -= size*2;
            this.Height -= size*2;
            this.Left += size;
            this.Top += size;
        }
    }
}