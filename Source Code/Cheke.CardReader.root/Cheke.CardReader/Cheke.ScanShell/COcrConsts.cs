namespace Cheke.ScanShell
{
    /// <summary>
    /// Summary description for COcrConsts.
    /// </summary>
    public class COcrConsts
    {
        //return values
        public const int TOCR_SUCCESS = 1;
        public const int TOCRJOBERROR = -2;
        public const int TOCR_BAD_TYPE = -3;

        //OCR text type detection
        public const int USE_ALPHANUM = 0;
        public const int USED_NUM_ONLY = 2;
        public const int USE_ALPHA_CAPS_ONLY = 3;
    }
}