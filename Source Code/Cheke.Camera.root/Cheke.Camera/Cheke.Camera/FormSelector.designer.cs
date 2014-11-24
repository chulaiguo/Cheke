namespace Cheke.Camera
{
    partial class FormSelector
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
            this.SuspendLayout();
            // 
            // FormSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(115, 113);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.MinimumSize = new System.Drawing.Size(8, 8);
            this.Name = "FormSelector";
            this.ShowInTaskbar = false;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormSelector_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}