using System.Windows.Forms;

namespace Cheke.WinCtrl
{
    public partial class FormStatus : Form
    {
        public FormStatus()
        {
            InitializeComponent();
        }

        public int Maximum
        {
            get { return this.progressBar1.Maximum; }
            set { this.progressBar1.Maximum = value; }
        }

        public int Minimum
        {
            get { return this.progressBar1.Minimum; }
            set { this.progressBar1.Minimum = value; }
        }

        public int Current
        {
            get { return this.progressBar1.Value; }
            set { this.progressBar1.Value = value; }
        }

        public string ProgressCaption
        {
            get { return this.lblProgress.Text; }
            set { this.lblProgress.Text = value; }
        }
    }
}