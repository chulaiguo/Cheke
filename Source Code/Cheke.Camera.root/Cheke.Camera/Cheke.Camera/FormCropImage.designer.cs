namespace Cheke.Camera
{
    partial class FormCropImage
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
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.lblNotes = new System.Windows.Forms.Label();
            this.picSelect = new DevExpress.XtraEditors.PictureEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCrop = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelect.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(241, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblNotes);
            this.pnlContent.Controls.Add(this.picSelect);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Controls.Add(this.btnOK);
            this.pnlContent.Controls.Add(this.btnCrop);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(346, 363);
            this.pnlContent.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(12, 9);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(323, 36);
            this.lblNotes.TabIndex = 26;
            this.lblNotes.Text = "Click and drag on the image to select a portion of the image  you wish to crop";
            // 
            // picSelect
            // 
            this.picSelect.Location = new System.Drawing.Point(12, 59);
            this.picSelect.Name = "picSelect";
            this.picSelect.Properties.ShowMenu = false;
            this.picSelect.Size = new System.Drawing.Size(320, 240);
            this.picSelect.TabIndex = 1;
            this.picSelect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSelect_MouseUp);
            this.picSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSelect_MouseMove);
            this.picSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSelect_MouseDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(149, 316);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(77, 33);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(37, 316);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(77, 33);
            this.btnCrop.TabIndex = 23;
            this.btnCrop.Text = "&Crop";
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // FormCropImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 363);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCropImage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crop Image";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSelect.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PictureEdit picSelect;
        private DevExpress.XtraEditors.SimpleButton btnCrop;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.Label lblNotes;
    }
}