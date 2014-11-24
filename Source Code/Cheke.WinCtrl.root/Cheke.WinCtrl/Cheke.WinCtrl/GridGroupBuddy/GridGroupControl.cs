using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Cheke.WinCtrl.GridControlCommand;

namespace Cheke.WinCtrl.GridGroupBuddy
{
    [ToolboxItem(true)]
    public partial class GridGroupControl : UserControlBase, IRefreshGridViewData
    {
        private GroupOperator _groupOperator = null;
        private GridHitInfo _hitInfo = null;

        public GridGroupControl()
        {
            InitializeComponent();
            this._groupOperator = new GroupOperator(this.gridControlLeft, this.gridControlRight);
        }

        public void SetDataSource(string userId, BusinessCollectionBase left, BusinessCollectionBase right)
        {
            this._groupOperator.SetDataSource(userId, left, right);
        }

        public void SetRightEditor(IRightEditor editor)
        {
            if (editor != null)
            {
                this.pnlRightEditor.Visible = true;
                editor.SetParent(this.pnlRightEditor);
            }
            else
            {
                this.pnlRightEditor.Visible = false;
                this.pnlRightEditor.Controls.Clear();
            }
        }

        public void SetUserId(string userId)
        {
            this.gridControlLeft.Tag = userId;
            this.gridControlRight.Tag = userId;
        }

        public void ApplyStyle()
        {
            GridMenuFacade.ApplyGridStyle(this.gridControlLeft);
            GridMenuFacade.ApplyGridStyle(this.gridControlRight);            
        }

        #region Properties
        
        [Browsable(false)]
        [DefaultValue(true)]
        public bool Editable
        {
            get
            {
                 return this.btnToRight.Enabled || this.btnToLeft.Enabled;
            }
            set
            {
                this.btnToRight.Enabled = value;
                this.btnToLeft.Enabled = value;

                this.gridControlLeft.AllowDrop = value;
                this.gridControlRight.AllowDrop = value;
                this.gridViewRight.OptionsBehavior.Editable = value;
            }
        }

        [Browsable(false)]
        public GridControl GridControlLeft
        {
            get { return this.gridControlLeft; }
        }

        [Browsable(false)]
        public GridControl GridControlRight
        {
            get { return this.gridControlRight; }
        }

        [Browsable(false)]
        public GridView GridViewLeft
        {
            get { return this.gridControlLeft.MainView as GridView; }
        }

        [Browsable(false)]
        public GridView GridViewRight
        {
            get { return this.gridControlRight.MainView as GridView; }
        }

        [Browsable(false)]
        public GroupOperator GroupOperator
        {
            get { return this._groupOperator; }
        }

        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue("Left")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LeftCaption
        {
            get { return this.splitContainer1.Panel1.Text; }
            set { this.splitContainer1.Panel1.Text = value; }
        }

        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue("Right")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string RightCaption
        {
            get { return this.splitContainer2.Panel2.Text; }
            set { this.splitContainer2.Panel2.Text = value; }
        }

        #endregion

        #region Event Handler

        private void GridGroupControl_Resize(object sender, EventArgs e)
        {
            this.btnToRight.Width = 68;
            this.btnToLeft.Width = 68;

            this.splitContainer1.SplitterPosition = this.splitContainer1.Width / 2 - this.btnToRight.Width + 8;
            this.splitContainer2.SplitterPosition = this.btnToRight.Width + 8;
            this.splitContainer2.Panel1.MinSize = this.splitContainer2.SplitterPosition;

            this.btnToRight.Top = this.splitContainer2.Top + this.splitContainer2.Height/4 - this.btnToRight.Height/2;
            this.btnToLeft.Top = this.splitContainer2.Top + (this.splitContainer2.Height/4)*3 - this.btnToLeft.Height/2;
            this.btnToRight.Left = this.splitContainer2.Left + 4;
            this.btnToLeft.Left = this.splitContainer2.Left + 4;
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            this._groupOperator.MoveLeftToRight();
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            this._groupOperator.MoveRightToLeft();
        }

        #endregion

        #region Drag and Drop

        private void GridControl_MouseDown(object sender, MouseEventArgs e)
        {
            GridControl gridControl = sender as GridControl;
            if (gridControl == null)
                return;

            GridView view = gridControl.MainView as GridView;
            if (view == null)
                return;

            this._hitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                this._hitInfo = hitInfo;
        }

        private void GridControl_MouseMove(object sender, MouseEventArgs e)
        {
            GridControl gridControl = sender as GridControl;
            if (gridControl == null)
                return;

            GridView view = gridControl.MainView as GridView;
            if (view == null)
                return;

            if (e.Button == MouseButtons.Left && this._hitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(this._hitInfo.HitPoint.X - dragSize.Width/2,
                                                             this._hitInfo.HitPoint.Y - dragSize.Height/2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(gridControl.Name, DragDropEffects.All);
                    this._hitInfo = null;
                }
            }
        }

        private void GridControl_DragDrop(object sender, DragEventArgs e)
        {
            GridControl gridControl = sender as GridControl;
            if (gridControl == null)
                return;

            //copy self is NOT allowed.
            if (gridControl.Name == (string) e.Data.GetData(typeof (string)))
            {
                return;
            }

            if (gridControl.Name == this.gridControlLeft.Name)
                this.btnToLeft.PerformClick();
            else if (gridControl.Name == this.gridControlRight.Name)
                this.btnToRight.PerformClick();
        }

        private void GridControl_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void GridControl_ControlDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion

        #region IRefreshGridViewData Members

        public void RefrshGridViewData(GridView view)
        {
            if (view == this.gridViewLeft)
            {
                BusinessCollectionBase list = this.gridControlRight.DataSource as BusinessCollectionBase;
                if (list == null)
                    return;

                if (list.IsDirty && DialogResult.Yes != GridMenuFacade.ShowRefreshWarning())
                    return;
            }

            GridMenuFacade.RefreshData(this.gridViewRight, this.Parent);
        }

        #endregion
    }
}