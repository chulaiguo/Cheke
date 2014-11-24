using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Cheke.WinCtrl
{
    public partial class FormChildrenSwitch : Form
    {
        private List<Form> _formList = null;

        public FormChildrenSwitch()
        {
            InitializeComponent();
        }

        private void FormChildrenSwitch_Load(object sender, EventArgs e)
        {
            this.GetChildren();
            if(this._formList.Count < 8)
            {
                this.DrawPictureBox(this._formList.Count, this._formList.Count);
            }
            else
            {
                this.DrawPictureBox(this._formList.Count, 8);
            }
        }

        private void GetChildren()
        {
            this._formList = new List<Form>();
            foreach (Form item in Application.OpenForms)
            {
                if (item.TopLevel)
                    continue;

                this._formList.Add(item);
            }
        }

        private void DrawPictureBox(int number, int groupNumber)
        {
            int xPos = 0;
            int yPos = this.Padding.Top;

            int iWidth = 50;
            int iHeight = 50;

            int xInterval = 10;
            int yInterval = 10;

            for (int i = 0; i < number; i++)
            {
                if (xPos >= iWidth*groupNumber + xInterval*(groupNumber - 1))
                {
                    xPos = 0;
                    yPos += iHeight + yInterval;
                }

                PictureEdit edit = new PictureEdit();
                edit.TabStop = true;
                edit.Properties.AppearanceFocused.BackColor = Color.Red;
                edit.Properties.ShowMenu = false;
                edit.Properties.SizeMode = PictureSizeMode.Zoom;
                edit.EditValue = this._formList[i].Icon.ToBitmap();
                edit.Tag = this._formList[i];
                edit.Enter += new EventHandler(edit_Enter);

                edit.Width = iWidth;
                edit.Height = iHeight;

                if (xPos == 0)
                {
                    xPos += xInterval;
                }
                else
                {
                    xPos += iWidth + xInterval;
                }
                edit.Left = xPos;
                edit.Top = yPos;

                this.Controls.Add(edit);
            }

            this.Width = (iWidth + xInterval)*(groupNumber + 1) + this.Padding.Left + this.Padding.Right;
            this.Height = yPos + iHeight + yInterval + this.label1.Height + this.Padding.Bottom + this.Padding.Top;

            this.CenterForm();
        }

        private void CenterForm()
        {
            int iLeft = (Screen.PrimaryScreen.WorkingArea.Width - this.Width)/2;
            int iTop = (Screen.PrimaryScreen.WorkingArea.Height - this.Height)/2;

            this.Left = iLeft;
            this.Top = iTop;
        }

        private void edit_Enter(object sender, EventArgs e)
        {
            PictureEdit edit = sender as PictureEdit;
            if (edit == null || edit.Tag == null)
                return;

            Form form = edit.Tag as Form;
            if (form == null)
                return;

            this.label1.Text = form.Text;
        }


        private void FormChildrenSwitch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                this.ProcessTabKey(true);
            }
        }

        private void FormChildrenSwitch_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                if (this.ActiveControl != null && this.ActiveControl.Tag != null)
                {
                    Form form = this.ActiveControl.Tag as Form;
                    if (form != null)
                    {
                        form.BringToFront();
                    }
                }

                this.Close();
            }
        }

        private void FormChildrenSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}