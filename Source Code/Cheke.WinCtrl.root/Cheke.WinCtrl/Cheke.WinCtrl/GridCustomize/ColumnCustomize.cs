using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;

namespace Cheke.WinCtrl.GridCustomize
{
    internal class ColumnCustomize
    {
        private string _fieldName = string.Empty;
        private string _caption = string.Empty;
        private bool _visible = false;
        private string _toolTip = string.Empty;
        private bool _readOnly = false;

        private int _sortIndex = 0;
        private ColumnSortMode _sortMode = ColumnSortMode.Default;
        private  ColumnSortOrder _sortOrder = ColumnSortOrder.None;

        private FormatType _displayFormatType = FormatType.None;
        private string _displayFormatString = string.Empty;
        private HorzAlignment _horzAlignment = HorzAlignment.Default;

        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public string ToolTip
        {
            get { return _toolTip; }
            set { _toolTip = value; }
        }

        public FormatType DisplayFormatType
        {
            get { return _displayFormatType; }
            set { _displayFormatType = value; }
        }

        public string DisplayFormatString
        {
            get { return _displayFormatString; }
            set { _displayFormatString = value; }
        }

        public HorzAlignment HorzAlignment
        {
            get { return _horzAlignment; }
            set { _horzAlignment = value; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        public int SortIndex
        {
            get { return _sortIndex; }
            set { _sortIndex = value; }
        }

        public ColumnSortMode SortMode
        {
            get { return _sortMode; }
            set { _sortMode = value; }
        }

        public ColumnSortOrder SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }
    }
}
