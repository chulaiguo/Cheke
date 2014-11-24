using System;
using DevExpress.XtraGrid;

namespace Cheke.WinCtrl
{
    public partial class FormViewBase : FormBase
    {
        public FormViewBase()
        {
            InitializeComponent();
        }

        public FormViewBase(string userId)
            : base(userId)
        {
            InitializeComponent();
        }

        protected GridControl GridControl
        {
            get { return this.gridControl1; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.gridView1.OptionsBehavior.Editable = false;
            this.gridControl1.UseEmbeddedNavigator = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}