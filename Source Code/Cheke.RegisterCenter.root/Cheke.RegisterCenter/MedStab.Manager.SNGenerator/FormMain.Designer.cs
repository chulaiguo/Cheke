namespace MedStab.Manager.SNGenerator
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
            this.lblAuthCode = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.lblMachineID = new System.Windows.Forms.Label();
            this.btnGenerateAuthcode = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAuthcode
            // 
            this.txtAuthcode.Location = new System.Drawing.Point(133, 121);
            this.txtAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthcode.Name = "txtAuthcode";
            this.txtAuthcode.ReadOnly = true;
            this.txtAuthcode.Size = new System.Drawing.Size(338, 24);
            this.txtAuthcode.TabIndex = 22;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.AutoSize = true;
            this.lblAuthCode.Location = new System.Drawing.Point(51, 121);
            this.lblAuthCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(74, 18);
            this.lblAuthCode.TabIndex = 21;
            this.lblAuthCode.Text = "Authcode:";
            // 
            // txtMachineID
            // 
            this.txtMachineID.Location = new System.Drawing.Point(133, 22);
            this.txtMachineID.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(338, 24);
            this.txtMachineID.TabIndex = 20;
            this.txtMachineID.TextChanged += new System.EventHandler(this.txtMachineID_TextChanged);
            // 
            // lblMachineID
            // 
            this.lblMachineID.AutoSize = true;
            this.lblMachineID.Location = new System.Drawing.Point(13, 25);
            this.lblMachineID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachineID.Name = "lblMachineID";
            this.lblMachineID.Size = new System.Drawing.Size(86, 18);
            this.lblMachineID.TabIndex = 19;
            this.lblMachineID.Text = "Machine ID:";
            // 
            // btnGenerateAuthcode
            // 
            this.btnGenerateAuthcode.Enabled = false;
            this.btnGenerateAuthcode.Location = new System.Drawing.Point(172, 187);
            this.btnGenerateAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateAuthcode.Name = "btnGenerateAuthcode";
            this.btnGenerateAuthcode.Size = new System.Drawing.Size(208, 32);
            this.btnGenerateAuthcode.TabIndex = 23;
            this.btnGenerateAuthcode.Text = "Generate Authcode";
            this.btnGenerateAuthcode.UseVisualStyleBackColor = true;
            this.btnGenerateAuthcode.Click += new System.EventHandler(this.btnGenerateAuthcode_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(133, 64);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(338, 24);
            this.txtProductName.TabIndex = 28;
            this.txtProductName.Text = "MedStab.Manager";
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(33, 67);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(108, 18);
            this.lblProductName.TabIndex = 27;
            this.lblProductName.Text = "Product Name:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 253);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.btnGenerateAuthcode);
            this.Controls.Add(this.txtAuthcode);
            this.Controls.Add(this.lblAuthCode);
            this.Controls.Add(this.txtMachineID);
            this.Controls.Add(this.lblMachineID);
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
        private System.Windows.Forms.Label lblAuthCode;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label lblMachineID;
        private System.Windows.Forms.Button btnGenerateAuthcode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;

    }
}