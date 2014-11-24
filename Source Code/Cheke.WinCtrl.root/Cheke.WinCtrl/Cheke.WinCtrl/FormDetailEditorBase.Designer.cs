namespace Cheke.WinCtrl
{
    partial class FormDetailEditorBase
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
            this.pnlModifiedTag = new DevExpress.XtraEditors.PanelControl();
            this.lblModifiedNotes = new DevExpress.XtraEditors.LabelControl();
            this.pnlCreatedTag = new DevExpress.XtraEditors.PanelControl();
            this.lblCreatedNotes = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModifiedTag)).BeginInit();
            this.pnlModifiedTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCreatedTag)).BeginInit();
            this.pnlCreatedTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Size = new System.Drawing.Size(494, 335);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 381);
            this.pnlButtons.Size = new System.Drawing.Size(494, 35);
            // 
            // pnlModifiedTag
            // 
            this.pnlModifiedTag.Controls.Add(this.lblModifiedNotes);
            this.pnlModifiedTag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlModifiedTag.Location = new System.Drawing.Point(0, 358);
            this.pnlModifiedTag.Name = "pnlModifiedTag";
            this.pnlModifiedTag.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.pnlModifiedTag.Size = new System.Drawing.Size(494, 23);
            this.pnlModifiedTag.TabIndex = 3;
            // 
            // lblModifiedNotes
            // 
            this.lblModifiedNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModifiedNotes.Location = new System.Drawing.Point(12, 7);
            this.lblModifiedNotes.Name = "lblModifiedNotes";
            this.lblModifiedNotes.Size = new System.Drawing.Size(78, 13);
            this.lblModifiedNotes.TabIndex = 1;
            this.lblModifiedNotes.Text = "lblModifiedNotes";
            // 
            // pnlCreatedTag
            // 
            this.pnlCreatedTag.Controls.Add(this.lblCreatedNotes);
            this.pnlCreatedTag.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCreatedTag.Location = new System.Drawing.Point(0, 335);
            this.pnlCreatedTag.Name = "pnlCreatedTag";
            this.pnlCreatedTag.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.pnlCreatedTag.Size = new System.Drawing.Size(494, 23);
            this.pnlCreatedTag.TabIndex = 4;
            // 
            // lblCreatedNotes
            // 
            this.lblCreatedNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCreatedNotes.Location = new System.Drawing.Point(12, 7);
            this.lblCreatedNotes.Name = "lblCreatedNotes";
            this.lblCreatedNotes.Size = new System.Drawing.Size(77, 13);
            this.lblCreatedNotes.TabIndex = 0;
            this.lblCreatedNotes.Text = "lblCreatedNotes";
            // 
            // FormDetailEditorBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(494, 416);
            this.Controls.Add(this.pnlCreatedTag);
            this.Controls.Add(this.pnlModifiedTag);
            this.Name = "FormDetailEditorBase";
            this.Text = "FormEditDetailBase";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.pnlModifiedTag, 0);
            this.Controls.SetChildIndex(this.pnlCreatedTag, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlModifiedTag)).EndInit();
            this.pnlModifiedTag.ResumeLayout(false);
            this.pnlModifiedTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCreatedTag)).EndInit();
            this.pnlCreatedTag.ResumeLayout(false);
            this.pnlCreatedTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlModifiedTag;
        private DevExpress.XtraEditors.LabelControl lblCreatedNotes;
        private DevExpress.XtraEditors.LabelControl lblModifiedNotes;
        private DevExpress.XtraEditors.PanelControl pnlCreatedTag;


    }
}
