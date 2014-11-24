namespace Cheke.VirtualKeyboard.Fixture
{
    partial class FormVirtualkeyboard
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
            this.keyboardCtrl1 = new Cheke.VirtualKeyboard.KeyboardCtrl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(765, 35);
            this.textBox1.TabIndex = 0;
            // 
            // keyboardCtrl1
            // 
            this.keyboardCtrl1.Location = new System.Drawing.Point(12, 59);
            this.keyboardCtrl1.Name = "keyboardCtrl1";
            this.keyboardCtrl1.Size = new System.Drawing.Size(765, 359);
            this.keyboardCtrl1.TabIndex = 1;
            // 
            // FormVirtualkeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 430);
            this.ControlBox = false;
            this.Controls.Add(this.keyboardCtrl1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormVirtualkeyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private KeyboardCtrl keyboardCtrl1;
    }
}