using System.Threading;
using System.Windows.Forms;
using Cheke.BusinessEntity;

namespace Cheke.WinCtrl.Task
{
    public class TaskBase
    {
        private string _userId = string.Empty;
        private bool _isStopped = false;
        private Result _result = new Result(false);

        public TaskBase(string userId)
        {
            this._userId = userId;
        }

        protected string UserId
        {
            get { return _userId; }
        }

        private bool IsStopped
        {
            get { return _isStopped; }
            set { _isStopped = value; }
        }

        public Result DoTask(string name)
        {
            if(!this.PrepareTask())
                return new Result(false);

            Thread thread = new Thread(WorkThread);
            thread.Start();
            this.ShowStatus(name);

            return this._result;
        }

        private void ShowStatus(string caption)
        {
            FormStatus frmStatus = new FormStatus();
            frmStatus.Show();
            frmStatus.Minimum = 0;
            frmStatus.Maximum = 10;
            frmStatus.ProgressCaption = caption;
            Application.DoEvents();
            while (!this.IsStopped)
            {
                frmStatus.Current++;
                if (frmStatus.Current == frmStatus.Maximum)
                {
                    frmStatus.Current = 0;
                }

                Thread.Sleep(100);
            }
            frmStatus.Close();
        }

        private void WorkThread()
        {
            this._result = this.Task();

            Thread.Sleep(1000);
            this.IsStopped = true;
        }

        protected virtual bool PrepareTask()
        {
            return true;
        }

        protected virtual Result Task()
        {
            return new Result(true);
        }
    }
}