using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;
using Cheke.WinCtrl.Warnings;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;

namespace Cheke.WinCtrl
{
    public partial class FormWorkBase : FormBase
    {
        private ProgressBarControl _progressBar = null;
        private Result _saveResult = null;

        private bool _isDeletedForm = false;
        private bool _isRefreshData = false;

        public FormWorkBase()
        {
            InitializeComponent();
        }

        public FormWorkBase(string userid, Control parent)
            : base(userid)
        {
            this.InitializeComponent();

            this.SetParent(parent);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                return;

            if (Translation.Translator.Instance.IsGatherString)
            {
                string key;
                if (this.TranslateCaption)
                {
                    key = string.Format("{0}|{1}", this.GetType().Name, this.lblCaption.Name);
                    Translation.Translator.Instance.AddTranslateString(key, this.Caption);
                }

                key = string.Format("{0}|{1}", this.GetType().Name, this.btnClose.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);

                key = string.Format("{0}|{1}", this.GetType().Name, this.btnSave.Name);
                Translation.Translator.Instance.RemoveTranslateString(key);
            }
            if (this.TranslateCaption && Translation.Translator.Instance.IsTranslate)
            {
                string key = string.Format("{0}|{1}", this.GetType().Name, this.lblCaption.Name);
                string caption = Translation.Translator.Instance.Translate(key);
                if(caption.Length > 0)
                {
                    this.Caption = caption;
                }
            }
        }

