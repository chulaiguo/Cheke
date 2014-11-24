using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using AppsUpdate.Data;
using AppsUpdate.IUpdateService;

namespace AppsUpdate.UpdateService
{
    public class CompressionDownloadService : ServiceBase, ICompressionDownloadService
    {
        public byte[] GetUpdateInfo(string projectName)
        {
            UpdateInfoCollection list = base.GetUpdateFileList(projectName);
            return this.Compress(list);
        }

        public byte[] GetUpdateFile(string projectName, string fileName)
        {
            byte[] buffer = base.DownloadFile(projectName, fileName);
            return this.Compress(buffer);
        }

        private byte[] Compress(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, obj);
                return Compress(stream.ToArray());
            }
        }

        private byte[] Compress(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (GZipStream zip = new GZipStream(stream, CompressionMode.Compress, true))
                {
                    zip.Write(data, 0, data.Length);
                    zip.Close();
                }
                return stream.ToArray();
            }
        }
    }
}
