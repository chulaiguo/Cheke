using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.GridControlBuddy;
using Cheke.WinCtrl.GridGroupBuddy;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Cheke.WinCtrl.GridControlCommand;

namespace Cheke.WinCtrl.Decoration
{
    public abstract class GridGroupControlDecorator : DecoratorBase, IApplyGridStyle
    {
        protected GridGroupControl _gridGroupControl = null;
        private IRightEditor _rightEditor = null;
        private string _userId = string.Empty;

        private GridMenuController _leftMenuController = null;
        private GridMenuController _rightMenuController = null;

        public GridGroupControlDecorator(string userId, GridGroupControl gridGroupControl)
        {
            this._userId = userId;
            this._gridGroupControl = gridGroupControl;
        }

        public override void Initialize()
        {
            //user
            this._gridGroupControl.SetUserId(this._userId);

            //columns
            this.SetLeftDisplayColumns(this._gridGroupControl.GridViewLeft);
            this.SetRightDisplayColumns(this._gridGroupControl.GridViewRight);

            //properties
            this.SetProperties(this._gridGroupControl.GridControlLeft);
            this.SetProperties(this._gridGroupControl.GridControlRight);
            this._gridGroupControl.GridViewRight.OptionsBehavior.Editable = true;

            //Conditions
            this.AddConditionsColumns(this._gridGroupControl.GridViewRight);
            this.AddConditionsStyle(this._gridGroupControl.GridViewRight);

            //menu
            this.RegisterContextMenu();

            //control events
            this.RegisterControlEvent();

            //delegate
            this._gridGroupControl.GroupOperator.CreateRightEntity = new CreateRightEntityDelegate(CreateRightEntity);
            this._gridGroupControl.GroupOperator.CompareEntity = new CompareEntityDelegate(CompareEntity);
            this._gridGroupControl.GroupOperator.CanMoveLeftToRight = new CanMoveLeftToRightDelegate(CanMoveLeftToRight);
            this._gridGroupControl.GroupOperator.CanMoveRightToLeft = new CanMoveRightToLeftDelegate(CanMoveRightToLeft);


            //Tooltip
            this.SetupTooltip();

            //style
            this.ApplyStyle();
        }

        public void SetDataSource(BusinessCollectionBase left, BusinessCollectionBase right)
        {
            this._gridGroupControl.SetDataSource(this._userId, left, right);
        }

        public virtual bool ReplaceData(BusinessBase entity)
        {
            return this._gridGroupControl.GroupOperator.ReplaceData(entity);
        }

        protected virtual void SetProperties(GridControl gridControl)
        {
            GridView view = gridControl.MainView as GridView;
            if (view == null)
                return;

            //Control
            gridControl.AllowDrop = true;
            gridControl.UseEmbeddedNavigator = false;
            gridControl.ShowOnlyPredefinedDetails = true;

            gridControl.LookAndFeel.Style = LookAndFeelStyle.Skin;
            gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            gridControl.LookAndFeel.UseWindowsXPTheme = false;

            //View
            view.OptionsBehavior.Editable = false;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsMenu.EnableColumnMenu = false;

            view.OptionsSelection.MultiSelect = true;
            view.OptionsSelection.EnableAppearanceFocusedRow = true;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            view.OptionsSelection.InvertSelection = false;

            view.OptionsDetail.EnableMasterViewMode = false;
            view.OptionsNavigation.EnterMoveNextColumn = false;
            view.OptionsCustomization.AllowFilter = false;
        }

        protected virtual void AddConditionsColumns(GridView view)
        {
            ConditionsStyleCommand.AddConditionsColumns(view);
        }

        protected virtual void AddConditionsStyle(GridView view)
        {
            ConditionsStyleCommand.AddConditionsStyle(view);
        }

        protected virtual void RegisterControlEvent()
        {
            this._gridGroupControl.GridControlRight.DataSourceChanged +=
                new EventHandler(RightGridControl_DataSourceChanged);

            this._gridGroupControl.GridViewLeft.DoubleClick += new EventHandler(GridViewLeft_DoubleClick);
            this._gridGroupControl.GridViewRight.DoubleClick += new EventHandler(GridViewRight_DoubleClick);
        }