        protected virtual bool TranslateCaption
        {
            get { return true; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();
            if (string.IsNullOrEmpty(this.Caption))
            {
                this.Caption = string.Format("Untitled {0}", Application.OpenForms.Count - 1);
            }

            this.btnSave.Text = UIStringManager.SaveButton_Caption;
            this.btnClose.Text = UIStringManager.CloseButton_Caption;

            if (this.SimpleMode)
            {
                this.btnRefresh.Visible = false;
                this.btnEdit.Visible = false;
                this.btnSave.Visible = true;
            }

            if (this.ViewMode)
            {
                this.btnRefresh.Visible = false;
                this.btnEdit.Visible = false;
                this.btnSave.Visible = false;
            }

            this.imgClose.Visible = this.Closable;
            this.pnlCaption.Visible = this.IsCaptionVisible;
        }

        protected string Caption
        {
            get { return this.lblCaption.Text; }
            set
            {
                this.lblCaption.Text = value;
                this.Text = value;
            }
        }

        public override string Text
        {
            get{ return base.Text; }
            set
            {
                base.Text = value;
                if (this.lblCaption != null)
                {
                    this.lblCaption.Text = value;
                }
            }
        }

        public bool IsDeletedForm
        {
            get { return _isDeletedForm; }
            set { _isDeletedForm = value; }
        }

        protected bool IsRefreshData
        {
            get { return _isRefreshData; }
        }

        protected virtual bool Editable
        {
            get { return true; }
        }

        protected virtual bool Closable
        {
            get { return true; }
        }

        protected virtual bool IsCaptionVisible
        {
            get { return true; }
        }

        public virtual void BeforeOpenAgain()
        {
        }

        protected virtual bool SimpleMode
        {
            get { return false; }
        }

        protected virtual bool ViewMode
        {
            get { return false; }
        }

        protected virtual bool IsDirty
        {
            get { return false; }
        }

        protected LabelControl CaptionCtrl
        {
            get { return this.lblCaption; }
        }

        protected virtual void BeginEdit()
        {
            this.UpdateUI(true);
        }

        protected virtual void EndEdit()
        {
            this.UpdateUI(false);
        }

        protected virtual void CancelEdit()
        {
            this.UpdateUI(false);
        }

        protected virtual bool ValidateData()
        {
            return true;
        }

        protected bool ShowImportButton
        {
            get { return this.btnImport.Enabled; }
            set { this.btnImport.Enabled = value; }
        }

        protected virtual void UpdateUI(bool isDirty)
        {
            if (this.SimpleMode || !this.pnlButtons.Enabled)
                return;

            if (isDirty)
            {
                this.btnRefresh.Visible = false;
                this.btnEdit.Visible = false;
                this.btnSave.Visible = true;
                this.btnImport.Visible = this.btnImport.Enabled;

                this.btnClose.Visible = true;
                this.btnClose.Text = UIStringManager.CancelButton_Caption;

                this.SetReadOnly(false);
            }
            else
            {
                this.btnRefresh.Visible = true;
                this.btnSave.Visible = false;
                this.btnEdit.Visible = this.Editable;
                this.btnImport.Visible = false;

                this.btnClose.Visible = this.Closable;
                this.btnClose.Text = UIStringManager.CloseButton_Caption;

                this.SetReadOnly(true);
            }
        }

        protected virtual void DataBinding()
        {
            Cursor.Current = Cursors.WaitCursor;

            List<XtraTabControl> list = FormUtil.GetTabControl(this);
            if(list.Count > 0)
            {
                XtraTabControl mainCtrl = list[0];
                foreach (XtraTabControl control in list)
                {
                    if(control.Parent == this.pnlContent)
                    {
                        mainCtrl = control;
                        break;
                    }
                }

                mainCtrl.Select();
                mainCtrl.SelectedTabPage.Select();
            }

            Cursor.Current = Cursors.Default;
        }

        protected virtual void ClearDataBinding()
        {
            List<XtraTabControl> list = FormUtil.GetTabControl(this);
            foreach (XtraTabControl tabControl in list)
            {
                foreach (XtraTabPage item in tabControl.TabPages)
                {
                    item.Tag = null;
                }
            }
        }

        protected virtual void RefreshAllData()
        {
            this.ClearDataBinding();

            this._isRefreshData = true;
            this.DataBinding();
            this._isRefreshData = false;

            this.UpdateUI(false);
        }

        public override void RefrshGridViewData(GridView view)
        {
            if (view.IsDetailView)
            {
                GridView parent = view.ParentView as GridView;
                if (parent == null || view.SourceRowHandle < 0)
                    return;

                ReflectorUtilitiy.ClearPropertyValue(view.SourceRow, view.DataSource.GetType());

                int rowHandle = view.SourceRowHandle;
                parent.CollapseMasterRow(rowHandle);
                parent.ExpandMasterRow(rowHandle);
            }
            else
            {
                this._isRefreshData = true;

                XtraTabControl xtraTabControl = FormUtil.GetParentTabControl(view.GridControl);
                if (xtraTabControl != null)
                {
                    xtraTabControl.SelectedTabPage.Tag = null;
                    xtraTabControl.Focus();

                    xtraTabControl.Select();
                    xtraTabControl.SelectedTabPage.Select();
                }
                else
                {
                    this.DataBinding();
                }

                this._isRefreshData = false;
            }
        }

        public void SaveAll()
        {
            if (!this.IsDirty)
            {
                this.EndEdit();
                return;
            }

            if (!this.ValidateData())
                return;

            this.Cursor = Cursors.WaitCursor;
            this.Save();
            this.Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.BeginEdit();
            this.Cursor = Cursors.Default;
        }

        protected virtual void Exit()
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.btnClose.Text == UIStringManager.CloseButton_Caption)
            {
                this.Exit();
            }
            else
            {
                if (!this.IsDirty)
                {
                    this.EndEdit();
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                this.CancelEdit();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (this.IsDirty && DialogResult.Yes != base.ShowRefreshDataWarning())
                return;

            this.RefreshAllData();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!this.btnSave.Visible || this.IsDeletedForm || !this.IsDirty)
                return;

            FormDirtyDataWarning dlg = new FormDirtyDataWarning(this.Caption, UIStringManager.SaveDataWarning, this);
            switch (dlg.ShowDialog())
            {
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
                case DialogResult.Yes:
                    if (this.ValidateData())
                    {
                        this.Save();
                        if (this.SaveResult != null && !this.SaveResult.OK)
                        {
                            e.Cancel = true;
                        }
                    }
                    break;
            }

            //if (DialogResult.Yes == base.ShowSaveDataWarning())
            //{
            //    this.Save();
            //    if (this.SaveResult != null && !this.SaveResult.OK)
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void FormWorkBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                FormChildrenSwitch dlg = new FormChildrenSwitch();
                dlg.ShowDialog();
            }
        }

