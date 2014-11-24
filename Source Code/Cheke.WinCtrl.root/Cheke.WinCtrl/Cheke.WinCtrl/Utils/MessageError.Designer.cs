namespace Cheke.WinCtrl.Utils
{
    partial class MessageError
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            this.pnlErrorDetail = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cheke.WinCtrl.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.labelControl1);
            this.pnlClient.Controls.Add(this.pictureBox1);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(449, 157);
            this.pnlClient.TabIndex = 1;
            // 
            // pnlErrorDetail
            // 
            this.pnlErrorDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlErrorDetail.Location = new System.Drawing.Point(0, 157);
            this.pnlErrorDetail.Name = "pnlErrorDetail";
            this.pnlErrorDetail.Size = new System.Drawing.Size(449, 100);
            this.pnlErrorDetail.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(70, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(469, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "You do not have sufficient security privileges to add new data. Please contact yo" +
    "ur administrator.";
            // 
            // MessageError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 257);
            this.ControlBox = false;
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlErrorDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MessageError";
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlErrorDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.PanelControl pnlClient;
        private DevExpress.XtraEditors.PanelControl pnlErrorDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}