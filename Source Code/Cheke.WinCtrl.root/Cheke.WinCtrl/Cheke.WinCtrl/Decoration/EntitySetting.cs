using System;

namespace Cheke.WinCtrl.Decoration
{
    public class EntitySetting
    {
        private Type _detailFormType = null;

        public EntitySetting()
        {
        }

        public EntitySetting(Type detailFormType)
        {
            this._detailFormType = detailFormType;
        }

        public Type DetailFormType
        {
            get { return _detailFormType; }
            set { _detailFormType = value; }
        }
    }
}