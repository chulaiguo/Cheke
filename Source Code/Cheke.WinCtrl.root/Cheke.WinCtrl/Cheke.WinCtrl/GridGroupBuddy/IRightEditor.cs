using System.Windows.Forms;

namespace Cheke.WinCtrl.GridGroupBuddy
{
    public interface IRightEditor
    {
        void SetParent(Control parent);
        void BindingData(object obj);
        bool Editable { get; set; }
    }
}