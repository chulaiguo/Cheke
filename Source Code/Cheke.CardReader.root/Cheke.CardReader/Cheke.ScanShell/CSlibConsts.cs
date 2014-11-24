namespace Cheke.ScanShell
{
    /// <summary>
    /// Summary description for CSlibconst ints.
    /// </summary>
    public class CSlibConst
    {
        //List of all scanner definition and error codes

        //Resolution types
        public const  int RES_200 = 200;
        public const  int RES_300 = 300;
        public const  int RES_400 = 400;
        public const  int RES_600 = 600;

        //Scanner types
        public const int CSSN_NONE = 0;
        public const int CSSN_600 = 1;
        public const int CSSN_800 = 2;
        public const int CSSN_800N = 3;
        public const int CSSN_1000 = 4;
        public const int CSSN_2000 = 5;
        public const int CSSN_2000N = 6;
        public const int CSSN_800E = 7;
        public const int CSSN_800EN = 8;
        public const int CSSN_3000 = 9;
        public const int CSSN_4000 = 10;
        public const int CSSN_800G = 11;
        public const int CSSN_5000 = 12;
        public const int CSSN_IDR = 13;   //snapshell
        public const int CSSN_800DX = 14;
        public const int CSSN_800DXN = 15;
        public const int CSSN_FDA = 16;   //snapshell
        public const int CSSN_TWN = 17;   //snapshell
        public const int LAST_SCANNER = CSSN_TWN;

        //Scanner color scheme types
        public const int GRAY_COLOR = 1;
        public const int BW = 2;
        public const int TRUECOLOR = 4;

        //Scanner return values
        public const int SLIB_FALSE = 0;
        public const int SLIB_TRUE = 1;

        //Scanner general error types
        public const int SLIB_ERR_NONE = 1;
        public const int SLIB_ERR_INVALID_SCANNER = -1;

        //Scanning failure definition
        public const int SLIB_ERR_SCANNER_GENERAL_FAIL = -2;
        public const int SLIB_ERR_CANCELED_BY_USER = -3;
        public const int SLIB_ERR_SCANNER_NOT_FOUND = -4;
        public const int SLIB_ERR_HARDWARE_ERROR  = -5;
        public const int SLIB_ERR_PAPER_FED_ERROR = -6;
        public const int SLIB_ERR_SCANABORT = -7;
        public const int SLIB_ERR_NO_PAPER = -8;
        public const int SLIB_ERR_PAPER_JAM = -9;
        public const int SLIB_ERR_FILE_IO_ERROR = -10;
        public const int SLIB_ERR_PRINTER_PORT_USED = -11;
        public const int SLIB_ERR_OUT_OF_MEMORY = -12;

        public const int SLIB_ERR_BAD_WIDTH_PARAM = -2;
        public const int SLIB_ERR_BAD_HEIGHT_PARAM = -3;

        public const int SLIB_ERR_BAD_PARAM = -2;

        public const int SLIB_LIBRARY_ALREADY_INITIALIZED = -13;
        public const int SLIB_ERR_DRIVER_NOT_FOUND = -14;
        public const int GENERAL_ERR_PLUG_NOT_FOUND = -200;

        //Button definition for ScanShell1000
        public const int TOP_BUTTON = 1;
        public const int MIDDLE_BUTTON = 3;
        public const int BOTTOM_BUTTON = 2;
    }
}