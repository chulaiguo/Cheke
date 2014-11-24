using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Cheke.WinCtrl.Common;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormDatatableItem : Form
    {
        private readonly DataRow _row = null;

        public FormDatatableItem()
        {
            InitializeComponent();
        }

        public FormDatatableItem(DataRow row)
        {
            InitializeComponent();

            this._row = row;
        }

        protected override void OnLoad(EventArgs e)
        {
            int totalHeight = 0;
            foreach (DataColumn column in this._row.Table.Columns)
            {
                if (column.DataType == typeof(byte[]))
                {
                    if (column.Caption.ToLower().Contains("photo"))
                    {
                        PictureEditEx picPhoto = new PictureEditEx();
                        picPhoto.Title = column.Caption;
                        picPhoto.EditValue = this._row[column.ColumnName];
                        picPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                        picPhoto.Dock = DockStyle.Top;

                        this.pnlClient.Controls.Add(picPhoto);
                        picPhoto.BringToFront();
                        totalHeight += picPhoto.Height;
                    }

                    continue;
                }

                TextEditEx edit = new TextEditEx();
                edit.Title = column.Caption;
                edit.EditValue = this._row[column.ColumnName];
                edit.Dock = DockStyle.Top;
                this.pnlClient.Controls.Add(edit);
                edit.BringToFront();
                totalHeight += edit.Height;
            }

            int diff = totalHeight - this.pnlClient.Height;
            this.AutoScrollMinSize = new Size(this.AutoScrollMinSize.Width, this.AutoScrollMinSize.Height + diff + 10);

            base.OnLoad(e);
        }
    }
}
