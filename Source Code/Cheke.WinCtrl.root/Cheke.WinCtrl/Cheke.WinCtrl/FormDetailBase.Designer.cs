namespace Cheke.WinCtrl
{
    partial class FormDetailBase
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
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding4 = new System.Windows.Forms.Label();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding2 = new System.Windows.Forms.Label();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding3 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblPadding1 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(470, 345);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnNew);
            this.pnlButtons.Controls.Add(this.lblPadding4);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.lblPadding2);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.lblPadding3);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.lblPadding1);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 345);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.pnlButtons.Size = new System.Drawing.Size(470, 35);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNew.Location = new System.Drawing.Point(35, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 25);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblPadding4
            // 
            this.lblPadding4.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding4.Location = new System.Drawing.Point(110, 5);
            this.lblPadding4.Name = "lblPadding4";
            this.lblPadding4.Size = new System.Drawing.Size(12, 25);
            this.lblPadding4.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Location = new System.Drawing.Point(122, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPadding2
            // 
            this.lblPadding2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding2.Location = new System.Drawing.Point(197, 5);
            this.lblPadding2.Name = "lblPadding2";
            this.lblPadding2.Size = new System.Drawing.Size(12, 25);
            this.lblPadding2.TabIndex = 11;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(209, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblPadding3
            // 
            this.lblPadding3.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding3.Location = new System.Drawing.Point(284, 5);
            this.lblPadding3.Name = "lblPadding3";
            this.lblPadding3.Size = new System.Drawing.Size(12, 25);
            this.lblPadding3.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(296, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPadding1
            // 
            this.lblPadding1.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPadding1.Location = new System.Drawing.Point(371, 5);
            this.lblPadding1.Name = "lblPadding1";
            this.lblPadding1.Size = new System.Drawing.Size(12, 25);
            this.lblPadding1.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(383, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormDetailBase
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(470, 380);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetailBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormDialogBase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl pnlContent;
        private System.Windows.Forms.Label lblPadding2;
        private System.Windows.Forms.Label lblPadding1;
        protected DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Label lblPadding4;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Label lblPadding3;
    }
}
