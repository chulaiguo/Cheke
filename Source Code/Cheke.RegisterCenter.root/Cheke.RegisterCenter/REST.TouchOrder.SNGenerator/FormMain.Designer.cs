namespace REST.TouchOrder.SNGenerator
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
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.btnGenerateAuthcode = new System.Windows.Forms.Button();
            this.lblStoreType = new System.Windows.Forms.Label();
            this.cmbStoreType = new System.Windows.Forms.ComboBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtAuthcode
            // 
            this.txtAuthcode.Location = new System.Drawing.Point(135, 225);
            this.txtAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuthcode.Name = "txtAuthcode";
            this.txtAuthcode.ReadOnly = true;
            this.txtAuthcode.Size = new System.Drawing.Size(338, 24);
            this.txtAuthcode.TabIndex = 22;
            // 
            // lblAuthCode
            // 
            this.lblAuthCode.AutoSize = true;
            this.lblAuthCode.Location = new System.Drawing.Point(55, 228);
            this.lblAuthCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAuthCode.Name = "lblAuthCode";
            this.lblAuthCode.Size = new System.Drawing.Size(74, 18);
            this.lblAuthCode.TabIndex = 21;
            this.lblAuthCode.Text = "Authcode:";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(135, 69);
            this.txtMachineName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(338, 24);
            this.txtMachineName.TabIndex = 20;
            this.txtMachineName.TextChanged += new System.EventHandler(this.txtMachineName_TextChanged);
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new System.Drawing.Point(15, 72);
            this.lblMachineName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(112, 18);
            this.lblMachineName.TabIndex = 19;
            this.lblMachineName.Text = "Machine Name:";
            // 
            // btnGenerateAuthcode
            // 
            this.btnGenerateAuthcode.Enabled = false;
            this.btnGenerateAuthcode.Location = new System.Drawing.Point(166, 273);
            this.btnGenerateAuthcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateAuthcode.Name = "btnGenerateAuthcode";
            this.btnGenerateAuthcode.Size = new System.Drawing.Size(208, 32);
            this.btnGenerateAuthcode.TabIndex = 23;
            this.btnGenerateAuthcode.Text = "Generate Authcode";
            this.btnGenerateAuthcode.UseVisualStyleBackColor = true;
            this.btnGenerateAuthcode.Click += new System.EventHandler(this.btnGenerateAuthcode_Click);
            // 
            // lblStoreType
            // 
            this.lblStoreType.AutoSize = true;
            this.lblStoreType.Location = new System.Drawing.Point(46, 31);
            this.lblStoreType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreType.Name = "lblStoreType";
            this.lblStoreType.Size = new System.Drawing.Size(84, 18);
            this.lblStoreType.TabIndex = 24;
            this.lblStoreType.Text = "Store Type:";
            // 
            // cmbStoreType
            // 
            this.cmbStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStoreType.FormattingEnabled = true;
            this.cmbStoreType.Location = new System.Drawing.Point(135, 26);
            this.cmbStoreType.Name = "cmbStoreType";
            this.cmbStoreType.Size = new System.Drawing.Size(338, 26);
            this.cmbStoreType.TabIndex = 26;
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(135, 111);
            this.txtStoreName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(338, 24);
            this.txtStoreName.TabIndex = 28;
            this.txtStoreName.TextChanged += new System.EventHandler(this.txtStoreName_TextChanged);
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Location = new System.Drawing.Point(35, 114);
            this.lblStoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(92, 18);
            this.lblStoreName.TabIndex = 27;
            this.lblStoreName.Text = "Store Name:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(135, 178);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(338, 24);
            this.txtKey.TabIndex = 30;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Key:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(1, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 3);
            this.panel1.TabIndex = 31;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 335);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStoreName);
            this.Controls.Add(this.lblStoreName);
            this.Controls.Add(this.cmbStoreType);
            this.Controls.Add(this.lblStoreType);
            this.Controls.Add(this.btnGenerateAuthcode);
            this.Controls.Add(this.txtAuthcode);
            this.Controls.Add(this.lblAuthCode);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.lblMachineName);
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
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Button btnGenerateAuthcode;
        private System.Windows.Forms.Label lblStoreType;
        private System.Windows.Forms.ComboBox cmbStoreType;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;

    }
}