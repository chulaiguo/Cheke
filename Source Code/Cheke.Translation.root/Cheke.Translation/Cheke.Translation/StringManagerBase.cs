using System;
using System.Reflection;

namespace Cheke.Translation
{
    public class StringManagerBase
    {
        protected static string Translate(string methodName, string text)
        {
            //remove the prefix: "get_" of method name
            if (methodName.StartsWith("get_"))
            {
                methodName = methodName.Substring(4);
            }

            string key = string.Format("StringManager|{0}", methodName);
            string translate = Translator.Instance.Translate(key);
            return translate.Length > 0 ? translate : text;
        }

        protected static void GetTranslateString(Type type)
        {
            if(type == typeof(object))
                return;

            BindingFlags flags = BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Static;
            FieldInfo[] fields = type.GetFields(flags);
            foreach (FieldInfo field in fields)
            {
                object obj = field.GetValue(null);
                if (obj == null)
                    continue;

                string text = obj.ToString();
                string name = field.Name.Substring(1);//remove the prefix: "_" of field name
                string key = string.Format("StringManager|{0}", name);
                Translator.Instance.AddTranslateString(key, text);
            }

            GetTranslateString(type.BaseType);
        }
    }
}