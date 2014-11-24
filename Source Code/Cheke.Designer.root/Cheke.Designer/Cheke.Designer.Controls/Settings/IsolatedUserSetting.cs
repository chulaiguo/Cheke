using System.Collections;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cheke.Designer.Controls.Settings
{
    public class IsolatedUserSetting
    {
        private readonly string _fileName;
        private readonly bool _isMachineStore = false;

        public IsolatedUserSetting(string fileName, bool isMachineStore)
        {
            this._fileName = fileName;
            this._isMachineStore = isMachineStore;
        }

        public void SaveSetting(object setting)
        {
            Hashtable table = new Hashtable();
            PropertyInfo[] properties = setting.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;

                object obj = item.GetValue(setting, null);
                if (obj == null)
                    return;

                if (table.ContainsKey(item.Name))
                {
                    table[item.Name] = obj;
                }
                else
                {
                    table.Add(item.Name, obj);
                }
            }


            this.SaveToFile(table);
        }

        public void LoadSetting(object setting)
        {
            Hashtable table = this.LoadFromFile();
            PropertyInfo[] properties = setting.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;

                if (!table.ContainsKey(item.Name))
                    continue;

                item.SetValue(setting, table[item.Name], null);
            }
        }

        private void SaveToFile(Hashtable table)
        {
            IsolatedStorageFile isoFile = this.GetIsolatedStorage();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this._fileName, FileMode.Create, isoFile))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, table);
            }
        }

        private Hashtable LoadFromFile()
        {
            Hashtable table;
            IsolatedStorageFile isoFile = this.GetIsolatedStorage();
            string[] files = isoFile.GetFileNames(this._fileName);
            if (files.Length == 1)
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(this._fileName, FileMode.Open, isoFile))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        table = (Hashtable)formatter.Deserialize(stream);
                    }
                    catch (SerializationException)
                    {
                        table = new Hashtable();
                    }
                }
            }
            else
            {
                table = new Hashtable();
            }
            return table;
        }

        private IsolatedStorageFile GetIsolatedStorage()
        {
            return this._isMachineStore ? IsolatedStorageFile.GetMachineStoreForDomain() : IsolatedStorageFile.GetUserStoreForDomain();
        }
    }
}