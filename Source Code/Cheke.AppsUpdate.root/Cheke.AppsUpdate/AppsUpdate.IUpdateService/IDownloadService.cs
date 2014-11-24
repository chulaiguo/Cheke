using AppsUpdate.Data;

namespace AppsUpdate.IUpdateService
{
    public interface IDownloadService
    {
        UpdateInfoCollection GetUpdateInfo(string projectName);
        byte[] GetUpdateFile(string projectName, string fileName);
    }
}
