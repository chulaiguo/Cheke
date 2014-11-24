namespace Cheke.WinCtrl.GridControlBuddy
{
    partial class FormBusinessItem
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
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(464, 462);
            this.pnlClient.TabIndex = 0;
            // 
            // FormDatatableItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(400, 460);
            this.ClientSize = new System.Drawing.Size(464, 462);
            this.Controls.Add(this.pnlClient);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBusinessItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBusinessItem";
            ((System.ComponentModel.ISupportInitialize)(this.pnlClient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlClient;
    }
}