using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace AppsStyle.StyleService
{
    public class ServiceBase : MarshalByRefObject
    {
        protected byte[] Compress(object obj)
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