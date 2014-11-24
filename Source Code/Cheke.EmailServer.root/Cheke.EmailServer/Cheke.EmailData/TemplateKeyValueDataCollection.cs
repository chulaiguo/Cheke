using System;
using System.Collections;

namespace Cheke.EmailData
{
    [Serializable]
    public class TemplateKeyValueDataCollection : CollectionBase
    {
        public void Add(TemplateKeyValueData entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, TemplateKeyValueData entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(TemplateKeyValueData entity)
        {
            this.List.Remove(entity);
        }

        public TemplateKeyValueData this[int index]
        {
            get { return (TemplateKeyValueData)base.List[index]; }
            set{{ base.List[index] = value; }}
        }

    }
}