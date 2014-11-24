namespace Cheke.Camera
{
    partial class UCPhoto
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picEdit
            // 
            this.picEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picEdit.Location = new System.Drawing.Point(5, 5);
            this.picEdit.Name = "picEdit";
            this.picEdit.Size = new System.Drawing.Size(132, 142);
            this.picEdit.TabIndex = 0;
            this.picEdit.Click += new System.EventHandler(this.picEdit_Click);
            // 
            // UCPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.picEdit);
            this.Name = "UCPhoto";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(142, 152);
            ((System.ComponentModel.ISupportInitialize)(this.picEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picEdit;

    }
}