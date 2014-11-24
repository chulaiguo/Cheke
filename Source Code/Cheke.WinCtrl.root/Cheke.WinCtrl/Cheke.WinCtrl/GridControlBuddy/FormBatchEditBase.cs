using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cheke.ClientSide;
using Cheke.WinCtrl.StringManager;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormBatchEditBase : FormMiscBase
    {
        private GridView _batchEditView = null;
        private List<BatchEditorEntity> _dataSource = null;

        public FormBatchEditBase()
        {
            InitializeComponent();
        }

        public FormBatchEditBase(GridView batchEditView)
        {
            InitializeComponent();

            this._batchEditView = batchEditView;
        }

        protected GridView BatchEditView
        {
            get { return _batchEditView; }
        }

        protected override void InitializeForm()
        {
            this.SetColumns(this.gridView1);

            this._dataSource = this.GetDataSource();
            this.gridControl1.DataSource = this._dataSource;
            this.ConditionsAdjustment();

            if (this._batchEditView.DataSource == null || this._dataSource.Count <= 0)
            {
                this.lblNoEditableColumns.Visible = true;
                this.btnOK.Enabled = false;
            }
        }

        protected virtual Dictionary<int, object> GetEditedList()
        {
            return null;
        }

        private List<BatchEditorEntity> GetDataSource()
        {
            List<BatchEditorEntity> list = new List<BatchEditorEntity>();
            foreach (GridColumn col in this.BatchEditView.Columns)
            {
                if (!col.Visible || !col.OptionsColumn.ShowInCustomizationForm)
                    continue;

                if (!col.OptionsColumn.AllowEdit)
                    continue;

                BatchEditorEntity entity = new BatchEditorEntity(col);
                list.Add(entity);
            }

            return list;
        }

        private void BatchEdit()
        {
            Dictionary<int, object> list = this.GetEditedList();
            if(list == null || list.Count == 0)
                return;

            this.Cursor = Cursors.WaitCursor;
            foreach (BatchEditorEntity entity in this._dataSource)
            {
                if (!entity.Actived)
                    continue;

                if (entity.FieldValue == null)
                    continue;

                this.SetEditedRecordValue(entity, list);
            }

            //amend entity
            IAmendEntity amend = this.FindIAmendEntity(this.BatchEditView.GridControl);
            if (amend != null)
            {
                foreach (KeyValuePair<int, object> pair in list)
                {
                    amend.Amend(this._batchEditView, pair.Value);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void SetEditedRecordValue(BatchEditorEntity entity, Dictionary<int, object> list)
        {
            if (!entity.FillSeries)
            {
                foreach (KeyValuePair<int, object> item in list)
                {
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, entity.FieldValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, entity.FieldValue);
                }

                return;
            }

            if (entity.FieldValue.GetType() == typeof (DateTime))
            {
                DateTime startValue;
                if(!DateTime.TryParse(entity.FieldValue.ToString(), out startValue))
                    return;

                int index = 0;
                foreach (KeyValuePair<int, object> item in list)
                {
                    DateTime propertyValue = startValue.AddDays(index);
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, propertyValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, propertyValue);
                    index++;
                }
            }
            else if (entity.FieldValue.GetType() == typeof (byte))
            {
                byte startValue;
                if(!byte.TryParse(entity.FieldValue.ToString(), out startValue))
                    return;

                byte propertyValue = startValue;
                foreach (KeyValuePair<int, object> item in list)
                {
                    if (propertyValue < 255)
                    {
                        propertyValue += 1;
                    }
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, propertyValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, propertyValue);
                }
            }
            else if (entity.FieldValue.GetType() == typeof(short))
            {
                short startValue;
                if (!short.TryParse(entity.FieldValue.ToString(), out startValue))
                    return;

                short propertyValue = startValue;
                foreach (KeyValuePair<int, object> item in list)
                {
                    if (propertyValue < short.MaxValue)
                    {
                        propertyValue += 1;
                    }
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, propertyValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, propertyValue);
                }
            }
            else if (entity.FieldValue.GetType() == typeof(int))
            {
                int startValue;
                if(!int.TryParse(entity.FieldValue.ToString(), out startValue))
                    return;

                int propertyValue = startValue;
                foreach (KeyValuePair<int, object> item in list)
                {
                    if (propertyValue < int.MaxValue)
                    {
                        propertyValue += 1;
                    }
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, propertyValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, propertyValue);
                }
            }
            else if (entity.FieldValue.GetType() == typeof(long))
            {
                long startValue;
                if (!long.TryParse(entity.FieldValue.ToString(), out startValue))
                    return;

                long propertyValue = startValue;
                foreach (KeyValuePair<int, object> item in list)
                {
                    if (propertyValue < long.MaxValue)
                    {
                        propertyValue += 1;
                    }
                    ReflectorUtilitiy.SetPropertyValue(item.Value, entity.BatchEditFieldName, propertyValue);
                    this.BatchEditView.SetRowCellValue(item.Key, entity.BatchEditFieldName, propertyValue);
                }
            }
        }

        private void SetColumns(GridView view)
        {
            view.Columns.Clear();

            GridColumn colActived = new GridColumn();
            colActived.Caption = GridStringManager.BatchEdit_Actived;
            colActived.FieldName = BatchEditorEntity.ActivedName;
            colActived.OptionsColumn.AllowMove = false;
            colActived.OptionsColumn.AllowSort = DefaultBoolean.False;
            colActived.OptionsFilter.AllowFilter = false;
            colActived.Width = (int) (this.Width*0.15);
            colActived.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colActived);

            GridColumn colCaption = new GridColumn();
            colCaption.Caption = GridStringManager.BatchEdit_Caption;
            colCaption.FieldName = BatchEditorEntity.FieldCaptionName;
            colCaption.OptionsColumn.AllowFocus = false;
            colCaption.OptionsColumn.AllowMove = false;
            colCaption.OptionsColumn.AllowSort = DefaultBoolean.False;
            colCaption.OptionsFilter.AllowFilter = false;
            colCaption.Width = (int) (this.Width*0.3);
            colCaption.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colCaption);

            GridColumn colValue = new GridColumn();
            colValue.Caption = GridStringManager.BatchEdit_Value;
            colValue.FieldName = BatchEditorEntity.FieldValueName;
            colValue.OptionsColumn.AllowMove = false;
            colValue.OptionsColumn.AllowSort = DefaultBoolean.False;
            colValue.OptionsFilter.AllowFilter = false;
            colValue.Width = (int) (this.Width*0.3);
            colValue.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colValue);

            GridColumn colFillSeries = new GridColumn();
            colFillSeries.Caption = GridStringManager.BatchEdit_FillSeries;
            colFillSeries.FieldName = BatchEditorEntity.FillSeriesName;
            colFillSeries.OptionsColumn.AllowMove = false;
            colFillSeries.OptionsColumn.AllowSort = DefaultBoolean.False;
            colFillSeries.OptionsFilter.AllowFilter = false;
            colFillSeries.Width = (int) (this.Width*0.15);
            colFillSeries.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colFillSeries);
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == BatchEditorEntity.FieldValueName ||
                e.Column.FieldName == BatchEditorEntity.FillSeriesName)
            {
                BatchEditorEntity entity = this.gridView1.GetRow(e.RowHandle) as BatchEditorEntity;
                if (entity == null)
                    return;

                if (e.Column.FieldName == BatchEditorEntity.FillSeriesName)
                {
                    e.RepositoryItem = entity.RepositoryFillSeries;
                }
                else
                {
                    e.RepositoryItem = entity.RepositoryFieldValue;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.BatchEdit();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConditionsAdjustment()
        {
            StyleFormatCondition cn;
            cn =
                new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns[BatchEditorEntity.ActivedName],
                                         null, false);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Strikeout);
            cn.Appearance.ForeColor = SystemColors.ControlDark;
            gridView1.FormatConditions.Add(cn);

            cn =
                new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns[BatchEditorEntity.ActivedName],
                                         null, true);
            cn.ApplyToRow = true;
            cn.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
            gridView1.FormatConditions.Add(cn);

            cn =
                new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns[BatchEditorEntity.FillSeriesName],
                                         null, true);
            cn.Appearance.BackColor = Color.Yellow;
            gridView1.FormatConditions.Add(cn);

            gridView1.BestFitColumns();
        }

        private IAmendEntity FindIAmendEntity(Control current)
        {
            string interfaceName = typeof(IAmendEntity).Name;
            while (current != null)
            {
                if (current.GetType().GetInterface(interfaceName) != null)
                {
                    return current as IAmendEntity;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}