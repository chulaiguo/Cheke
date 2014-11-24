using System;

namespace AppsUpdate.Data
{
    [Serializable]
    public class UpdateInfo
    {
        private string _fileName = string.Empty;
        private string _fileVersion = string.Empty;
        private long _lastWriteTime = 0;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string FileVersion
        {
            get { return _fileVersion; }
            set { _fileVersion = value; }
        }

        public long LastWriteTime
        {
            get { return _lastWriteTime; }
            set { _lastWriteTime = value; }
        }
    }
}