using System.Collections;

namespace Cheke.UpdateServiceWrapper
{
    internal class UpdateInfoCollection : CollectionBase
    {
        public void Add(UpdateInfo entity)
        {
            this.List.Add(entity);
        }

        public void AddRange(UpdateInfoCollection list)
        {
            foreach (UpdateInfo item in list)
            {
                this.List.Add(item);
            }
        }

        public UpdateInfo this[int index]
        {
            get { return (UpdateInfo) base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}