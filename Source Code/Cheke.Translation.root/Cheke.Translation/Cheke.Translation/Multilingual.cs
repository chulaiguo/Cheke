using System;

namespace Cheke.Translation
{
    [Serializable]
    public class Multilingual
    {
        private string _key = string.Empty;
        private string _english = string.Empty;
        private string _other = string.Empty;

        [NonSerialized] private bool _isDirty = false;
        [NonSerialized] private bool _isNew = false;

        public string Key
        {
            get { return _key; }
            set
            {
                if (this._key != value)
                {
                    this._key = value;
                    this.MarkDirty();
                }
            }
        }

        public string English
        {
            get { return _english; }
            set
            {
                if (this._english != value)
                {
                    this._english = value;
                    this.MarkDirty();
                }
            }
        }

        public string Other
        {
            get { return _other; }
            set
            {
                if (this._other != value)
                {
                    this._other = value;
                    this.MarkDirty();
                }
            }
        }

        public string Group
        {
            get { return this.Key.Split('|')[0]; }
        }

        public virtual bool IsDirty
        {
            get { return this._isDirty; }
        }

        public bool IsSelfDirty
        {
            get { return this._isDirty; }
        }

        public bool IsNew
        {
            get { return this._isNew; }
        }

        public void AcceptChanges()
        {
            this._isDirty = false;
            this._isNew = false;
        }

        private void MarkDirty()
        {
            this._isDirty = true;
        }
    }

    public class MultilingualSchema
    {
        public const string Group = "Group";
        public const string Key = "Key";
        public const string English = "English";
        public const string Other = "Other";
    }
}