namespace Cheke.Camera.Fixture
{
    partial class FormFixture
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
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTakePicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Location = new System.Drawing.Point(114, 274);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(122, 32);
            this.btnLoadPicture.TabIndex = 0;
            this.btnLoadPicture.Text = "Load Picture";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.btnLoadPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(57, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 205);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Location = new System.Drawing.Point(114, 329);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(122, 32);
            this.btnTakePicture.TabIndex = 2;
            this.btnTakePicture.Text = "Take Picture";
            this.btnTakePicture.UseVisualStyleBackColor = true;
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // FormFixture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 419);
            this.Controls.Add(this.btnTakePicture);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLoadPicture);
            this.Name = "FormFixture";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTakePicture;
    }
}

