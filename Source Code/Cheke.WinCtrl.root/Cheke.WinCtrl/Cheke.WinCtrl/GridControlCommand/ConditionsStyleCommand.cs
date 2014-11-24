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
        public static Color DirtyDataColor = Color.BurlyWood;
        public static Color NewDataColor = Color.DarkKhaki;

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
            cn.Appearance.BackColor = ConditionsStyleCommand.DirtyDataColor;
            view.FormatConditions.Add(cn);

            cn = new StyleFormatCondition(FormatConditionEnum.Equal, view.Columns["IsNew"], null, true);
            cn.ApplyToRow = true;
            cn.Appearance.BackColor = ConditionsStyleCommand.NewDataColor;
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
                    DirtyDataColor = Color.FromName(dirtyColorName);
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
                    NewDataColor = Color.FromName(newColorName);
                }
                storage.Dispose();
            }
        }
    }
}
