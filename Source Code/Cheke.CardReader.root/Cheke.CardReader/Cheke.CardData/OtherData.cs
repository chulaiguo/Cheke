namespace Cheke.CardData
{
    public class OtherData
    {
        private string _idType = string.Empty;
        private string _idFormat = string.Empty;
        private byte[] _idData = null;

        public string IDType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public string IDFormat
        {
            get { return _idFormat; }
            set { _idFormat = value; }
        }

        public byte[] IDData
        {
            get { return _idData; }
            set { _idData = value; }
        }
    }
}
