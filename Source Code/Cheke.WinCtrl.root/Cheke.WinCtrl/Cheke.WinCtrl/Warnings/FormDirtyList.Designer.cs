namespace Cheke.WinCtrl.Warnings
{
    partial class FormDirtyList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabUpdatingList = new DevExpress.XtraTab.XtraTabPage();
            this.grdUpdaingList = new DevExpress.XtraGrid.GridControl();
            this.grdUpdaingListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabInsertingList = new DevExpress.XtraTab.XtraTabPage();
            this.grdInsertingList = new DevExpress.XtraGrid.GridControl();
            this.grdInsertingListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabDeletingList = new DevExpress.XtraTab.XtraTabPage();
            this.grdDeletingList = new DevExpress.XtraGrid.GridControl();
            this.grdDeletingListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabUpdatingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdaingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdaingListView)).BeginInit();
            this.tabInsertingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertingListView)).BeginInit();
            this.tabDeletingList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeletingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeletingListView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 409);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBottom.Size = new System.Drawing.Size(693, 38);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(611, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabUpdatingList;
            this.xtraTabControl1.Size = new System.Drawing.Size(693, 409);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabUpdatingList,
            this.tabInsertingList,
            this.tabDeletingList});
            // 
            // tabUpdatingList
            // 
            this.tabUpdatingList.Controls.Add(this.grdUpdaingList);
            this.tabUpdatingList.Name = "tabUpdatingList";
            this.tabUpdatingList.Size = new System.Drawing.Size(686, 380);
            this.tabUpdatingList.Text = "Updating List";
            // 
            // grdUpdaingList
            // 
            this.grdUpdaingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUpdaingList.Location = new System.Drawing.Point(0, 0);
            this.grdUpdaingList.MainView = this.grdUpdaingListView;
            this.grdUpdaingList.Name = "grdUpdaingList";
            this.grdUpdaingList.Size = new System.Drawing.Size(686, 380);
            this.grdUpdaingList.TabIndex = 0;
            this.grdUpdaingList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdUpdaingListView});
            // 
            // grdUpdaingListView
            // 
            this.grdUpdaingListView.GridControl = this.grdUpdaingList;
            this.grdUpdaingListView.Name = "grdUpdaingListView";
            // 
            // tabInsertingList
            // 
            this.tabInsertingList.Controls.Add(this.grdInsertingList);
            this.tabInsertingList.Name = "tabInsertingList";
            this.tabInsertingList.Size = new System.Drawing.Size(686, 380);
            this.tabInsertingList.Text = "Inserting List";
            // 
            // grdInsertingList
            // 
            this.grdInsertingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInsertingList.Location = new System.Drawing.Point(0, 0);
            this.grdInsertingList.MainView = this.grdInsertingListView;
            this.grdInsertingList.Name = "grdInsertingList";
            this.grdInsertingList.Size = new System.Drawing.Size(686, 380);
            this.grdInsertingList.TabIndex = 1;
            this.grdInsertingList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdInsertingListView});
            // 
            // grdInsertingListView
            // 
            this.grdInsertingListView.GridControl = this.grdInsertingList;
            this.grdInsertingListView.Name = "grdInsertingListView";
            // 
            // tabDeletingList
            // 
            this.tabDeletingList.Controls.Add(this.grdDeletingList);
            this.tabDeletingList.Name = "tabDeletingList";
            this.tabDeletingList.Size = new System.Drawing.Size(686, 380);
            this.tabDeletingList.Text = "Deleting List";
            // 
            // grdDeletingList
            // 
            this.grdDeletingList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDeletingList.Location = new System.Drawing.Point(0, 0);
            this.grdDeletingList.MainView = this.grdDeletingListView;
            this.grdDeletingList.Name = "grdDeletingList";
            this.grdDeletingList.Size = new System.Drawing.Size(686, 380);
            this.grdDeletingList.TabIndex = 1;
            this.grdDeletingList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdDeletingListView});
            // 
            // grdDeletingListView
            // 
            this.grdDeletingListView.GridControl = this.grdDeletingList;
            this.grdDeletingListView.Name = "grdDeletingListView";
            // 
            // FormDirtyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 447);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.pnlBottom);
            this.MinimizeBox = false;
            this.Name = "FormDirtyList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List";
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabUpdatingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdaingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUpdaingListView)).EndInit();
            this.tabInsertingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertingListView)).EndInit();
            this.tabDeletingList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDeletingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDeletingListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabUpdatingList;
        private DevExpress.XtraTab.XtraTabPage tabInsertingList;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraTab.XtraTabPage tabDeletingList;
        private DevExpress.XtraGrid.GridControl grdUpdaingList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdUpdaingListView;
        private DevExpress.XtraGrid.GridControl grdInsertingList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdInsertingListView;
        private DevExpress.XtraGrid.GridControl grdDeletingList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdDeletingListView;
    }
}