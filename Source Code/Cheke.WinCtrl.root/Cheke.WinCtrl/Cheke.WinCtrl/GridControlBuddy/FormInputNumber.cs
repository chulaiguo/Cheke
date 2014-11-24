using System;
using System.Windows.Forms;

namespace Cheke.WinCtrl.GridControlBuddy
{
    public partial class FormInputNumber : FormMiscBase
    {
        private int _inputNumber = 0;

        public FormInputNumber()
        {
            InitializeComponent();
        }

        public int InputNumber
        {
            get { return _inputNumber; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int.TryParse(this.txtInput.Text.Trim(), out this._inputNumber);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}