namespace Cheke.SNGenerator
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
            this.txtAuthcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerateAuthcode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAuthcode
            // 
            this.txtAuthcode.Location = new System.Drawing.Point(134, 121);
            this.txtAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthcode.Name = "txtAuthcode";
            this.txtAuthcode.ReadOnly = true;
            this.txtAuthcode.Size = new System.Drawing.Size(375, 24);
            this.txtAuthcode.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 124);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "Authcode:";
            // 
            // txtMachineID
            // 
            this.txtMachineID.Location = new System.Drawing.Point(134, 41);
            this.txtMachineID.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(378, 24);
            this.txtMachineID.TabIndex = 20;
            this.txtMachineID.TextChanged += new System.EventHandler(this.txtMachineID_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "Machine ID:";
            // 
            // btnGenerateAuthcode
            // 
            this.btnGenerateAuthcode.Enabled = false;
            this.btnGenerateAuthcode.Location = new System.Drawing.Point(150, 182);
            this.btnGenerateAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateAuthcode.Name = "btnGenerateAuthcode";
            this.btnGenerateAuthcode.Size = new System.Drawing.Size(208, 32);
            this.btnGenerateAuthcode.TabIndex = 23;
            this.btnGenerateAuthcode.Text = "Generate Authcode";
            this.btnGenerateAuthcode.UseVisualStyleBackColor = true;
            this.btnGenerateAuthcode.Click += new System.EventHandler(this.btnGenerateAuthcode_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 240);
            this.Controls.Add(this.btnGenerateAuthcode);
            this.Controls.Add(this.txtAuthcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMachineID);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAuthcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerateAuthcode;

    }
}