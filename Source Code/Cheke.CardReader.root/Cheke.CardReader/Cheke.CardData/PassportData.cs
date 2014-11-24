namespace Cheke.CardData
{
    public class PassportData
    {
        private string _nameFirst = string.Empty;
        private string _nameLast = string.Empty;

        private byte[] _rawImage = null;

        public string NameFirst
        {
            get { return _nameFirst; }
            set { _nameFirst = value; }
        }

        public string NameLast
        {
            get { return _nameLast; }
            set { _nameLast = value; }
        }

        public byte[] RawImage
        {
            get { return _rawImage; }
            set { _rawImage = value; }
        }
    }
}