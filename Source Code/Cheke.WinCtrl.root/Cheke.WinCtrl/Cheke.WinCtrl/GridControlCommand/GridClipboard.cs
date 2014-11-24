using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.GridControlBuddy;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal class GridClipboard
    {
        internal static bool CanCut(GridView view)
        {
            if(!view.Editable)
                return false;

            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null || list.Count == 0)
                return false;

            if (view.FocusedRowHandle < 0)
                return false;

            return true;
        }

        internal static bool CanCopy(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null || list.Count == 0)
                return false;

            if(view.FocusedRowHandle < 0)
                return false;

            return true;
        }

        internal static bool CanPaste(GridView view)
        {
            if (view.DataSource == null)
                return false;

            if(!view.Editable)
                return false;

            IDataObject obj = Clipboard.GetDataObject();
            if(obj == null)
                return false;

            object clipboard = obj.GetData(DataFormats.Serializable);
            if (clipboard == null)
                return false;

            if (view.DataSource.GetType() != clipboard.GetType())
                return false;

            return true;
        }

        internal static void Cut(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null || list.Count == 0)
                return;

            BusinessCollectionBase listSelected = GetSelectedEntity(view);
            if (listSelected == null)
                return;

            //copy selected items
            IDataObject obj = new DataObject();
            obj.SetData(DataFormats.Serializable, listSelected);
            Clipboard.SetDataObject(obj);

            //Remove selected items
            foreach (BusinessBase item in listSelected)
            {
                list.Remove(item);
            }
        }

        internal static void Copy(GridView view)
        {
            BusinessCollectionBase list = GetSelectedEntity(view);
            if (list == null)
                return;

            IDataObject obj = new DataObject();
            obj.SetData(DataFormats.Serializable, list);
            Clipboard.SetDataObject(obj);
        }

        internal static void Multicopy(GridView view)
        {
            BusinessCollectionBase list = GetSelectedEntity(view);
            if (list == null )
                return;

            FormInputNumber dlg = new FormInputNumber();
            if(dlg.ShowDialog() != DialogResult.OK)
                 return;

            if(dlg.InputNumber <= 0)
                return;

            ArrayList arrList = new ArrayList();
            for (int i = 0; i < dlg.InputNumber - 1; i++)
            {
                foreach (BusinessBase item in list)
                {
                    BusinessBase entity = Activator.CreateInstance(item.GetType()) as BusinessBase;
                    if (entity == null)
                        continue;

                    entity.CopyFrom(item, false);
                    arrList.Add(entity);
                }
            }

            foreach (BusinessBase item in arrList)
            {
                list.Add(item);
            }

            IDataObject obj = new DataObject();
            obj.SetData(DataFormats.Serializable, list);
            Clipboard.SetDataObject(obj);
        }

        internal static void Paste(GridView view)
        {
            BusinessCollectionBase list = view.DataSource as BusinessCollectionBase;
            if (list == null)
                return;

            IDataObject obj = Clipboard.GetDataObject();
            if (obj == null)
                return;

            BusinessCollectionBase clipboard = obj.GetData(DataFormats.Serializable) as BusinessCollectionBase;
            if (clipboard == null)
                return;

            if (list.GetType() != clipboard.GetType())
                return;

            ArrayList pastedList = new ArrayList();
            BusinessBase parent = GetParentEntity(view);
            foreach (BusinessBase item in clipboard)
            {
                BusinessBase entity = Activator.CreateInstance(item.GetType()) as BusinessBase;
                if (entity == null)
                    continue;

                entity.CopyFrom(item, false);
                SetParentEntity(entity, parent);
                //CopyChildren(item, entity);
                IGridClipboard paste = FindIGridClipboard(view.GridControl);
                if (paste != null)
                {
                    paste.AfterPaste(entity);
                }

                pastedList.Add(entity);
                list.Add(entity);
            }

            SelectList(view, pastedList);
        }

        private static BusinessCollectionBase GetSelectedEntity(GridView view)
        {
            if (view.DataSource == null)
                return null;

            BusinessCollectionBase list = Activator.CreateInstance(view.DataSource.GetType()) as BusinessCollectionBase;
            if (list == null)
                return null;

            int[] rowHandles = view.GetSelectedRows();
            if (rowHandles == null || rowHandles.Length == 0)
                return list;

            for (int i = 0; i < rowHandles.Length; i++)
            {
                BusinessBase entity = view.GetRow(rowHandles[i]) as BusinessBase;
                if (entity == null)
                    continue;

                list.Add(entity);
            }

            return list;
        }

        private static BusinessBase GetParentEntity(GridView view)
        {
            if (view.IsDetailView)
            {
                return view.SourceRow as BusinessBase;
            }

            Form parentForm = FormUtil.GetParentForm(view.GridControl);
            if(parentForm == null)
                return null;

            return FormUtil.GetEntityData(parentForm);
        }

        private static void SetParentEntity(BusinessBase entity, BusinessBase parent)
        {
            if(entity == null || parent == null)
                return;

            PropertyInfo[] properties = entity.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if(item.PropertyType != parent.GetType())
                    continue;

                item.SetValue(entity, parent, null);
            }
        }

        private static void SelectList(GridView view, ArrayList list)
        {
            for (int i = 0; i < view.DataRowCount; i++)
            {
                object obj = view.GetRow(i);
                if (obj == null)
                    continue;

                if (IsExist(list, obj))
                {
                    view.SelectRow(i);
                }
                else
                {
                    view.UnselectRow(i);
                }
            }
        }

        private static bool IsExist(ArrayList list, object obj)
        {
            foreach (object item in list)
            {
                if (item.Equals(obj))
                    return true;
            }

            return false;
        }

        private static IGridClipboard FindIGridClipboard(Control current)
        {
            string interfaceName = typeof(IAmendEntity).Name;
            while (current != null)
            {
                if (current.GetType().GetInterface(interfaceName) != null)
                {
                    return current as IGridClipboard;
                }

                current = current.Parent;
            }

            return null;
        }

        //private static void CopyChildren(BusinessBase srcEntity, BusinessBase dstEntity)
        //{
        //    PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(srcEntity, false, true);
        //    foreach (PropertyInfo info in properties)
        //    {
        //        if (info.PropertyType == typeof(BusinessCollectionBase) ||
        //            info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
        //        {
        //            BusinessCollectionBase list = info.GetValue(srcEntity, null) as BusinessCollectionBase;
        //            if (list != null && list.Count > 0)
        //            {
        //                BusinessCollectionBase dstChildren = Activator.CreateInstance(list.GetType()) as BusinessCollectionBase;
        //                info.SetValue(dstEntity, dstChildren, null);
        //                CopyChildren(list, dstChildren, dstEntity);
        //            }
        //        }
        //    }
        //}

        //private static void CopyChildren(BusinessCollectionBase srcChildren, BusinessCollectionBase dstChildren, BusinessBase dstEntity)
        //{
        //    foreach (BusinessBase child in srcChildren)
        //    {
        //        BusinessBase entity = Activator.CreateInstance(child.GetType()) as BusinessBase;
        //        if (entity == null)
        //            continue;

        //        entity.CopyFrom(child, false);
        //        SetParentEntity(entity, dstEntity);
        //        dstChildren.Add(entity);
        //    }
        //}
    }
}
