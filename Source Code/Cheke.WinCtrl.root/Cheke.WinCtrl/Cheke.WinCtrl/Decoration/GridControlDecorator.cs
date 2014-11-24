using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.Translation;
using Cheke.WinCtrl.GridControlBuddy;
using Cheke.WinCtrl.GridControlCommand;
using Cheke.WinCtrl.GridCustomize;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Collections;

namespace Cheke.WinCtrl.Decoration
{
    public delegate void FocusedEntityChangedDelegate(object obj);
    public delegate void OnGetColumnTranslateStringHandler(TranslatorBase translator, string typeName, GridControlDecorator decorator, GridColumn column);
    public delegate void OnTranslateColumnHandler(TranslatorBase translator, string typeName, GridControlDecorator decorator, GridColumn column);

    public abstract class GridControlDecorator : DecoratorBase, IApplyGridStyle
    {
        public FocusedEntityChangedDelegate FocusedEntityChanged;
        public OnGetColumnTranslateStringHandler OnGetColumnTranslateString;
        public OnTranslateColumnHandler OnTranslateColumn;

        private readonly GridControl _gridControl = null;
        private readonly GridView _gridView = null;
        private readonly GridMenuController _menuController = null;
        private readonly string _userId = string.Empty;

        private bool _isDoubleClickToEditor = false;
        private bool _neverShowEmbeddedNavigator = false;
        private bool _isHistoryView = false;
        private int _langID = 1033;

        protected GridControlDecorator(string userId, GridControl gridControl)
        {
            this._userId = userId;
            this._gridControl = gridControl;

            this._gridView = gridControl.MainView as GridView;
            this._menuController = new GridMenuController(this);
            this._isDoubleClickToEditor = true;
        }

        public override void Initialize()
        {
            this._gridControl.Tag = this.UserId;

            this.SetProperties();
            this.SetDisplayColumns(this._gridView);
            this.RestoreLayout(this._gridView);

            this.AddConditionsColumns(this._gridView);
            this.AddConditionsStyle(this._gridView);

            if (!this.IsSaveFilter())
            {
                this.ClearActiveFilter(this._gridView);
            }

            this.RegisterContextMenu();
            this.RegisterControlEvent();
            this.RegisterViewEvent();

            this.SetupTooltip();

            this.ApplyStyle();
        }

        protected abstract void SetDisplayColumns(GridView view);

        protected virtual void ClearActiveFilter(GridView view)
        {
            view.ActiveFilter.Clear();
        }

        private bool IsSaveFilter()
        {
            object obj = ConfigurationManager.AppSettings["SaveFilter"];
            if (obj != null)
            {
                return string.Compare(obj.ToString(), true.ToString(), StringComparison.OrdinalIgnoreCase) == 0;
            }
           
            return true;
        }

        public virtual void GetTranslateString()
        {
            this.GetTranslateString(this._gridView);
        }

        protected void GetTranslateString(GridView view)
        {
            foreach (GridColumn item in view.Columns)
            {
                this.GetColumnTranslateString(item);
            }
        }

        protected virtual void GetColumnTranslateString(GridColumn column)
        {
            string thisTypeName = this.GetType().Name;
            string key = string.Format("{0}|{1}", thisTypeName, column.FieldName);
            Translator.Instance.AddTranslateString(key, column.Caption);
            if (this.OnGetColumnTranslateString != null)
            {
                this.OnGetColumnTranslateString(Translator.Instance, thisTypeName, this, column);
            }
        }

        public virtual void Translate()
        {
            this.Translate(this._gridView);
        }

        protected void Translate(GridView view)
        {
            foreach (GridColumn item in view.Columns)
            {
                this.TranslateColumn(item);
            }
        }

        protected virtual void TranslateColumn(GridColumn column)
        {
            string thisTypeName = this.GetType().Name;
            string key = string.Format("{0}|{1}", thisTypeName, column.FieldName);
            string translate = Translator.Instance.Translate(key);
            if (translate.Length > 0)
            {
                column.Caption = translate;
            }

            if (this.OnTranslateColumn != null)
            {
                this.OnTranslateColumn(Translator.Instance, thisTypeName, this, column);
            }
        }

