using System.Collections;

namespace Cheke.WinCtrl.GridCustomize
{
    internal class ColumnCustomizeCollection : CollectionBase
    {
        public void Add(ColumnCustomize entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, ColumnCustomize entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(ColumnCustomize entity)
        {
            this.List.Remove(entity);
        }

        public ColumnCustomize this[int index]
        {
            get { return (ColumnCustomize)base.List[index]; }
            set { base.List[index] = value; }
        }
    }
}
