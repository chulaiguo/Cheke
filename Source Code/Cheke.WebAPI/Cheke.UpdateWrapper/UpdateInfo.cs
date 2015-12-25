namespace Cheke.UpdateWrapper
{
    internal class UpdateInfo
    {
        private readonly string _fileName = string.Empty;
        private readonly long _lastWriteTime = 0;

        public UpdateInfo(string fileName, long lastWriteTime)
        {
            this._fileName = fileName;
            this._lastWriteTime = lastWriteTime;
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public long LastWriteTime
        {
            get { return _lastWriteTime; }
        }
    }
}