using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cheke.ImageProcessing;

namespace Cheke.Camera
{
    public partial class FormSelector : Form
    {
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        private Image _srcImage = null;

        public FormSelector()
        {
            InitializeComponent();
        }

        public FormSelector(Control parent)
        {
            InitializeComponent();

            this.SetParent(parent);
            this.EnableDoubleBuffering();
        }

        public Image SrcImage
        {
            get { return _srcImage; }
            set { _srcImage = value; }
        }

        private void SetParent(Control panel)
        {
            if (this.DesignMode)
                return;

            this.TopLevel = false;
            this.Left = (panel.Width - this.Width)/2;
            this.Top = (panel.Height - this.Height)/2;
            this.Parent = panel;
        }

        private void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint,
                          true);
            this.UpdateStyles();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            if (this.Parent != null)
            {
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.SrcImage != null)
            {
                this.DrawImage(e.Graphics);
            }
            else
            {
                base.OnPaint(e);
            }
        }

        private void DrawImage(Graphics g)
        {
            Rectangle srcRect = this.GetSrcRectangle();
            if (srcRect.IsEmpty)
                return;

            Rectangle dstRect = this.GetDstRectangle();
            if (dstRect.IsEmpty)
                return;

            g.DrawImage(this.SrcImage, dstRect, srcRect, GraphicsUnit.Pixel);
        }

        public Image GetCropImage()
        {
            Rectangle srcRect = this.GetSrcRectangle();
            if (srcRect.IsEmpty)
                return null;

            return Processing.CropImage(new Bitmap(this.SrcImage), srcRect.Left, srcRect.Top, srcRect.Width, srcRect.Height);
        }

        private Rectangle GetSrcRectangle()
        {
            if (this.Left >= this.SrcImage.Width || this.Top >= this.SrcImage.Height)
                return Rectangle.Empty;

            if (this.Left + this.Width <= 0 || this.Top + this.Height <= 0)
                return Rectangle.Empty;

            int left = this.Left + (this.Bounds.Width - this.ClientRectangle.Width)/2;
            int top = this.Top + (this.Bounds.Height - this.ClientRectangle.Height) / 2;
            int width = this.ClientRectangle.Width;
            int height = this.ClientRectangle.Height;
            if (this.Left < 0)
            {
                left = 0;
                width += this.Left;
            }
            else
            {
                if (this.Left + this.Width > this.SrcImage.Width)
                {
                    width = this.SrcImage.Width - this.Left;
                }
            }

            if (this.Top < 0)
            {
                top = 0;
                height += this.Top;
            }
            else
            {
                if (this.Top + this.Height > this.SrcImage.Height)
                {
                    height = this.SrcImage.Height - this.Top;
                }
            }

            return new Rectangle(left, top, width, height);
        }

        private Rectangle GetDstRectangle()
        {
            if (this.Left >= this.SrcImage.Width || this.Top >= this.SrcImage.Height)
                return Rectangle.Empty;

            if (this.Left + this.Width <= 0 || this.Top + this.Height <= 0)
                return Rectangle.Empty;

            int left = 0;
            int top = 0;
            int width = this.ClientRectangle.Width;
            int height = this.ClientRectangle.Height;
            if (this.Left < 0)
            {
                left = -this.Left;
                width -= left;
            }
            else
            {
                if (this.Left + this.Width > this.SrcImage.Width)
                {
                    width = this.SrcImage.Width - this.Left;
                }
            }

            if (this.Top < 0)
            {
                top = -this.Top;
                height -= top;
            }
            else
            {
                if (this.Top + this.Height > this.SrcImage.Height)
                {
                    height = this.SrcImage.Height - this.Top;
                }
            }

            return new Rectangle(left, top, width, height);
        }

        private void FormSelector_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
    }
}