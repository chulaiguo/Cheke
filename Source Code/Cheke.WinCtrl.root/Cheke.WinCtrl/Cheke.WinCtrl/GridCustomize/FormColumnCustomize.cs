using System.Collections.Generic;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridCustomize
{
    public partial class FormColumnCustomize : FormMiscBase
    {
        private readonly GridView _view = null;
        private readonly SortedList<string, GridColumn> _columnIndex = new SortedList<string, GridColumn>();

        public FormColumnCustomize()
        {
            InitializeComponent();
        }

        public FormColumnCustomize(GridView view)
        {
            InitializeComponent();

            this._view = view;
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.SetColumns();
            this.SetDataSource();
        }

        private void SetColumns()
        {
            GridColumn colFieldName = new GridColumn();
            colFieldName.Caption = "Field Name";
            colFieldName.FieldName = ColumnCustomizeSchema.FieldName;
            colFieldName.OptionsColumn.AllowEdit = false;
            colFieldName.OptionsColumn.AllowFocus = false;
            colFieldName.VisibleIndex = -1;
            this.gridView1.Columns.Add(colFieldName);

            GridColumn colCaption = new GridColumn();
            colCaption.Caption = "Caption";
            colCaption.FieldName = ColumnCustomizeSchema.Caption;
            colCaption.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colCaption);

            GridColumn colVisible = new GridColumn();
            colVisible.Caption = "Visible";
            colVisible.FieldName = ColumnCustomizeSchema.Visible;
            colVisible.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colVisible);

            GridColumn colReadOnly = new GridColumn();
            colReadOnly.Caption = "ReadOnly";
            colReadOnly.FieldName = ColumnCustomizeSchema.ReadOnly;
            colReadOnly.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colReadOnly);

            GridColumn colSortOrder = new GridColumn();
            colSortOrder.Caption = "SortOrder";
            colSortOrder.FieldName = ColumnCustomizeSchema.SortOrder;
            colSortOrder.ColumnEdit = this.GetSortOrderEditor();
            colSortOrder.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colSortOrder);

            GridColumn colSortMode = new GridColumn();
            colSortMode.Caption = "SortMode";
            colSortMode.FieldName = ColumnCustomizeSchema.SortMode;
            colSortMode.ColumnEdit = this.GetSortModeEditor();
            colSortMode.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colSortMode);

            GridColumn colSortIndex = new GridColumn();
            colSortIndex.Caption = "SortIndex";
            colSortIndex.FieldName = ColumnCustomizeSchema.SortIndex;
            colSortIndex.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colSortIndex);

            GridColumn colToolTip = new GridColumn();
            colToolTip.Caption = "ToolTip";
            colToolTip.FieldName = ColumnCustomizeSchema.ToolTip;
            colToolTip.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colToolTip);

            GridColumn colDisplayFormatType = new GridColumn();
            colDisplayFormatType.Caption = "Display Format Type";
            colDisplayFormatType.FieldName = ColumnCustomizeSchema.DisplayFormatType;
            colDisplayFormatType.ColumnEdit = this.GetFormatTypeEditor();
            colDisplayFormatType.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colDisplayFormatType);

            GridColumn colDisplayFormatString = new GridColumn();
            colDisplayFormatString.Caption = "Display Format String";
            colDisplayFormatString.FieldName = ColumnCustomizeSchema.DisplayFormatString;
            colDisplayFormatString.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colDisplayFormatString);

            GridColumn colHorzAlignment = new GridColumn();
            colHorzAlignment.Caption = "HorzAlignment";
            colHorzAlignment.FieldName = ColumnCustomizeSchema.HorzAlignment;
            colHorzAlignment.ColumnEdit = this.GetHAlignmentEditor();
            colHorzAlignment.VisibleIndex = this.gridView1.Columns.Count;
            this.gridView1.Columns.Add(colHorzAlignment);
        }

        private RepositoryItemComboBox GetFormatTypeEditor()
        {
            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            editor.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.gridControl1.RepositoryItems.Add(editor);
            editor.Items.Add(FormatType.None);
            editor.Items.Add(FormatType.Numeric);
            editor.Items.Add(FormatType.DateTime);

            return editor;
        }

        private RepositoryItemComboBox GetHAlignmentEditor()
        {
            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            editor.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.gridControl1.RepositoryItems.Add(editor);
            editor.Items.Add(HorzAlignment.Default);
            editor.Items.Add(HorzAlignment.Near);
            editor.Items.Add(HorzAlignment.Far);
            editor.Items.Add(HorzAlignment.Center);

            return editor;
        }

        private RepositoryItemComboBox GetSortModeEditor()
        {
            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            editor.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.gridControl1.RepositoryItems.Add(editor);
            editor.Items.Add(ColumnSortMode.Default);
            editor.Items.Add(ColumnSortMode.Value);
            editor.Items.Add(ColumnSortMode.DisplayText);

            return editor;
        }

        private RepositoryItemComboBox GetSortOrderEditor()
        {
            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            editor.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.gridControl1.RepositoryItems.Add(editor);
            editor.Items.Add(ColumnSortOrder.None);
            editor.Items.Add(ColumnSortOrder.Ascending);
            editor.Items.Add(ColumnSortOrder.Descending);

            return editor;
        }

        private void SetDataSource()
        {
            ColumnCustomizeCollection list = new ColumnCustomizeCollection();
            foreach (GridColumn item in this._view.Columns)
            {
                if (!item.OptionsColumn.ShowInCustomizationForm)
                    continue;

                if(!this._columnIndex.ContainsKey(item.FieldName))
                {
                    this._columnIndex.Add(item.FieldName, item);
                }

                ColumnCustomize entity = new ColumnCustomize();
                entity.FieldName = item.FieldName;
                entity.Caption = item.Caption;
                entity.Visible = item.Visible;
                entity.ToolTip = item.ToolTip;
                entity.ReadOnly = !item.OptionsColumn.AllowEdit;
                entity.SortIndex = item.SortIndex;
                entity.SortMode = item.SortMode;
                entity.SortOrder = item.SortOrder;
               
                entity.HorzAlignment = item.AppearanceCell.TextOptions.HAlignment;
                entity.DisplayFormatType = item.DisplayFormat.FormatType;
                entity.DisplayFormatString = item.DisplayFormat.FormatString;

                list.Add(entity);
            }

            this.gridControl1.DataSource = list;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            ColumnCustomizeCollection list = this.gridControl1.DataSource as ColumnCustomizeCollection;
            if(list == null)
                return;

            foreach (ColumnCustomize item in list)
            {
                if(!this._columnIndex.ContainsKey(item.FieldName))
                    continue;

                GridColumn column = this._columnIndex[item.FieldName];
                column.Caption = item.Caption;
                column.ToolTip = item.ToolTip;
                column.Visible = item.Visible;
                column.OptionsColumn.AllowEdit = !item.ReadOnly;
                column.OptionsColumn.AllowFocus = !item.ReadOnly;

                column.SortIndex = item.SortIndex;
                column.SortMode = item.SortMode;
                column.SortOrder = item.SortOrder;

                column.DisplayFormat.FormatType = item.DisplayFormatType;
                column.DisplayFormat.FormatString = item.DisplayFormatString;

                column.AppearanceCell.Options.UseTextOptions = item.HorzAlignment != HorzAlignment.Default;
                column.AppearanceCell.TextOptions.HAlignment = item.HorzAlignment;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}