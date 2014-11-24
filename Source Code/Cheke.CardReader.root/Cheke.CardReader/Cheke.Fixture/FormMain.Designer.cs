namespace Cheke.Fixture
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
            this.btnTestIDCheck = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTestScanShell = new System.Windows.Forms.Button();
            this.btnScanPassPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestIDCheck
            // 
            this.btnTestIDCheck.Location = new System.Drawing.Point(114, 23);
            this.btnTestIDCheck.Name = "btnTestIDCheck";
            this.btnTestIDCheck.Size = new System.Drawing.Size(171, 68);
            this.btnTestIDCheck.TabIndex = 0;
            this.btnTestIDCheck.Text = "Test IDCheck";
            this.btnTestIDCheck.UseVisualStyleBackColor = true;
            this.btnTestIDCheck.Click += new System.EventHandler(this.btnTestIDCheck_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(114, 263);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(171, 68);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTestScanShell
            // 
            this.btnTestScanShell.Location = new System.Drawing.Point(114, 102);
            this.btnTestScanShell.Name = "btnTestScanShell";
            this.btnTestScanShell.Size = new System.Drawing.Size(171, 68);
            this.btnTestScanShell.TabIndex = 2;
            this.btnTestScanShell.Text = "Test ScanShell";
            this.btnTestScanShell.UseVisualStyleBackColor = true;
            this.btnTestScanShell.Click += new System.EventHandler(this.btnTestScanShell_Click);
            // 
            // btnScanPassPort
            // 
            this.btnScanPassPort.Location = new System.Drawing.Point(114, 176);
            this.btnScanPassPort.Name = "btnScanPassPort";
            this.btnScanPassPort.Size = new System.Drawing.Size(171, 68);
            this.btnScanPassPort.TabIndex = 3;
            this.btnScanPassPort.Text = "Test Passport";
            this.btnScanPassPort.UseVisualStyleBackColor = true;
            this.btnScanPassPort.Click += new System.EventHandler(this.btnScanPassPort_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 343);
            this.ControlBox = false;
            this.Controls.Add(this.btnScanPassPort);
            this.Controls.Add(this.btnTestScanShell);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTestIDCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestIDCheck;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTestScanShell;
        private System.Windows.Forms.Button btnScanPassPort;
    }
}