using System;
using System.Collections;

namespace AppsUpdate.Data
{
    [Serializable]
    public class UpdateDirectoryCollection : CollectionBase
    {
        public void Add(UpdateDirectory entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, UpdateDirectory entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(UpdateDirectory entity)
        {
            this.List.Remove(entity);
        }

        public void AddRange(UpdateDirectoryCollection list)
        {
            foreach (UpdateDirectory item in list)
            {
                this.List.Add(item);
            }
        }

        public UpdateDirectory this[int index]
        {
            get { return (UpdateDirectory)base.List[index]; }
            set { { base.List[index] = value; } }
        }

        public int GetDownloadFilesCount()
        {
            int total = 0;
            foreach (UpdateDirectory item in base.List)
            {
                total += item.DownloadList.Count;
            }

            return total;
        }
    }
}