namespace Cheke.ScanShell
{
    /// <summary>
    /// Summary description for CImageConsts.
    /// </summary>
    public class CImageConsts
    {
        //List of all Image definition and error codes

        //return values
        public const int IMG_ERR_SUCCESS= 0;
        public const int IMG_ERR_FILE_OPEN= -100;
        public const int IMG_ERR_BAD_ANGLE_0= -101;
        public const int IMG_ERR_BAD_ANGLE_1= -102;
        public const int IMG_ERR_BAD_DESTINATION= -103;
        public const int IMG_ERR_FILE_SAVE_TO_FILE= -104;
        public const int IMG_ERR_FILE_SAVE_TO_CLIPBOARD= -105;
        public const int IMG_ERR_FILE_OPEN_FIRST= -106;
        public const int IMG_ERR_FILE_OPEN_SECOND= -107;
        public const int IMG_ERR_COMB_TYPE= -108;

        public const int IMG_ERR_BAD_COLOR= -130;
        public const int IMG_ERR_BAD_DPI= -131;
        public const int INVALID_INTERNAL_IMAGE= -132;


        //image saving target definition
        public const int SAVE_TO_FILE= 0;
        public const int SAVE_TO_CLIPBOARD= 1;

        //image rotation angle definitions
        public const int ANGLE_0= 0;
        public const int ANGLE_90= 1;
        public const int ANGLE_180= 2;
        public const int ANGLE_270= 3;

        //image combination options
        public const int IMAGE_COMB_VERTICAL= 0;
        public const int IMAGE_COMB_HORIZONTAL= 1;

        //image color conversion
        public const int IMAGE_SAME_COLOR= 0;
        public const int IMAGE_BW= 2;
        public const int IMAGE_GRAY_256= 1;
        public const int IMAGE_COLOR_256= 3;
        public const int IMAGE_COLOR_TRUE= 4;
    }
}