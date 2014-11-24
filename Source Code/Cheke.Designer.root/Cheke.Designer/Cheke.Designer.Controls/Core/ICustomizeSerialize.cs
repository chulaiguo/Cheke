using System.Windows.Forms;

namespace Cheke.Designer.Controls.Core
{
    public interface ICustomizeSerialize
    {
        void PreSerialize(Control child);
        void AfterDeserialize(Control child);
    }
}
