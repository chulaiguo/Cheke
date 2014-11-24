using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cheke.Camera.Fixture
{
    public partial class FormFixture : Form
    {
        public FormFixture()
        {
            InitializeComponent();
        }

        private void btnLoadPicture_Click(object sender, EventArgs e)
        {
            Image pic = this.LoadPicture();
            this.pictureBox1.Image = pic;
        }


        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            Image pic = this.TakePicture();
            this.pictureBox1.Image = pic;
        }

        private Image LoadPicture()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Photo";
            dlg.Filter = "Image File(JPeg, Gif, Bmp, etc.) |*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png|" +
                "Bitmap File(*.bmp)|*.bmp|" +
                "Gif File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "PNG File(*.png)|*.png";

            if (dlg.ShowDialog() != DialogResult.OK)
                return null;

            Image image = Image.FromFile(dlg.FileName);
            FormCropImage cropForm = new FormCropImage(image);
            if (cropForm.ShowDialog() != DialogResult.OK)
                return null;

            return cropForm.Photo;
        }

        private Image TakePicture()
        {
            try
            {
                FormCamera dlgForm = new FormCamera();
                if (dlgForm.ShowDialog() != DialogResult.OK)
                    return null;

                return dlgForm.Photo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}
