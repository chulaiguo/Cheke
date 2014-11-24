namespace Cheke.WinCtrl
{
    partial class FormDetailListBase
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
            this.btnCopyNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Size = new System.Drawing.Size(570, 362);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCopyNew);
            this.pnlButtons.Location = new System.Drawing.Point(0, 362);
            this.pnlButtons.Size = new System.Drawing.Size(570, 35);
            this.pnlButtons.Controls.SetChildIndex(this.btnCopyNew, 0);
            // 
            // btnCopyNew
            // 
            this.btnCopyNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopyNew.Location = new System.Drawing.Point(12, 5);
            this.btnCopyNew.Name = "btnCopyNew";
            this.btnCopyNew.Size = new System.Drawing.Size(75, 25);
            this.btnCopyNew.TabIndex = 16;
            this.btnCopyNew.Text = "Cop&y New";
            this.btnCopyNew.Click += new System.EventHandler(this.btnCopyNew_Click);
            // 
            // FormDetailListBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(570, 397);
            this.Name = "FormDetailListBase";
            this.Text = "FormEditListBase";
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCopyNew;
    }
}
