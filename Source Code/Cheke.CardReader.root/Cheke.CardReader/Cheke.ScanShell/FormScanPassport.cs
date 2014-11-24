using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cheke.CardData;

namespace Cheke.ScanShell
{
    public partial class FormScanPassport : FormScanBase
    {
        public FormScanPassport()
        {
            InitializeComponent();
        }

        protected override void UpdatePassportUI(PassportData data)
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
                if (data.RawImage != null)
                {
                    MemoryStream memory = new MemoryStream(data.RawImage);
                    this.PictureBox1.Image = Image.FromStream(memory);
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
            this.UpdatePassportUI(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.UnLoadSdk();
            this.Cursor = Cursors.Default;

            this.Close();
        }
    }
}
