using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cheke.Designer.Studio
{
    [ToolboxItem(false)]
    public partial class HostControl : UserControl, ICustomTypeDescriptor
    {
        public HostControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Category("Size (Inches)")]
        [DisplayName("Width")]
        public float WidthInches
        {
            get { return this.XPixelToInches(this.Width); }
            set { this.Width = this.InchesToXPixel(value); }
        }

        [Browsable(true)]
        [Category("Size (Inches)")]
        [DisplayName("Height")]
        public float HeightInches
        {
            get { return this.YPixelToInches(this.Height); }
            set { this.Height = this.InchesToYPixel(value); }
        }

        private int InchesToXPixel(float inches)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return (int)(inches * g.DpiX);
            }
        }

        private float XPixelToInches(int pixels)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return pixels / g.DpiX;
            }
        }

        private int InchesToYPixel(float inches)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return (int)(inches * g.DpiY);
            }
        }

        private float YPixelToInches(int pixels)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return pixels / g.DpiY;
            }
        } 

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
            return TypeDescriptor.GetDefaultProperty(this, true);
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
            return TypeDescriptor.GetProperties(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection list = new PropertyDescriptorCollection(null);
            foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(this, attributes, true))
            {
                if (item.Name == "WidthInches" || item.Name == "HeightInches" || item.Name == "BackColor" || item.Name == "BackgroundImage" || item.Name == "BackgroundImageLayout")
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