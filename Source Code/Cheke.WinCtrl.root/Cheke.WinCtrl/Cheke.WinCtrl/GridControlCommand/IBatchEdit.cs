using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    public interface IBatchEdit
    {
        void BatchEdit(GridView view, bool append);
    }
}
