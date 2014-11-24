using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using Cheke.CardData;

namespace Cheke.IDCheck
{
    public partial class FormDriverLicenses : FormDriverLicensesBase
    {
        public FormDriverLicenses()
        {
            InitializeComponent();
        }

        protected override bool Initialize()
        {
            if (!base.Initialize())
                return false;

            this.SetupCOMPorts();
            return true;
        }

        private void SetupCOMPorts()
        {
            this.cmbCOMPort.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                this.cmbCOMPort.Items.Add(port);
            }

            if (this.cmbCOMPort.Items.Count > 0)
            {
                this.cmbCOMPort.SelectedIndex = this.cmbCOMPort.Items.Count - 1;
            }
        }

        private void cmbCOMPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCOMPort.SelectedIndex > 0)
            {
                base.SetupCOMPorts(this.cmbCOMPort.Text);
            }
        }

        protected override void UpdateUI(DriverLicenseData data)
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
            this.UpdateUI(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
