using System;

namespace Cheke.EmailData
{
    [Serializable]
    public class AttachmentData
    {
        private string _name = string.Empty;
        private byte[] _data = null;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}