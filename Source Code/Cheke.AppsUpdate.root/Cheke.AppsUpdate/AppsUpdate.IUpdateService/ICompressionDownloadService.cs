namespace AppsUpdate.IUpdateService
{
    public interface ICompressionDownloadService
    {
        byte[] GetUpdateInfo(string projectName);
        byte[] GetUpdateFile(string projectName, string fileName);
    }  
}
