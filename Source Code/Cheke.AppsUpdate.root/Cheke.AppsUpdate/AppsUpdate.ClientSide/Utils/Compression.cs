using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppsUpdate.ClientSide.Utils
{
    internal class Compression
    {
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
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }

        private static MemoryStream Decompress(byte[] data)
        {
            MemoryStream destination = new MemoryStream();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                using (GZipStream zip = new GZipStream(stream, CompressionMode.Decompress, true))
                {
                    int num;
                    byte[] buffer = new byte[4096];
                    while ((num = zip.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        destination.Write(buffer, 0, num);
                    }
                }
            }

            destination.Flush();
            return destination;
        }
    }
}
