using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cheke.WinCtrl.Storage
{
    internal class MachineStorage
    {
        private readonly string _fileName;
        private readonly IsolatedStorageFile _storageFile;

        public MachineStorage(string fileName)
        {
            this._fileName = fileName;
            this._storageFile = IsolatedStorageFile.GetMachineStoreForDomain();
        }

        public object ReadObject()
        {
            if (this._storageFile.GetFileNames(this._fileName).Length == 0)
                return null;

            object obj;
            using (FileStream fr = new IsolatedStorageFileStream(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read, this._storageFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = formatter.Deserialize(fr);
            }

            return obj;
        }

        public void SaveObject(object obj)
        {
            using (FileStream fw = new IsolatedStorageFileStream(this._fileName, FileMode.Create, this._storageFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fw, obj);
            }
        }
    }
}