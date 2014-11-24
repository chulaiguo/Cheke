using System.Collections;

namespace Cheke.CardData
{
    public class OtherDataCollection : CollectionBase
    {
        public void Add(OtherData entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, OtherData entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(OtherData entity)
        {
            this.List.Remove(entity);
        }

        public OtherData this[int index]
        {
            get { return (OtherData)base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}
