using System;

namespace AppsStyle.Data
{
    [Serializable]
    public class StyleInfo
    {
        private string _fileName = string.Empty;
        private byte[] _fileData = null;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public byte[] FileData
        {
            get { return _fileData; }
            set { _fileData = value; }
        }
    }
}