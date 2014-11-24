using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl
{
    public partial class FormListDiffBase : FormBase
    {
        private BusinessCollectionBase _originalList = null;
        private BusinessCollectionBase _currentList = null;

        private SortedList<string, BusinessBase> _newIndex = null;
        private SortedList<string, BusinessBase> _deleteIndex = null;
        private SortedList<string, BusinessBase> _dirtyIndex = null;

        private SortedList<string, SortedList<string, object>> _changedValueIndex = null;

        public FormListDiffBase()
        {
            InitializeComponent();
        }

        public FormListDiffBase(string userId)
            : base (userId)
        {
            InitializeComponent();
        }

        protected GridControl GridControl
        {
            get { return this.gridControl1; }
        }

        protected BusinessCollectionBase OriginalList
        {
            get { return _originalList; }
            set { _originalList = value; }
        }   
        
        protected BusinessCollectionBase CurrentList
        {
            get { return _currentList; }
            set { _currentList = value; }
        }

        public SortedList<string, BusinessBase> NewIndex
        {
            get { return _newIndex; }
        }

        public SortedList<string, BusinessBase> DeleteIndex
        {
            get { return _deleteIndex; }
        }

        public SortedList<string, BusinessBase> DirtyIndex
        {
            get { return _dirtyIndex; }
        }

        public SortedList<string, SortedList<string, object>> ChangedValueIndex
        {
            get { return _changedValueIndex; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.GetDifferent();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void DataBinding(bool isRefresh)
        {

        }

        public override void RefrshGridViewData(GridView view)
        {
            this.DataBinding(true);
        }

        protected override void ReplaceData(BusinessBase entity)
        {
            if(this._currentList == null)
                return;

            EntityUtility.ReplaceList(this._currentList, entity);
        }

        private void GetDifferent()
        {
            if(this._currentList == null || this._originalList == null)
                return;

            SortedList<string, BusinessBase> originalIndex = new SortedList<string, BusinessBase>();
            foreach (BusinessBase item in this._originalList)
            {
                if (originalIndex.ContainsKey(item.PKString))
                    continue;
                
                originalIndex.Add(item.PKString, item);
            }

            SortedList<string, BusinessBase> currentIndex = new SortedList<string, BusinessBase>();
            foreach (BusinessBase item in this._currentList)
            {
                if (currentIndex.ContainsKey(item.PKString))
                    continue;

                currentIndex.Add(item.PKString, item);
            }

            this._newIndex = new SortedList<string, BusinessBase>();
            foreach (KeyValuePair<string, BusinessBase> pair in currentIndex)
            {
                if(originalIndex.ContainsKey(pair.Key))
                    continue;

                if (this.NewIndex.ContainsKey(pair.Key))
                    continue;

                this.NewIndex.Add(pair.Key, pair.Value);
            }

            this._deleteIndex = new SortedList<string, BusinessBase>();
            foreach (KeyValuePair<string, BusinessBase> pair in originalIndex)
            {
                if(currentIndex.ContainsKey(pair.Key))
                    continue;

                if(this.DeleteIndex.ContainsKey(pair.Key))
                    continue;
                
                this.DeleteIndex.Add(pair.Key, pair.Value);
            }

            this._dirtyIndex = new SortedList<string, BusinessBase>();
            this._changedValueIndex = new SortedList<string, SortedList<string, object>>();
            foreach (KeyValuePair<string, BusinessBase> pair in originalIndex)
            {
                if (!currentIndex.ContainsKey(pair.Key))
                    continue;

                if (this.DirtyIndex.ContainsKey(pair.Key) || this.ChangedValueIndex.ContainsKey(pair.Key))
                    continue;

                BusinessBase original = pair.Value;
                BusinessBase current = currentIndex[pair.Key];
                SortedList<string, object> diffProperties = this.GetDiffProperties(original, current);
                if(diffProperties == null || diffProperties.Count == 0)
                    continue;

                this.DirtyIndex.Add(current.PKString, current);
                this.ChangedValueIndex.Add(current.PKString, diffProperties);
            }
        }

        private SortedList<string, object> GetDiffProperties(BusinessBase original, BusinessBase current)
        {
            if (original == null || current == null)
                return null;

            if (original.GetType() != current.GetType())
                return null;

            SortedList<string, object> retList = new SortedList<string, object>();
            GetDiffProperties(retList, original.GetType(), original, current);

            return retList;
        }

        private void GetDiffProperties(SortedList<string, object> list, Type type, BusinessBase original, BusinessBase current)
        {
            if (type == typeof(BusinessBase))
                return;

            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(type, false, true);
            foreach (PropertyInfo info in properties)
            {
                if (list.ContainsKey(info.Name))
                    continue;

                if (!info.CanRead || !info.CanWrite)
                    continue;

                if (!info.PropertyType.IsValueType && info.PropertyType != typeof(string))
                    continue;

                object originalValue = info.GetValue(original, null);
                object currentValue = info.GetValue(current, null);
                if (originalValue == null || currentValue == null)
                    continue;

                if (!originalValue.Equals(currentValue))
                {
                    list.Add(info.Name, currentValue);
                    continue;
                }
            }

            GetDiffProperties(list, type.BaseType, original, current);
        }
    }
}