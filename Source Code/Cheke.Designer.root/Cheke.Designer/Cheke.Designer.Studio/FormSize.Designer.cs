namespace Cheke.Designer.Studio
{
    partial class FormSize
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
            this.lblWidth = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInches1 = new System.Windows.Forms.Label();
            this.lblInches2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(19, 29);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(60, 26);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(146, 20);
            this.txtWidth.TabIndex = 0;
            this.txtWidth.Text = "2.12";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(63, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(60, 75);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(146, 20);
            this.txtHeight.TabIndex = 1;
            this.txtHeight.Text = "3.37";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(16, 78);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(163, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInches1
            // 
            this.lblInches1.AutoSize = true;
            this.lblInches1.Location = new System.Drawing.Point(209, 28);
            this.lblInches1.Name = "lblInches1";
            this.lblInches1.Size = new System.Drawing.Size(39, 13);
            this.lblInches1.TabIndex = 4;
            this.lblInches1.Text = "Inches";
            // 
            // lblInches2
            // 
            this.lblInches2.AutoSize = true;
            this.lblInches2.Location = new System.Drawing.Point(209, 78);
            this.lblInches2.Name = "lblInches2";
            this.lblInches2.Size = new System.Drawing.Size(39, 13);
            this.lblInches2.TabIndex = 5;
            this.lblInches2.Text = "Inches";
            // 
            // FormSize
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(272, 192);
            this.Controls.Add(this.lblInches2);
            this.Controls.Add(this.lblInches1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInches1;
        private System.Windows.Forms.Label lblInches2;
    }
}