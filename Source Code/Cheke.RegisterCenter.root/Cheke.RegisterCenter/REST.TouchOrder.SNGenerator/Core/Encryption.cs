using System;
using System.Security.Cryptography;
using System.Text;

namespace REST.TouchOrder.SNGenerator.Core
{
    internal static class Encryption
    {
        public static string GetMD5(string text)
        {
            text = string.Format("{0}@ChekeIT#REST", text.Replace("-", "%"));
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(UTF8Encoding.Default.GetBytes(text));
            string cryptText = BitConverter.ToString(data);
            return cryptText.Replace("-", "");
        }
    }
}