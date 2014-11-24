namespace Cheke.WinCtrl
{
    partial class FormWorkBase
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
            this.pnlCaption = new DevExpress.XtraEditors.PanelControl();
            this.imgClose = new System.Windows.Forms.PictureBox();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.lblPaddingImport = new System.Windows.Forms.Label();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding3 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding1 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaption)).BeginInit();
            this.pnlCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.imgClose);
            this.pnlCaption.Controls.Add(this.lblCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(748, 32);
            this.pnlCaption.TabIndex = 0;
            // 
            // imgClose
            // 
            this.imgClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.imgClose.Image = global::Cheke.WinCtrl.Properties.Resources.Closebutton;
            this.imgClose.Location = new System.Drawing.Point(718, 2);
            this.imgClose.Name = "imgClose";
            this.imgClose.Size = new System.Drawing.Size(28, 28);
            this.imgClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgClose.TabIndex = 2;
            this.imgClose.TabStop = false;
            this.imgClose.Click += new System.EventHandler(this.imgClose_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Location = new System.Drawing.Point(2, 6);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(63, 19);
            this.lblCaption.TabIndex = 0;
            this.lblCaption.Text = "Caption";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnImport);
            this.pnlButtons.Controls.Add(this.lblPaddingImport);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.lblPadding3);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.lblPadding1);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 451);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlButtons.Size = new System.Drawing.Size(748, 34);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnImport.Enabled = true;
            this.btnImport.Location = new System.Drawing.Point(99, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 24);
            this.btnImport.TabIndex = 25;
            this.btnImport.Text = "&Import";
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblPaddingImport
            // 
            this.lblPaddingImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPaddingImport.Location = new System.Drawing.Point(87, 5);
            this.lblPaddingImport.Name = "lblPaddingImport";
            this.lblPaddingImport.Size = new System.Drawing.Size(12, 24);
            this.lblPaddingImport.TabIndex = 26;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Enabled = true;
            this.btnEdit.Location = new System.Drawing.Point(487, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 24);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblPadding3
            // 
            this.lblPadding3.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding3.Location = new System.Drawing.Point(562, 5);
            this.lblPadding3.Name = "lblPadding3";
            this.lblPadding3.Size = new System.Drawing.Size(12, 24);
            this.lblPadding3.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Enabled = true;
            this.btnSave.Location = new System.Drawing.Point(574, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPadding1
            // 
            this.lblPadding1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding1.Location = new System.Drawing.Point(649, 5);
            this.lblPadding1.Name = "lblPadding1";
            this.lblPadding1.Size = new System.Drawing.Size(12, 24);
            this.lblPadding1.TabIndex = 20;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(661, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Enabled = true;
            this.btnRefresh.Location = new System.Drawing.Point(12, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 32);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(748, 419);
            this.pnlContent.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormWorkBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(748, 485);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlCaption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormWorkBase";
            this.ShowInTaskbar = false;
            this.Text = "FormWorkBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormWorkBase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaption)).EndInit();
            this.pnlCaption.ResumeLayout(false);
            this.pnlCaption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlCaption;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        protected DevExpress.XtraEditors.PanelControl pnlButtons;
        protected DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.Label lblPadding3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblPadding1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.Label lblPaddingImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox imgClose;
    }
}
