using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal class GridEditCommand
    {
        internal static void Cut(GridView view)
        {
            GridClipboard.Cut(view);
        }

        internal static void Copy(GridView view)
        {
            GridClipboard.Copy(view);
        }

        internal static void Multicopy(GridView view)
        {
            GridClipboard.Multicopy(view);
        }

        internal static void Paste(GridView view)
        {
            GridClipboard.Paste(view);
        }

        internal static bool CanCut(GridView view)
        {
            return GridClipboard.CanCut(view);
        }

        internal static bool CanCopy(GridView view)
        {
            return GridClipboard.CanCopy(view);
        }

        internal static bool CanPaste(GridView view)
        {
            return GridClipboard.CanPaste(view);
        }

        internal static bool CanBatchAppend(GridView view)
        {
            if (!view.Editable)
                return false;

            if (FormMainBase.Instance == null)
                return false;

            return FormMainBase.Instance.CanBatchAppend;
        }

        internal static bool CanBatchEdit(GridView view)
        {
            if (!view.Editable)
                return false;

            if (view.FocusedRowHandle < 0)
                return false;

            if (FormMainBase.Instance == null)
                return false;

            return FormMainBase.Instance.CanBatchEdit;
        }
    }
}