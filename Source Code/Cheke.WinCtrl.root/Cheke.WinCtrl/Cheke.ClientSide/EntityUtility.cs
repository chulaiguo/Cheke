using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cheke.BusinessEntity;
using System.Text;

namespace Cheke.ClientSide
{
    public static class EntityUtility
    {
        #region Accept Delete
        public static void AcceptDeletes(BusinessBase item, Result r)
        {
            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(item, false, true);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(BusinessCollectionBase) ||
                    info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
                {
                    BusinessCollectionBase children = info.GetValue(item, null) as BusinessCollectionBase;
                    if (children != null)
                    {
                        AcceptDeletes(children, r);
                    }
                }
            }
        }

        public static void AcceptDeletes(BusinessCollectionBase list, Result r)
        {
            list.AcceptDeletes(r);

            foreach (BusinessBase item in list)
            {
                AcceptDeletes(item, r);
            }
        }

        #endregion

        #region Replace item

        public static void ReplaceItem(BusinessBase entity, BusinessBase newEntity)
        {
            if (entity == null || newEntity == null)
                return;

            if (newEntity.GetType() == entity.GetType())
            {
                if (!newEntity.IsDeleted && entity.Equals(newEntity))
                {
                    entity.CopyFrom(newEntity, true);
                }

                return;
            }

            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(entity, false, true);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(BusinessCollectionBase) ||
                    info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
                {
                    BusinessCollectionBase list = info.GetValue(entity, null) as BusinessCollectionBase;
                    if (list == null)
                        continue;

                    ReplaceChildren(list, newEntity, entity);
                }
            }
        }

        private static void ReplaceChildren(BusinessCollectionBase list, BusinessBase newEntity, BusinessBase parent)
        {
            //self
            if (list.GetItemType() == newEntity.GetType())
            {
                BusinessBase child = FindChild(list, newEntity);
                if (child != null)
                {
                    if (newEntity.IsDeleted || !IsEntityParent(newEntity, parent))
                    {
                        list.Remove(child);
                        list.AcceptChanges(child.ObjectID);
                    }
                    else
                    {
                        child.CopyFrom(newEntity, true);
                    }
                }
                else
                {
                    BusinessBase deletedChild = FindDeletedChild(list, newEntity);
                    if (deletedChild != null)
                    {
                        list.AcceptChanges(deletedChild.ObjectID);
                    }

                    if (!newEntity.IsDeleted && IsEntityParent(newEntity, parent))
                    {
                        list.Add(newEntity);
                    }
                }
            }

            //children
            foreach (BusinessBase item in list)
            {
                ReplaceItem(item, newEntity);
            }
        }

        public static void ReplaceList(BusinessCollectionBase list, BusinessBase newEntity)
        {
            if (list == null || newEntity == null)
                return;

            SortedList<string, Type> sortedList = new SortedList<string, Type>();
            sortedList.Add(list.GetItemType().FullName, list.GetItemType());
            if(!Replaceable(list, newEntity, sortedList))
                return;

            //self
            if (list.GetItemType() == newEntity.GetType())
            {
                BusinessBase child = FindChild(list, newEntity);
                if (child != null)
                {
                    if (newEntity.IsDeleted)
                    {
                        list.Remove(child);
                        list.AcceptChanges(child.ObjectID);
                    }
                    else
                    {
                        child.CopyFrom(newEntity, true);
                    }
                }
                else
                {
                    BusinessBase deletedChild = FindDeletedChild(list, newEntity);
                    if (deletedChild != null)
                    {
                        list.AcceptChanges(deletedChild.ObjectID);
                    }

                    if (!newEntity.IsDeleted)
                    {
                        list.Add(newEntity);
                    }
                }

                return;
            }

            //children
            foreach (BusinessBase item in list)
            {
                ReplaceItem(item, newEntity);
            }
        }

        private static bool Replaceable(BusinessCollectionBase list, BusinessBase newEntity, SortedList<string, Type> sortedList)
        {
            if (list == null || newEntity == null)
                return false;

            if (list.GetItemType() == newEntity.GetType())
                return true;

            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(list.GetItemType(), false, true);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(BusinessCollectionBase) ||
                    info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
                {
                    if(sortedList.ContainsKey(info.PropertyType.FullName))
                        continue;

                    sortedList.Add(info.PropertyType.FullName, info.PropertyType);

                    BusinessCollectionBase children = Activator.CreateInstance(info.PropertyType) as BusinessCollectionBase;
                    if(Replaceable(children, newEntity, sortedList))
                        return true;
                }
            }

            return false;
        }

        public static void ReplaceListParent(BusinessCollectionBase list, BusinessBase newEntity)
        {
            PropertyInfo property = GetParentProperty(list.GetItemType(), newEntity.GetType());
            if (property == null)
                return;

            ReplaceParent(list, property, newEntity);
        }

        private static BusinessBase FindChild(BusinessCollectionBase list, BusinessBase entity)
        {
            int index = list.IndexOf(entity);
            if (index == -1)
                return null;

            return list[index];
        }

        private static BusinessBase FindDeletedChild(BusinessCollectionBase list, BusinessBase entity)
        {
            ArrayList deletedList = list.GetDeletedList();
            foreach (BusinessBase item in deletedList)
            {
                if (item.Equals(entity))
                    return item;
            }

            return null;
        }

        #endregion

        #region Replace parent

        private static void ReplaceParent(BusinessCollectionBase list, PropertyInfo parentProperty, BusinessBase parent)
        {
            if (list == null || parent == null || parentProperty == null)
                return;

            if (parent.IsDeleted)
            {
                List<BusinessBase> deletedList = new List<BusinessBase>();
                foreach (BusinessBase item in list)
                {
                    if (parent.Equals(parentProperty.GetValue(item, null)))
                    {
                        deletedList.Add(item);
                    }
                }

                foreach (BusinessBase item in deletedList)
                {
                    list.Remove(item);
                    list.AcceptChanges(item.ObjectID);
                }
            }
            else
            {
                foreach (BusinessBase item in list)
                {
                    ReplaceParent(item, parentProperty, parent);
                }
            }
        }

        public static void ReplaceParent(BusinessBase entity, PropertyInfo parentProperty, BusinessBase parent)
        {
            if (entity == null || parent == null || parentProperty == null)
                return;

            object entityParent = parentProperty.GetValue(entity, null);
            if (parent.Equals(entityParent))
            {
                parentProperty.SetValue(entity, parent, null);
            }
        }

        #endregion

        #region GetListChanges

        public static List<BusinessBase> GetChanges(BusinessBase item)
        {
            List<BusinessBase> changed = new List<BusinessBase>();
            if (item == null || !item.IsDirty)
                return changed;

            GetItemChanges(item, changed);
            return changed;
        }

        public static List<BusinessBase> GetChanges(BusinessCollectionBase list)
        {
            List<BusinessBase> changed = new List<BusinessBase>();
            if (list == null || !list.IsDirty)
                return changed;

            GetListChanges(list, changed);
            return changed;
        }

        private static void GetListChanges(BusinessCollectionBase list, List<BusinessBase> changed)
        {
            ArrayList deletedList = list.GetDeletedList();
            foreach (BusinessBase item in deletedList)
            {
                changed.Add(item);
            }

            foreach (BusinessBase item in list)
            {
                if (!item.IsDirty)
                    continue;

                GetItemChanges(item, changed);
            }
        }

        private static void GetItemChanges(BusinessBase item, List<BusinessBase> changed)
        {
            if (item.IsDeleted)
            {
                changed.Add(item);
                return;
            }

            if (item.IsSelfDirty)
            {
                changed.Add(item);
            }

            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(item, false, true);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(BusinessCollectionBase) ||
                    info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
                {
                    BusinessCollectionBase list = info.GetValue(item, null) as BusinessCollectionBase;
                    if (list != null)
                    {
                        GetListChanges(list, changed);
                    }
                }
            }
        }

        public static BusinessCollectionBase GetListChanges(BusinessCollectionBase list)
        {
            BusinessCollectionBase retList = Activator.CreateInstance(list.GetType()) as BusinessCollectionBase;
            if (retList == null)
                return list;

            foreach (BusinessBase item in list)
            {
                if (!item.IsDirty)
                    continue;

                retList.Add(item);
            }

            ArrayList deletedList = list.GetDeletedList();
            foreach (BusinessBase item in deletedList)
            {
                item.Delete();
                retList.Add(item);
            }

            return retList;
        }

        public static List<BusinessCollectionBase> SplitList(BusinessCollectionBase list, int interval)
        {
            List<BusinessCollectionBase> retList = new List<BusinessCollectionBase>();

            BusinessCollectionBase children = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (i % interval == 0)
                {
                    children = Activator.CreateInstance(list.GetType()) as BusinessCollectionBase;
                    retList.Add(children);
                }

                if (children != null)
                {
                    children.Add(list[i]);
                }
            }

            return retList;
        }


        #endregion

        #region GetInValidInfo
        public static Result GetInvalidInfo(BusinessBase entity)
        {
            StringBuilder builder = new StringBuilder();
            GetItemInvalidInfo(entity, builder);

            return new Result(builder.ToString());
        }

        public static Result GetInvalidInfo(BusinessCollectionBase list)
        {
            StringBuilder builder = new StringBuilder();
            GetListInvalidInfo(list, builder);

            return new Result(builder.ToString());
        }

        private static void GetItemInvalidInfo(BusinessBase item, StringBuilder builder)
        {
            builder.AppendLine(item.BrokenRulesString);

            //if (item.RulesCollection.Count > 0)
            //{
            //    builder.AppendLine(string.Format("{0}:", item.TableName));
            //    foreach (Rule rule in item.RulesCollection)
            //    {
            //        builder.AppendLine(string.Format("\t{0}", rule.Description));
            //    }
            //}

            //PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(item, false, true);
            //foreach (PropertyInfo info in properties)
            //{
            //    if (info.PropertyType == typeof(BusinessCollectionBase) ||
            //        info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
            //    {
            //        BusinessCollectionBase list = info.GetValue(item, null) as BusinessCollectionBase;
            //        if (list != null)
            //        {
            //            GetListInvalidInfo(list, builder);
            //        }
            //    }
            //}
        }

        private static void GetListInvalidInfo(BusinessCollectionBase list, StringBuilder builder)
        {
            foreach (BusinessBase item in list)
            {
                GetItemInvalidInfo(item, builder);
            }
        }
        #endregion

        #region MiscFunctions

        public static bool IsEntityParent(BusinessBase entity, BusinessBase parent)
        {
            PropertyInfo property = GetParentProperty(entity.GetType(), parent.GetType());
            if (property == null)
                return false;

            return parent.Equals(property.GetValue(entity, null));
        }

        public static PropertyInfo GetParentProperty(Type entityType, Type parentType)
        {
            PropertyInfo[] properties = entityType.GetProperties();
            foreach (PropertyInfo item in properties)
            {
                if (item.PropertyType != parentType)
                    continue;

                return item;
            }

            return null;
        }

        public static bool IsEntityDataEqual(BusinessBase entity, BusinessBase cmpEntity)
        {
            if (entity == null || cmpEntity == null)
                return false;

            if (entity.GetType() != cmpEntity.GetType())
                return false;

            PropertyInfo[] properties = ReflectorUtilitiy.GetPropertyCollection(entity, false, true);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType.IsSubclassOf(typeof(BusinessBase)))
                    continue;

                if (info.PropertyType.IsSubclassOf(typeof(BusinessCollectionBase)))
                {
                    BusinessCollectionBase list1 = info.GetValue(entity, null) as BusinessCollectionBase;
                    BusinessCollectionBase list2 = info.GetValue(cmpEntity, null) as BusinessCollectionBase;
                    if (list1 == null && list2 == null)
                        continue;

                    if (list1 == null)
                    {
                        if (list2.Count == 0)
                            continue;

                        return false;
                    }

                    if (list2 == null)
                    {
                        if (list1.Count == 0)
                            continue;

                        return false;
                    }

                    if (list1.Count != list2.Count)
                        return false;

                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (list1[i] == null && list2[i] == null)
                            continue;

                        if (!IsEntityDataEqual(list1[i], list2[i]))
                            return false;
                    }
                }
                else
                {
                    object val1 = info.GetValue(entity, null);
                    object val2 = info.GetValue(cmpEntity, null);
                    if (val1 == null && val2 == null)
                        continue;

                    if (val1 == null || val2 == null)
                        return false;

                    if (!val1.Equals(val2))
                        return false;
                }
            }

            return true;
        }

        public static void SynchronizeParentData(BusinessBase srcEntity, BusinessBase dstEntity)
        {
            if (srcEntity.GetType() != dstEntity.GetType())
                return;

            PropertyInfo[] properties = srcEntity.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo info in properties)
            {
                if (!info.PropertyType.IsSubclassOf(typeof(BusinessBase)))
                    continue;

                object parent = info.GetValue(srcEntity, null);
                info.SetValue(dstEntity, parent, null);
            }
        }

        public static void CopyParent(BusinessBase parent, BusinessBase child)
        {
            Type parentType = parent.GetType();

            PropertyInfo[] properties = child.GetType().GetProperties(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType != parentType)
                    continue;

                info.SetValue(child, parent, null);
            }
        }

        #endregion
    }
}