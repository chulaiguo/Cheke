using System;
using System.Collections;
using System.Collections.Generic;

namespace Cheke.Designer.Controls.Core
{
    public static class BindingFieldCache
    {
        private readonly static SortedList<string, string> _IndexFieldList = new SortedList<string, string>();
        
        public static void AddFieldList(BindingFieldCollection list)
        {
            foreach (BindingField item in list)
            {
                if (_IndexFieldList.ContainsKey(item.FieldAlias))
                    continue;

                _IndexFieldList.Add(item.FieldAlias, item.FieldName);
            }
        }

        public static string GetFieldNameByAlias(string alias)
        {
            return _IndexFieldList.ContainsKey(alias) ? _IndexFieldList[alias] : string.Empty;
        }
    }

    [Serializable]
    public class BindingField
    {
        private readonly string _fieldName = string.Empty;
        private readonly string _fieldAlias = string.Empty;

        public BindingField(string fieldName, string fieldAlias)
        {
            this._fieldName = fieldName;
            this._fieldAlias = fieldAlias;
        }

        public string FieldName
        {
            get { return _fieldName; }
        }

        public string FieldAlias
        {
            get { return _fieldAlias; }
        }
    }

    [Serializable]
    public class BindingFieldCollection : CollectionBase
    {
        public void Add(BindingField entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, BindingField entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(BindingField entity)
        {
            this.List.Remove(entity);
        }

        public void AddRange(BindingFieldCollection list)
        {
            foreach (BindingField item in list)
            {
                this.List.Add(item);
            }
        }

        public BindingField this[int index]
        {
            get { return (BindingField)base.List[index]; }
            set { { base.List[index] = value; } }
        }
    }
}
