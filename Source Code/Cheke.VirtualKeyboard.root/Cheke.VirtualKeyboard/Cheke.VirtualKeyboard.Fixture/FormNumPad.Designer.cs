namespace Cheke.VirtualKeyboard.Fixture
{
    partial class FormNumPad
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numPadCtrl1 = new Cheke.VirtualKeyboard.NumPadCtrl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 35);
            this.textBox1.TabIndex = 0;
            // 
            // numPadCtrl1
            // 
            this.numPadCtrl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.numPadCtrl1.Location = new System.Drawing.Point(16, 63);
            this.numPadCtrl1.Name = "numPadCtrl1";
            this.numPadCtrl1.Size = new System.Drawing.Size(320, 264);
            this.numPadCtrl1.TabIndex = 1;
            // 
            // FormNumPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 339);
            this.ControlBox = false;
            this.Controls.Add(this.numPadCtrl1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormNumPad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private NumPadCtrl numPadCtrl1;
    }
}