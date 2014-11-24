using System;
using System.Collections.Generic;
using Cheke.WinCtrl.Decoration;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl
{
    public partial class FormDuplicateBase : FormMiscBase
    {
        private GridControlDecorator _decorator = null;

        private readonly string _userId = string.Empty;
        private readonly object _dataSource = null;
        private readonly Type _decoratorType = null;

        private SortedList<string, GridColumn> _columnIndex = null;

        public FormDuplicateBase()
        {
            InitializeComponent();
        }

        public FormDuplicateBase(GridControlDecorator srcDecorator)
        {
            InitializeComponent();

            this._userId = srcDecorator.UserId;
            this._dataSource = srcDecorator.DataSource;
            this._decoratorType = srcDecorator.GetType();
        }

        protected GridControlDecorator Decorator
        {
            get { return this._decorator; }
        }

        protected object DataSource
        {
            get { return _dataSource; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this._decorator = Activator.CreateInstance(this._decoratorType, this._userId, this.gridControl1) as GridControlDecorator;
            if (this._decorator != null)
            {
                this._decorator.Initialize();
                this._decorator.Editable = false;
            }

            this.InitializeView(this.gridView1);
            this.DataBinding();
        }

        protected virtual void DataBinding()
        {
            this._decorator.DataSource = this.DataSource;
        }

        protected virtual void InitializeView(GridView view)
        {
           
        }

        protected GridColumn AddCalculateColumn(string caption, string fieldName)
        {
            if(this._columnIndex == null)
            {
                this._columnIndex = new SortedList<string, GridColumn>();
                foreach (GridColumn item in this.gridView1.Columns)
                {
                    if (this._columnIndex.ContainsKey(item.FieldName))
                        continue;

                    this._columnIndex.Add(item.FieldName, item);
                }
            }

            if(this._columnIndex.ContainsKey(fieldName))
            {
                this._columnIndex[fieldName].VisibleIndex = this._columnIndex.Count;
            }
            else
            {
                GridColumn col = new GridColumn();
                col.Caption = caption;
                col.FieldName = fieldName;
                col.VisibleIndex = this.gridView1.Columns.Count;
                this.gridView1.Columns.Add(col);

                this._columnIndex.Add(fieldName, col);
            }

            return this._columnIndex[fieldName];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}