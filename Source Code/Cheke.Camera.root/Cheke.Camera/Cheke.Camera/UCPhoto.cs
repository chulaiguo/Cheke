using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace Cheke.Camera
{
    public partial class UCPhoto : UserControl
    {
        public event EventHandler OnPictureClick = null;

        public Image Image
        {
            get { return this.picEdit.Image; }
        }

        public UCPhoto(Image photo)
        {
            InitializeComponent();

            this.picEdit.Properties.ShowMenu = false;
            this.picEdit.Properties.SizeMode = PictureSizeMode.Stretch;
            this.picEdit.Image = photo;
        }

        public void AdjustWidth()
        {
            int imgHeight = this.Height - this.Padding.Top - this.Padding.Bottom;
            int imgWidth = imgHeight * 4 / 3;
            this.Width = imgWidth + this.Padding.Left + this.Padding.Right;
        }

        private void picEdit_Click(object sender, System.EventArgs e)
        {
            if(this.OnPictureClick != null)
            {
                this.OnPictureClick(this.picEdit, EventArgs.Empty);
            }
        }
    }
}