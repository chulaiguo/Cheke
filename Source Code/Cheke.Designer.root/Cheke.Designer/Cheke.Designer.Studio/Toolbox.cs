using System;
using System.Collections;

namespace Cheke.Designer.Studio
{
    public class Toolbox
    {
        private readonly Type _toolType = null;
        private readonly string _displayName = string.Empty;

        public Toolbox(Type toolType, string displayName)
        {
            this._toolType = toolType;
            this._displayName = displayName;
        }

        public Type ToolType
        {
            get { return _toolType; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }
    }

    public class ToolboxCollection : CollectionBase
    {
        public void Add(Toolbox entity)
        {
            this.List.Add(entity);
        }

        public void Insert(int index, Toolbox entity)
        {
            this.List.Insert(index, entity);
        }

        public void Remove(Toolbox entity)
        {
            this.List.Remove(entity);
        }

        public Toolbox this[int index]
        {
            get { return (Toolbox)base.List[index]; }
            set { { base.List[index] = value; } }
        }
    }
}
