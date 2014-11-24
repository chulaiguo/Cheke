using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cheke.BusinessEntity;

namespace Cheke.Translation
{
    [Serializable]
    public class MultilingualCollection : CollectionBase
    {
        public Result LoadFromFile(string fileName)
        {
            Result result = new Result(true);
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream stream = new FileStream(fileName, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        MultilingualCollection list = formatter.Deserialize(stream) as MultilingualCollection;
                        if (list != null)
                        {
                            this.AddRange(list);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Add(Guid.NewGuid(), ex);
            }

            return result;
        }

        public Result SaveToFile(string fileName)
        {
            Result result = new Result(true);
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    stream.SetLength(0);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                }
            }
            catch (Exception ex)
            {
                result.Add(Guid.NewGuid(), ex);
            }

            return result;
        }

        public void Add(Multilingual entity)
        {
            this.List.Add(entity);
        }

        public void Remove(Multilingual entity)
        {
            this.List.Remove(entity);
        }

        public void AddRange(MultilingualCollection list)
        {
            foreach (Multilingual item in list)
            {
                this.List.Add(item);
            }
        }

        public Multilingual this[int index]
        {
            get { return (Multilingual) base.List[index]; }
            set { base.List[index] = value; }
        }

        public bool IsDirty
        {
            get
            {
                foreach (Multilingual item in this.List)
                {
                    if (item.IsDirty)
                        return true;
                }

                return false;
            }
        }

        public void AcceptChanges()
        {
            foreach (Multilingual item in this.List)
            {
                item.AcceptChanges();
            }
        }
    }
}