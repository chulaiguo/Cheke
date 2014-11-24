using System;

namespace Cheke.Modem
{
    public class RingEventArgs : EventArgs
    {
        private string _originalString = string.Empty;
        private string _phoneNumber = string.Empty;
        private bool _handled = false;

        public bool Handled
        {
            get { return _handled; }
            set { _handled = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string OriginalString
        {
            get { return _originalString; }
            set { _originalString = value; }
        }
    }
}