        private void imgClose_Click(object sender, EventArgs e)
        {
            this.Exit();
        }

        private void SetParent(Control panel)
        {
            if (this.DesignMode)
                return;

            if (panel == null)
            {
                this.TopLevel = true;
                this.pnlCaption.Visible = false;
                this.btnRefresh.Visible = false;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.TopLevel = false;
                this.Parent = panel;
                this.Dock = DockStyle.Fill;
            }
        }

        public virtual bool Contains(object obj)
        {
            BusinessBase item = obj as BusinessBase;
            if(item == null)
                return false;

            BusinessBase entity = FormUtil.GetEntityData(this);
            if (entity == null)
                return false;

            return item.Equals(entity);
        }

        public virtual bool IsChildForm(BusinessBase parent)
        {
            BusinessBase entity = FormUtil.GetEntityData(this);
            if (entity == null)
                return false;

            return EntityUtility.IsEntityParent(entity, parent);
        }

        protected virtual void Save()
        {
        }

        protected virtual void AfterSave()
        {
            this.EndEdit();
            if (this.SaveResult.OK)
            {
                if (this.SimpleMode)
                {
                    base.ShowMessage(UIStringManager.SaveDataSuccess);
                }
            }
            else
            {
                this.ShowSaveDataError(this.SaveResult);
                this.BeginEdit();
            }
        }

        protected Result SaveResult
        {
            get { return _saveResult; }
            set { _saveResult = value; }
        }

        public override void SaveGridViewData(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            List<BusinessCollectionBase> srcList = new List<BusinessCollectionBase>();
            srcList.Add(list);
            this.SaveWithProgress(srcList);
        }

