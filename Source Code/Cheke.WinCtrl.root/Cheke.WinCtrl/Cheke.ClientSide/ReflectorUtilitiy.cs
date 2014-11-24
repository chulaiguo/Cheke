using System;
using System.Reflection;

namespace Cheke.ClientSide
{
    public static class ReflectorUtilitiy
    {
        public static FieldInfo[] GetFieldCollection(object obj, bool includePublic, bool declaredOnly)
        {
            return GetFieldCollection(obj.GetType(), includePublic, declaredOnly);
        }

        public static PropertyInfo[] GetPropertyCollection(object obj, bool includeNoPublic, bool declaredOnly)
        {
            return GetPropertyCollection(obj.GetType(), includeNoPublic, declaredOnly);
        }

        public static FieldInfo[] GetFieldCollection(Type type, bool includePublic, bool declaredOnly)
        {
            BindingFlags flags = BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance;
            if (includePublic)
            {
                flags |= BindingFlags.Public;
            }

            if (declaredOnly)
            {
                flags |= BindingFlags.DeclaredOnly;
            }

            return type.GetFields(flags);
        }

        public static PropertyInfo[] GetPropertyCollection(Type type, bool includeNoPublic, bool declaredOnly)
        {
            BindingFlags flags = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance;
            if (includeNoPublic)
            {
                flags |= BindingFlags.NonPublic;
            }

            if (declaredOnly)
            {
                flags |= BindingFlags.DeclaredOnly;
            }

            return type.GetProperties(flags);
        }


        public static void ClearPropertyValue(object obj, Type fieldType)
        {
            PropertyInfo[] fieldCollection = GetPropertyCollection(obj, true, true);
            foreach (PropertyInfo info in fieldCollection)
            {
                if(!info.CanWrite)
                    continue;

                if (info.PropertyType == fieldType)
                {
                    info.SetValue(obj, null, null);
                    return;
                }
            }
        }

        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            PropertyInfo[] fieldCollection = GetPropertyCollection(obj, false, false);
            foreach (PropertyInfo info in fieldCollection)
            {
                if (!info.CanWrite)
                    continue;

                if (info.Name == propertyName)
                {
                    info.SetValue(obj, value, null);
                    return;
                }
            }
        }
    }
}