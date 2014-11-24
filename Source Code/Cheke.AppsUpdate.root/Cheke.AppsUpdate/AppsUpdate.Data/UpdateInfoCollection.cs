using System;
using System.Collections;

namespace AppsUpdate.Data
{
    [Serializable]
    public class UpdateInfoCollection : CollectionBase
    {
        public void Add(UpdateInfo entity)
        {
            this.List.Add(entity);
        }

        public UpdateInfo this[int index]
        {
            get { return (UpdateInfo) base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}