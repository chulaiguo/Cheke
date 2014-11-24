using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.StringManager;

namespace Cheke.WinCtrl.Warnings
{
    [ToolboxItem(false)]
    public partial class DirtyDataCtrl : UserControl
    {
        private readonly GridControlDecorator _decorator = null;
        private ArrayList _updateList = null;
        private ArrayList _insertList = null;
        private ArrayList _deletedList = null;

        public DirtyDataCtrl()
        {
            InitializeComponent();
        }

        public DirtyDataCtrl(string message)
        {
            InitializeComponent();

            this.lblMessage.Text = message;
            this.lblMessage.Enabled = false;
        }

        public DirtyDataCtrl(string tableName, GridControlDecorator decorator)
        {
            InitializeComponent();

            this._decorator = decorator;
            this.CreateDirtyListMessage(tableName);
        }

        private void CreateDirtyListMessage(string tableName)
        {
            BusinessCollectionBase dataSource = this._decorator.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return;

            this._insertList = new ArrayList();
            this._updateList = new ArrayList();
            foreach (BusinessBase item in dataSource)
            {
                if (!item.IsSelfDirty)
                    continue;

                if (item.IsNew)
                {
                    this._insertList.Add(item);
                }
                else
                {
                    this._updateList.Add(item);
                }
            }

            this._deletedList = dataSource.GetDeletedList();

            StringBuilder builder = new StringBuilder();
            if (tableName.Length > 0)
            {
                builder.AppendFormat("{0}:", tableName);
            }
            if (this._insertList.Count > 0)
            {
                builder.AppendFormat(UIStringManager.Common_InsertRecords, this._insertList.Count);
            }
            if (this._updateList.Count > 0)
            {
                builder.AppendFormat(UIStringManager.Common_UdapteRecords, this._updateList.Count);
            }
            if (this._deletedList.Count > 0)
            {
                builder.AppendFormat(UIStringManager.Common_DeleteRecords, this._deletedList.Count);
            }

            this.lblMessage.Text = builder.ToString();
        }

        private void lblMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDirtyList dlg = new FormDirtyList(this._decorator, this._updateList, this._insertList, this._deletedList);
            dlg.ShowDialog();
        }
    }
}
