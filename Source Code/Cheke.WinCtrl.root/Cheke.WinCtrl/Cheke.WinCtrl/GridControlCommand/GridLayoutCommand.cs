using System;
using System.Windows.Forms;
using Cheke.WinCtrl.Storage;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal static class GridLayoutCommand
    {
        internal static void SaveLayoutToFile(string userId, GridControl gridControl)
        {
            GridView mainView = gridControl.MainView as GridView;
            if (mainView == null)
                return;

            SaveLayoutToFile(userId, mainView, GetLayoutFileName(userId, gridControl, mainView));

            bool done = false;
            for (int i = 0; i < mainView.RowCount; i++)
            {
                int relationCount = mainView.GetRelationCount(i);
                if (relationCount == 0)
                    continue;

                for (int j = 0; j < relationCount; j++)
                {
                    GridView detail = mainView.GetDetailView(i, j) as GridView;
                    if (detail == null)
                        continue;

                    done = true;
                    SaveLayoutToFile(userId, detail, GetLayoutFileName(userId, gridControl, detail));
                }

                if (done)
                    break;
            }
        }

        internal static void ApplyDefaultLayout(string userId, GridControl gridControl)
        {
            GridView mainView = gridControl.MainView as GridView;
            if (mainView == null)
                return;

            ApplyDefaultLayout(userId, gridControl, mainView);

            bool done = false;
            for (int i = 0; i < mainView.RowCount; i++)
            {
                int relationCount = mainView.GetRelationCount(i);
                if (relationCount == 0)
                    continue;

                for (int j = 0; j < relationCount; j++)
                {
                    GridView detail = mainView.GetDetailView(i, j) as GridView;
                    if (detail == null)
                        continue;

                    done = true;
                    ApplyDefaultLayout(userId, gridControl, detail);
                }

                if (done)
                    break;
            }
        }

        internal static void RestoreLayoutFromFile(string userId, GridControl gridControl, GridView view)
        {
            string fielName = GetLayoutFileName(userId, gridControl, view);
            RestoreLayoutFromFile(view, fielName);
        }

        internal static void DeleteLayoutFile(string userId, GridControl gridControl, GridView view)
        {
            string fielName = GetLayoutFileName(userId, gridControl, view);
            StyleStorage storage = new StyleStorage(fielName);
            storage.DeleteLayout();
            storage.Dispose();
        }

        private static void RestoreLayoutFromFile(GridView view, string file)
        {
            string userId = view.GridControl.Tag as string;
            StyleStorage storage = new StyleStorage(file);
            storage.RestoreLayout(userId, view);
            storage.Dispose();
        }

        private static void SaveLayoutToFile(string userId, GridView view, string file)
        {
            StyleStorage storage = new StyleStorage(file);
            storage.SaveLayout(userId, view);
            storage.Dispose();
        }

        private static void ApplyDefaultLayout(string userId, GridControl gridControl, GridView view)
        {
            string fileName = GetLayoutFileName(userId, gridControl, view);
            StyleStorage storage = new StyleStorage(fileName);
            storage.ApplyDefaultLayout(userId, view);
            storage.Dispose();
        }

        internal static string GetLayoutFileName(string userId, GridControl gridControl, GridView view)
        {
            Control parentForm = GetParentControl(typeof(Form), gridControl);
            string formName = parentForm != null ? parentForm.Name : "Untitled";

            return String.Format("{0}.{1}.{2}.style", userId, formName, view.Name);
        }

        private static Control GetParentControl(Type parentType, Control control)
        {
            while (control != null)
            {
                if (control.GetType().IsSubclassOf(parentType) || control.GetType() == parentType)
                {
                    return control;
                }
                control = control.Parent;
            }

            return control;
        }
    }
}