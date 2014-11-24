using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cheke.SNGenerator.Core
{
    internal class Encryption
    {
        private TripleDESCryptoServiceProvider _des = new TripleDESCryptoServiceProvider();
        private UTF8Encoding _utf8 = new UTF8Encoding();

        private byte[] _keyValue = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private byte[] _iVValue = { 8, 7, 6, 5, 4, 3, 2, 1 };

        public byte[] Key
        {
            get { return _keyValue; }
            set { _keyValue = value; }
        }

        public byte[] iV
        {
            get { return _iVValue; }
            set { _iVValue = value; }
        }

        public string GetAuthcode(string text)
        {
            text = this.Encrypt(text);
            if (text.Length < 29)
            {
                text += "C6D54ACB0C9EDCF3GEFKWTZCYWAGWC";
            }

            char[] authCode = new char[29];
            for (int i = 0; i < authCode.Length; i++)
            {
                if ((i + 1) % 5 == 0)
                {
                    authCode[i] = '-';
                    continue;
                }

                char item = text[i];
                if (!char.IsLetterOrDigit(item))
                {
                    authCode[i] = (char)('A' + i);
                }
                else
                {
                    authCode[i] = char.ToUpper(item);
                }
            }

            return new string(authCode);
        }

        public string Encrypt(string text)
        {
            byte[] input = _utf8.GetBytes(text);
            byte[] output = this.Transform(input, _des.CreateEncryptor(this._keyValue, this._iVValue));
            return Convert.ToBase64String(output);
        }

        public string Decrypt(string text)
        {
            byte[] input = Convert.FromBase64String(text);
            byte[] output = this.Transform(input, _des.CreateDecryptor(this._keyValue, this._iVValue));
            return _utf8.GetString(output);
        }

        private byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
        {
            // Create the necessary streams
            MemoryStream memory = new MemoryStream();
            CryptoStream stream = new CryptoStream(memory, cryptoTransform, CryptoStreamMode.Write);

            // Transform the bytes as requesed
            stream.Write(input, 0, input.Length);
            stream.FlushFinalBlock();

            // Read the memory stream and convert it back into byte array
            memory.Position = 0;
            byte[] result = new byte[memory.Length];
            memory.Read(result, 0, result.Length);

            // Clean up
            memory.Close();
            stream.Close();

            // Return result
            return result;
        }

        public static bool IsLicensed(string machineID, string productKey)
        {
            if (machineID.Length == 0 || productKey.Length == 0)
                return false;

            Encryption enc = new Encryption();
            string authcode = enc.GetAuthcode(machineID);
            return productKey == authcode;
        }
    }
}