using System.Drawing;
using System.Windows.Forms;

namespace Cheke.Camera
{
    public partial class FormCapturedPhotos : Form
    {
        public FormCapturedPhotos()
        {
            InitializeComponent();
        }

        public FormCapturedPhotos(Control parent)
        {
            InitializeComponent();

            this.SetParent(parent);
        }

        private void SetParent(Control panel)
        {
            if (this.DesignMode)
                return;

            this.TopLevel = false;
            this.Parent = panel;
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(panel.Width, 0);
        }

        public void AddPhoto(UCPhoto pic)
        {
            pic.Dock = DockStyle.Left;
            //pic.Width = (int)(pic.Height*4/3.0);
            this.Controls.Add(pic);
        }

        public void DeleteAll()
        {
            this.Controls.Clear();
        }
    }
}