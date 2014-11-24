namespace Cheke.WinCtrl
{
    partial class FormSelectBase
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding1 = new System.Windows.Forms.Label();
            this.pnlSearch = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(465, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(378, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(552, 240);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DataSourceChanged += new System.EventHandler(this.gridControl1_DataSourceChanged);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDetail);
            this.pnlButtons.Controls.Add(this.label1);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Controls.Add(this.lblPadding1);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 292);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlButtons.Size = new System.Drawing.Size(552, 40);
            this.pnlButtons.TabIndex = 10;
            // 
            // btnDetail
            // 
            this.btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetail.Enabled = false;
            this.btnDetail.Location = new System.Drawing.Point(99, 7);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 26);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "&Detail...";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(87, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 26);
            this.label1.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(12, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblPadding1
            // 
            this.lblPadding1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding1.Location = new System.Drawing.Point(453, 7);
            this.lblPadding1.Name = "lblPadding1";
            this.lblPadding1.Size = new System.Drawing.Size(12, 26);
            this.lblPadding1.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(552, 52);
            this.pnlSearch.TabIndex = 1;
            // 
            // FormSelectBase
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(552, 332);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSelectBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSelectBase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraEditors.PanelControl pnlSearch;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        protected DevExpress.XtraEditors.PanelControl pnlButtons;
        private System.Windows.Forms.Label lblPadding1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
