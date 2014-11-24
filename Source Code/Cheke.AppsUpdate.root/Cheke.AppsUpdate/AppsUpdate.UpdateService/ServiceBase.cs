using System;
using System.Configuration;
using System.IO;
using AppsUpdate.Data;

namespace AppsUpdate.UpdateService
{
    public class ServiceBase : MarshalByRefObject
    {
        protected UpdateInfoCollection GetUpdateFileList(string projectName)
        {
            UpdateInfoCollection list = new UpdateInfoCollection();

            string updatePath = this.GetUpdatePath(projectName);
            if (!Directory.Exists(updatePath))
                return list;

            DirectoryInfo di = new DirectoryInfo(updatePath);
            foreach (FileInfo fi in di.GetFiles())
            {
                if(fi.Name.ToLower() == "cheke.classfactory.dll")
                    continue;

                if (fi.Name.ToLower() == "cheke.configuration.dll")
                    continue;

                if (fi.Name.ToLower() == "thumbs.db")
                    continue;

                UpdateInfo entity = new UpdateInfo();
                entity.FileName = fi.Name;
                entity.LastWriteTime = fi.LastWriteTime.Ticks;
                list.Add(entity);
            }

            return list;
        }


        protected byte[] DownloadFile(string projectName, string fileName)
        {
            string updatePath = this.GetUpdatePath(projectName);
            string filePath = string.Format(@"{0}\{1}", updatePath, fileName);
            if (!File.Exists(filePath))
                return null;

            byte[] array;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                array = new byte[fs.Length];
                fs.Read(array, 0, (int)fs.Length);
            }

            return array;
        }

        private string GetUpdatePath(string projectName)
        {
            string updatePath = ConfigurationManager.AppSettings[projectName];
            if (!string.IsNullOrEmpty(updatePath))
                return updatePath;

            return string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, projectName);
        }
    }
}
