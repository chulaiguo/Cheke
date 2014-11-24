using System;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;

namespace Cheke.WinCtrl.Warnings
{
    public partial class FormDirtyDataWarning : Form
    {
        private int _detailHeight = 0;

        public FormDirtyDataWarning()
        {
            InitializeComponent();
        }

        public FormDirtyDataWarning(string title, string question, Form dirtyFrm)
        {
            InitializeComponent();

            this.Text = title;
            this.lblQuestion.Text = question;

            BusinessBase entity = FormUtil.GetEntityData(dirtyFrm);
            if (entity != null && entity.IsSelfDirty)
            {
                this.dirtyMessageCtrl.CreateGeneralMessage(string.Format("The general information is changed."));
            }
            this.dirtyMessageCtrl.CretaeDirtyListMessage(dirtyFrm);

            this.btnCancel.Text = UIStringManager.CancelButton_Caption;
            this.btnYes.Text = UIStringManager.YesButton_Caption;
            this.btnNo.Text = UIStringManager.NoButton_Caption;
            this.btnDetail.Text = UIStringManager.DetailButton_Caption;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this._detailHeight = this.dirtyMessageCtrl.Height;
            this.ShowDetail(false);
        }

        private void ShowDetail(bool visible)
        {
            if (!visible)
            {
                this.dirtyMessageCtrl.Visible = false;
                this.Height -= this._detailHeight;
                this.Top += this._detailHeight / 2;
            }
            else
            {
                this.Height += this._detailHeight;
                this.Top -= this._detailHeight / 2;
                this.dirtyMessageCtrl.Visible = true;
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.ShowDetail(!this.dirtyMessageCtrl.Visible);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}