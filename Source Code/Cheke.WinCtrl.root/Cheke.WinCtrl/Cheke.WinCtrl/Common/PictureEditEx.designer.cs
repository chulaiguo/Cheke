namespace Cheke.WinCtrl.Common
{
    partial class PictureEditEx
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All Picture Files|*.bmp;*.gif;*.jpg;*.jpeg;*.ico|Bitmap Files(*.bmp)|*.bmp|Graphi" +
                "cs Interchange Format(*.gif)|*.gif|JPEG File Interchange Format(*.jpg;*.jpeg)|*." +
                "jpg;*.jpeg|Icon Files(*.ico)|*.ico";
            // 
            // PictureEditEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PictureEditEx";
            this.Size = new System.Drawing.Size(150, 150);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}
