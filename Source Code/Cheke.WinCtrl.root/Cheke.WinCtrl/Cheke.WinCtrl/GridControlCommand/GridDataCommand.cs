using System.Collections;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal class GridDataCommand
    {
        internal static void SaveChanges(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null || !list.IsDirty)
                return;

            ISaveGridViewData operation = FindISaveChanges(view.GridControl);
            if (operation != null)
            {
                operation.SaveGridViewData(view);
            }
        }

        internal static void RecoverDeletedItems(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null || !list.IsDirty)
                return;

            ArrayList deletedList = list.GetDeletedList();
            foreach (BusinessBase item in deletedList)
            {
                if(item.IsNew)
                    continue;

                item.AcceptChanges();
                list.Add(item);
                list.AcceptChanges(item.ObjectID);
            }
        }

        internal static void RefreshData(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            if (list.IsDirty && DialogResult.Yes != ShowRefreshWarning())
                return;

            RefreshData(view, view.GridControl);
        }

        internal static void RefreshData(GridView view, Control parent)
        {
            IRefreshGridViewData operation = FindIRefreshData(parent);
            if (operation != null)
            {
                operation.RefrshGridViewData(view);
            }
        }

        internal static DialogResult ShowRefreshWarning()
        {
            return MessageBoxUtil.ShowRefreshDataWarning("Refresh Warning");
        }

        internal static ISaveGridViewData FindISaveChanges(Control current)
        {
            string interfaceName = typeof(ISaveGridViewData).Name;
            while (current != null)
            {
                if (current.GetType().GetInterface(interfaceName) != null)
                {
                    return current as ISaveGridViewData;
                }

                current = current.Parent;
            }

            return null;
        }

        internal static IRefreshGridViewData FindIRefreshData(Control current)
        {
            string interfaceName = typeof(IRefreshGridViewData).Name;
            while (current != null)
            {
                if (current.GetType().GetInterface(interfaceName) != null)
                {
                    return current as IRefreshGridViewData;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}