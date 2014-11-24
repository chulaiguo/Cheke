using Cheke.BusinessEntity;

namespace Cheke.WinCtrl.GridControlCommand
{
    public interface IGridClipboard
    {
        void AfterPaste(BusinessBase entity);
    }
}
