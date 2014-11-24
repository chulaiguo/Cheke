namespace AppsStyle.IStyleService
{
    public interface ICompressionStyleService
    {
        void AddStyleFile(string userId, string projectName, string fileName, byte[] data);
        void DeleteStyleFile(string userId, string projectName, string fileName);

        byte[] GetStyleFiles(string userId, string projectName);
    }
}