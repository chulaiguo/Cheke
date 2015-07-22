using System;
using System.Drawing;
using Cheke.WinCtrl.Storage;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    public static class ConditionsStyleCommand
    {
        public static void AddConditionsColumns(GridView view)
        {
            GridColumn colIsDirty = new GridColumn();
            colIsDirty.Caption = "IsDirty";
            colIsDirty.FieldName = "IsSelfDirty";
            colIsDirty.VisibleIndex = -1;
            colIsDirty.OptionsColumn.ShowInCustomizationForm = false;
            colIsDirty.Tag = true;
            view.Columns.Add(colIsDirty);

            GridColumn colIsNew = new GridColumn();
            colIsNew.Caption = "IsNew";
            colIsNew.FieldName = "IsNew";
            colIsNew.VisibleIndex = -1;
            colIsNew.OptionsColumn.ShowInCustomizationForm = false;
            colIsNew.Tag = true;
            view.Columns.Add(colIsNew);
        }

        public static void AddConditionsStyle(GridView view)
        {
            StyleFormatCondition cn = new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IsSelfDirty"], null, true);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = FormMainBase.ListDirtyColor;
            view.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IsNew"], null, true);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = FormMainBase.ListNewColor;
            view.FormatConditions.Add(cn);
        }

        public static void SaveConditionsStyleToFile(string userId, Color dirtyColor, Color newColor)
        {
            //Save DirtyColor
            string fileName = String.Format("{0}.DirtyColor.style", userId);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                storage.Save(dirtyColor.Name);
                storage.Dispose();
            }

            //Save NewColor
            fileName = String.Format("{0}.NewColor.style", userId);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                storage.Save(newColor.Name);
                storage.Dispose();
            }
        }

        public static void RestoreStyleFromFile(string userId)
        {
            //Restore DirtyColor
            string fileName = String.Format("{0}.DirtyColor.style", userId);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string dirtyColorName = storage.Read() as string;
                if (!string.IsNullOrEmpty(dirtyColorName))
                {
                    FormMainBase.ListDirtyColor = Color.FromName(dirtyColorName);
                }
                storage.Dispose();
            }

            //Restore NewColor
            fileName = String.Format("{0}.NewColor.style", userId);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string newColorName = storage.Read() as string;
                if (!string.IsNullOrEmpty(newColorName))
                {
                    FormMainBase.ListNewColor = Color.FromName(newColorName);
                }
                storage.Dispose();
            }
        }
    }
}
