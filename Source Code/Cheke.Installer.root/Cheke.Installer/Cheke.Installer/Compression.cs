using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cheke.Installer
{
    public static class Compression
    {
        private static MemoryStream Decompress(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Position = 0L;
                using (GZipStream zipStream = new GZipStream(memoryStream, CompressionMode.Decompress, true))
                {
                    int num;
                    byte[] buffer = new byte[0x1000];
                    while ((num = zipStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        stream.Write(buffer, 0, num);
                    }
                }
            }
            stream.Flush();
            return stream;
        }

        public static byte[] DecompressToByteArray(byte[] data)
        {
            using (MemoryStream stream = Decompress(data))
            {
                return stream.ToArray();
            }
        }

        public static object DecompressToObject(byte[] data)
        {
            using (MemoryStream stream = Decompress(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stream.Position = 0L;
                return formatter.Deserialize(stream);
            }
        }
    }
}
