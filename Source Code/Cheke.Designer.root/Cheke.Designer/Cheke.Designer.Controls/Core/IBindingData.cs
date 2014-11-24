using System.Windows.Forms;

namespace Cheke.Designer.Controls.Core
{
    public interface IBindingData
    {
        void Binding(Control child, object entity);
    }
}
