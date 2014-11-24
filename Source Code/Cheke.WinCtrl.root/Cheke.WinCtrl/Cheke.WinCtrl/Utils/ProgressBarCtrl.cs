using System.ComponentModel;
using System.Windows.Forms;

namespace Cheke.WinCtrl.Utils
{
    public delegate void ProgressLoadingStartHandle(object sender, DoWorkEventArgs e);
    public delegate void ProgressLoadingCompletedHandle(object sender, RunWorkerCompletedEventArgs e);

    public partial class ProgressLoadingCtrl : UserControl
    {
        public event ProgressLoadingStartHandle ProgressLoadingStart;
        public event ProgressLoadingCompletedHandle ProgressLoadingCompleted;

        public ProgressLoadingCtrl()
        {
            InitializeComponent();
        }

        public bool PercentView
        {
            get { return this.progressBarControl1.Properties.PercentView; }
            set { this.progressBarControl1.Properties.PercentView = value; }
        }

        public bool ShowTitle
        {
            get { return this.progressBarControl1.Properties.ShowTitle; }
            set { this.progressBarControl1.Properties.ShowTitle = value; }
        }

        public int Minimum
        {
            get { return this.progressBarControl1.Properties.Minimum; }
            set { this.progressBarControl1.Properties.Minimum = value; }
        }

        public int Maximum
        {
            get { return this.progressBarControl1.Properties.Maximum; }
            set { this.progressBarControl1.Properties.Maximum = value; }
        }

        public int Step
        {
            get { return this.progressBarControl1.Properties.Step; }
            set { this.progressBarControl1.Properties.Step = value; }
        }

        public object EditValue
        {
            get { return this.progressBarControl1.EditValue; }
            set { this.progressBarControl1.EditValue = value; }
        }

        public void RunWorkerAsync(object argument)
        {
            this.backgroundWorker1.RunWorkerAsync(argument);
        }

        public void ReportProgress(int percentProgress)
        {
            this.backgroundWorker1.ReportProgress(percentProgress);
        }

        public bool CancellationPending
        {
            get { return this.backgroundWorker1.CancellationPending; }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.ProgressLoadingStart != null)
            {
                this.ProgressLoadingStart(sender, e);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBarControl1.PerformStep();
            this.progressBarControl1.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.ProgressLoadingCompleted != null)
            {
                this.ProgressLoadingCompleted(sender, e);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
        }
    }
}
