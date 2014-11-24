using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System;

namespace Cheke.Designer.Controls.Core
{
    public class ControlSerialization
    {
        private const string _HostControl = "HostControl";

        private readonly IDesignerHost _designerHost = null;
        private readonly ICustomizeSerialize _customize = null;

        private readonly Control _container = null;
        private readonly IBindingData _binding = null;
        private readonly object _entity = null;

        public ControlSerialization(Control container, IBindingData binding, object entity)
        {
            this._container = container;
            this._binding = binding;
            this._entity = entity;
        }

        public ControlSerialization(Control container, ICustomizeSerialize customize)
        {
            this._container = container;
            this._customize = customize;
        }

        public ControlSerialization(IDesignerHost designerHost, ICustomizeSerialize customize)
        {
            this._designerHost = designerHost;
            this._container = designerHost.RootComponent as Control;
            this._customize = customize;
        }

        public void SaveToStream(Stream stream)
        {
            Hashtable hashTable = this.Serialize();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, hashTable);
        }

        public void LoadFromStream(Stream stream)
        {
            this._container.Controls.Clear();
            
            BinaryFormatter formatter = new BinaryFormatter();
            Hashtable hashTable = formatter.Deserialize(stream) as Hashtable;
            this.Deserialize(hashTable);
        }

