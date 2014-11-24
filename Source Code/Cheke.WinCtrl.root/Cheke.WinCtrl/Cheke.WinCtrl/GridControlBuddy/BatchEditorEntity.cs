using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Mask;
using System.Drawing;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public class BatchEditorEntity
    {
        public const string ActivedName = "Actived";
        public const string FieldCaptionName = "FieldCaption";
        public const string FieldValueName = "FieldValue";
        public const string FillSeriesName = "FillSeries";

        private bool _actived = false;
        private string _fieldCaption = string.Empty;
        private object _fieldValue = null;
        private object _tag = null;
        private bool _fillSeries = false;

        private string _batchEditFieldName = null;
        private RepositoryItem _repositoryFieldValue = null;
        private RepositoryItemCheckEdit _repositoryFillSeries = null;

        public BatchEditorEntity(GridColumn col)
        {
            this._batchEditFieldName = col.FieldName;
            this._actived = false;
            this._fieldCaption = col.Caption;
            this._fillSeries = false;

            this._repositoryFillSeries = new RepositoryItemCheckEdit();
            this._repositoryFillSeries.ReadOnly = true;

            this.CreateFieldValueRepository(col);
        }

        //public BatchEditorEntity(string fieldName, string caption, Type columnType, RepositoryItem columnEdit)
        //{
        //    this._batchEditFieldName = fieldName;
        //    this._actived = false;
        //    this._fieldCaption = caption;
        //    this._fillSeries = false;

        //    this._repositoryFillSeries = new RepositoryItemCheckEdit();
        //    this._repositoryFillSeries.ReadOnly = true;

        //    this.CreateFieldValueRepository(columnType, columnEdit);
        //}

        private void CreateFieldValueRepository(GridColumn col)
        {
            Type columnType = col.ColumnType;
            RepositoryItem columnEdit = col.ColumnEdit;

            if (columnType == typeof(string))
            {
                this._fieldValue = string.Empty;

                if (columnEdit == null)
                {
                    RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                    this._repositoryFieldValue = editor;
                }
                else
                {
                    RepositoryItemLookUpEdit colLookUpEdit = columnEdit as RepositoryItemLookUpEdit;
                    if (colLookUpEdit != null)
                    {
                        RepositoryItemLookUpEdit editor = new RepositoryItemLookUpEdit();
                        foreach (LookUpColumnInfo item in colLookUpEdit.Columns)
                        {
                            LookUpColumnInfo lookUpCol = new LookUpColumnInfo();
                            lookUpCol.FieldName = item.FieldName;
                            lookUpCol.Caption = item.Caption;
                            editor.Columns.Add(lookUpCol);
                        }

                        editor.NullText = "N/A";
                        editor.DropDownRows = colLookUpEdit.DropDownRows;
                        editor.PopupWidth = colLookUpEdit.PopupWidth;
                        editor.ValueMember = colLookUpEdit.ValueMember;
                        editor.DisplayMember = colLookUpEdit.DisplayMember;
                        editor.DataSource = colLookUpEdit.DataSource;

                        this._repositoryFieldValue = editor;
                        return;
                    }

                    RepositoryItemFontEdit colFontEdit = columnEdit as RepositoryItemFontEdit;
                    if (colFontEdit != null)
                    {
                        RepositoryItemFontEdit editor = new RepositoryItemFontEdit();
                        this._repositoryFieldValue = editor;
                        return;
                    }

                    RepositoryItemTextEdit colTextEdit = columnEdit as RepositoryItemTextEdit;
                    if(colTextEdit != null)
                    {
                        RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                        editor.Mask.MaskType = colTextEdit.Mask.MaskType;
                        editor.Mask.EditMask = colTextEdit.Mask.EditMask;
                        editor.Mask.UseMaskAsDisplayFormat = colTextEdit.Mask.UseMaskAsDisplayFormat;

                        this._repositoryFieldValue = editor;
                        return;
                    }

                    this._repositoryFieldValue = Activator.CreateInstance(columnEdit.GetType()) as RepositoryItem;
                }
            }
            else if (columnType == typeof(Color))
            {
                RepositoryItemColorEdit colColorEdit = columnEdit as RepositoryItemColorEdit;
                if (colColorEdit != null)
                {
                    RepositoryItemColorEdit editor = new RepositoryItemColorEdit();
                    this._repositoryFieldValue = editor;
                    return;
                }

                this._repositoryFieldValue = Activator.CreateInstance(columnEdit.GetType()) as RepositoryItem;

            }
            else if (columnType == typeof(byte[]))
            {
                this._fieldValue = null;

                if (columnEdit == null)
                {
                    RepositoryItemImageEdit editor = new RepositoryItemImageEdit();
                    this._repositoryFieldValue = editor;
                }
                else
                {
                    this._repositoryFieldValue = Activator.CreateInstance(columnEdit.GetType()) as RepositoryItem;
                }
            }
            else if (columnType == typeof(DateTime))
            {
                this._fieldValue = DateTime.Today;

                RepositoryItemTimeEdit colEdit = columnEdit as RepositoryItemTimeEdit;
                if (colEdit != null)
                {
                    RepositoryItemTimeEdit editor = new RepositoryItemTimeEdit();
                    editor.EditMask = colEdit.EditMask;

                    this._repositoryFieldValue = editor;
                }
                else
                {
                    RepositoryItemDateEdit editor = new RepositoryItemDateEdit();
                    editor.TextEditStyle = TextEditStyles.DisableTextEditor;
                    editor.ShowClear = false;

                    this._fillSeries = true;
                    this._repositoryFillSeries.ReadOnly = false;
                    this._repositoryFieldValue = editor;
                }
            }
            else if (columnType == typeof(Guid))
            {
                this._fieldValue = Guid.Empty;

                RepositoryItemLookUpEdit editor = new RepositoryItemLookUpEdit();

                RepositoryItemLookUpEdit colEdit = columnEdit as RepositoryItemLookUpEdit;
                if (colEdit != null)
                {

                    foreach (LookUpColumnInfo item in colEdit.Columns)
                    {
                        LookUpColumnInfo lookUpCol = new LookUpColumnInfo();
                        lookUpCol.FieldName = item.FieldName;
                        lookUpCol.Caption = item.Caption;
                        editor.Columns.Add(lookUpCol);
                    }

                    editor.NullText = "N/A";
                    editor.DropDownRows = colEdit.DropDownRows;
                    editor.PopupWidth = colEdit.PopupWidth;
                    editor.ValueMember = colEdit.ValueMember;
                    editor.DisplayMember = colEdit.DisplayMember;
                    editor.DataSource = colEdit.DataSource;
                }

                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(bool))
            {
                this._fieldValue = false;

                RepositoryItemCheckEdit editor = new RepositoryItemCheckEdit();
                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(double))
            {
                this._fieldValue = (double)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "f";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(decimal))
            {
                this._fieldValue = (decimal)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "f";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(float))
            {
                this._fieldValue = (float)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "f";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(byte))
            {
                this._fieldValue = (byte)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "d";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._fillSeries = true;
                this._repositoryFillSeries.ReadOnly = false;
                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(short))
            {
                this._fieldValue = (short)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "d";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._fillSeries = true;
                this._repositoryFillSeries.ReadOnly = false;
                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(int))
            {
                this._fieldValue = 0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "d";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._fillSeries = true;
                this._repositoryFillSeries.ReadOnly = false;
                this._repositoryFieldValue = editor;
            }
            else if (columnType == typeof(long))
            {
                this._fieldValue = (long)0;

                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                editor.Mask.MaskType = MaskType.Numeric;
                editor.Mask.EditMask = "d";
                if (col.DisplayFormat.FormatString.Length > 0)
                {
                    editor.Mask.EditMask = col.DisplayFormat.FormatString;
                }

                this._fillSeries = true;
                this._repositoryFillSeries.ReadOnly = false;
                this._repositoryFieldValue = editor;
            }
            else
            {
                RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
                this._repositoryFieldValue = editor;
            }
        }

        public bool Actived
        {
            get { return _actived; }
            set { _actived = value; }
        }

        public string FieldCaption
        {
            get { return _fieldCaption; }
        }

        public object FieldValue
        {
            get { return _fieldValue; }
            set { _fieldValue = value; }
        }

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        public bool FillSeries
        {
            get { return _fillSeries; }
            set { _fillSeries = value; }
        }

        public string BatchEditFieldName
        {
            get { return _batchEditFieldName; }
        }

        public RepositoryItem RepositoryFieldValue
        {
            get { return _repositoryFieldValue; }
        }

        public RepositoryItemCheckEdit RepositoryFillSeries
        {
            get { return _repositoryFillSeries; }
        }

        
    }
}