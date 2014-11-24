using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;

namespace Cheke.WinCtrl.Storage
{
    public class StyleStorage : IDisposable
    {
        private readonly string _fileName = string.Empty;
        private readonly IsolatedStorageFile _storageFile;

        public StyleStorage(string fileName)
        {
            this._fileName = fileName;
            this._storageFile = IsolatedStorageFile.GetMachineStoreForDomain();
        }

        private string GetDefaultFileName(string userId)
        {
            return string.Format("{0}\\Styles\\default{1}", Application.StartupPath, this._fileName.Substring(userId.Length));
        }

        public void Dispose()
        {
            this._storageFile.Close();
            this._storageFile.Dispose();
        }

        public void DownloadLayout(byte[] data)
        {
            try
            {
                using (FileStream fw = new IsolatedStorageFileStream(this._fileName, FileMode.Create, this._storageFile))
                {
                    fw.Write(data, 0, data.Length);
                    fw.Flush();
                }
            }
            catch
            {
            }
        }

        public bool ApplyDefaultLayout(string userId, GridView gridView)
        {
            try
            {
                //Default style
                string defaultFileName = this.GetDefaultFileName(userId);
                FileInfo defaultFileInfo = new FileInfo(defaultFileName);
                if (defaultFileInfo.Exists)
                {
                    using (FileStream fr = new FileStream(defaultFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        gridView.RestoreLayoutFromStream(fr);
                    }
                }
                else
                {
                    gridView.BestFitColumns();
                }

                //Delete Layout File From Local
                if (this._storageFile.GetFileNames(this._fileName).Length > 0)
                {
                    ClearLocalFile(this._storageFile, this._fileName);
                }

                //Delete Layout File From Server
                if (FormMainBase.Instance != null)
                {
                    FormMainBase.Instance.DeleteLayoutFromServer(this._fileName);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteLayout()
        {
            try
            {
                //Delete Layout File From Local
                if (this._storageFile.GetFileNames(this._fileName).Length > 0)
                {
                    this._storageFile.DeleteFile(this._fileName);
                }

                //Delete Layout File From Server
                if (FormMainBase.Instance != null)
                {
                    FormMainBase.Instance.DeleteLayoutFromServer(this._fileName);
                }
            }
            catch
            {
            }
        }

        public static void ClearLocalFiles(string prefix, string suffix)
        {
            try
            {
                IsolatedStorageFile storageFile = IsolatedStorageFile.GetMachineStoreForDomain();
                string[] files = storageFile.GetFileNames();
                foreach (string item in files)
                {
                    string fileName = item.ToLower();

                    if (!fileName.StartsWith(prefix))
                        continue;

                    if (!fileName.EndsWith(suffix))
                        continue;

                    ClearLocalFile(storageFile, fileName);
                }
            }
            catch
            {
            }
        }

        public static void ClearLocalFile(string fileName)
        {
            try
            {
                IsolatedStorageFile storageFile = IsolatedStorageFile.GetMachineStoreForDomain();
                if (storageFile.GetFileNames(fileName).Length > 0)
                {
                    ClearLocalFile(storageFile, fileName);
                }
            }
            catch
            {
            }
        }

        private static void ClearLocalFile(IsolatedStorageFile storageFile, string fileName)
        {
            try
            {
                using (FileStream fw = new IsolatedStorageFileStream(fileName, FileMode.Create, storageFile))
                {
                    fw.SetLength(0);
                    fw.Flush();
                }
            }
            catch
            {
            }
        }

        public void SaveLayout(string userId, GridView gridView)
        {
            try
            {
                //Save Layout to Local
                using (FileStream fw = new IsolatedStorageFileStream(this._fileName, FileMode.Create, this._storageFile))
                {
                    if (FormMainBase.Instance != null && FormMainBase.Instance.CustomizeGridViewFullLayout)
                    {
                        gridView.SaveLayoutToStream(fw, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                    }
                    else
                    {
                        gridView.SaveLayoutToStream(fw);
                    }

                    fw.Flush();
                }

                //Save Layout File To Server
                if (FormMainBase.Instance != null)
                {
                    byte[] buffer;
                    using (FileStream fr = new IsolatedStorageFileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
                    {
                        buffer = new byte[fr.Length];
                        fr.Read(buffer, 0, buffer.Length);
                    }
                    FormMainBase.Instance.SaveLayoutToServer(this._fileName, buffer);
                }
            }
            catch
            {
            }
        }

        public void SaveLayout(string userId, DockManager dockManager)
        {
            try
            {
                //Save Layout to Local
                using (FileStream fw = new IsolatedStorageFileStream(this._fileName, FileMode.Create, this._storageFile))
                {
                    dockManager.SaveLayoutToStream(fw);
                    fw.Flush();
                }

                //Save Layout File To Server
                if (FormMainBase.Instance != null)
                {
                    byte[] buffer;
                    using (FileStream fr = new IsolatedStorageFileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
                    {
                        buffer = new byte[fr.Length];
                        fr.Read(buffer, 0, buffer.Length);
                    }
                    FormMainBase.Instance.SaveLayoutToServer(this._fileName, buffer);
                }
            }
            catch
            {
            }
        }

        public void RestoreLayout(string userId, GridView gridView)
        {
            try
            {
                //Local
                if (this._storageFile.GetFileNames(this._fileName).Length > 0)
                {
                    using (FileStream fr = new IsolatedStorageFileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
                    {
                        if (fr.Length > 0)
                        {
                            RestoreLayoutFromStream(gridView, fr);
                            return;
                        }
                    }
                }

                //Default
                string defaultFileName = this.GetDefaultFileName(userId);
                FileInfo defaultFileInfo = new FileInfo(defaultFileName);
                if(defaultFileInfo.Exists)
                {
                    using(FileStream fr = new FileStream(defaultFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        RestoreLayoutFromStream(gridView, fr);
                    }
                }
            }
            catch
            {
            }
        }

        public void RestoreLayout(string userId, DockManager dockManager)
        {
            try
            {
                if (this._storageFile.GetFileNames(this._fileName).Length > 0)
                {
                    using (FileStream fr = new IsolatedStorageFileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
                    {
                        if (fr.Length > 0)
                        {
                            dockManager.RestoreLayoutFromStream(fr);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void RestoreLayoutFromStream(GridView gridView, FileStream fr)
        {
            if (FormMainBase.Instance != null && FormMainBase.Instance.CustomizeGridViewFullLayout)
            {
                gridView.RestoreLayoutFromStream(fr, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
            else
            {
                gridView.RestoreLayoutFromStream(fr);
            }
        }

        public object Read()
        {
            try
            {
                return this.ReadObject(this._fileName);
            }
            catch
            {
                return null;
            }
        }

        public void Save(object obj)
        {
            try
            {
                this.SaveObject(obj, this._fileName);
            }
            catch
            {
            }
        }

        private object ReadObject(string fileName)
        {
            if (this._storageFile.GetFileNames(fileName).Length == 0)
                return null;

            object obj;
            using (FileStream fr = new IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = formatter.Deserialize(fr);
            }

            return obj;
        }

        private void SaveObject(object obj, string fileName)
        {
            using (FileStream fw = new IsolatedStorageFileStream(fileName, FileMode.Create, this._storageFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fw, obj);
            }
        }
    }
}
