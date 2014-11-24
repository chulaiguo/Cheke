namespace Cheke.ScanShell
{
    /// <summary>
    /// Summary description for CLicense.
    /// </summary>
    public class CLicense
    {
        /* Setup the license value.
		* For permanent use: You will be provided with a permanent license in your scanner box
		* For evaluation: Use the temporary SDK license, which is given below.
		* If the license is already expired, you may obtain a valid temporary
		* license at http://www.card-reader.com/developers_login.asp
		*/

        public const string LICENSE_VALUE = "99P2XEWA6CTG781W";
       
        //Error types
        public const int LICENSE_VALID = 1;
        public const int LICENSE_EXPIRED = -20;
        public const int LICENSE_INVALID = -21;
        public const int LICENSE_DOES_NOT_MATCH_LIBRARY = -22;
    }
}