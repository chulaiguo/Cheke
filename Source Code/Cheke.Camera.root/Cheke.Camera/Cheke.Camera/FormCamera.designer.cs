namespace Cheke.Camera
{
    partial class FormCamera
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
            this.btnTakePicture = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.pnlContent = new DevExpress.XtraEditors.PanelControl();
            this.grpSelectPicture = new DevExpress.XtraEditors.GroupControl();
            this.picSelect = new DevExpress.XtraEditors.PictureEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCrop = new DevExpress.XtraEditors.SimpleButton();
            this.grpLiveVideo = new DevExpress.XtraEditors.GroupControl();
            this.pnlVideo = new DevExpress.XtraEditors.PanelControl();
            this.btnDeleteAll = new DevExpress.XtraEditors.SimpleButton();
            this.grpPhotoList = new DevExpress.XtraEditors.GroupControl();
            this.pnlCaptuedPhotos = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSelectPicture)).BeginInit();
            this.grpSelectPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLiveVideo)).BeginInit();
            this.grpLiveVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPhotoList)).BeginInit();
            this.grpPhotoList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaptuedPhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(22, 275);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(128, 33);
            this.btnTakePicture.TabIndex = 7;
            this.btnTakePicture.Text = "Take &Picture";
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(257, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpSelectPicture);
            this.pnlContent.Controls.Add(this.grpLiveVideo);
            this.pnlContent.Controls.Add(this.grpPhotoList);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(732, 494);
            this.pnlContent.TabIndex = 10;
            // 
            // grpSelectPicture
            // 
            this.grpSelectPicture.Controls.Add(this.btnCancel);
            this.grpSelectPicture.Controls.Add(this.picSelect);
            this.grpSelectPicture.Controls.Add(this.btnOK);
            this.grpSelectPicture.Controls.Add(this.btnCrop);
            this.grpSelectPicture.Location = new System.Drawing.Point(357, 5);
            this.grpSelectPicture.Name = "grpSelectPicture";
            this.grpSelectPicture.Size = new System.Drawing.Size(361, 313);
            this.grpSelectPicture.TabIndex = 22;
            this.grpSelectPicture.Text = "Selected Picture";
            // 
            // picSelect
            // 
            this.picSelect.Location = new System.Drawing.Point(20, 20);
            this.picSelect.Name = "picSelect";
            this.picSelect.Properties.ShowMenu = false;
            this.picSelect.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picSelect.Size = new System.Drawing.Size(320, 240);
            this.picSelect.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(168, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(83, 33);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Enabled = false;
            this.btnCrop.Location = new System.Drawing.Point(64, 275);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(83, 33);
            this.btnCrop.TabIndex = 23;
            this.btnCrop.Text = "&Crop";
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // grpLiveVideo
            // 
            this.grpLiveVideo.Controls.Add(this.pnlVideo);
            this.grpLiveVideo.Controls.Add(this.btnDeleteAll);
            this.grpLiveVideo.Controls.Add(this.btnTakePicture);
            this.grpLiveVideo.Location = new System.Drawing.Point(8, 5);
            this.grpLiveVideo.Name = "grpLiveVideo";
            this.grpLiveVideo.Size = new System.Drawing.Size(324, 313);
            this.grpLiveVideo.TabIndex = 21;
            this.grpLiveVideo.Text = "Live Video";
            // 
            // pnlVideo
            // 
            this.pnlVideo.Location = new System.Drawing.Point(2, 20);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(320, 240);
            this.pnlVideo.TabIndex = 11;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(178, 275);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(128, 33);
            this.btnDeleteAll.TabIndex = 10;
            this.btnDeleteAll.Text = "&Clear Captured Photos";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // grpPhotoList
            // 
            this.grpPhotoList.Controls.Add(this.pnlCaptuedPhotos);
            this.grpPhotoList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpPhotoList.Location = new System.Drawing.Point(2, 324);
            this.grpPhotoList.Name = "grpPhotoList";
            this.grpPhotoList.Size = new System.Drawing.Size(728, 168);
            this.grpPhotoList.TabIndex = 20;
            this.grpPhotoList.Text = " Captured Photos";
            // 
            // pnlCaptuedPhotos
            // 
            this.pnlCaptuedPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCaptuedPhotos.Location = new System.Drawing.Point(2, 21);
            this.pnlCaptuedPhotos.Name = "pnlCaptuedPhotos";
            this.pnlCaptuedPhotos.Size = new System.Drawing.Size(724, 145);
            this.pnlCaptuedPhotos.TabIndex = 0;
            // 
            // FormCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 494);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCamera";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSelectPicture)).EndInit();
            this.grpSelectPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLiveVideo)).EndInit();
            this.grpLiveVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPhotoList)).EndInit();
            this.grpPhotoList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaptuedPhotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTakePicture;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl grpLiveVideo;
        private DevExpress.XtraEditors.GroupControl grpPhotoList;
        private DevExpress.XtraEditors.GroupControl grpSelectPicture;
        private DevExpress.XtraEditors.PictureEdit picSelect;
        private DevExpress.XtraEditors.SimpleButton btnCrop;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDeleteAll;
        private DevExpress.XtraEditors.PanelControl pnlCaptuedPhotos;
        private DevExpress.XtraEditors.PanelControl pnlVideo;
    }
}