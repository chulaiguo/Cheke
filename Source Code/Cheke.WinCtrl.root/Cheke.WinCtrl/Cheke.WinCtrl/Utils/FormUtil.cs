using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using Cheke.WinCtrl.Common;
using Cheke.WinCtrl.Decoration;
using DevExpress.XtraTab;

namespace Cheke.WinCtrl.Utils
{
    internal static class FormUtil
    {
        internal static object GetFormField(Form form, Type fieldType)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, true, false);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == fieldType)
                {
                    return field.GetValue(form);
                }
            }

            return null;
        }

        internal static GridControlDecorator GetGridDecorator(Form form)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, true, false);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
                {
                    return field.GetValue(form) as GridControlDecorator;
                }
            }

            return null;
        }

        internal static BusinessBase GetEntityData(Form form)
        {
            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(form, true, true);
            foreach (PropertyInfo item in properties)
            {
                if (item.PropertyType == typeof (BusinessBase)
                    || item.PropertyType.IsSubclassOf(typeof(BusinessBase)))
                {
                    return item.GetValue(form, null) as BusinessBase;
                }
            }

            return null;
        }

        internal static List<BusinessCollectionBase> GetListData(Form form)
        {
            List<BusinessCollectionBase> list = new List<BusinessCollectionBase>();
            FieldInfo[] fieldCollection = ReflectorUtilitiy.GetFieldCollection(form, true, false);
            foreach (FieldInfo info in fieldCollection)
            {
                if (info.FieldType == typeof (BusinessCollectionBase) ||
                    info.FieldType.IsSubclassOf(typeof (BusinessCollectionBase)))
                {
                    BusinessCollectionBase data = info.GetValue(form) as BusinessCollectionBase;
                    if (data != null)
                    {
                        list.Add(data);
                    }
                }
            }

            return list;
        }

        internal static void SetFormReadOnly(Form form, bool readOnly)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, true, false);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(EditorBase)))
                {
                    EditorBase editor = field.GetValue(form) as EditorBase;
                    if (editor == null || editor.Tag != null)
                        continue;

                    editor.ReadOnly = readOnly;
                    editor.EnableTooltip(!readOnly);
                    editor.EnableDirtyColor = !readOnly;
                    if (readOnly && editor.IsDirty)
                    {
                        editor.IsDirty = false;
                    }
                }
                else if (field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
                {
                    GridControlDecorator decorator = field.GetValue(form) as GridControlDecorator;
                    if (decorator == null)
                        continue;

                    decorator.Editable = !readOnly;
                }
            }
        }

        internal static bool IsReadOnly(Form form)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, false, true);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(EditorBase)))
                {
                    EditorBase editor = field.GetValue(form) as EditorBase;
                    if (editor == null)
                        continue;

                    if(!editor.ReadOnly)
                        return false;
                }
            }

            return true;
        }

        internal static string GetCustomizeRules(object entity, string fieldName)
        {
            if (entity == null || fieldName.Length == 0)
                return string.Empty;

            MethodInfo method = entity.GetType().GetMethod("GetTooltip", BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if(method == null)
                return string.Empty;

            return method.Invoke(null, new object[] {fieldName}).ToString();
        }

        internal static void ResetGridLayout(Form form)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, false, true);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
                {
                    GridControlDecorator decorator = field.GetValue(form) as GridControlDecorator;
                    if (decorator == null)
                        continue;

                    decorator.ResetLayout();
                }
            }
        }

        internal static void RefreshEditorDataBinding(Form form)
        {
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, true, false);
            foreach (FieldInfo field in fields)
            {
                if (!field.FieldType.IsSubclassOf(typeof(EditorBase)))
                    continue;

                EditorBase editor = field.GetValue(form) as EditorBase;
                if (editor == null)
                    continue;

                editor.RefreshDataBinding();
            }
        }

        internal static void SetChildrenReadOnly(Control parent, bool readOnly)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.GetType().IsSubclassOf(typeof(EditorBase)))
                {
                    EditorBase editor = ctrl as EditorBase;
                    if (editor == null || editor.Tag != null)
                        continue;

                    editor.ReadOnly = readOnly;
                }
            }
        }


        internal static List<XtraTabControl> GetTabControl(Form form)
        {
            List<XtraTabControl> retList = new List<XtraTabControl>();
            FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(form, false, true);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof (XtraTabControl))
                {
                    retList.Add(field.GetValue(form) as XtraTabControl);
                }
            }

            return retList;
        }

        internal static Form GetParentForm(Control current)
        {
            while (current != null)
            {
                if (current is Form)
                {
                    return current as Form;
                }

                current = current.Parent;
            }

            return null;
        }

        internal static XtraTabControl GetParentTabControl(Control current)
        {
            while (current != null)
            {
                if (current is XtraTabControl)
                {
                    return current as XtraTabControl;
                }

                current = current.Parent;
            }

            return null;
        }
    }
}