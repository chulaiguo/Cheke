namespace Cheke.VirtualKeyboard.Fixture
{
    partial class FormMain
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
            this.btnVirtualKeyboard = new System.Windows.Forms.Button();
            this.btnNumPad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVirtualKeyboard
            // 
            this.btnVirtualKeyboard.Location = new System.Drawing.Point(88, 56);
            this.btnVirtualKeyboard.Name = "btnVirtualKeyboard";
            this.btnVirtualKeyboard.Size = new System.Drawing.Size(143, 40);
            this.btnVirtualKeyboard.TabIndex = 0;
            this.btnVirtualKeyboard.Text = "VirtualKeyboard";
            this.btnVirtualKeyboard.UseVisualStyleBackColor = true;
            this.btnVirtualKeyboard.Click += new System.EventHandler(this.btnVirtualKeyboard_Click);
            // 
            // btnNumPad
            // 
            this.btnNumPad.Location = new System.Drawing.Point(88, 126);
            this.btnNumPad.Name = "btnNumPad";
            this.btnNumPad.Size = new System.Drawing.Size(143, 37);
            this.btnNumPad.TabIndex = 1;
            this.btnNumPad.Text = "NumPad";
            this.btnNumPad.UseVisualStyleBackColor = true;
            this.btnNumPad.Click += new System.EventHandler(this.btnNumPad_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 223);
            this.Controls.Add(this.btnNumPad);
            this.Controls.Add(this.btnVirtualKeyboard);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVirtualKeyboard;
        private System.Windows.Forms.Button btnNumPad;


    }
}