        public void BestFitColumns()
        {
            this._gridView.BestFitColumns();
        }

        protected void RestoreLayout(GridView view)
        {
            GridLayoutCommand.RestoreLayoutFromFile(this.UserId, this._gridControl, view);
        }

        protected virtual void SetProperties()
        {
            this._gridControl.UseEmbeddedNavigator = true;
            this._gridControl.ShowOnlyPredefinedDetails = true;
            this._gridControl.LookAndFeel.Style = LookAndFeelStyle.Skin;
            this._gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this._gridControl.LookAndFeel.UseWindowsXPTheme = false;

            this._gridView.OptionsSelection.MultiSelect = true;

            this._gridView.OptionsView.ColumnAutoWidth = false;
            this._gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this._gridView.OptionsPrint.PrintDetails = true;

            this._gridView.OptionsDetail.EnableMasterViewMode = false;
            //this._gridView.OptionsDetail.AutoZoomDetail = true;
            this._gridView.OptionsDetail.AllowZoomDetail = true;
            this._gridView.OptionsCustomization.AllowFilter = true;
        }

        protected virtual void AddConditionsColumns(GridView view)
        {
            ConditionsStyleCommand.AddConditionsColumns(view);
        }

        protected virtual void AddConditionsStyle(GridView view)
        {
            ConditionsStyleCommand.AddConditionsStyle(view);
        }

        protected virtual void RegisterContextMenu()
        {
            this._menuController.RegisterContextMenu();
        }

        public void ResetLayout()
        {
            GridMenuFacade.ApplyDefaultLayout(this.UserId, this._gridControl);
        }

        public void ShowPreview()
        {
            this._gridControl.ShowPrintPreview();
        }

        public void Print()
        {
            this._gridControl.Print();
        }

        #region Properties

        public object DataSource
        {
            get { return this._gridControl.DataSource; }
            set { this._gridControl.DataSource = value; }
        }

        public bool EnableMasterViewMode
        {
            get { return this._gridView.OptionsDetail.EnableMasterViewMode; }
            set { this._gridView.OptionsDetail.EnableMasterViewMode = value; }
        }

        public BindingManagerBase CurrencyManager
        {
            get { return this._gridControl.BindingContext[this._gridControl.DataSource]; }
        }

        public string UserId
        {
            get { return _userId; }
        }

        public int LangID
        {
            get { return _langID; }
            set { _langID = value; }
        }

        public bool IsDoubleClickToEditor
        {
            get { return this._isDoubleClickToEditor; }
            set { this._isDoubleClickToEditor = value; }
        }

        public bool NeverShowEmbeddedNavigator
        {
            get { return _neverShowEmbeddedNavigator; }
            set { _neverShowEmbeddedNavigator = value; }
        }

        public bool IsHistoryView
        {
            get { return _isHistoryView; }
            set { _isHistoryView = value; }
        }

        public GridMenuController MenuController
        {
            get { return _menuController; }
        }

        public GridControl GridControl
        {
            get { return _gridControl; }
        }

        public GridView GridView
        {
            get { return _gridView; }
        }

        #endregion

        #region Privilege

        protected virtual bool HasAddNewPrivilege()
        {
            BusinessCollectionBase dataSource = this._gridControl.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return false;

            return FormMainBase.Instance.HasAddNewPrivilege(dataSource.TableName);
        }

        protected virtual bool HasDeletePrivilege()
        {
            BusinessCollectionBase dataSource = this._gridControl.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return false;

            return FormMainBase.Instance.HasDeletePrivilege(dataSource.TableName);
        }

        protected virtual bool HasEditPrivilege()
        {
            BusinessCollectionBase dataSource = this._gridControl.DataSource as BusinessCollectionBase;
            if (dataSource == null)
                return false;

            return FormMainBase.Instance.HasEditPrivilege(dataSource.TableName);
        }

        #endregion

        #region MessageBoxs

        protected void ShowMessage(string info, string title)
        {
            if (string.IsNullOrEmpty(info))
                return;

            MessageBoxUtil.ShowMessage(info, title);
        }

