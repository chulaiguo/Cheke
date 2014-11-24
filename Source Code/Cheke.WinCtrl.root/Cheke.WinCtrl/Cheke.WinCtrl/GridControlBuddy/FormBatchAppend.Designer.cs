namespace Cheke.WinCtrl.GridControlBuddy
{
    partial class FormBatchAppend
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
            this.txtAppendCount = new Cheke.WinCtrl.Common.TextEditEx();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAppendCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.txtAppendCount);
            this.pnlButtons.Controls.SetChildIndex(this.txtAppendCount, 0);
            // 
            // txtAppendCount
            // 
            this.txtAppendCount.EditValue = "1";
            this.txtAppendCount.Location = new System.Drawing.Point(12, 10);
            this.txtAppendCount.Name = "txtAppendCount";
            this.txtAppendCount.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.txtAppendCount.Properties.Mask.EditMask = "d";
            this.txtAppendCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAppendCount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAppendCount.ReadOnly = false;
            this.txtAppendCount.Size = new System.Drawing.Size(228, 20);
            this.txtAppendCount.TabIndex = 4;
            this.txtAppendCount.Title = "Append Count:";
            // 
            // FormBatchAppend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(544, 368);
            this.Name = "FormBatchAppend";
            this.Text = "Batch Append";
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAppendCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cheke.WinCtrl.Common.TextEditEx txtAppendCount;

    }
}