        public void SaveToFile(string fileName)
        {
            using(FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                this.SaveToStream(stream);
            }
        }

        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return;

            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    this.LoadFromStream(stream);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeserializeHostControl(Stream stream, Control hostControl)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Hashtable hashTable = formatter.Deserialize(stream) as Hashtable;
            if (hashTable != null)
            {
                foreach (DictionaryEntry item in hashTable)
                {
                    string[] splits = item.Key.ToString().Split('|');
                    if (splits.Length < 3)
                        continue;

                    //Type type = Type.GetType(splits[1]);
                    //if (type == null)
                    //    continue;

                    if (splits[2] != _HostControl)
                        continue;

                    DeserializeHost(hostControl, item.Value as Hashtable);
                    break;
                }
            }
        }

        private Hashtable Serialize()
        {
            Hashtable hashTable = new Hashtable();

            //Parent
            string key = string.Format("{0}|{1}|{2}", 0, this._container.GetType().AssemblyQualifiedName, _HostControl);
            hashTable.Add(key, SerializeChild(this._container));

            //Children
            int index = -1;
            foreach (Control child in this._container.Controls)
            {
                index++;
                key = string.Format("{0}|{1}|{2}", index, child.GetType().AssemblyQualifiedName, Guid.NewGuid());
                if(this._customize != null)
                {
                    this._customize.PreSerialize(child);
                }
                hashTable.Add(key, SerializeChild(child));
            }

            return hashTable;
        }

        private void Deserialize(Hashtable hashTable)
        {
            SortedList<int, Type> childTypeList = new SortedList<int, Type>();
            SortedList<int, Hashtable> childList = new SortedList<int, Hashtable>();
            foreach (DictionaryEntry item in hashTable)
            {
                string[] splits = item.Key.ToString().Split('|');
                if (splits.Length < 3)
                    continue;

                int index;
                if(!int.TryParse(splits[0], out index))
                    continue;

                if (splits[2] == _HostControl)
                {
                    DeserializeHost(this._container, item.Value as Hashtable);
                }
                else
                {
                    Type type = Type.GetType(splits[1]);
                    if (type != null)
                    {
                        childTypeList.Add(index, type);
                        childList.Add(index, item.Value as Hashtable);
                    }
                }
            }

            this.DeserializeChild(childTypeList, childList);
        }

        private void DeserializeChild(SortedList<int, Type> childTypeList, SortedList<int, Hashtable> childList)
        {
            foreach (KeyValuePair<int, Hashtable> pair in childList)
            {
                if(!childTypeList.ContainsKey(pair.Key))
                    continue;

                Control child;
                if (this._designerHost != null)
                {
                    child = this._designerHost.CreateComponent(childTypeList[pair.Key]) as Control;
                }
                else
                {
                    child = Activator.CreateInstance(childTypeList[pair.Key]) as Control;
                }

                if (child != null)
                {

                    DeserializeChild(child, pair.Value);
                    if (this._customize != null)
                    {
                        this._customize.AfterDeserialize(child);
                    }
                    if (this._binding != null && this._entity != null)
                    {
                        this._binding.Binding(child, this._entity);
                    }
                    this._container.Controls.Add(child);
                }
            }
        }


        private static Hashtable SerializeChild(Control child)
        {
            Hashtable hashTable = new Hashtable();
            PropertyInfo[] properties = child.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach(PropertyInfo item in properties)
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;

                if (item.PropertyType.IsValueType || item.PropertyType == typeof(string)
                    || item.PropertyType == typeof(byte[]) || item.PropertyType == typeof(Font))
                {
                    hashTable.Add(item.Name, item.GetValue(child, null));
                    continue;
                }

                if (item.PropertyType == typeof(Image))
                {
                    Image image = item.GetValue(child, null) as Image;
                    if (image == null)
                        continue;

                    //if (image.Width > child.Width || image.Height > child.Height)
                    //{
                    //    Bitmap bmpIn = new Bitmap(image);
                    //    image = ImageProcessing.Processing.ResizeImage(bmpIn, child.Width, child.Height);
                    //}

                    using(MemoryStream ms =new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] data = ms.GetBuffer();
                        hashTable.Add(item.Name, data);
                    }

                    continue;
                }
            }

            return hashTable;
        }

        private static void DeserializeChild(Control child, Hashtable hashTable)
        {
            PropertyInfo[] properties = child.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo item in properties)
            {
                if (!hashTable.ContainsKey(item.Name))
                    continue;

                if (!item.CanRead || !item.CanWrite)
                    continue;

                object value = hashTable[item.Name];
                if (item.PropertyType == typeof(Image))
                {
                    if(value == null)
                        continue;

                    if (value.GetType() == typeof(byte[]))
                    {
                        byte[] data = value as byte[];
                        if (data == null)
                            continue;

                        MemoryStream stream = new MemoryStream(data);
                        Image image = Image.FromStream(stream);

                        item.SetValue(child, image, null);
                    }
                    else
                    {
                        item.SetValue(child, value, null);
                    }
                }
                else
                {
                    item.SetValue(child, value, null);
                }
            }
        }


        private static void DeserializeHost(Control child, Hashtable hashTable)
        {
            PropertyInfo[] properties = child.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo item in properties)
            {
                if (!hashTable.ContainsKey(item.Name))
                    continue;

                if(!item.CanRead || !item.CanWrite)
                    continue;

                if (item.Name == "BackColor" || item.Name == "BackgroundImage" || item.Name == "BackgroundImageLayout" || item.Name == "LandScape"
                    || item.Name == "Width" || item.Name == "Height")
                {
                    if (item.PropertyType == typeof (Color))
                    {
                        Color color = (Color) hashTable[item.Name];
                        if (color != Color.Transparent)
                        {
                            item.SetValue(child, color, null);
                        }
                    }
                    else
                    {
                        object value = hashTable[item.Name];
                        if (item.PropertyType == typeof(Image))
                        {
                            if (value == null)
                                continue;

                            if (value.GetType() == typeof(byte[]))
                            {
                                byte[] data = value as byte[];
                                if (data == null)
                                    continue;

                                MemoryStream stream = new MemoryStream(data);
                                Image image = Image.FromStream(stream);

                                item.SetValue(child, image, null);
                            }
                            else
                            {
                                item.SetValue(child, value, null);
                            }
                        }
                        else
                        {
                            item.SetValue(child, value, null);
                        }
                    }
                }
            }
        }
    }
}