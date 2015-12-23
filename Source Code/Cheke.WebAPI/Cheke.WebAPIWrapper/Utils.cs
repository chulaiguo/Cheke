using System;
using System.IO;

namespace Cheke.WebAPIWrapper
{
	internal static class Utils
    {
        internal static Exception DeserializeException(byte[] data)
		{
			return Deserialize(data) as Exception;
		}

        internal static byte[] Serialize(object obj)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(stream, obj);
                data = stream.ToArray();
            }

            return data;
        }

        internal static object Deserialize(byte[] data)
        {
            object result;
            using (MemoryStream stream = new MemoryStream(data))
            {
                result = (new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Deserialize(stream));
            }
            return result;
        }

        internal static byte[] CompressObject(object obj)
        {
            return Compress(Serialize(obj));
        }

        internal static object DecompressObject(byte[] data)
        {
            return Deserialize(Decompress(data));
        }

        internal static byte[] Compress(byte[] data)
        {
            if (data == null || data.Length == 0)
                return data;

            using (MemoryStream stream = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Compress, true))
                {
                    zip.Write(data, 0, data.Length);
                    zip.Close();
                }
                return stream.ToArray();
            }
        }

        internal static byte[] Decompress(byte[] data)
        {
            if (data == null || data.Length == 0)
                return data;

            byte[] result;
            using (MemoryStream stream = new MemoryStream())
            {
                using (MemoryStream buffer = new MemoryStream())
                {
                    buffer.Write(data, 0, data.Length);
                    buffer.Position = 0L;

                    using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(
                        buffer, System.IO.Compression.CompressionMode.Decompress, true))
                    {
                        byte[] array = new byte[4096];
                        int count;
                        while ((count = zip.Read(array, 0, array.Length)) != 0)
                        {
                            stream.Write(array, 0, count);
                        }
                    }
                }

                stream.Flush();
                result = stream.ToArray();
            }

            return result;
        }
    }
}
