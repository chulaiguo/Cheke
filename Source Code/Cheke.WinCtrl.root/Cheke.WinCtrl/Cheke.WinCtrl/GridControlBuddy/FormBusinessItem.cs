using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.Common;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormBusinessItem : Form
    {
        private readonly BusinessBase _entity = null;

        public FormBusinessItem()
        {
            InitializeComponent();
        }

        public FormBusinessItem(BusinessBase entity)
        {
            InitializeComponent();

            this._entity = entity;
        }

        protected override void OnLoad(EventArgs e)
        {
            int totalHeight = 0;

            PropertyInfo[] list = this._entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo info in list)
            {
                if (info.Name == "BrokenRulesString" || info.Name == "TableName" || info.Name == "PKString"
                    || info.Name == "IsDirty" || info.Name == " IsSelfDirty" || info.Name == "IsNew" 
                    || info.Name == "IsDeleted" || info.Name == " IsLogicDeleted"  || info.Name == " IsValid"
                    || info.Name == "IsActive")
                    continue;

                if(info.PropertyType == typeof(Guid))
                    continue;

                if (info.PropertyType.IsValueType 
                    || info.PropertyType == typeof (string))
                {
                    TextEditEx edit = new TextEditEx();
                    edit.Title = info.Name;
                    edit.EditValue = info.Name;
                    edit.Dock = DockStyle.Top;
                    this.pnlClient.Controls.Add(edit);
                    edit.BringToFront();
                    totalHeight += edit.Height;
                }

                if ( info.PropertyType == typeof(byte[]))
                {
                    if (info.Name.ToLower().Contains("photo"))
                    {
                        PictureEditEx picPhoto = new PictureEditEx();
                        picPhoto.Title = info.Name;
                        picPhoto.EditValue = info.Name;
                        picPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                        picPhoto.Dock = DockStyle.Top;

                        this.pnlClient.Controls.Add(picPhoto);
                        picPhoto.BringToFront();
                        totalHeight += picPhoto.Height;
                    }
                }
            }

            int diff = totalHeight - this.pnlClient.Height;
            this.AutoScrollMinSize = new Size(this.AutoScrollMinSize.Width, this.AutoScrollMinSize.Height + diff + 10);

            base.OnLoad(e);
        }
    }
}