        protected void ShowWarningMessage(string warningMsg, string title)
        {
            if (string.IsNullOrEmpty(warningMsg))
                return;

            MessageBoxUtil.ShowWarningMessage(warningMsg, title);
        }

        protected void ShowErrorMessage(string error, string title)
        {
            if (string.IsNullOrEmpty(error))
                return;

            MessageBoxUtil.ShowErrorMessage(error, title);
        }

        protected DialogResult ShowQuestion(string question, string title)
        {
            return MessageBoxUtil.ShowQuestion(question, title);
        }

        #endregion

        #region RepositoryItem Editor

        protected RepositoryItemButtonEdit AddButtonEdit(GridView view)
        {
            RepositoryItemButtonEdit editor = new RepositoryItemButtonEdit();
            editor.TextEditStyle = TextEditStyles.HideTextEditor;
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemTextEdit AddTextEdit(GridView view)
        {
            RepositoryItemTextEdit editor = new RepositoryItemTextEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemMemoEdit AddMemoEdit(GridView view)
        {
            RepositoryItemMemoEdit editor = new RepositoryItemMemoEdit();
            view.GridControl.RepositoryItems.Add(editor);

            view.OptionsView.RowAutoHeight = true;

            return editor;
        }

        protected RepositoryItemMemoExEdit AddMemoExEdit(GridView view)
        {
            RepositoryItemMemoExEdit editor = new RepositoryItemMemoExEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemDateEdit AddDateEdit(GridView view)
        {
            RepositoryItemDateEdit editor = new RepositoryItemDateEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemTimeEdit AddTimeEdit(GridView view)
        {
            RepositoryItemTimeEdit editor = new RepositoryItemTimeEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemLookUpEdit AddLookUpEdit(GridView view)
        {
            RepositoryItemLookUpEdit editor = new RepositoryItemLookUpEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemComboBox AddComboBox(GridView view)
        {
            RepositoryItemComboBox editor = new RepositoryItemComboBox();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        protected RepositoryItemCheckEdit AddCheckEdit(GridView view)
        {
            RepositoryItemCheckEdit editor = new RepositoryItemCheckEdit();
            view.GridControl.RepositoryItems.Add(editor);

            return editor;
        }

        #endregion

        #region Tooltip

        private void SetupTooltip()
        {
            ToolTipController.DefaultController.GetActiveObjectInfo += DefaultController_GetActiveObjectInfo;
        }

        protected virtual void DefaultController_GetActiveObjectInfo(object sender,
                                                                     ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != this._gridControl)
                return;

            GridView view = this._gridControl.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null)
                return;

            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            if (hi == null || !hi.InRowCell)
                return;

            e.Info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"),
                                            this.GetCellHintText(view, hi.RowHandle));
        }

        protected virtual string GetCellHintText(GridView view, int rowHandle)
        {
            StringWriter writer = new StringWriter(new StringBuilder());
            foreach (GridColumn col in view.Columns)
            {
                if (col.Tag != null)
                    continue;

                if (col.OptionsColumn.ShowInCustomizationForm)
                    continue;

                writer.WriteLine("{0}: {1}", col.Caption, view.GetRowCellDisplayText(rowHandle, col));
            }

            return writer.ToString();
        }

        #endregion

        #region Default Control Events

        protected virtual void RegisterControlEvent()
        {
            this._gridControl.DataSourceChanged += GridControl_DataSourceChanged;
            this._gridControl.FocusedViewChanged += GridControl_FocusedViewChanged;
            this._gridControl.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;

            this._gridControl.KeyPress += GridControl_KeyPress;
            this._gridControl.ProcessGridKey += GridControl_ProcessGridKey;
        }

        protected virtual void GridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.FocusedEntityChanged == null)
                return;

            BusinessCollectionBase list = this._gridControl.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            this.CurrencyManager.CurrentChanged -= currencyManager_CurrentChanged;
            this.CurrencyManager.CurrentChanged += currencyManager_CurrentChanged;
            if (list.Count > 0)
            {
                this.FocusedEntityChanged(list[0]);
            }
            else
            {
                this.FocusedEntityChanged(null);
            }
        }

        private void currencyManager_CurrentChanged(object sender, EventArgs e)
        {
            if (this.CurrencyManager.Count > 0)
            {
                this.FocusedEntityChanged(this.CurrencyManager.Current);
            }
            else
            {
                this.FocusedEntityChanged(null);
            }
        }

        protected virtual void GridControl_FocusedViewChanged(object sender, ViewFocusEventArgs e)
        {
            GridView view = e.View as GridView;
            if (view == null)
                return;

            view.GridControl.UseEmbeddedNavigator = view.OptionsBehavior.Editable;
        }

        #endregion

        #region Default View Events

        protected virtual void RegisterViewEvent()
        {
            this.RegisterBasicViewEvent(this._gridView);
        }

        protected void RegisterBasicViewEvent(GridView view)
        {
            view.MasterRowExpanded += GridView_MasterRowExpanded;
            view.InitNewRow += GridView_InitNewRow;

            view.DoubleClick += GridView_DoubleClick;
            view.ShownEditor += GridView_ShownEditor;

            view.GroupLevelStyle += GridView_GroupLevelStyle;
        }

        private void GridView_GroupLevelStyle(object sender, GroupLevelStyleEventArgs e)
        {
            e.LevelAppearance.BackColor = this.GetColorByIndex(e.Level);
            if (e.Level == 1)
            {
                e.LevelAppearance.ForeColor = Color.White;
            }
            else
            {
                e.LevelAppearance.ForeColor = Color.Black;
            }
        }

        private void GridView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView mainView = sender as GridView;
            if (mainView == null)
                return;

            GridView detailView = mainView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            if (detailView != null)
            {
                detailView.BestFitColumns();

                GridControl gridControl = mainView.GridControl;
                string userId = gridControl.Tag as string;
                GridLayoutCommand.RestoreLayoutFromFile(userId, gridControl, detailView);
            }
        }

        private void GridView_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            view.ActiveEditor.DoubleClick -= GridView_DoubleClick;
            view.ActiveEditor.DoubleClick += GridView_DoubleClick;
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            if (!this._isDoubleClickToEditor)
                return;

            GridView view = this._gridControl.FocusedView as GridView;
            if (view == null)
                return;

            if (view.FocusedRowHandle < 0)
                return;

            NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(this._gridControl.EmbeddedNavigator.Buttons.Edit);
                this.NavigatorEditClick(view, args);
        }

        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            BusinessBase entity = view.GetRow(e.RowHandle) as BusinessBase;
            if (entity == null)
                return;

