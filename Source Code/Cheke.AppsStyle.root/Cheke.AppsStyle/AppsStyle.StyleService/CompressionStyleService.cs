using System.Configuration;
using System.IO;
using AppsStyle.Data;
using AppsStyle.IStyleService;

namespace AppsStyle.StyleService
{
    public class CompressionStyleService : ServiceBase, ICompressionStyleService
    {
        public byte[] GetStyleFiles(string userId, string projectName)
        {
            string rootPath = ConfigurationManager.AppSettings[projectName];
            if (string.IsNullOrEmpty(rootPath))
                return null;

            if (!Directory.Exists(rootPath))
                return null;

            string userPath = string.Format(@"{0}\{1}", rootPath, userId);
            if (!Directory.Exists(userPath))
                return null;

            StyleInfoCollection retList = new StyleInfoCollection();
            string[] files = Directory.GetFiles(userPath);
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
              
                StyleInfo entity = new StyleInfo();
                entity.FileName = info.Name;
                retList.Add(entity);

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    entity.FileData = new byte[fs.Length];
                    fs.Read(entity.FileData, 0, entity.FileData.Length);
                }
            }

            return base.Compress(retList);
        }

        public void AddStyleFile(string userId, string projectName, string fileName, byte[] data)
        {
            if(data == null || data.Length == 0)
                return;

            string rootPath = ConfigurationManager.AppSettings[projectName];
            if (string.IsNullOrEmpty(rootPath))
                return;

            if (!Directory.Exists(rootPath))
                return;

            string userPath = string.Format(@"{0}\{1}", rootPath, userId);
            if (!Directory.Exists(userPath))
            {
                Directory.CreateDirectory(userPath);
            }

            string filePath = string.Format(@"{0}\{1}", userPath, fileName);
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                fs.SetLength(0);
                fs.Write(data, 0, data.Length);
            }
        }

        public void DeleteStyleFile(string userId, string projectName, string fileName)
        {
            string rootPath = ConfigurationManager.AppSettings[projectName];
            if (string.IsNullOrEmpty(rootPath))
                return;

            if (!Directory.Exists(rootPath))
                return;

            string userPath = string.Format(@"{0}\{1}", rootPath, userId);
            if (!Directory.Exists(userPath))
                return;

            string filePath = string.Format(@"{0}\{1}", userPath, fileName);
            if (!File.Exists(filePath))
                return;

            File.Delete(filePath);
        }
    }
}