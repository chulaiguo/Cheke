using System;
using System.Drawing;
using System.IO;
using Cheke.CardData;

namespace Cheke.ScanShell
{
    public partial class FormScanDLBy2DBarcode : FormScanBase
    {
        public FormScanDLBy2DBarcode()
        {
            InitializeComponent();

            this.ScanType = ScanType.DLByBarcode;
        }

        protected override void UpdateDriverLicenseUI(DriverLicenseData data)
        {
            //Clear Image
            if (this.PictureBox1.Image != null)
            {
                this.PictureBox1.Image.Dispose();
                this.PictureBox1.Image = null;
            }

            //Card data
            if (data != null)
            {
                if (data.FaceImage != null)
                {
                    MemoryStream memory = new MemoryStream(data.FaceImage);
                    this.PictureBox1.Image = Image.FromStream(memory);
                }
                else
                {
                    if (data.RawImage != null)
                    {
                        MemoryStream memory = new MemoryStream(data.RawImage);
                        this.PictureBox1.Image = Image.FromStream(memory);
                    }
                }

                this.txtFirstName.Text = data.NameFirst;
                this.txtLastName.Text = data.NameLast;
            }
            else
            {
                this.txtFirstName.Text = string.Empty;
                this.txtLastName.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.UpdateDriverLicenseUI(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
