using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cheke.Excel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.Translation.Manager
{
    public partial class FormMain : Form
    {
        private readonly SortedList<string, Multilingual> _sortedList = new SortedList<string, Multilingual>();

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
                return;

            this.InitGridView(this.gridView1);
        }

        private void InitGridView(GridView view)
        {
            GridColumn colGroup = new GridColumn();
            colGroup.Caption = "Group";
            colGroup.FieldName = MultilingualSchema.Group;
            colGroup.OptionsColumn.AllowEdit = false;
            colGroup.OptionsColumn.AllowFocus = false;
            colGroup.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colGroup);

            GridColumn colKey = new GridColumn();
            colKey.Caption = "Key";
            colKey.FieldName = MultilingualSchema.Key;
            colKey.OptionsColumn.AllowEdit = false;
            colKey.OptionsColumn.AllowFocus = false;
            colKey.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colKey);

            GridColumn colEnglish = new GridColumn();
            colEnglish.Caption = "English";
            colEnglish.FieldName = MultilingualSchema.English;
            colEnglish.OptionsColumn.AllowEdit = false;
            colEnglish.OptionsColumn.AllowFocus = false;
            colEnglish.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colEnglish);

            GridColumn colChinese = new GridColumn();
            colChinese.Caption = "Other";
            colChinese.FieldName = MultilingualSchema.Other;
            //colChinese.OptionsColumn.AllowEdit = false;
            //colChinese.OptionsColumn.AllowFocus = false;
            colChinese.VisibleIndex = view.Columns.Count;
            view.Columns.Add(colChinese);

            GridColumn colIsDirty = new GridColumn();
            colIsDirty.Caption = "IsDirty";
            colIsDirty.FieldName = "IsSelfDirty";
            colIsDirty.VisibleIndex = -1;
            colIsDirty.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(colIsDirty);

            GridColumn colIsNew = new GridColumn();
            colIsNew.Caption = "IsNew";
            colIsNew.FieldName = "IsNew";
            colIsNew.VisibleIndex = -1;
            colIsNew.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(colIsNew);

            this.AddConditionsStyle(view);
        }

        private void AddConditionsStyle(GridView view)
        {
            StyleFormatCondition cn = new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IsSelfDirty"], null, true);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.BurlyWood;
            view.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IsNew"], null, true);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = Color.DarkKhaki;
            view.FormatConditions.Add(cn);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(DialogResult.Yes != MessageBox.Show("Are you sure you want to exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }

            base.OnClosing(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Language Files (*.dat)|*.dat";
            if(dlg.ShowDialog() != DialogResult.OK)
                return;

            MultilingualCollection list = this.GetDataSource();
            list.SaveToFile(dlg.FileName);
            list.AcceptChanges();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = string.Empty;
            dlg.Filter = "Language Files (*.dat)|*.dat|Excel Files (*.xls)|*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.Import(dlg.FileName);
            this.Cursor = Cursors.Default;
        }

        private void btnMergeOldFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = string.Empty;
            dlg.Filter = "Language Files (*.dat)|*.dat|Excel Files (*.xls)|*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.Merge(dlg.FileName);
            this.Cursor = Cursors.Default;
        }

        private void Import(string fileName)
        {
            SortedList<string, Multilingual> list;
            string extension = Path.GetExtension(fileName).ToLower();
            if (extension == ".xls")
            {
                list = this.ImportFromExcel(fileName);
            }
            else if (extension == ".dat")
            {
                list = this.ImportFormFile(fileName);
            }
            else
            {
                return;
            }

            //add or modify
            foreach (KeyValuePair<string, Multilingual> item in list)
            {
                if (!this._sortedList.ContainsKey(item.Key))
                {
                    this._sortedList.Add(item.Key, item.Value);
                }
                else
                {
                    Multilingual srcEntity = this._sortedList[item.Key];
                    if (item.Value.English.Length > 0)
                    {
                        srcEntity.English = item.Value.English;
                    }

                    if (item.Value.Other.Length > 0)
                    {
                        srcEntity.Other = item.Value.Other;
                    }
                }
            }

            //delete
            List<string> deletedList = new List<string>();
            foreach (KeyValuePair<string, Multilingual> item in this._sortedList)
            {
                if (list.ContainsKey(item.Key))
                    continue;

                deletedList.Add(item.Key);
            }
            foreach (string item in deletedList)
            {
                this._sortedList.Remove(item);
            }

            this.gridControl1.DataSource = this.GetDataSource();
        }

        private void Merge(string fileName)
        {
            SortedList<string, Multilingual> list;
            string extension = Path.GetExtension(fileName).ToLower();
            if (extension == ".xls")
            {
                list = this.ImportFromExcel(fileName);
            }
            else if (extension == ".dat")
            {
                list = this.ImportFormFile(fileName);
            }
            else
            {
                return;
            }

            //modify
            foreach (KeyValuePair<string, Multilingual> item in list)
            {
                if (!this._sortedList.ContainsKey(item.Key))
                    continue;

                Multilingual srcEntity = this._sortedList[item.Key];
                if (srcEntity.Other.Length == 0)
                {
                    srcEntity.Other = item.Value.Other;
                }
            }

            this.gridControl1.DataSource = this.GetDataSource();
        }

        private SortedList<string, Multilingual> ImportFormFile(string fileName)
        {
            SortedList<string, Multilingual> sortedList = new SortedList<string, Multilingual>();
            MultilingualCollection list = new MultilingualCollection();
            list.LoadFromFile(fileName);

            foreach (Multilingual item in list)
            {
                if (sortedList.ContainsKey(item.Key))
                    continue;

                sortedList.Add(item.Key, item);
            }
            return sortedList;
        }

        private SortedList<string, Multilingual> ImportFromExcel(string fileName)
        {
            byte[] data = File.ReadAllBytes(fileName);
            SortedList<string, Multilingual> list = new SortedList<string, Multilingual>();
            string[] sheetList = new ExcelReader().GetExcelSheetsList(data);
            foreach (string sheet in sheetList)
            {
                if (!sheet.EndsWith("$"))
                    continue;

                DataTable dt = new ExcelReader().LoadIntoDataTable(data, sheet, true);
                foreach (DataRow row in dt.Rows)
                {
                    string key = string.Empty;
                    string english = string.Empty;
                    string other = string.Empty;
                    foreach (DataColumn column in dt.Columns)
                    {
                        string colValue = row[column.ColumnName].ToString().Trim();
                        if (column.ColumnName == MultilingualSchema.Key)
                        {
                            key = colValue;
                        }
                        else if (column.ColumnName == MultilingualSchema.English)
                        {
                            english = colValue;
                        }
                        else if (column.ColumnName == MultilingualSchema.Other)
                        {
                            other = colValue;
                        }
                    }

                    if (key.Length == 0 || english.Length == 0)
                        continue;

                    if (list.ContainsKey(key))
                    {
                        list[key].English = english;

                        if (other.Length > 0)
                        {
                            list[key].Other = other;
                        }
                    }
                    else
                    {
                        Multilingual entity = new Multilingual();
                        entity.Key = key;
                        entity.English = english;
                        entity.Other = other;
                        list.Add(key, entity);
                    }
                }
            }

            return list;
        }

        private MultilingualCollection GetDataSource()
        {
            MultilingualCollection list = new MultilingualCollection();
            foreach (KeyValuePair<string, Multilingual> pair in this._sortedList)
            {
                list.Add(pair.Value);
            }

            return list;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormModifyMultiLanguage dlg = new FormModifyMultiLanguage();
            if(dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Multilingual entity = new Multilingual();
            entity.Key = dlg.Key;
            entity.English = dlg.English;
            entity.Other = dlg.Other;

            if(!this._sortedList.ContainsKey(entity.Key))
            {
                this._sortedList.Add(entity.Key, entity);
                this.gridControl1.DataSource = this.GetDataSource();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if(this.gridView1.FocusedRowHandle < 0)
                return;

            Multilingual entity = this.gridView1.GetRow(this.gridView1.FocusedRowHandle) as Multilingual;
            if(entity == null)
                return;

            FormModifyMultiLanguage dlg = new FormModifyMultiLanguage(entity.Key, entity.English, entity.Other);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            entity.Key = dlg.Key;
            entity.English = dlg.English;
            entity.Other = dlg.Other;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.gridView1.FocusedRowHandle < 0)
                return;

            int[] rows = this.gridView1.GetSelectedRows();
            foreach (int row in rows)
            {
                Multilingual entity = this.gridView1.GetRow(row) as Multilingual;
                if (entity == null)
                    return;

                if (!this._sortedList.ContainsKey(entity.Key))
                    return;

                this._sortedList.Remove(entity.Key);
            }

            this.gridControl1.DataSource = this.GetDataSource();
        }
    }
}