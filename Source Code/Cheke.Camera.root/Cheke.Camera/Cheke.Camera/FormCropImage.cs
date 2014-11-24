using System;
using System.Drawing;
using System.Windows.Forms;
using Cheke.ImageProcessing;

namespace Cheke.Camera
{
    public partial class FormCropImage : Form
    {
        private FormSelector _selector = null;
        private Image _srcImage = null;
        private Bitmap _darkImage = null;
        private Image _photo = null;

        private bool _captured = false;
        private int _startX = 0;
        private int _startY = 0;

        public FormCropImage()
        {
            InitializeComponent();
        }

        public FormCropImage(Image srcImage)
        {
            InitializeComponent();

            this._srcImage = srcImage;
        }

        public Image Photo
        {
            get { return _photo; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Cursor = Cursors.WaitCursor;
            this._srcImage = this.ResizeImage(this._srcImage);
            this.CenterSelectedPhoto(this._srcImage);

            this.picSelect.Image = this._srcImage;
            Bitmap bitmap = new Bitmap(this._srcImage);
            this._darkImage = Processing.ColorBalance(bitmap, 0.7F);
            
            this._selector = new FormSelector(this.picSelect);
            this._selector.SrcImage = this._srcImage;
            this._selector.Hide();
            this.Cursor = Cursors.Default;
        }

        private Image ResizeImage(Image image)
        {
            if (image.Width <= this.picSelect.Width && image.Height <= this.picSelect.Height)
            {
                return image;
            }

            Bitmap bmpIn = new Bitmap(image);
            return Processing.ResizeImage(bmpIn, this.picSelect.Width, this.picSelect.Height);
        }

        private void CenterSelectedPhoto(Image image)
        {
            int xPadding = this.picSelect.Width - image.Width;
            if (xPadding > 0)
            {
                this.picSelect.Width = image.Width;
                this.picSelect.Left += xPadding/2;
            }

            int yPadding = this.picSelect.Height - image.Height;
            if (yPadding > 0)
            {
                this.picSelect.Height = image.Height;
                this.picSelect.Top += yPadding/2;
            }
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            this.picSelect.Image = this._selector.GetCropImage();
            this._selector.Hide();
            this.btnCrop.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this._photo = this.picSelect.Image;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void picSelect_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.btnCrop.Enabled)
                return;

            if(e.Button == MouseButtons.Left)
            {
                this._captured = true;
                this._startX = e.X;
                this._startY = e.Y;
            }
        }

        private void picSelect_MouseUp(object sender, MouseEventArgs e)
        {
            this._captured = false;
        }

        private void picSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if(!this._captured || !this.btnCrop.Enabled)
                return;

            if(e.Button == MouseButtons.Left)
            {
                if (this.picSelect.Tag == null)
                {
                    this.picSelect.Image = this._darkImage;
                    this.picSelect.Tag = 1;
                }

                this._selector.Left = e.X >= this._startX ? this._startX : e.X;
                this._selector.Top = e.Y >= this._startY ? this._startY : e.Y;
                this._selector.Width = Math.Abs(e.X - this._startX);
                this._selector.Height = Math.Abs(e.Y - this._startY);
                this._selector.Show();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this._selector != null)
            {
                this._selector.Close();
            }
        }
    }
}