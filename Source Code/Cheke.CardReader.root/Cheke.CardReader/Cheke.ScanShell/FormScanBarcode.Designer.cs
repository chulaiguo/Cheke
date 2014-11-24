namespace Cheke.ScanShell
{
    partial class FormScanBarcode
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
            this.pnlClient = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBC1DBarcode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnClear);
            this.pnlClient.Controls.Add(this.PictureBox1);
            this.pnlClient.Controls.Add(this.txtBC1DBarcode);
            this.pnlClient.Controls.Add(this.label8);
            this.pnlClient.Controls.Add(this.btnClose);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(456, 453);
            this.pnlClient.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(226, 394);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 34);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(427, 293);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 190;
            this.PictureBox1.TabStop = false;
            // 
            // txtBC1DBarcode
            // 
            this.txtBC1DBarcode.Enabled = false;
            this.txtBC1DBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBC1DBarcode.Location = new System.Drawing.Point(111, 322);
            this.txtBC1DBarcode.Name = "txtBC1DBarcode";
            this.txtBC1DBarcode.Size = new System.Drawing.Size(308, 31);
            this.txtBC1DBarcode.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 25);
            this.label8.TabIndex = 188;
            this.label8.Text = "Barcode";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(325, 394);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormScanBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 453);
            this.Controls.Add(this.pnlClient);
            this.Name = "FormScanBarcode";
            this.Text = "Scan Barcode";
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.TextBox txtBC1DBarcode;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button btnClear;
    }
}