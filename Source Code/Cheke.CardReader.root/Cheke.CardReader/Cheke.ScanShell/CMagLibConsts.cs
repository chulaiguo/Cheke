namespace Cheke.ScanShell
{
    /// <summary>
    /// Summary description for CMagLibConsts.
    /// </summary>
    public class CMagLibConsts
    {
        public const int MAG_ERR_NONE = 1;
        public const int MAG_ERR_CARD_DETECTED= 2;
        public const int MAG_ERR_NO_FREE_COM= -30;
        public const int MAG_ERR_NO_READER_FOUND= -31;
        public const int MAG_ERR_BAD_PARAM= -32;
        public const int MAG_ERR_CARD_NOT_DETECTED= -33;
        public const int SERIAL_NOT_INIT= -34;
        public const int SERIAL_PORT_NOT_OPEN= -35;
        public const int SERIAL_PORT_CONFIG_FAIL= -36;
        public const int SERIAL_COM_TIMEOUT_FAIL= -37;
        public const int SERIAL_FAIL_TO_TX= -38;

        //driver's license card formats
        public const int UNKNOWN_FORMAT= 0;
        public const int LONG_AAMVA= 1;
        public const int SHORT_AAMVA= 2;
        public const int OLD_CA_DMV= 3;
        public const int OLD_LA_DMV= 4;
    }
}