        public virtual bool Editable
        {
            get { return this._gridGroupControl.Editable; }
            set
            {
                if (this._rightEditor != null)
                {
                    this._rightEditor.Editable = value;
                }

                this._gridGroupControl.Editable = value;
            }
        }
        
        public string UserId
        {
            get { return _userId; }
        }

        #region Tooltip

        private void SetupTooltip()
        {
            ToolTipController.DefaultController.GetActiveObjectInfo +=
                new ToolTipControllerGetActiveObjectInfoEventHandler(DefaultController_GetActiveObjectInfo);
        }

        protected virtual void DefaultController_GetActiveObjectInfo(object sender,
                                                                     ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            GridControl control = e.SelectedControl as GridControl;
            if (control == null)
                return;

            GridView view = control.GetViewAt(e.ControlMousePosition) as GridView;
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
                if (col.OptionsColumn.ShowInCustomizationForm)
                    continue;

                writer.WriteLine("{0}: {1}", col.Caption, view.GetRowCellDisplayText(rowHandle, col));
            }

            return writer.ToString();
        }

        #endregion

        #region context menu
        protected GridMenuController LeftMenuController
        {
            get { return _leftMenuController; }
        }

        protected GridMenuController RightMenuController
        {
            get { return _rightMenuController; }
        } 
        
        protected virtual void RegisterContextMenu()
        {
            this._leftMenuController = new GridMenuController(this._userId, this._gridGroupControl.GridControlLeft);
            this._leftMenuController.MenuOptions.ShowEditMenu = false;
            this._leftMenuController.RegisterContextMenu();

            this._rightMenuController = new GridMenuController(this._userId, this._gridGroupControl.GridControlRight);
            this._rightMenuController.MenuOptions.ShowEditMenu = false;
            this._rightMenuController.RegisterContextMenu();
        }
        #endregion

        #region Double click
        private void GridViewLeft_DoubleClick(object sender, EventArgs e)
        {
            if (this.DetailFormType == null)
                return;

            GridView view = this._gridGroupControl.GridViewLeft;
            BusinessBase left = view.GetRow(view.FocusedRowHandle) as BusinessBase;
            if (left == null)
                return;

            ShowDetailForm(left);
        }

        private void GridViewRight_DoubleClick(object sender, EventArgs e)
        {
            if (this.DetailFormType == null)
                return;

            GridView view = this._gridGroupControl.GridViewRight;
            BusinessBase right = view.GetRow(view.FocusedRowHandle) as BusinessBase;
            if (right == null)
                return;

            BusinessBase left = this._gridGroupControl.GroupOperator.GetLeftByRight(right);
            if (left == null)
                return;

            ShowDetailForm(left);
        }

        protected virtual Type DetailFormType
        {
            get { return null; }
        }

        private void ShowDetailForm(BusinessBase entity)
        {
            if (this.DetailFormType.IsSubclassOf(typeof(FormDetailEditorBase)))
            {
                Form dlg = (Form)Activator.CreateInstance(this.DetailFormType,
                                                           new object[]
                                                               {
                                                                   this._userId, entity.Clone()
                                                               });
                dlg.ShowDialog();
            }
            else if (this.DetailFormType.IsSubclassOf(typeof(FormWorkEditorBase)))
            {
                if (FormMainBase.Instance.HasTopLevelForm())
                {
                    Form dlg = (Form)Activator.CreateInstance(this.DetailFormType,
                                                         new object[]
                                                             {
                                                                 this._userId, null, 
                                                                 entity.Clone()
                                                             });
                    dlg.ShowDialog();
                }
                else
                {
                    FormMainBase.Instance.ShowChildForm(this.DetailFormType, entity.Clone() as BusinessBase);                              
                }
            }
        }
        #endregion

        #region Focused entity changed

        public BindingManagerBase RightCurrencyManager
        {
            get
            {
                return this._gridGroupControl.GridControlRight.BindingContext[
                    this._gridGroupControl.GridControlRight.DataSource];
            }
        }

        public BindingManagerBase LeftCurrencyManager
        {
            get
            {
                return this._gridGroupControl.GridControlLeft.BindingContext[
                    this._gridGroupControl.GridControlLeft.DataSource];
            }
        }

