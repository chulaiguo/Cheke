using System;
using System.Windows.Forms;
using Cheke.Designer.Controls.Settings;

namespace Cheke.Designer.Controls.Utils
{
    public partial class FormUserSetting : Form
    {
        public FormUserSetting()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UserSetting setting = UserSetting.LoadSetting();
            this.chkUseDefaultPrinter.Checked = setting.UseDefaultPrinter;
            this.chkRememberPrinter.Checked = setting.RememberChoosedPrinter;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UserSetting setting = UserSetting.LoadSetting();
            setting.UseDefaultPrinter = this.chkUseDefaultPrinter.Checked;
            setting.RememberChoosedPrinter = this.chkRememberPrinter.Checked;
            setting.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkUseDefaultPrinter_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkUseDefaultPrinter.Checked)
            {
                this.chkRememberPrinter.Checked = false;
                this.chkRememberPrinter.Enabled = false;
            }
            else
            {
                this.chkRememberPrinter.Enabled = true;
            }
        }
    }
}