            this.InitNewEntity(view, entity);
        }

        protected virtual void InitNewEntity(GridView view, BusinessBase entity)
        {
        }

        public void ConfigureLayout(GridView view)
        {
            FormColumnCustomize dlg = new FormColumnCustomize(view);
            dlg.ShowDialog();
        }
        #endregion

        #region Process GridKey

        private bool IsTopLevelParent()
        {
            Control current = this.GridControl;
            while (current != null)
            {
                Form frm = current as Form;
                if (frm != null)
                {
                    return frm.TopLevel;
                }

                current = current.Parent;
            }

            return true;
        }

        private void GridControl_ProcessGridKey(object sender, KeyEventArgs e)
        {
            GridView view = this._gridControl.FocusedView as GridView;
            if (view == null)
                return;

            if (e.KeyCode == Keys.Enter && !this.IsTopLevelParent())
            {
                this.NavigatorEditClick(view, new NavigatorButtonClickEventArgs(this.GridControl.EmbeddedNavigator.Buttons.Edit));
                return;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        if (GridClipboard.CanCopy(view))
                        {
                            GridClipboard.Copy(view);
                        }
                        e.Handled = true;
                        break;
                        //case Keys.X:
                        //    if (GridClipboard.CanCut(view))
                        //    {
                        //        GridClipboard.Cut(view);
                        //    }
                        //    e.Handled = true;
                        //    break;
                    case Keys.V:
                        if (GridClipboard.CanPaste(view))
                        {
                            GridClipboard.Paste(view);
                        }
                        e.Handled = true;
                        break;
                    case Keys.M:
                        if (GridClipboard.CanCopy(view))
                        {
                            GridClipboard.Multicopy(view);
                        }
                        e.Handled = true;
                        break;
                    case Keys.Q:
                        if (GridEditCommand.CanBatchAppend(view))
                        {
                            this.BatchAppend(view);
                        }
                        e.Handled = true;
                        break;
                    case Keys.E:
                        if (GridEditCommand.CanBatchEdit(view))
                        {
                            this.BatchEdit(view);
                        }
                        e.Handled = true;
                        break;
                    case Keys.L:
                        if (e.Shift)
                        {
                            GridView focusedView = this._gridControl.FocusedView as GridView;
                            if (focusedView != null)
                            {
                                ICollection list = focusedView.DataSource as ICollection;
                                if (list != null)
                                {
                                    MessageBoxUtil.ShowFocusedViewDataRecords(list.Count);
                                }
                            }
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                        break;
                    case Keys.H:
                        if (e.Shift && FormMainBase.Instance != null &&
                            FormMainBase.Instance.CustomizeGridViewFullLayout)
                        {
                            GridView focusedView = this._gridControl.FocusedView as GridView;
                            if (focusedView != null)
                            {
                                FormColumnCustomize dlg = new FormColumnCustomize(focusedView);
                                dlg.ShowDialog();
                            }
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = false;
                        }
                        break;
                    default:
                        e.Handled = false;
                        break;
                }

                return;
            }

            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                    case Keys.Add:
                        if (this.Editable && this.GridControl.EmbeddedNavigator.Buttons.Append.Visible)
                        {
                            this.NavigatorAppendClick(view, new NavigatorButtonClickEventArgs(this.GridControl.EmbeddedNavigator.Buttons.Append));
                        }
                        e.Handled = true;
                        break;
                    case Keys.D:
                    case Keys.Subtract:
                        if (this.Editable && view.RowCount > 0 && this.GridControl.EmbeddedNavigator.Buttons.Remove.Visible)
                        {
                            FormRemoveWarning dlg = new FormRemoveWarning(view);
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                view.DeleteSelectedRows();
                                if (view.RowCount > 0)
                                {
                                    view.SelectRow(0);
                                }
                            }
                        }
                        e.Handled = true;
                        break;
                    case Keys.E:
                        if (this.Editable && view.RowCount > 0 && this.GridControl.EmbeddedNavigator.Buttons.Edit.Visible)
                        {
                            this.NavigatorEditClick(view, new NavigatorButtonClickEventArgs(this.GridControl.EmbeddedNavigator.Buttons.Edit));
                        }
                        e.Handled = true;
                        break;
                    default:
                        e.Handled = false;
                        break;
                }
            }
        }

        private void GridControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        #endregion

        #region EmbeddedNavigator_ButtonClick

        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            GridView view = this._gridControl.FocusedView as GridView;
            if (view == null)
                return;

            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (!this.HasDeletePrivilege())
                {
                    MessageBoxUtil.ShowNoDeletePrivilegeWarning("Warning");
                    e.Handled = true;
                }
                else
                {
                    this.NavigatorRemoveClick(view, e);
                }
            }
            else if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                if (!this.HasAddNewPrivilege())
                {
                    MessageBoxUtil.ShowNoAddNewPrivilegeWarning("Warning");
                    e.Handled = true;
                }
                else
                {
                    this.NavigatorAppendClick(view, e);
                }
            }
            else if (e.Button.ButtonType == NavigatorButtonType.Edit)
            {
                this.NavigatorEditClick(view, e);
            }
        }

        protected virtual Dictionary<Type, EntitySetting> EntitySettingDictionary
        {
            get { return new Dictionary<Type, EntitySetting>(); }
        }

        protected virtual bool CanSaveDetailForm()
        {
            return true;
        }

        protected virtual BusinessBase CreateNewEntity(Type entityType)
        {
            return Activator.CreateInstance(entityType) as BusinessBase;
        }

        public void AddNewRecord()
        {
            if (!this.HasAddNewPrivilege())
            {
                MessageBoxUtil.ShowNoAddNewPrivilegeWarning("Warning");
                return;
            }

            NavigatorButtonClickEventArgs e =new NavigatorButtonClickEventArgs(this.GridControl.EmbeddedNavigator.Buttons.Append);
            this.NavigatorAppendClick(this.GridView, e);
        }

        public void RemoveSelectedRecords()
        {
            if (!this.HasDeletePrivilege())
            {
                MessageBoxUtil.ShowNoDeletePrivilegeWarning("Warning");
                return;
            }
           
            NavigatorButtonClickEventArgs e = new NavigatorButtonClickEventArgs(this.GridControl.EmbeddedNavigator.Buttons.Remove);
            this.NavigatorRemoveClick(this.GridView, e);
        }

        protected virtual void NavigatorAppendClick(GridView view, NavigatorButtonClickEventArgs e)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            foreach (KeyValuePair<Type, EntitySetting> item in this.EntitySettingDictionary)
            {
                if (item.Value == null || item.Value.DetailFormType == null)
                    continue;

                if (list.GetItemType() == item.Key)
                {
                    e.Handled = true;

                    BusinessBase entity = this.CreateNewEntity(item.Key);
                    if (entity == null)
                    {
                        e.Handled = true;
                        return;
                    }

                    this.InitNewEntity(view, entity);

                    if (item.Value.DetailFormType.IsSubclassOf(typeof (FormDetailEditorBase)))
                    {
                        FormDetailBase dlg = (FormDetailBase) Activator.CreateInstance(item.Value.DetailFormType,
                                                                                       new object[]
                                                                                           {
                                                                                               this.UserId, entity
                                                                                           });
                        if (!this.CanSaveDetailForm())
                        {
                            dlg.ParentList = this.DataSource as BusinessCollectionBase;
                        }
                        dlg.ShowDialog();
                    }
                    else if (item.Value.DetailFormType.IsSubclassOf(typeof (FormDetailListBase)))
                    {
                        Form dlg = (Form) Activator.CreateInstance(item.Value.DetailFormType,
                                                                   new object[]
                                                                       {
                                                                           this.UserId, entity,
                                                                           list.Clone()
                                                                       });
                        dlg.ShowDialog();
                    }
                    else if (item.Value.DetailFormType.IsSubclassOf(typeof (FormWorkEditorBase)))
                    {
                        if (FormMainBase.Instance.HasTopLevelForm())
                        {
                            Form dlg = (Form) Activator.CreateInstance(item.Value.DetailFormType,
                                                                       new object[]
                                                                           {
                                                                               this.UserId, null, entity
                                                                           });
                            dlg.ShowDialog();
                        }
                        else
                        {
                            FormMainBase.Instance.ShowChildForm(item.Value.DetailFormType, entity);
                        }
                    }
                }
            }
        }

        protected virtual void NavigatorRemoveClick(GridView view, NavigatorButtonClickEventArgs e)
        {
            FormRemoveWarning dlg = new FormRemoveWarning(view);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                e.Handled = true;
            }
        }

        protected virtual void NavigatorEditClick(GridView view, NavigatorButtonClickEventArgs e)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            foreach (KeyValuePair<Type, EntitySetting> item in this.EntitySettingDictionary)
            {
                if (item.Value == null || item.Value.DetailFormType == null)
                    continue;

                if (list.GetItemType() == item.Key)
                {
                    e.Handled = true;

                    BusinessBase entity = view.GetRow(view.FocusedRowHandle) as BusinessBase;
                    if (entity == null)
                        continue;

                    if (item.Value.DetailFormType.IsSubclassOf(typeof (FormDetailEditorBase)))
                    {
                        FormDetailBase dlg = (FormDetailBase) Activator.CreateInstance(item.Value.DetailFormType,
                                                                                       new object[]
                                                                                           {
                                                                                               this.UserId,
                                                                                               entity.Clone()
                                                                                           });
                        if (!this.CanSaveDetailForm())
                        {
                            dlg.ParentList = this.DataSource as BusinessCollectionBase;
                        }
                        dlg.ShowDialog();
                    }
                    else if (item.Value.DetailFormType.IsSubclassOf(typeof (FormDetailListBase)))
                    {
                        Form dlg = (Form) Activator.CreateInstance(item.Value.DetailFormType,
                                                                   new object[]
                                                                       {
                                                                           this.UserId, entity.Clone(),
                                                                           list.Clone()
                                                                       });
                        dlg.ShowDialog();
                    }
                    else if (item.Value.DetailFormType.IsSubclassOf(typeof (FormWorkEditorBase)))
                    {
                        if (FormMainBase.Instance.HasTopLevelForm())
                        {
                            Form dlg = (Form) Activator.CreateInstance(item.Value.DetailFormType,
                                                                       new object[]
                                                                           {
                                                                               this.UserId, null,
                                                                               entity.Clone()
                                                                           });
                            dlg.ShowDialog();
                        }
                        else
                        {
                            FormMainBase.Instance.ShowChildForm(item.Value.DetailFormType,
                                                                entity.Clone() as BusinessBase);
                        }
                    }
                }
            }
        }

        #endregion

        #region Edit Menu
        public virtual List<DXMenuItem> CreateEditMenus(GridView view)
        {
            List<DXMenuItem> retList = new List<DXMenuItem>();
            
            DXMenuItem cutItem = this.CreateMenu(GridStringManager.CutMenu);
            cutItem.Enabled = this.CanCut(view);
            cutItem.Tag = view;
            cutItem.Click += CutMenu_Click;
            retList.Add(cutItem);

            DXMenuItem copyItem = this.CreateMenu(GridStringManager.CopyMenu);
            copyItem.Enabled = this.CanCopy(view);
            copyItem.Tag = view;
            copyItem.Click += CopyMenu_Click;
            retList.Add(copyItem);

            DXMenuItem multiCopyItem = this.CreateMenu(GridStringManager.MulticopyMenu);
            multiCopyItem.Enabled = this.CanMultiCopy(view);
            multiCopyItem.Tag = view;
            multiCopyItem.Click += MulticopyMenu_Click;
            retList.Add(multiCopyItem);

            DXMenuItem pasteItem = this.CreateMenu(GridStringManager.PasteMenu);
            pasteItem.Enabled = this.CanPaste(view);
            pasteItem.Tag = view;
            pasteItem.Click += PasteMenu_Click;
            retList.Add(pasteItem);

            DXMenuItem batchAppendItem = this.CreateMenu(GridStringManager.BatchAppendMenu);
            batchAppendItem.Enabled = this.CanBatchAppend(view);
            batchAppendItem.BeginGroup = true;
            batchAppendItem.Tag = view;
            batchAppendItem.Click += BatchAppend_Click;
            retList.Add(batchAppendItem);

            DXMenuItem batchEditItem = this.CreateMenu(GridStringManager.BatchEditMenu);
            batchEditItem.Enabled = this.CanBatchEdit(view);
            batchEditItem.Tag = view;
            batchEditItem.Click += BatchEdit_Click;
            retList.Add(batchEditItem);

            return retList;
        }

        protected virtual bool CanCut(GridView view)
        {
            return GridEditCommand.CanCut(view);
        }

        protected virtual void Cut(GridView view)
        {
            GridEditCommand.Cut(view);
        }

        private void CutMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if(view == null)
                return;

            this.Cut(view);
        }

        protected virtual bool CanCopy(GridView view)
        {
            return GridEditCommand.CanCopy(view);
        }

        protected virtual void Copy(GridView view)
        {
            GridEditCommand.Copy(view);
        }

        protected virtual bool CanMultiCopy(GridView view)
        {
            return GridEditCommand.CanCopy(view);
        }

        protected virtual void MultiCopy(GridView view)
        {
            GridEditCommand.Multicopy(view);
        }

        private void CopyMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if (view == null)
                return;

            this.Copy(view);
        }

        private void MulticopyMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if (view == null)
                return;

            this.MultiCopy(view);
        }

        protected virtual bool CanPaste(GridView view)
        {
            return GridEditCommand.CanPaste(view);
        }

        protected virtual void Paste(GridView view)
        {
            GridEditCommand.Paste(view);
        }

        private void PasteMenu_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if (view == null)
                return;

            this.Paste(view);
        }

        protected virtual bool CanBatchEdit(GridView view)
        {
            return GridEditCommand.CanBatchEdit(view);
        }

        protected virtual void BatchEdit(GridView view)
        {
            FormBatchEdit dlg = new FormBatchEdit(view);
            dlg.ShowDialog();
        }

        private void BatchEdit_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if (view == null)
                return;

            this.BatchEdit(view);
        }

        protected virtual bool CanBatchAppend(GridView view)
        {
            return GridEditCommand.CanBatchAppend(view);
        }

        protected virtual void BatchAppend(GridView view)
        {
            FormBatchAppend dlg = new FormBatchAppend(view);
            dlg.ShowDialog();
        }

        private void BatchAppend_Click(object sender, EventArgs e)
        {
            DXMenuItem menu = sender as DXMenuItem;
            if (menu == null)
                return;

            GridView view = menu.Tag as GridView;
            if (view == null)
                return;

            this.BatchAppend(view);
        }

        protected DXMenuItem CreateMenu(string caption)
        {
            DXMenuItem menu = new DXMenuItem();
            menu.Caption = caption;
            return menu;
        }
        #endregion

        #region Application Menu
        public virtual void CreateApplicationMenus(DXMenuItemCollection menus, GridView view)
        {
        }
        #endregion

        #region ShowDataHistory

        public virtual void ShowEditEvents(GridView view)
        {
            if (FormMainBase.Instance != null)
            {
                FormMainBase.Instance.ShowEditEvents(this);
            }
        }

        public virtual void ShowDeleteEvents(GridView view)
        {
            if (FormMainBase.Instance != null)
            {
                FormMainBase.Instance.ShowDeleteEvents(this);
            }
        }

        public virtual BusinessCollectionBase FilterDeleteEvents(BusinessCollectionBase list)
        {
            return list;
        }

        #endregion

        #region Editable

        public virtual bool Editable
        {
            get { return this._gridView.OptionsBehavior.Editable; }
            set
            {
                //if (value != this._gridView.OptionsBehavior.Editable)
                {
                    this._gridView.OptionsBehavior.Editable = value;
                    //this._gridView.OptionsSelection.MultiSelect = value;

                    if(this.NeverShowEmbeddedNavigator)
                    {
                        this._gridControl.UseEmbeddedNavigator = false;
                    }
                    else
                    {
                        this._gridControl.UseEmbeddedNavigator = this._gridView.OptionsBehavior.Editable;
                    }
                }
            }
        }

        #endregion

        #region IApplyGridStyle Members

        public void ApplyStyle()
        {
            GridMenuFacade.ApplyGridStyle(this._gridControl);
        }

        #endregion

        #region Helper functions

        private Color GetColorByIndex(int index)
        {
            switch (index%5)
            {
                case 0:
                    return Color.LightSkyBlue;
                case 1:
                    return Color.LightCoral;
                case 2:
                    return Color.LightGreen;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.LightYellow;
                default:
                    return Color.LightGray;
            }
        }

        public List<object> GetSelectedRecords()
        {
            List<object> list = new List<object>();
            GridView view = this.GridControl.FocusedView as GridView;
            if (view == null || view.FocusedRowHandle < 0)
                return null;

            int[] rowHandles = view.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0)
                return list;

            for (int i = 0; i < rowHandles.Length; i++)
            {
                object entity = view.GetRow(rowHandles[i]);
                if (entity == null)
                    continue;

                list.Add(entity);
            }

            return list;
        }

        protected object GetFocusedRecord()
        {
            GridView view = this.GridControl.FocusedView as GridView;
            if (view == null || view.FocusedRowHandle < 0)
                return null;

            return view.GetRow(view.FocusedRowHandle);
        }
        #endregion
    }
}