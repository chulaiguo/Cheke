using AppsUpdate.IUpdateService;
using AppsUpdate.Data;

namespace AppsUpdate.UpdateService
{
    public class DownloadService : ServiceBase, IDownloadService
    {
        public UpdateInfoCollection GetUpdateInfo(string projectName)
        {
           return base.GetUpdateFileList(projectName);
        }

        public virtual byte[] GetUpdateFile(string projectName, string fileName)
        {
            return base.DownloadFile(projectName, fileName);
        }
    }
}
