using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AppsUpdate.Data;

namespace AppsUpdate.ClientSide
{
    public static class AutoUpdate
    {
        public static int GetUpdateFiles(string projectName, UpdateDirectoryCollection updateDictoryList)
        {
            List<FileInfo> obsoleteFileList = new List<FileInfo>();
            AppsUpdateDictoryList update = new AppsUpdateDictoryList(updateDictoryList);
            if (!update.GetUpdateFiles(obsoleteFileList))
            {
                DialogResult result = ShowUpdateError(projectName);
                return result == DialogResult.Yes ? 0 : -1;
            }

            return updateDictoryList.GetDownloadFilesCount() + obsoleteFileList.Count;
        }

        public static bool Update(string projectName, UpdateDirectoryCollection updateDictoryList)
        {
            return Update(projectName, updateDictoryList, true);
        }

        public static bool Update(string projectName, UpdateDirectoryCollection updateDictoryList, bool showProgress)
        {
            List<FileInfo> obsoleteFileList = new List<FileInfo>();
            AppsUpdateDictoryList update = new AppsUpdateDictoryList(updateDictoryList, showProgress);
            if (!update.GetUpdateFiles(obsoleteFileList))
                return DialogResult.Yes == ShowUpdateError(projectName);

            if (updateDictoryList.GetDownloadFilesCount() > 0 || obsoleteFileList.Count > 0)
            {
                if (!update.DoUpdate(obsoleteFileList))
                {
                    return DialogResult.Yes == ShowUpdateError(projectName);
                }
            }

            return true;
        }

        private static DialogResult ShowUpdateError(string projectName)
        {
            string msg = "Update failed, are you sure to continue?";
            return MessageBox.Show(msg, projectName, MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }
    }
}