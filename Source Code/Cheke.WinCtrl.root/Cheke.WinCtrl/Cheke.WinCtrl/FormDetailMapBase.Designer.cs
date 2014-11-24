namespace Cheke.WinCtrl
{
    partial class FormDetailMapBase
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
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding3 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding1 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCreatedTag = new DevExpress.XtraEditors.PanelControl();
            this.lblCreatedNotes = new DevExpress.XtraEditors.LabelControl();
            this.pnlModifiedTag = new DevExpress.XtraEditors.PanelControl();
            this.lblModifiedNotes = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCreatedTag)).BeginInit();
            this.pnlCreatedTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModifiedTag)).BeginInit();
            this.pnlModifiedTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(470, 299);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.lblPadding3);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.lblPadding1);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 345);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 3, 20, 3);
            this.pnlButtons.Size = new System.Drawing.Size(470, 35);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(199, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblPadding3
            // 
            this.lblPadding3.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding3.Location = new System.Drawing.Point(274, 5);
            this.lblPadding3.Name = "lblPadding3";
            this.lblPadding3.Size = new System.Drawing.Size(12, 25);
            this.lblPadding3.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(286, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPadding1
            // 
            this.lblPadding1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding1.Location = new System.Drawing.Point(361, 5);
            this.lblPadding1.Name = "lblPadding1";
            this.lblPadding1.Size = new System.Drawing.Size(12, 25);
            this.lblPadding1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(373, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCreatedTag
            // 
            this.pnlCreatedTag.Controls.Add(this.lblCreatedNotes);
            this.pnlCreatedTag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCreatedTag.Location = new System.Drawing.Point(0, 299);
            this.pnlCreatedTag.Name = "pnlCreatedTag";
            this.pnlCreatedTag.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.pnlCreatedTag.Size = new System.Drawing.Size(470, 23);
            this.pnlCreatedTag.TabIndex = 6;
            // 
            // lblCreatedNotes
            // 
            this.lblCreatedNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedNotes.Location = new System.Drawing.Point(12, 7);
            this.lblCreatedNotes.Name = "lblCreatedNotes";
            this.lblCreatedNotes.Size = new System.Drawing.Size(77, 13);
            this.lblCreatedNotes.TabIndex = 0;
            this.lblCreatedNotes.Text = "lblCreatedNotes";
            // 
            // pnlModifiedTag
            // 
            this.pnlModifiedTag.Controls.Add(this.lblModifiedNotes);
            this.pnlModifiedTag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModifiedTag.Location = new System.Drawing.Point(0, 322);
            this.pnlModifiedTag.Name = "pnlModifiedTag";
            this.pnlModifiedTag.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.pnlModifiedTag.Size = new System.Drawing.Size(470, 23);
            this.pnlModifiedTag.TabIndex = 5;
            // 
            // lblModifiedNotes
            // 
            this.lblModifiedNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedNotes.Location = new System.Drawing.Point(12, 7);
            this.lblModifiedNotes.Name = "lblModifiedNotes";
            this.lblModifiedNotes.Size = new System.Drawing.Size(78, 13);
            this.lblModifiedNotes.TabIndex = 1;
            this.lblModifiedNotes.Text = "lblModifiedNotes";
            // 
            // FormDetailMapBase
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(470, 380);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlCreatedTag);
            this.Controls.Add(this.pnlModifiedTag);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetailMapBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditMapBase";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCreatedTag)).EndInit();
            this.pnlCreatedTag.ResumeLayout(false);
            this.pnlCreatedTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModifiedTag)).EndInit();
            this.pnlModifiedTag.ResumeLayout(false);
            this.pnlModifiedTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl pnlContent;
        protected DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.PanelControl pnlCreatedTag;
        private DevExpress.XtraEditors.LabelControl lblCreatedNotes;
        private DevExpress.XtraEditors.PanelControl pnlModifiedTag;
        private DevExpress.XtraEditors.LabelControl lblModifiedNotes;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private System.Windows.Forms.Label lblPadding3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblPadding1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}
