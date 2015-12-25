using System;
using System.Collections;

namespace Cheke.UpdateWrapper
{
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
            get { return (UpdateDirectory) base.List[index]; }
            set { base.List[index] = value; }
        }

        public int GetUpdateFilesCount()
        {
            int retVal = 0;
            foreach (UpdateDirectory item in this.List)
            {
                retVal  += item.GetUpdateFilesCount();
            }

            return retVal;
        }

        public int UpdateFiles()
        {
            int retUpdateFiles = 0;
            foreach (UpdateDirectory item in this.List)
            {
                retUpdateFiles += item.UpdateFiles();
            }

            return retUpdateFiles;
        }

        public int UpdateFiles(EventHandler reportProgresss)
        {
            int retUpdateFiles = 0;
            foreach (UpdateDirectory item in this.List)
            {
                retUpdateFiles += item.UpdateFiles(reportProgresss);
            }

            return retUpdateFiles;
        }
    }
}