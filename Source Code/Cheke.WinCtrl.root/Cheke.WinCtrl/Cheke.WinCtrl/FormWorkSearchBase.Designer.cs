namespace Cheke.WinCtrl
{
    partial class FormWorkSearchBase
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
            this.pnlSearchCriteria = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblPadding = new System.Windows.Forms.Label();
            this.btnLoadNextPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadAll = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.label3);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.label2);
            this.pnlButtons.Controls.Add(this.btnLoadAll);
            this.pnlButtons.Controls.Add(this.label1);
            this.pnlButtons.Controls.Add(this.btnLoadNextPage);
            this.pnlButtons.Controls.Add(this.lblPadding);
            this.pnlButtons.Location = new System.Drawing.Point(0, 458);
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.pnlButtons.Size = new System.Drawing.Size(839, 34);
            this.pnlButtons.Controls.SetChildIndex(this.lblPadding, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnLoadNextPage, 0);
            this.pnlButtons.Controls.SetChildIndex(this.label1, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnLoadAll, 0);
            this.pnlButtons.Controls.SetChildIndex(this.label2, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlButtons.Controls.SetChildIndex(this.label3, 0);
            this.pnlButtons.Controls.SetChildIndex(this.btnNew, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.gridControl1);
            this.pnlContent.Controls.Add(this.pnlSearchCriteria);
            this.pnlContent.Size = new System.Drawing.Size(839, 426);
            // 
            // pnlSearchCriteria
            // 
            this.pnlSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchCriteria.Location = new System.Drawing.Point(2, 2);
            this.pnlSearchCriteria.Name = "pnlSearchCriteria";
            this.pnlSearchCriteria.Size = new System.Drawing.Size(835, 87);
            this.pnlSearchCriteria.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 89);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(835, 335);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // lblPadding
            // 
            this.lblPadding.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPadding.Location = new System.Drawing.Point(164, 5);
            this.lblPadding.Name = "lblPadding";
            this.lblPadding.Size = new System.Drawing.Size(12, 24);
            this.lblPadding.TabIndex = 27;
            // 
            // btnLoadNextPage
            // 
            this.btnLoadNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadNextPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadNextPage.Enabled = false;
            this.btnLoadNextPage.Location = new System.Drawing.Point(176, 5);
            this.btnLoadNextPage.Name = "btnLoadNextPage";
            this.btnLoadNextPage.Size = new System.Drawing.Size(99, 24);
            this.btnLoadNextPage.TabIndex = 28;
            this.btnLoadNextPage.Text = "&Load Next Page";
            this.btnLoadNextPage.Visible = false;
            this.btnLoadNextPage.Click += new System.EventHandler(this.btnLoadNextPage_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadAll.Enabled = false;
            this.btnLoadAll.Location = new System.Drawing.Point(287, 5);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(88, 24);
            this.btnLoadAll.TabIndex = 29;
            this.btnLoadAll.Text = "Load &All";
            this.btnLoadAll.Visible = false;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(275, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 24);
            this.label1.TabIndex = 30;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Location = new System.Drawing.Point(404, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 24);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "&New";
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(566, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 24);
            this.label2.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(479, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 24);
            this.label3.TabIndex = 38;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(491, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 24);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FormWorkSearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(839, 492);
            this.Name = "FormWorkSearchBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormWorkSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraEditors.PanelControl pnlSearchCriteria;
        private System.Windows.Forms.Label lblPadding;
        private DevExpress.XtraEditors.SimpleButton btnLoadAll;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnLoadNextPage;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
