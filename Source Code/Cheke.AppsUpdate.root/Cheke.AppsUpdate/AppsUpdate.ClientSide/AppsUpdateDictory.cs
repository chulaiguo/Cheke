using System;
using System.Collections.Generic;
using System.IO;
using AppsUpdate.ClientSide.Utils;
using AppsUpdate.Data;
using AppsUpdate.IUpdateService;
using Cheke.ClassFactory;

namespace AppsUpdate.ClientSide
{
    internal class AppsUpdateDictory
    {
        private readonly UpdateDirectory _updateDictory = null;

        public AppsUpdateDictory(UpdateDirectory updateDictory)
        {
            this._updateDictory = updateDictory;
        }

        public void GetUpdateFiles(List<FileInfo> obsoleteFileList)
        {
            byte[] data = this.UpdateService.GetUpdateInfo(this._updateDictory.Server);
            UpdateInfoCollection updateFiles = (UpdateInfoCollection)Compression.DecompressToObject(data);

            foreach (UpdateInfo item in updateFiles)
            {
                //ObsoleteFiles
                if (string.Compare(item.FileName, "ObsoleteFiles.txt", true) == 0)
                {
                    obsoleteFileList.AddRange(this.GetObsoleteFiles(item.FileName));
                    continue;
                }

                string newFilePath = this._updateDictory.Local + "\\" + item.FileName;
                if (!File.Exists(newFilePath))
                {
                    this._updateDictory.DownloadList.Add(item);
                    continue;
                }

                FileInfo fileInfo = new FileInfo(newFilePath);
                if (fileInfo.LastWriteTime.Ticks != item.LastWriteTime)
                {
                    this._updateDictory.DownloadList.Add(item);
                }
            }
        }

        private List<FileInfo> GetObsoleteFiles(string fileName)
        {
            List<FileInfo> retList = new List<FileInfo>();
            byte[] buffer = this.DownloadFile(this._updateDictory.Server, fileName);
            if (buffer == null)
                return retList;

            using (MemoryStream memory = new MemoryStream(buffer))
            {
                using(StreamReader sr = new StreamReader(memory))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        if (line == null || line.Trim().Length == 0)
                            continue;

                        FileInfo info = new FileInfo(string.Format("{0}\\{1}", this._updateDictory.Local, line));
                        if (!info.Exists)
                            continue;
                         
                        retList.Add(info);
                    }
                }
            }

            return retList;
        }

        public void Download(EventHandler reportProgresss)
        {
            if (!Directory.Exists(this._updateDictory.Local))
            {
                Directory.CreateDirectory(this._updateDictory.Local);
            }

            string dirUpdate = string.Format(@"{0}\Update", this._updateDictory.Local);
            if (Directory.Exists(dirUpdate))
            {
                Directory.Delete(dirUpdate, true);
            }
            Directory.CreateDirectory(dirUpdate);

            foreach (UpdateInfo item in this._updateDictory.DownloadList)
            {
                this.DownloadFile(item.FileName, new DateTime(item.LastWriteTime));
                reportProgresss(string.Format("Download {0} ...", item.FileName), new EventArgs());
            }
        }

        private void DownloadFile(string fileName, DateTime lastWriteTime)
        {
            byte[] data = this.DownloadFile(this._updateDictory.Server, fileName);
            if (data == null)
                return;

            if (string.Compare(fileName, "ProductCode.cc", StringComparison.OrdinalIgnoreCase) == 0)
            {
                data = Guid.NewGuid().ToByteArray();
            }

            string filePath = string.Format(@"{0}\Update\{1}", this._updateDictory.Local, fileName);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(data, 0, data.Length);
            }

            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.LastWriteTime = lastWriteTime;
        }

        private byte[] DownloadFile(string dirServer, string fileName)
        {
            byte[] data = this.UpdateService.GetUpdateFile(dirServer, fileName);
            if (data == null)
                return null;

            return Compression.DecompressToByteArray(data);
        }

        public void Backup()
        {
            if (!Directory.Exists(this._updateDictory.Local))
            {
                Directory.CreateDirectory(this._updateDictory.Local);
            }

            string dirBackup = string.Format(@"{0}\Backup", this._updateDictory.Local);
            if (Directory.Exists(dirBackup))
            {
                Directory.Delete(dirBackup, true);
            }
            Directory.CreateDirectory(dirBackup);

            foreach (UpdateInfo item in this._updateDictory.DownloadList)
            {
                string srcFileName = string.Format(@"{0}\{1}", this._updateDictory.Local, item.FileName);
                if (!File.Exists(srcFileName))
                    continue;

                string dstFileName = string.Format(@"{0}\Backup\{1}", this._updateDictory.Local, item.FileName);
                File.Copy(srcFileName, dstFileName);
            }
        }

        public void Update()
        {
            string updatePath = string.Format(@"{0}\Update", this._updateDictory.Local);
            DirectoryInfo dirUpdate = new DirectoryInfo(updatePath);
            foreach (FileInfo fi in dirUpdate.GetFiles())
            {
                string dstFileName = string.Format(@"{0}\{1}", this._updateDictory.Local, fi.Name);
                File.Copy(fi.FullName, dstFileName, true);
            }
        }

        private ICompressionDownloadService UpdateService
        {
            get { return ((ICompressionDownloadService)(ClassBuilder.GetFactory("UpdateServiceFactory"))); }
        }
    }
}