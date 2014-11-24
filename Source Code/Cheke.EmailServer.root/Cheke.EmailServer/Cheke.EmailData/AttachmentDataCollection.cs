using System;
using System.Collections;

namespace Cheke.EmailData
{
    [Serializable]
    public class AttachmentDataCollection : CollectionBase
    {
        public void Add(AttachmentData entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, AttachmentData entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(AttachmentData entity)
        {
            this.List.Remove(entity);
        }

        public AttachmentData this[int index]
        {
            get { return (AttachmentData)base.List[index]; }
            set { { base.List[index] = value; } }
        }
    }
}