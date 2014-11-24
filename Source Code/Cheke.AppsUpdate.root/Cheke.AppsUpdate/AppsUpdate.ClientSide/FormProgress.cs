using System.Windows.Forms;

namespace AppsUpdate.ClientSide
{
    internal partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();
        }

        public ProgressBar Progress
        {
            get { return this.progressBar1; }
        }

        public Label Title
        {
            get { return this.lblTitle; }
        }
    }
}