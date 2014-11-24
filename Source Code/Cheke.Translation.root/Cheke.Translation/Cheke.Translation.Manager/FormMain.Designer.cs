namespace Cheke.Translation.Manager
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnMergeOldFile = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding3 = new System.Windows.Forms.Label();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding2 = new System.Windows.Forms.Label();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(729, 439);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnMergeOldFile);
            this.pnlBottom.Controls.Add(this.lblPadding3);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.lblPadding2);
            this.pnlBottom.Controls.Add(this.btnNew);
            this.pnlBottom.Controls.Add(this.lblPadding);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnImport);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 439);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlBottom.Size = new System.Drawing.Size(729, 46);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnMergeOldFile
            // 
            this.btnMergeOldFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMergeOldFile.Location = new System.Drawing.Point(351, 7);
            this.btnMergeOldFile.Name = "btnMergeOldFile";
            this.btnMergeOldFile.Size = new System.Drawing.Size(93, 32);
            this.btnMergeOldFile.TabIndex = 6;
            this.btnMergeOldFile.Text = "Merge";
            this.btnMergeOldFile.Click += new System.EventHandler(this.btnMergeOldFile_Click);
            // 
            // lblPadding3
            // 
            this.lblPadding3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPadding3.Location = new System.Drawing.Point(331, 7);
            this.lblPadding3.Name = "lblPadding3";
            this.lblPadding3.Size = new System.Drawing.Size(20, 32);
            this.lblPadding3.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Location = new System.Drawing.Point(238, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 32);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPadding2
            // 
            this.lblPadding2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPadding2.Location = new System.Drawing.Point(218, 7);
            this.lblPadding2.Name = "lblPadding2";
            this.lblPadding2.Size = new System.Drawing.Size(20, 32);
            this.lblPadding2.TabIndex = 5;
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Location = new System.Drawing.Point(125, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(93, 32);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblPadding
            // 
            this.lblPadding.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPadding.Location = new System.Drawing.Point(105, 7);
            this.lblPadding.Name = "lblPadding";
            this.lblPadding.Size = new System.Drawing.Size(20, 32);
            this.lblPadding.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(624, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.Location = new System.Drawing.Point(12, 7);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 32);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 485);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Translation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Label lblPadding;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Label lblPadding2;
        private DevExpress.XtraEditors.SimpleButton btnMergeOldFile;
        private System.Windows.Forms.Label lblPadding3;
    }
}