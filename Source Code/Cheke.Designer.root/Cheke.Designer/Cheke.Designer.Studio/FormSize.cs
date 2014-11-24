using System;
using System.Windows.Forms;

namespace Cheke.Designer.Studio
{
    public partial class FormSize : Form
    {
        private float _widthInches = 0;
        private float _heightInches = 0;

        public FormSize()
        {
            InitializeComponent();
        }

        public FormSize(float width, float height)
        {
            InitializeComponent();

            this.txtWidth.Text = string.Format("{0}", width);
            this.txtHeight.Text = string.Format("{0}", height);
        }

        public float WidthInches
        {
            get { return _widthInches; }
        }

        public float HeightInches
        {
            get { return _heightInches; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            float result;
            if(!float.TryParse(this.txtWidth.Text.Trim(), out result))
            {
                this.txtWidth.Select();
                return;
            }

            this._widthInches = result;

            if (!float.TryParse(this.txtHeight.Text.Trim(), out result))
            {
                this.txtHeight.Select();
                return;
            }

            this._heightInches = result;

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
