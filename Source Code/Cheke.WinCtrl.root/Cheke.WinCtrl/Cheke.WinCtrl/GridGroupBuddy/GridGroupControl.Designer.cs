namespace Cheke.WinCtrl.GridGroupBuddy
{
    partial class GridGroupControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControlLeft = new DevExpress.XtraGrid.GridControl();
            this.gridViewLeft = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnToLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnToRight = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlRight = new DevExpress.XtraGrid.GridControl();
            this.gridViewRight = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlRightEditor = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRightEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.gridControlLeft);
            this.splitContainer1.Panel1.ShowCaption = true;
            this.splitContainer1.Panel1.Text = "Left";
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(358, 204);
            this.splitContainer1.SplitterPosition = 130;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridControlLeft
            // 
            this.gridControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlLeft.EmbeddedNavigator.Name = "";
            this.gridControlLeft.Location = new System.Drawing.Point(0, 0);
            this.gridControlLeft.MainView = this.gridViewLeft;
            this.gridControlLeft.Name = "gridControlLeft";
            this.gridControlLeft.Size = new System.Drawing.Size(126, 182);
            this.gridControlLeft.TabIndex = 0;
            this.gridControlLeft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeft});
            this.gridControlLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.GridControl_DragEnter);
            this.gridControlLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridControl_DragDrop);
            this.gridControlLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseMove);
            this.gridControlLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseDown);
            this.gridControlLeft.DragOver += new System.Windows.Forms.DragEventHandler(this.GridControl_ControlDragOver);
            // 
            // gridViewLeft
            // 
            this.gridViewLeft.GridControl = this.gridControlLeft;
            this.gridViewLeft.Name = "gridViewLeft";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Panel1.Controls.Add(this.btnToLeft);
            this.splitContainer2.Panel1.Controls.Add(this.btnToRight);
            this.splitContainer2.Panel2.Controls.Add(this.gridControlRight);
            this.splitContainer2.Panel2.Controls.Add(this.pnlRightEditor);
            this.splitContainer2.Panel2.ShowCaption = true;
            this.splitContainer2.Panel2.Text = "Right";
            this.splitContainer2.Size = new System.Drawing.Size(218, 200);
            this.splitContainer2.SplitterPosition = 78;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnToLeft
            // 
            this.btnToLeft.Location = new System.Drawing.Point(6, 124);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnToLeft.Size = new System.Drawing.Size(68, 25);
            this.btnToLeft.TabIndex = 1;
            this.btnToLeft.Text = "<<";
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Location = new System.Drawing.Point(6, 52);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnToRight.Size = new System.Drawing.Size(68, 25);
            this.btnToRight.TabIndex = 0;
            this.btnToRight.Text = ">>";
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // gridControlRight
            // 
            this.gridControlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRight.EmbeddedNavigator.Name = "";
            this.gridControlRight.Location = new System.Drawing.Point(0, 0);
            this.gridControlRight.MainView = this.gridViewRight;
            this.gridControlRight.Name = "gridControlRight";
            this.gridControlRight.Size = new System.Drawing.Size(130, 142);
            this.gridControlRight.TabIndex = 0;
            this.gridControlRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRight});
            this.gridControlRight.DragEnter += new System.Windows.Forms.DragEventHandler(this.GridControl_DragEnter);
            this.gridControlRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridControl_DragDrop);
            this.gridControlRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseMove);
            this.gridControlRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridControl_MouseDown);
            this.gridControlRight.DragOver += new System.Windows.Forms.DragEventHandler(this.GridControl_ControlDragOver);
            // 
            // gridViewRight
            // 
            this.gridViewRight.GridControl = this.gridControlRight;
            this.gridViewRight.Name = "gridViewRight";
            // 
            // pnlRightEditor
            // 
            this.pnlRightEditor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRightEditor.Location = new System.Drawing.Point(0, 142);
            this.pnlRightEditor.Name = "pnlRightEditor";
            this.pnlRightEditor.Size = new System.Drawing.Size(130, 36);
            this.pnlRightEditor.TabIndex = 2;
            this.pnlRightEditor.Visible = false;
            // 
            // GridGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GridGroupControl";
            this.Size = new System.Drawing.Size(358, 204);
            this.Resize += new System.EventHandler(this.GridGroupControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRightEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer2;
        private DevExpress.XtraEditors.SimpleButton btnToRight;
        private DevExpress.XtraEditors.SimpleButton btnToLeft;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.XtraEditors.PanelControl pnlRightEditor;

        private DevExpress.XtraGrid.GridControl gridControlLeft;
        private DevExpress.XtraGrid.GridControl gridControlRight;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeft;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRight;
    }
}
