namespace Cheke.WinCtrl.GridControlBuddy
{
    partial class FormInputNumber
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
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOK);
            this.pnlClient.Controls.Add(this.txtInput);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(252, 150);
            this.pnlClient.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(142, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(37, 85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 26);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtInput
            // 
            this.txtInput.EditValue = "0";
            this.txtInput.Location = new System.Drawing.Point(12, 28);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.Mask.EditMask = "\\d+";
            this.txtInput.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInput.Size = new System.Drawing.Size(217, 20);
            this.txtInput.TabIndex = 0;
            // 
            // FormInputNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 150);
            this.ControlBox = false;
            this.Controls.Add(this.pnlClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormInputNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Number";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlClient;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}