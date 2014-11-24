using System;
using System.Drawing;
using System.Windows.Forms;
using Cheke.ImageProcessing;
using DevExpress.XtraEditors;

namespace Cheke.Camera
{
    public partial class FormCamera : Form
    {
        private FormCapturedPhotos _capturedPhotos = null;
        private Image _photo = null;
        private Camera _camera = null;

        public FormCamera()
        {
            InitializeComponent();
        }

        public Image Photo
        {
            get { return _photo; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Cursor = Cursors.WaitCursor;
            this._camera = new Camera(this.pnlVideo.Handle, 0, 0, this.pnlVideo.Width, this.pnlVideo.Height);
            this._camera.Start();

            this._capturedPhotos = new FormCapturedPhotos(this.pnlCaptuedPhotos);
            this._capturedPhotos.Show();
            this.Cursor = Cursors.Default;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if(this._camera != null)
            {
                this._camera.Stop();
            }

            if (this._capturedPhotos != null)
            {
                this._capturedPhotos.Close();
            }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            Image image = this._camera.GrabImage();
            if(image == null)
                return;

            UCPhoto pic = new UCPhoto(image);
            pic.OnPictureClick += CaptuedPhoto_Click;
            this._capturedPhotos.AddPhoto(pic);
            pic.AdjustWidth();

            if (this.picSelect.Tag == null)
            {
                this.CaptuedPhoto(image);
            }
        }

        private void CaptuedPhoto_Click(object sender, EventArgs e)
        {
            PictureEdit pic = sender as PictureEdit;
            if (pic == null)
                return;

            if (this.picSelect.Tag != null)
            {
                if (DialogResult.Yes != MessageBox.Show("Are you sure you want to discard the changed photo?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    return;
            }

           this.CaptuedPhoto(pic.Image);
        }

        private void CaptuedPhoto(Image image)
        {
            this.picSelect.Image = image;
            this.picSelect.Tag = null;

            this.btnCrop.Enabled = true;
            this.btnOK.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.picSelect.Image == null)
                return;

            this._photo = this.ResizeImage(this.picSelect.Image);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (this.picSelect.Image == null)
                return;

            FormCropImage cropForm = new FormCropImage(this.picSelect.Image);
            if (cropForm.ShowDialog() != DialogResult.OK)
                return;

            this.picSelect.Image = cropForm.Photo;
            this.picSelect.Tag = 1;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            this._capturedPhotos.DeleteAll();
        }

        private Image ResizeImage(Image image)
        {
            if (image.Width <= 320 && image.Height <= 240)
            {
                return image;
            }

            Bitmap bmpIn = new Bitmap(image);
            return Processing.ResizeImage(bmpIn, 320, 240);
        }
    }
}