using System.Collections;

namespace Cheke.CardData
{
    public class PersonalIDDataCollection : CollectionBase
    {
        public void Add(PersonalIDData entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, PersonalIDData entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(PersonalIDData entity)
        {
            this.List.Remove(entity);
        }

        public PersonalIDData this[int index]
        {
            get { return (PersonalIDData)base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}
