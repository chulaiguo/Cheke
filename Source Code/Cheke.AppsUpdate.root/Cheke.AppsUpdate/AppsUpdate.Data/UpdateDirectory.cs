using System;

namespace AppsUpdate.Data
{
    [Serializable]
    public class UpdateDirectory
    {
        private string _local = string.Empty;
        private string _server = string.Empty;
        private UpdateInfoCollection _downloadList = null;

        public UpdateDirectory(string local, string server)
        {
            this._local = local;
            this._server = server;
            this._downloadList = new UpdateInfoCollection();
        }

        public string Local
        {
            get { return _local; }
        }

        public string Server
        {
            get { return _server; }
        }

        public UpdateInfoCollection DownloadList
        {
            get { return _downloadList; }
        }
    }
}