using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Cheke.Designer.Controls.Core
{
    public class ControlBindingData
    {
        private Control _container = null;

        public ControlBindingData(Control container)
        {
            this._container = container;
        }

        //public void BindingData(object entity)
        //{
        //    if(entity == null)
        //        return;

        //    PropertyInfo[] properties = entity.GetType().GetProperties();

        //    foreach (Control child in this._container.Controls)
        //    {
        //        switch (child.GetType().Name)
        //        {
        //            case PictureControlSchema.TypeName:
        //                PictureControlBase picCtrl = child as PictureControlBase;
        //                if (picCtrl != null)
        //                {
        //                    PropertyInfo property = this.GetPropertyInfo(properties, picCtrl.FieldName);
        //                    if (property == null)
        //                        continue;

        //                    object propertyValue = property.GetValue(entity, null);
        //                    if (propertyValue == null || propertyValue.GetType() != typeof(byte[]))
        //                        continue;

        //                    MemoryStream stream = new MemoryStream((byte[])propertyValue);
        //                    picCtrl.Picture = Image.FromStream(stream);
        //                }
        //                break;
        //            case TextControlSchema.TypeName:
        //                TextControlBase textCtrl = child as TextControlBase;
        //                if (textCtrl != null)
        //                {
        //                    PropertyInfo property = this.GetPropertyInfo(properties, textCtrl.FieldName);
        //                    if (property == null)
        //                        continue;

        //                    object propertyValue = property.GetValue(entity, null);
        //                    if (propertyValue == null)
        //                        continue;

        //                    textCtrl.Text = propertyValue.ToString();
        //                }
        //                break;
        //            case Barcode39ControlSchema.TypeName:
        //                Barcode39ControlBase barcodeCtrl = child as Barcode39ControlBase;
        //                if (barcodeCtrl != null)
        //                {
        //                    PropertyInfo property = this.GetPropertyInfo(properties, barcodeCtrl.FieldName);
        //                    if (property == null)
        //                        continue;

        //                    object propertyValue = property.GetValue(entity, null);
        //                    if (propertyValue == null)
        //                        continue;

        //                    barcodeCtrl.BarCode = propertyValue.ToString();
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        private PropertyInfo GetPropertyInfo(PropertyInfo[] properties, string propertyName)
        {
            if(string.IsNullOrEmpty(propertyName))
                return null;

            foreach (PropertyInfo item in properties)
            {
                if(item.Name == propertyName)
                    return item;
            }

            return null;
        }
    }
}
