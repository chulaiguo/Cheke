using System;
using System.Collections;

namespace AppsStyle.Data
{
    [Serializable]
    public class StyleInfoCollection : CollectionBase
    {
        public void Add(StyleInfo entity)
        {
            this.List.Add(entity);
        }

        public StyleInfo this[int index]
        {
            get { return (StyleInfo) base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}