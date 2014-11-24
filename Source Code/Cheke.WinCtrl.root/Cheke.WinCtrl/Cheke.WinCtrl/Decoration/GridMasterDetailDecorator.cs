using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.Decoration
{
    public abstract class GridMasterDetailDecorator : GridControlDecorator
    {
        private const string ReadOnlyViewFlag = "ReadOnlyViewFlag";
        private const string EditableViewFlag = "EditableViewFlag";

        protected GridMasterDetailDecorator(string userId, GridControl gridControl)
            : base(userId, gridControl)
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            this.SetupDetailViewTree();
        }

        protected override void RegisterViewEvent()
        {
            base.RegisterViewEvent();

            this.GridView.MasterRowGetRelationName += GridView_MasterRowGetRelationName;
            this.GridView.MasterRowEmpty += GridView_MasterRowEmpty;
            this.GridView.MasterRowGetChildList += GridView_MasterRowGetChildList;
            this.GridView.MasterRowGetRelationCount += GridView_MasterRowGetRelationCount;
        }

        protected virtual void GridView_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        protected virtual void GridView_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
        }

        protected virtual void GridView_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        protected virtual void GridView_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
        }

        public override void GetTranslateString()
        {
            this.GetTranslateString(this.GridControl.LevelTree);
        }

        private void GetTranslateString(GridLevelNode parent)
        {
            GridView parentView = parent.LevelTemplate as GridView;
            if (parentView == null)
                return;

            this.GetTranslateString(parentView);
            if (parent.Nodes.Count == 0)
                return;

            foreach (GridLevelNode item in parent.Nodes)
            {
                GridView view = item.LevelTemplate as GridView;
                if(view == null)
                    continue;

                this.GetTranslateString(item);
            }
        }

        public override void Translate()
        {
            this.Translate(this.GridControl.LevelTree);
        }

        private void Translate(GridLevelNode parent)
        {
            GridView parentView = parent.LevelTemplate as GridView;
            if (parentView == null)
                return;

            this.Translate(parentView);
            if (parent.Nodes.Count == 0)
                return;

            foreach (GridLevelNode item in parent.Nodes)
            {
                GridView view = item.LevelTemplate as GridView;
                if (view == null)
                    continue;

                this.Translate(item);
            }
        }

        #region Detail View

        protected virtual void SetupDetailViewTree()
        {
        }

        protected GridLevelNode AddLevelTreeNode(string relationName, string caption, bool editable)
        {
            return this.AddLevelTreeNode(this.GridControl.LevelTree, relationName, caption, editable);
        }

        protected GridLevelNode AddLevelTreeNode(GridLevelNode parent, string relationName, string caption,
                                                 bool editable)
        {
            GridLevelNode child = parent.Nodes[relationName];
            if (child == null)
            {
                GridView detailView = this.CreateDetailView(caption, editable);
                child = parent.Nodes.Add(relationName, detailView);
            }

            this.SetParentViewProperties(parent.LevelTemplate as GridView);

            return child;
        }

        private void SetParentViewProperties(GridView view)
        {
            view.OptionsDetail.EnableMasterViewMode = true;
            view.OptionsDetail.EnableDetailToolTip = true;
            view.OptionsDetail.ShowDetailTabs = true;
            view.OptionsDetail.SmartDetailExpand = true;
            view.OptionsDetail.AllowExpandEmptyDetails = true;

            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsNavigation.EnterMoveNextColumn = true;
            view.OptionsCustomization.AllowFilter = true;
        }

        private GridView CreateDetailView(string caption, bool editable)
        {
            GridView detailView = new GridView(this.GridControl);
            detailView.ViewCaption = caption;
            detailView.DetailHeight = 1000; // always show all the available rows which fit in the grid control

            if (editable)
            {
                detailView.Name += EditableViewFlag;
            }
            else
            {
                detailView.Name += ReadOnlyViewFlag;
            }

            detailView.OptionsBehavior.Editable = editable;
            detailView.OptionsView.ColumnAutoWidth = false;
            detailView.OptionsNavigation.EnterMoveNextColumn = true;

            detailView.OptionsDetail.EnableMasterViewMode = false;
            detailView.OptionsDetail.EnableDetailToolTip = true;
            detailView.OptionsDetail.ShowDetailTabs = true;
            detailView.OptionsDetail.SmartDetailExpand = true;
            //detailView.OptionsDetail.AutoZoomDetail = true;
            detailView.OptionsDetail.AllowZoomDetail = true;

            this.RegisterBasicViewEvent(detailView);
            this.AddDetailConditions(detailView);

            return detailView;
        }

        protected virtual void AddDetailConditions(GridView detailView)
        {
            this.AddConditionsColumns(detailView);
            this.AddConditionsStyle(detailView);
        }

        #endregion

        #region Editable

        public override bool Editable
        {
            get { return this.GridView.OptionsBehavior.Editable; }
            set
            {
                //if (value != this.GridView.OptionsBehavior.Editable)
                {
                    this.GridView.OptionsBehavior.Editable = value;
                    //this.GridView.OptionsSelection.MultiSelect = value;

                    foreach (GridLevelNode item in this.GridControl.LevelTree.Nodes)
                    {
                        this.SetNodeEditable(item, value);
                    }

                    GridView focusView = this.GridControl.FocusedView as GridView;
                    if (focusView != null)
                    {
                        this.GridControl.UseEmbeddedNavigator = focusView.OptionsBehavior.Editable;
                    }
                }
            }
        }

        private void SetNodeEditable(GridLevelNode parent, bool editable)
        {
            GridView viewParent = parent.LevelTemplate as GridView;
            if (viewParent != null && viewParent.Name.EndsWith(EditableViewFlag))
            {
                viewParent.OptionsBehavior.Editable = editable;
                //viewParent.OptionsSelection.MultiSelect = editable;
            }

            if (parent.Nodes.Count == 0)
                return;

            foreach (GridLevelNode item in parent.Nodes)
            {
                GridView view = item.LevelTemplate as GridView;
                if (view != null && view.Name.EndsWith(EditableViewFlag))
                {
                    view.OptionsBehavior.Editable = editable;
                    //view.OptionsSelection.MultiSelect = editable;
                }

                this.SetNodeEditable(item, editable);
            }
        }

        #endregion
    }
}