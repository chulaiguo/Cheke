using System;
using System.IO;

namespace Cheke.UpdateServiceWrapper
{
    public class UpdateDirectory
    {
        private readonly string _local = string.Empty;
        private readonly string _server = string.Empty;

        private UpdateInfoCollection _downloadList = null;

        public UpdateDirectory(string local, string server)
        {
            this._local = local;
            this._server = server;
        }

        public string Local
        {
            get { return _local; }
        }

        public string Server
        {
            get { return _server; }
        }

        public int GetUpdateFilesCount()
        {
            if (this._downloadList == null)
            {
                this._downloadList = this.GetUpdateFiles();
            }

            return this._downloadList.Count;
        }

        public int UpdateFiles()
        {
            return UpdateFiles(null);
        }

        public int UpdateFiles(EventHandler reportProgresss)
        {
            if (this._downloadList == null)
            {
                this._downloadList = this.GetUpdateFiles();
            }

            if (this._downloadList.Count > 0)
            {
                this.UpdateFiles(this._downloadList, reportProgresss);
            }

            return this._downloadList.Count;
        }

        private UpdateInfoCollection GetUpdateFiles()
        {
            UpdateInfoCollection retList = new UpdateInfoCollection();

            string[] list = UpdateWrapper.GetUpdateInfo(this.Server);
            if (list != null)
            {
                foreach (string item in list)
                {
                    if (string.IsNullOrEmpty(item))
                        continue;

                    string[] splits = item.Split(':');
                    if (splits.Length < 2)
                        continue;

                    string fileName = splits[0];
                    long lastWriteTime;
                    if (!long.TryParse(splits[1], out lastWriteTime))
                        continue;

                    string localFileName = this.Local + "\\" + fileName;
                    FileInfo local = new FileInfo(localFileName);
                    if (local.Exists && local.LastWriteTime.Ticks == lastWriteTime)
                        continue;

                    retList.Add(new UpdateInfo(fileName, lastWriteTime));
                }
            }

            return retList;
        }

        private void UpdateFiles(UpdateInfoCollection list, EventHandler reportProgresss)
        {
            if (!Directory.Exists(this.Local))
            {
                Directory.CreateDirectory(this.Local);
            }

            foreach (UpdateInfo item in list)
            {
                string localFileName = this.Local + "\\" + item.FileName;

                byte[] buffer;
                if (string.Compare(item.FileName, "ProductCode.cc", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    buffer = Guid.NewGuid().ToByteArray();
                }
                else
                {
                    buffer = UpdateWrapper.GetUpdateFile(this.Server, item.FileName);
                }

                if (buffer != null)
                {
                    using (FileStream stream = new FileStream(localFileName, FileMode.Create))
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }

                    FileInfo info = new FileInfo(localFileName);
                    info.LastWriteTime = new DateTime(item.LastWriteTime);

                    if (reportProgresss != null)
                    {
                        reportProgresss(item.FileName, new EventArgs());
                    }
                }
            }
        }
    }
}