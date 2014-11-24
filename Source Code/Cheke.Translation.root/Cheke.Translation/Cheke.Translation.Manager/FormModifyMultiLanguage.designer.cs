namespace Cheke.Translation.Manager
{
    partial class FormModifyMultiLanguage
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
            this.pnlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.pnlClient = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.txtOther = new DevExpress.XtraEditors.MemoEdit();
            this.txtEnglish = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOther.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglish.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnOK);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 344);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(443, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(334, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(227, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.labelControl3);
            this.pnlClient.Controls.Add(this.txtKey);
            this.pnlClient.Controls.Add(this.txtOther);
            this.pnlClient.Controls.Add(this.txtEnglish);
            this.pnlClient.Controls.Add(this.labelControl2);
            this.pnlClient.Controls.Add(this.labelControl1);
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(443, 344);
            this.pnlClient.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(18, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(12, 31);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(414, 20);
            this.txtKey.TabIndex = 2;
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(12, 228);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(414, 96);
            this.txtOther.TabIndex = 0;
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(12, 92);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(414, 96);
            this.txtEnglish.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 209);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Other";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 73);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "English";
            // 
            // FormModifyMultiLanguage
            // 
            this.ClientSize = new System.Drawing.Size(443, 387);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlButtons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModifyMultiLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multilingual Detail";
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOther.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnglish.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlButtons;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl pnlClient;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.MemoEdit txtOther;
        private DevExpress.XtraEditors.MemoEdit txtEnglish;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtKey;
    }
}