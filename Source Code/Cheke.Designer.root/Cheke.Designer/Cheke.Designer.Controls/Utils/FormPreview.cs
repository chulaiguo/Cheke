using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cheke.Designer.Controls.Core;

namespace Cheke.Designer.Controls.Utils
{
    public partial class FormPreview : Form
    {
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        private readonly byte[] _template = null;
        private readonly bool _maximized = false;

        private readonly IBindingData _binding = null;
        private readonly object _entity = null;

        private bool _enablePrint = false;

        public FormPreview()
        {
            InitializeComponent();
        }

        public FormPreview(byte[] template, IBindingData binding, object entity)
        {
            InitializeComponent();

            this._template = template;
            this._binding = binding;
            this._entity = entity;
        }

        public FormPreview(byte[] template, bool maximized, IBindingData binding, object entity)
        {
            InitializeComponent();

            this._template = template;
            this._maximized = maximized;
            this._binding = binding;
            this._entity = entity;
        }

        public bool EnablePrint
        {
            get { return _enablePrint; }
            set { _enablePrint = value; }
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if(!this.EnablePrint)
            {
                this.btnSave.Enabled = false;
                this.btnPrint.Enabled = false;
                this.btnOption.Enabled = false;
            }

            MemoryStream stream = new MemoryStream(this._template);
            Control hostControl = new Control();
            ControlSerialization.DeserializeHostControl(stream, hostControl);
            this.pnlClient.Width = hostControl.Width;
            this.pnlClient.Height = hostControl.Height;

            stream = new MemoryStream(this._template);
            ControlSerialization serialization = new ControlSerialization(this.pnlTemplate, this._binding, this._entity);
            serialization.LoadFromStream(stream);

            if (this._maximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.MaximizedCenter();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.btnClose.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.NormalCenter();
            }
        }

        private void MaximizedCenter()
        {
            const int padding = 10;
            if (this.pnlClient.Width >= this.Width)
            {
                this.pnlClient.Left = 0;
                this.pnlTemplate.Left = 0;
            }
            else
            {
                int maxXPadding = (this.Width - this.pnlClient.Width)/2;
                if(padding < maxXPadding)
                {
                    this.pnlClient.Left = maxXPadding - padding;
                    this.pnlClient.Width += padding * 2;
                    this.pnlTemplate.Left = padding;
                }
                else
                {
                    this.pnlClient.Left = 0;
                    this.pnlClient.Width = this.Width;
                    this.pnlTemplate.Left = maxXPadding;
                }
            }

            if (this.pnlClient.Height >= (this.Height - this.toolStrip1.Height))
            {
                this.pnlClient.Top = this.toolStrip1.Height;
                this.pnlTemplate.Top = 0;
            }
            else
            {
                int maxYPadding = (this.Height - this.toolStrip1.Height - this.pnlClient.Height)/2;
                if(padding < maxYPadding)
                {
                    this.pnlClient.Top = this.toolStrip1.Height + maxYPadding - padding;
                    this.pnlClient.Height += padding * 2;
                    this.pnlTemplate.Top = padding;
                }
                else
                {
                    this.pnlClient.Top = this.toolStrip1.Height;
                    this.pnlClient.Height = this.Height - this.toolStrip1.Height;
                    this.pnlTemplate.Top = maxYPadding;
                }
            }
        }

        private void NormalCenter()
        {
            const int padding = 20;
            this.Width = this.pnlClient.Width + padding * 4 + SystemInformation.Border3DSize.Width * 2;
            this.Height = this.pnlClient.Height + this.toolStrip1.Height + padding * 4 + SystemInformation.Border3DSize.Height * 2 + SystemInformation.CaptionHeight;

            this.pnlClient.Left = padding;
            this.pnlClient.Top = this.toolStrip1.Height + padding;
            this.pnlClient.Width += padding * 2;
            this.pnlClient.Height += padding * 2;

            this.pnlTemplate.Left = padding;
            this.pnlTemplate.Top = padding;
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            PrintControl print = new PrintControl(this.pnlTemplate);
            print.Print();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            PrintControl print = new PrintControl(this.pnlTemplate);
            Bitmap bmp = print.GetFormImage();

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "Save Image As";
            saveDlg.Filter = "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg"
                             + "|GIF files (*.gif)|*.gif"
                             + "|BMP files (*.bmp)|*.bmp"
                             + "|Tiff files (*.tif;*.tiff)|*.tif;*.tiff"
                             + "|Png files (*.png)|*.png";

            if(saveDlg.ShowDialog() != DialogResult.OK)
                return;

            string fileName = saveDlg.FileName;
            string extension = Path.GetExtension(fileName);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bmp.Save(fileName, ImageFormat.Bmp);
                    break;
                case ".jpg":
                case ".jpeg":
                    bmp.Save(fileName, ImageFormat.Jpeg);
                    break;
                case ".gif":
                    bmp.Save(fileName, ImageFormat.Gif);
                    break;
                case ".tif":
                case ".tiff":
                    bmp.Save(fileName, ImageFormat.Tiff);
                    break;
                case ".png":
                    bmp.Save(fileName, ImageFormat.Png);
                    break;
                default:break;
            }
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            FormUserSetting dlg = new FormUserSetting();
            dlg.ShowDialog();
        }

        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if(this._maximized)
                return;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
    }
}