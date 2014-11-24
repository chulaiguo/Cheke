using System.Windows.Forms;
using Cheke.BusinessEntity;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal static class GridHistoryCommand
    {
        internal static void ShowEditEvents(GridView view)
        {
            BusinessBase entity = view.GetRow(view.FocusedRowHandle) as BusinessBase;
            if (entity == null)
                return;

            IShowDataHistory operation = FindIHistory(view.GridControl);
            if (operation != null)
            {
                operation.ShowEditEvents(view, entity);
            }
        }

        internal static void ShowDeleteEvents(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            IShowDataHistory operation = FindIHistory(view.GridControl);
            if (operation != null)
            {
                operation.ShowDeleteEvents(view, list.GetItemType());
            }
        }

        internal static IShowDataHistory FindIHistory(Control current)
        {
            string interfaceName = typeof(IShowDataHistory).Name;
            while (current != null)
            {
                if (current.GetType().GetInterface(interfaceName) != null)
                {
                    return current as IShowDataHistory;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}