        private void RightGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (this._rightEditor == null)
                return;

            BusinessCollectionBase list = this._gridGroupControl.GridControlRight.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            this.RightCurrencyManager.CurrentChanged -= new EventHandler(rightCurrencyManager_CurrentChanged);
            this.RightCurrencyManager.CurrentChanged += new EventHandler(rightCurrencyManager_CurrentChanged);
            if (list.Count > 0)
            {
                this.FocusedRightEntityChanged(list[0]);
            }
            else
            {
                this.FocusedRightEntityChanged(null);
            }
        }

        private void rightCurrencyManager_CurrentChanged(object sender, EventArgs e)
        {
            if (this.RightCurrencyManager.Count > 0)
            {
                this.FocusedRightEntityChanged(this.RightCurrencyManager.Current);
            }
            else
            {
                this.FocusedRightEntityChanged(null);
            }
        }

        protected virtual void FocusedRightEntityChanged(object entity)
        {
            this._rightEditor.BindingData(entity);
        }
        #endregion

        #region Group operation

        public void SetRightEditor(IRightEditor editor)
        {
            this._rightEditor = editor;
            this._gridGroupControl.SetRightEditor(editor);
        }

        protected abstract void SetLeftDisplayColumns(GridView view);
        protected abstract void SetRightDisplayColumns(GridView view);

        public virtual void GetTranslateString(Type frmType)
        {
            string thisTypeName = this.GetType().Name;
            string key = string.Format("{0}|{1}|Left", frmType.Name, thisTypeName);
            Cheke.Translation.Translator.Instance.AddTranslateString(key, this._gridGroupControl.LeftCaption);
            key = string.Format("{0}|{1}|Right", frmType.Name, thisTypeName);
            Cheke.Translation.Translator.Instance.AddTranslateString(key, this._gridGroupControl.RightCaption);

            foreach (GridColumn item in this._gridGroupControl.GridViewLeft.Columns)
            {
                key = string.Format("{0}|{1}", thisTypeName, item.FieldName);
                Cheke.Translation.Translator.Instance.AddTranslateString(key, item.Caption);
            }

            foreach (GridColumn item in this._gridGroupControl.GridViewRight.Columns)
            {
                key = string.Format("{0}|{1}", thisTypeName, item.FieldName);
                Cheke.Translation.Translator.Instance.AddTranslateString(key, item.Caption);
            }
        }

        public virtual void Translate(Type frmType)
        {
            string thisTypeName = this.GetType().Name;
            string key = string.Format("{0}|{1}|Left", frmType.Name, thisTypeName);
            string translate = Cheke.Translation.Translator.Instance.Translate(key);
            if (translate.Length > 0)
            {
                this._gridGroupControl.LeftCaption = translate;
            }

            key = string.Format("{0}|{1}|Right", frmType.Name, thisTypeName);
            translate = Cheke.Translation.Translator.Instance.Translate(key);
            if (translate.Length > 0)
            {
                this._gridGroupControl.RightCaption = translate;
            }

            foreach (GridColumn item in this._gridGroupControl.GridViewLeft.Columns)
            {
                key = string.Format("{0}|{1}", thisTypeName, item.FieldName);
                translate = Cheke.Translation.Translator.Instance.Translate(key);
                if (translate.Length > 0)
                {
                    item.Caption = translate;
                }
            }

            foreach (GridColumn item in this._gridGroupControl.GridViewRight.Columns)
            {
                key = string.Format("{0}|{1}", thisTypeName, item.FieldName);
                translate = Cheke.Translation.Translator.Instance.Translate(key);
                if (translate.Length > 0)
                {
                    item.Caption = translate;
                }
            }
        }

        protected abstract BusinessBase CreateRightEntity(BusinessBase leftEntity);
        protected abstract bool CompareEntity(BusinessBase left, BusinessBase right);

        protected virtual bool CanMoveLeftToRight(BusinessBase left)
        {
            return true;
        }

        protected virtual bool CanMoveRightToLeft(BusinessBase right)
        {
            return true;
        }
        #endregion

        #region IApplyGridStyle Members

        public void ApplyStyle()
        {
            this._gridGroupControl.ApplyStyle();
        }

        #endregion
    }
}