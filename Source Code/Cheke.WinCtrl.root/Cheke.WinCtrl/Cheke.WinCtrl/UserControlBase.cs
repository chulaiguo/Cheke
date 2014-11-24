using System.ComponentModel;
using System.Windows.Forms;

namespace Cheke.WinCtrl
{
    [ToolboxItem(false)]
    public partial class UserControlBase : UserControl
    {
        public UserControlBase()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        protected virtual bool FixedHeight
        {
            get { return false; }
        }

        [Browsable(false)]
        protected virtual bool FixedWidth
        {
            get { return false; }
        }

        [Browsable(false)]
        protected virtual int InnerHeight
        {
            get { return 20; }
        }

        [Browsable(false)]
        protected virtual int InnerWidth
        {
            get { return 150; }
        }

        private void UserControlBase_Resize(object sender, System.EventArgs e)
        {
            if(!this.Visible)
                return;
            
            if (this.FixedWidth)
            {
                this.Width = this.InnerWidth;
            }

            if (this.FixedHeight)
            {
                this.Height = this.InnerHeight;
            }
        }
    }
}