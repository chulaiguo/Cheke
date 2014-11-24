using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Decoration;
using DevExpress.XtraTab;

namespace Cheke.WinCtrl.Warnings
{
    [ToolboxItem(false)]
    public partial class DirtyDataCtrlContainer : UserControl
    {
        public DirtyDataCtrlContainer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if(this.Controls.Count > 0)
            {
                this.AutoScrollMinSize = new Size(0, this.Controls.Count * this.Controls[0].Height);
            }
        }

        public void CreateGeneralMessage(string message)
        {
            if (message.Length == 0)
                return;

            DirtyDataCtrl item = new DirtyDataCtrl(message);
            item.Dock = DockStyle.Top;
            this.Controls.Add(item);
            item.BringToFront();
        }

        public void CretaeDirtyListMessage(Form frm)
        {
            SortedList<string, GridControlDecorator> sortedList = new SortedList<string, GridControlDecorator>();
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(frm, false, true);
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
                    continue;

                GridControlDecorator decorator = field.GetValue(frm) as GridControlDecorator;
                if (decorator == null)
                    continue;

                BusinessCollectionBase dataSource = decorator.DataSource as BusinessCollectionBase;
                if (dataSource == null || !dataSource.IsDirty)
                    continue;

                XtraTabPage tabPage = GetParentTabPage(decorator.GridControl);
                string tableName = tabPage != null ? tabPage.Text : string.Empty;
                if(sortedList.ContainsKey(tableName))
                    continue;

                sortedList.Add(tableName, decorator);
            }

            foreach (KeyValuePair<string, GridControlDecorator> pair in sortedList)
            {
                DirtyDataCtrl item = new DirtyDataCtrl(pair.Key, pair.Value);
                item.Dock = DockStyle.Top;
                this.Controls.Add(item);
                item.BringToFront();
            }
        }

        private static XtraTabPage GetParentTabPage(Control current)
        {
            while (current != null)
            {
                if (current is XtraTabPage)
                {
                    return current as XtraTabPage;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}
