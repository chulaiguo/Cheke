using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AppsUpdate.Data;

namespace AppsUpdate.ClientSide
{
    internal class AppsUpdateDictoryList
    {
        private readonly bool _showProgress = false;
        private readonly UpdateDirectoryCollection _updateDictoryList = null;

        private FormProgress _progress = null;

        public AppsUpdateDictoryList(UpdateDirectoryCollection updateDictoryList)
        {
            this._updateDictoryList = updateDictoryList;
        }

        public AppsUpdateDictoryList(UpdateDirectoryCollection updateDictoryList, bool showProgress)
        {
            this._showProgress = showProgress;
            this._updateDictoryList = updateDictoryList;
        }

        public bool GetUpdateFiles(List<FileInfo> obsoleteFileList)
        {
            try
            {
                foreach (UpdateDirectory item in this._updateDictoryList)
                {
                    AppsUpdateDictory entity = new AppsUpdateDictory(item);
                    entity.GetUpdateFiles(obsoleteFileList);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        public bool DoUpdate(List<FileInfo> obsoleteFileList)
        {
            if (this._showProgress)
            {
                this._progress = new FormProgress();
            }

            try
            {
                if (this._showProgress)
                {
                    this._progress.Show();
                    this._progress.Progress.Minimum = 0;
                    this._progress.Progress.Maximum = this._updateDictoryList.GetDownloadFilesCount() + 3;
                    this._progress.Progress.Step = 1;
                    this._progress.Progress.Value = 0;
                }

                this.Download();
                this.Backup();
                this.Update();

                this.DeleteObsoleteFiles(obsoleteFileList);
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex.Message);
                return false;
            }
            finally
            {
                if (this._showProgress)
                {
                    this._progress.Close();
                }
            }

            return true;
        }

        private void Download()
        {
            foreach (UpdateDirectory item in this._updateDictoryList)
            {
                AppsUpdateDictory entity = new AppsUpdateDictory(item);
                entity.Download(DwonloadProgresss);
            }
        }

        private void DwonloadProgresss(object sender, EventArgs e)
        {
            if (this._showProgress)
            {
                this._progress.Title.Text = sender as string;
                this._progress.Progress.PerformStep();
                Application.DoEvents();
            }
        }

        private void Backup()
        {
            if (this._showProgress)
            {
                this._progress.Title.Text = "Backup ...";
                this._progress.Progress.PerformStep();
                Application.DoEvents();
            }

            foreach (UpdateDirectory item in this._updateDictoryList)
            {
                AppsUpdateDictory entity = new AppsUpdateDictory(item);
                entity.Backup();
            }
        }

        private void Update()
        {
            if (this._showProgress)
            {
                this._progress.Title.Text = "Update ...";
                this._progress.Progress.PerformStep();
                Application.DoEvents();
            }

            foreach (UpdateDirectory item in this._updateDictoryList)
            {
                AppsUpdateDictory entity = new AppsUpdateDictory(item);
                entity.Update();
            }
        }

        private void DeleteObsoleteFiles(List<FileInfo> obsoleteFileList)
        {
            if (this._showProgress)
            {
                this._progress.Title.Text = "Delete obsolete files ...";
                this._progress.Progress.PerformStep();
                Application.DoEvents();
            }

            foreach (FileInfo fileInfo in obsoleteFileList)
            {
                if (!fileInfo.Exists)
                    continue;

                fileInfo.Delete();
            }
        }

        private void ShowErrorMessage(string error)
        {
            MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}