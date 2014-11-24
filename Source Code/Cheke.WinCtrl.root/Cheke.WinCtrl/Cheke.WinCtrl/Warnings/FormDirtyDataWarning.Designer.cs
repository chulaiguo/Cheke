namespace Cheke.WinCtrl.Warnings
{
    partial class FormDirtyDataWarning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDirtyDataWarning));
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            this.dirtyMessageCtrl = new Cheke.WinCtrl.Warnings.DirtyDataCtrlContainer();
            this.pnlCaption = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.lblQuestion = new DevExpress.XtraEditors.LabelControl();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaption)).BeginInit();
            this.pnlCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.dirtyMessageCtrl);
            this.pnlClient.Controls.Add(this.pnlCaption);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Padding = new System.Windows.Forms.Padding(5);
            this.pnlClient.Size = new System.Drawing.Size(499, 301);
            this.pnlClient.TabIndex = 0;
            // 
            // dirtyMessageCtrl
            // 
            this.dirtyMessageCtrl.AutoScroll = true;
            this.dirtyMessageCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dirtyMessageCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dirtyMessageCtrl.Location = new System.Drawing.Point(7, 111);
            this.dirtyMessageCtrl.Name = "dirtyMessageCtrl";
            this.dirtyMessageCtrl.Size = new System.Drawing.Size(485, 183);
            this.dirtyMessageCtrl.TabIndex = 1;
            this.dirtyMessageCtrl.Visible = false;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.btnCancel);
            this.pnlCaption.Controls.Add(this.picQuestion);
            this.pnlCaption.Controls.Add(this.btnDetail);
            this.pnlCaption.Controls.Add(this.lblQuestion);
            this.pnlCaption.Controls.Add(this.btnNo);
            this.pnlCaption.Controls.Add(this.btnYes);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(7, 7);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(485, 104);
            this.pnlCaption.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(374, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picQuestion
            // 
            this.picQuestion.Image = ((System.Drawing.Image)(resources.GetObject("picQuestion.Image")));
            this.picQuestion.Location = new System.Drawing.Point(15, 13);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(65, 71);
            this.picQuestion.TabIndex = 0;
            this.picQuestion.TabStop = false;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(96, 64);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "Detail";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Location = new System.Drawing.Point(106, 26);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(292, 13);
            this.lblQuestion.TabIndex = 1;
            this.lblQuestion.Text = "You have some unsaved data, would you like to save it now?";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(282, 64);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(189, 64);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Yes";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // FormDirtyDataWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 301);
            this.ControlBox = false;
            this.Controls.Add(this.pnlClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDirtyDataWarning";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirtyDataWarning";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlCaption)).EndInit();
            this.pnlCaption.ResumeLayout(false);
            this.pnlCaption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlClient;
        private DevExpress.XtraEditors.LabelControl lblQuestion;
        private System.Windows.Forms.PictureBox picQuestion;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraEditors.SimpleButton btnNo;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.PanelControl pnlCaption;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DirtyDataCtrlContainer dirtyMessageCtrl;
    }
}