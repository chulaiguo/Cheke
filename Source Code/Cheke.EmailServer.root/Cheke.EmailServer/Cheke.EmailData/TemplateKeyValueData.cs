using System;

namespace Cheke.EmailData
{
    [Serializable]
    public class TemplateKeyValueData
    {
        private string _key = string.Empty;
        private string _value = string.Empty;

        public TemplateKeyValueData()
        {
        }

        public TemplateKeyValueData(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}