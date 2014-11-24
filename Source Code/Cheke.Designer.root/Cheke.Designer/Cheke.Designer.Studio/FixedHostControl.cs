using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cheke.Designer.Studio
{
    [ToolboxItem(false)]
    public partial class FixedHostControl : UserControl, ICustomTypeDescriptor
    {
        public static int FixedWidth = 300;
        public static int FixedHeight = 400;

        private bool _landScape = false;

        public FixedHostControl()
        {
            InitializeComponent();
        }

        #region Properties
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool LandScape
        {
            get { return _landScape; }
            set
            {
                if (this._landScape != value)
                {
                    this._landScape = value;
                    if ((this._landScape && base.Width < base.Height) || (!this._landScape && base.Width > base.Height))
                    {
                            int switchValue = base.Width;
                            base.Width = base.Height;
                            base.Height = switchValue;

                            FixedWidth = base.Width;
                            FixedHeight = base.Height;
                    }
                }
            }
        }
        #endregion

        #region Implementation of ICustomTypeDescriptor

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection list = new PropertyDescriptorCollection(null);
            foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(this, attributes, true))
            {
                if (item.Name == "BackColor" || item.Name == "BackgroundImage" || item.Name == "BackgroundImageLayout" || item.Name == "LandScape")
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion
    }
}