        protected void SaveWithProgress(List<BusinessCollectionBase> srcList)
        {
            if (this._progressBar != null && this._progressBar.Visible)
                return;

            this.Cursor = Cursors.WaitCursor;
            this.pnlButtons.Enabled = false;
            List<BusinessCollectionBase> splits = this.SplitSavingData(srcList);
            if (this._progressBar == null)
            {
                this._progressBar = new ProgressBarControl();
                this.pnlContent.Controls.Add(this._progressBar);
                this._progressBar.Size = new System.Drawing.Size(500, 35);
                int x = (this.pnlContent.Width - this._progressBar.Width) / 2;
                int y = (this.pnlContent.Height - this._progressBar.Height) / 2;
                this._progressBar.Location = new System.Drawing.Point(x, y);
                this._progressBar.Properties.PercentView = true;
                this._progressBar.Properties.ShowTitle = true;
                this._progressBar.BringToFront();
            }

            this._progressBar.Visible = true;
            this._progressBar.Properties.Minimum = 0;
            this._progressBar.Properties.Maximum = splits.Count;
            this._progressBar.Properties.Step = 1;

            ArrayList list = new ArrayList();
            list.Add(srcList);
            list.Add(splits);
            this.backgroundWorker1.RunWorkerAsync(list);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ArrayList list = e.Argument as ArrayList;
            if (list == null || list.Count != 2)
                return;

            List<BusinessCollectionBase> srcList = list[0] as List<BusinessCollectionBase>;
            List<BusinessCollectionBase> splits = list[1] as List<BusinessCollectionBase>;
            if (srcList == null || splits == null)
                return;

            Result result = this.SaveData(splits);
            foreach (BusinessCollectionBase item in srcList)
            {
                EntityUtility.AcceptDeletes(item, result);
            }

            e.Result = result;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this._progressBar.PerformStep();
            this._progressBar.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.SaveResult = e.Result as Result;
            this.pnlButtons.Enabled = true;
            this.AfterSave();
            this._progressBar.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private Result SaveData(List<BusinessCollectionBase> splits)
        {
            Result retResult = new Result(true);
            for (int i = 0; i < splits.Count; i++)
            {
                Result r = base.SaveListOffEcho(splits[i]);
                retResult.Add(r);

                Thread.Sleep(1000);
                this.backgroundWorker1.ReportProgress(i);
            }

            return retResult;
        }

        private List<BusinessCollectionBase> SplitSavingData(List<BusinessCollectionBase> list)
        {
            List<BusinessCollectionBase> retList = new List<BusinessCollectionBase>();

            foreach (BusinessCollectionBase item in list)
            {
                BusinessCollectionBase children = EntityUtility.GetListChanges(item);
                List<BusinessCollectionBase> childrenList = EntityUtility.SplitList(children, 50);
                retList.AddRange(childrenList);
            }

            return retList;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
           this.Import();
        }

        public bool CanImport
        {
            get { return this.btnImport.Visible && this.btnImport.Enabled; }
        }

        public void Import()
        {
            this.openFileDialog1.FileName = string.Empty;
            this.openFileDialog1.Filter = this.ImportFilter;
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            Application.DoEvents();

            this.Cursor = Cursors.WaitCursor;
            this.Import(this.openFileDialog1.FileName);
            this.Cursor = Cursors.Default;
        }

        protected virtual string ImportFilter
        {
            get { return "Excel Files (*.xls)|*.xls"; }
        }

        protected virtual void Import(string fileName)
        {
            List<BusinessCollectionBase> list = this.GetImportDataList();
            if (list == null || list.Count == 0)
                return;

            SortedList<string, BusinessCollectionBase> srcListIndex = new SortedList<string, BusinessCollectionBase>();
            SortedList<string, BusinessCollectionBase> importListIndex = new SortedList<string, BusinessCollectionBase>();
            foreach (BusinessCollectionBase item in list)
            {
                if (item == null)
                    continue;

                BusinessCollectionBase importList = Activator.CreateInstance(item.GetType()) as BusinessCollectionBase;
                if (importList == null)
                    continue;

                srcListIndex.Add(item.TableName.ToUpper(), item);
                importListIndex.Add(item.TableName.ToUpper(), importList);
            }
            if (importListIndex.Count == 0)
                return;

            DataSet dataSet = FormMainBase.Instance.LoadFromExcel(fileName);
            if (dataSet == null || dataSet.Tables.Count == 0)
                return;

            foreach (DataTable table in dataSet.Tables)
            {
                if (table.Rows.Count == 0 || table.Columns.Count == 0)
                    continue;

                string tableName = table.TableName.Trim('\'');
                if (!tableName.EndsWith("$"))
                    continue;

                string key = tableName.TrimEnd('$').ToUpper();
                if (!importListIndex.ContainsKey(key))
                    continue;

                List<PropertyInfo> columnList = this.LoadFromDataTable(table, importListIndex[key]);
                this.ProcessImportData(srcListIndex[key], importListIndex[key], columnList);
            }

            //List<BusinessCollectionBase> list = this.GetImportDataList();
            //if(list == null || list.Count == 0)
            //    return;

            //Hashtable tableList = new Hashtable();
            //foreach (BusinessCollectionBase item in list)
            //{
            //    if (item == null)
            //        continue;

            //    tableList.Add(item.TableName.ToUpper(), item);
            //}
            //string[] sheetList = Cheke.Excel.ExcelSheetReader.GetExcelSheetsList(fileName);
            //foreach (string sheet in sheetList)
            //{
            //    if (!sheet.EndsWith("$"))
            //        continue;

            //    string key = sheet.TrimEnd('$').ToUpper();
            //    BusinessCollectionBase srcList = tableList[key] as BusinessCollectionBase;
            //    if (srcList == null)
            //        continue;

            //    BusinessCollectionBase importedList = Activator.CreateInstance(srcList.GetType()) as BusinessCollectionBase;
            //    if (importedList == null)
            //        continue;

            //    DataTable dt = Cheke.Excel.ExcelSheetReader.LoadSheetIntoDataSet(fileName, sheet, true);
            //    List<PropertyInfo> columnList = this.LoadFromDataTable(dt, importedList);
            //    this.ProcessImportData(srcList, importedList, columnList);
            //}
        }

        protected virtual List<BusinessCollectionBase> GetImportDataList()
        {
            return null;
        }

        protected virtual void ProcessImportData(BusinessCollectionBase src, BusinessCollectionBase imported, List<PropertyInfo> columnList)
        {
            foreach (BusinessBase item in imported)
            {
                src.Add(item);
            }
        }

        private List<PropertyInfo> LoadFromDataTable(DataTable dt, BusinessCollectionBase list)
        {
            PropertyInfo[] properties = list.GetItemType().GetProperties();
            Hashtable propertyList = new Hashtable();
            foreach (PropertyInfo item in properties)
            {
                if (!item.CanRead || !item.CanWrite)
                    continue;

                if (!item.PropertyType.IsValueType && item.PropertyType != typeof(string))
                    continue;

                propertyList.Add(item.Name, item);
            }

            bool isFirstRow = true;
            List<PropertyInfo> columnList = new List<PropertyInfo>();
            foreach (DataRow row in dt.Rows)
            {
                object entity = Activator.CreateInstance(list.GetItemType());
                foreach (DataColumn column in dt.Columns)
                {
                    PropertyInfo property = propertyList[column.ColumnName] as PropertyInfo;
                    if (property == null)
                        continue;

                    if (isFirstRow)
                        columnList.Add(property);

                    string colValue = row[column.ColumnName].ToString().Trim();
                    property.SetValue(entity, this.Convert(property, colValue), null);
                }

                isFirstRow = false;
                list.Add(entity);
            }

            return columnList;
        }

        private object Convert(PropertyInfo property, string colValue)
        {
            switch (property.PropertyType.Name)
            {
                case "Boolean":
                    {
                        bool result;
                        if (bool.TryParse(colValue, out result))
                            return result;

                        return colValue == "T" || colValue == "Y" || colValue == "1";
                    }
                case "Byte":
                    {
                        byte result;
                        if (byte.TryParse(colValue, out result))
                            return result;

                        return (byte)0;
                    }
                case "Int16":
                    {
                        short result;
                        if (short.TryParse(colValue, out result))
                            return result;

                        return (short)0;
                    }
                case "Int32":
                    {
                        int result;
                        if (int.TryParse(colValue, out result))
                            return result;

                        return 0;
                    }
                case "Int64":
                    {
                        long result;
                        if (long.TryParse(colValue, out result))
                            return result;

                        return (long)0;
                    }
                case "Decimal":
                    {
                        decimal result;
                        if (decimal.TryParse(colValue, out result))
                            return result;

                        return (decimal)0;
                    }
                case "Single":
                    {
                        float result;
                        if (float.TryParse(colValue, out result))
                            return result;

                        return (float)0;
                    }
                case "Double":
                    {
                        double result;
                        if (double.TryParse(colValue, out result))
                            return result;

                        return (double)0;
                    }
                case "DateTime":
                    {
                        DateTime result;
                        if (DateTime.TryParse(colValue, out result))
                            return result;

                        return new DateTime(1900, 1, 1);
                    }
                case "Guid":
                    {
                        try
                        {
                            return new Guid(colValue);
                        }
                        catch
                        {
                            return Guid.Empty;
                        }
                    }
                default:
                    return colValue;
            }
        }
    }
}