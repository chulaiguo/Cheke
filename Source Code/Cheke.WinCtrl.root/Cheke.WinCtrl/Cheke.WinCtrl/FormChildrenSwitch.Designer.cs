namespace Cheke.WinCtrl
{
    partial class FormChildrenSwitch
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
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(10, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 23);
            this.label1.TabIndex = 0;
            // 
            // FormChildrenSwitch
            // 
            this.ClientSize = new System.Drawing.Size(498, 157);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FormChildrenSwitch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormChildrenSwitch_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormChildrenSwitch_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormChildrenSwitch_MouseDown);
            this.Load += new System.EventHandler(this.FormChildrenSwitch_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
    }
}
