using System;
using System.IO;
using System.Windows.Forms;
using Cheke.CardData;

namespace Cheke.ScanShell
{
    public partial class FormScanBase : FormBase
    {
        private NetScanW.CBarCodeClass mBarCode;
        private NetScanWex.CBarCodeClass mBarCodeEx;

        private NetScanW.MagLibClass mMagLib;
        private NetScanWex.MagLibClass mMagLibEx;

        private NetScanW.CPassportClass mPassport;
        private NetScanWex.CPassportClass mPassportEx;

        private ScanType _scanType = ScanType.DLByOCR;

        public FormScanBase()
        {
            InitializeComponent();
        }

        public FormScanBase(Control parent)
            : base(parent)
        {
            this.InitializeComponent();
        }

        public ScanType ScanType
        {
            get { return _scanType; }
            set { _scanType = value; }
        }

        #region Load/Unlod SDK
        protected override bool LoadSdk()
        {
            if (!base.LoadSdk())
                return false;

            try
            {
                if (!this.LoadBarcodeSdk())
                    return false;

                if (!this.LoadMagneticSdk())
                    return false;

                if (!this.LoadPassportSdk())
                    return false;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool LoadBarcodeSdk()
        {
            mBarCode = new NetScanW.CBarCodeClass();
            mBarCodeEx = new NetScanWex.CBarCodeClass();

            int ret = mBarCode.InitLibrary(CLicense.LICENSE_VALUE);
            if (ret != CLicense.LICENSE_VALID)
            {
                switch (ret)
                {
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("Error: License Expired! - Library not loaded (BarCode)",
                                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("Error: License Invalid for SDK (BarCode)", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                        MessageBox.Show("Error: License Invalid for ID Library!  (BarCode)", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                        MessageBox.Show("Error: The scanner is not attached or license expired. (BarCode)",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            if (ret == CLicense.LICENSE_VALID || ret == CSlibConst.SLIB_LIBRARY_ALREADY_INITIALIZED)
            {
                return true;
            }

            return false;
        }

        private bool LoadMagneticSdk()
        {
            mMagLib = new NetScanW.MagLibClass();
            mMagLibEx = new NetScanWex.MagLibClass();

            int ret = mMagLib.InitLibrary(CLicense.LICENSE_VALUE);
            if (ret != CLicense.LICENSE_VALID)
            {
                switch (ret)
                {
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("Error: License Expired! - Library not loaded (MagLib)",
                                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("Error: License Invalid for SDK (MagLib)", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                        MessageBox.Show("Error: License Invalid for ID Library!  (MagLib)", this.Text,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                        //MessageBox.Show("Error: The scanner is not attached or license expired.(MagLib)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ret = CLicense.LICENSE_VALID;
                        break;
                    case CMagLibConsts.MAG_ERR_NO_READER_FOUND:
                        //MessageBox.Show("Error: The magnetic reader is not attached or license expired.(MagLib)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ret = CLicense.LICENSE_VALID;
                        break;
                }
            }

            if (ret == CLicense.LICENSE_VALID || ret == CSlibConst.SLIB_LIBRARY_ALREADY_INITIALIZED)
            {
                return true;
            }

            return false;
        }

        private bool LoadPassportSdk()
        {
            mPassport = new NetScanW.CPassportClass();
            mPassportEx = new NetScanWex.CPassportClass();

            int ret = mPassport.Init(CLicense.LICENSE_VALUE);
            if (ret != CLicense.LICENSE_VALID)
            {
                switch (ret)
                {
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("Error: License Expired! - Library not loaded (Passport)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("Error: License Invalid for SDK (Passport)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                        MessageBox.Show("Error: License Invalid for ID Library!  (Passport)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                        MessageBox.Show("Error: The scanner is not attached or license expired.(Passport)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            if (ret == CLicense.LICENSE_VALID || ret == CSlibConst.SLIB_LIBRARY_ALREADY_INITIALIZED)
            {
                return true;
            }

            return false;
        }

        protected override void UnLoadSdk()
        {
            base.UnLoadSdk();

            try
            {
                mBarCodeEx = null;
                mBarCode = null;

                if (mMagLibEx != null)
                {
                    mMagLibEx.ReleasePort();
                }
                mMagLibEx = null;
                mMagLib = null;

                mPassportEx = null;
                mPassport = null;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Scan
        protected override void Scan()
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.ScanType == ScanType.Passport)
            {
                PassportData data = this.ScanPassport();
                this.UpdatePassportUI(data);
                this.OnProcessPassport(data);

            }
            else
            {
                DriverLicenseData data = null;
                switch (this.ScanType)
                {
                    case ScanType.DLByBarcode:
                        data = this.ScanByBarcode();
                        break;
                    case ScanType.DLByMagnetic:
                        data = this.ExtractDataByMagnetic();
                        break;
                    case ScanType.DLByOCR:
                        data = this.ScanByOCR();
                        break;
                }

                this.UpdateDriverLicenseUI(data);
                this.OnProcessDriverLicenses(data);
            }
            this.Cursor = Cursors.Default;
        }

        protected virtual void OnProcessDriverLicenses(DriverLicenseData data)
        {
            
        }

        protected virtual void OnProcessPassport(PassportData data)
        {
           
        }

        protected virtual void UpdateDriverLicenseUI(DriverLicenseData data)
        {
        }

        protected virtual void UpdatePassportUI(PassportData data)
        {
        }
        #endregion

        #region Barcode
        private DriverLicenseData ScanByBarcode()
        {
            try
            {
                //verify that te scanner is connected
                int status = mSLib.IsScannerValid;
                if (status == CSlibConst.SLIB_ERR_INVALID_SCANNER)
                {
                    MessageBox.Show("The scanner is not found. Please verify that the scanner is connected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                mSLib.Resolution = 600;   //(600 is recomnded for most Barcode cards)
                mSLib.ScannerColorScheme = CSlibConst.TRUECOLOR;    //(recomnded for passports)
                mSLib.ScanHeight = 360;  //(recomnded for most Barcode cards)
                mSLib.ScanWidth = 220;   //(recomnded for most Barcode cards)
                mSLibEx.InOutScan = 0;

                mSLib.ScanToFileEx(base.ImageFilePath);       //Scan the card
                int lastError = mSLib.LastErrorStatus;           //Verify that the scan complete successfully
                if (lastError != CSlibConst.SLIB_TRUE)
                {
                    this.Cursor = Cursors.Default;
                    switch (lastError)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_GENERAL_FAIL:
                            MessageBox.Show("ERROR: General failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_CANCELED_BY_USER:
                            MessageBox.Show("ERROR: Scan canceled by the user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_NOT_FOUND:
                            MessageBox.Show("ERROR: Scanner not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_HARDWARE_ERROR:
                            MessageBox.Show("ERROR: Hardware failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_FED_ERROR:
                            MessageBox.Show("ERROR: Paper feed problem", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANABORT:
                            MessageBox.Show("ERROR: Scanner aborted", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_NO_PAPER:
                            MessageBox.Show("ERROR: No paper found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_JAM:
                            MessageBox.Show("ERROR: Paper Jammed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_FILE_IO_ERROR:
                            MessageBox.Show("ERROR: Hardware IO failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PRINTER_PORT_USED:
                            MessageBox.Show("ERROR: Printer port already used by other utility (for parallel models only)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_OUT_OF_MEMORY:
                            MessageBox.Show("ERROR: Out of memory", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                            MessageBox.Show("ERROR: Scanner type is not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    return ExtractDataByBarcode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private DriverLicenseData ExtractDataByBarcode()
        {
            try
            {
                //Make sure that you have scanned an image before using this
                //function. This image is stored internaly by the dll and used for
                //data extraction. Its the application job to verify this condition.
                //Using 'ProcImage()' without scanning preceding image scan yield
                //false results.
                long retVal = mBarCode.ProcImage("");
                switch (retVal)
                {
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                        MessageBox.Show("ERROR: Scanner is not connected/responding", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CidLibConsts.ID_ERR_STATE_NOT_SUPORTED:
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("ERROR: State type is not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        //Get fresh data from OCR
                        mBarCode.RefreshData();

                        //Load a copy from the data
                        DriverLicenseData data = new DriverLicenseData();
                        data.RawImage = base.GetRwaImage();
                        data.NameFirst = mBarCode.NameFirst;
                        data.NameLast = mBarCode.NameLast;
                        return data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        #endregion

        #region Magnetic
        private DriverLicenseData ExtractDataByMagnetic()
        {
            try
            {
                if (mMagLib.WasCardSweeped() == CMagLibConsts.MAG_ERR_CARD_DETECTED)
                {
                    if (mMagLib.Process() != CMagLibConsts.UNKNOWN_FORMAT)
                    {
                        DriverLicenseData data = new DriverLicenseData();
                        data.NameFirst = mMagLib.NameFirst;
                        data.NameLast = mMagLib.NameLast;
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        #endregion

        #region OCR
        private DriverLicenseData ScanByOCR()
        {
            try
            {
                //verify that te scanner is connected
                int status = mSLib.IsScannerValid;
                if (status == CSlibConst.SLIB_ERR_INVALID_SCANNER)
                {
                    MessageBox.Show("The scanner is not found. Please verify that the scanner is connected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                //Set the scan properties
                mSLib.Resolution = 300;    //(300 is recomnded for most DL\ID cards)
                mSLib.ScannerColorScheme = CSlibConst.TRUECOLOR;    //(recomnded for most DL\ID cards)
                mSLib.ScanHeight = 360;  //(recomnded for most DL\ID cards)
                mSLib.ScanWidth = 220;   //(recomnded for most DL\ID cards)
                mSLibEx.InOutScan = 0;
                mSLibEx.Duplex = 0;

                mSLib.ScanToFileEx(base.ImageFilePath);       //Scan the card
                short lastError = mSLib.LastErrorStatus;     //Verify that the scan complete successfully
                if (lastError != CSlibConst.SLIB_TRUE)
                {
                    switch (lastError)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_GENERAL_FAIL:
                            MessageBox.Show("ERROR: General failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_CANCELED_BY_USER:
                            MessageBox.Show("ERROR: Scan canceled by the user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_NOT_FOUND:
                            MessageBox.Show("ERROR: Scanner not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_HARDWARE_ERROR:
                            MessageBox.Show("ERROR: Hardware failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_FED_ERROR:
                            MessageBox.Show("ERROR: Paper feed problem", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANABORT:
                            MessageBox.Show("ERROR: Scanner aborted", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_NO_PAPER:
                            MessageBox.Show("ERROR: No paper found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_JAM:
                            MessageBox.Show("ERROR: Paper Jammed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_FILE_IO_ERROR:
                            MessageBox.Show("ERROR: Hardware IO failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PRINTER_PORT_USED:
                            MessageBox.Show("ERROR: Printer port already used by other utility (for parallel models only)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_OUT_OF_MEMORY:
                            MessageBox.Show("ERROR: Out of memory", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                            MessageBox.Show("ERROR: Scanner type is not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    return this.ExtractDataByOCR();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private DriverLicenseData ExtractDataByOCR()
        {
            try
            {
                string imageSource = string.Empty;

                int angle;
                int stateId = mIdData.AutoDetectStateEx(imageSource, out angle);

                if (angle != CImageConsts.ANGLE_0)
                {
                    mImage.RotateImage("", CImageConsts.ANGLE_0, CImageConsts.SAVE_TO_FILE, base.ImageFilePath);
                }

                mIdDataEx.WideCharacters = 0;
                long retVal = mIdData.ProcState(imageSource, stateId);
                switch (retVal)
                {
                    case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                        MessageBox.Show("ERROR: Plug (scanner) not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                        MessageBox.Show("ERROR: Scanner is not connected/responding", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CidLibConsts.ID_ERR_STATE_NOT_SUPORTED:
                        MessageBox.Show("ERROR: State type is not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        //Get fresh data from OCR
                        mIdData.RefreshData();

                        //Load a copy from the data
                        DriverLicenseData data = new DriverLicenseData();
                        data.RawImage = base.GetRwaImage();
                        data.NameFirst = mIdData.NameFirst;
                        data.NameLast = mIdData.NameLast;
                        data.NameMiddle = mIdData.NameMiddle;
                        data.DateOfBirth = mIdDataEx.DateOfBirth4;
                        data.IssueDate = mIdDataEx.IssueDate4;
                        data.ExpirationDate = mIdDataEx.ExpirationDate4;
                        data.EyeColor = mIdData.Eyes;
                        data.HairColor = mIdData.Hair;
                        data.HeightCm = mIdData.Height;
                        data.WeightKg = mIdData.Weight;
                        data.Address1 = mIdData.Address;
                        data.Address2 = mIdData.Address2;
                        data.City = mIdData.City;
                        data.State = mIdData.State;
                        data.PostalCode = mIdData.Zip;
                        data.RestrictionCodes = mIdData.Restriction;
                        data.Gender = mIdData.Sex;
                        data.SocialSecurityNumber = mIdData.SocialSecurity;

                        // Get face image
                        string fileName = string.Format(@"{0}\ChekeScanShellFaceImage.jpg", System.IO.Path.GetTempPath());
                        int result = mIdData.GetFaceImage(imageSource, fileName, stateId);
                        if (result >= 0)
                        {
                            using (FileStream fs = new FileStream(fileName, FileMode.Open))
                            {
                                data.FaceImage = new byte[fs.Length];
                                fs.Read(data.FaceImage, 0, data.FaceImage.Length);
                            }
                        }

                        return data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        #endregion

        #region Passport
        private PassportData ScanPassport()
        {
            try
            {
                //verify that te scanner is connected
                int status = mSLib.IsScannerValid;
                if (status == CSlibConst.SLIB_ERR_INVALID_SCANNER)
                {
                    MessageBox.Show("The scanner is not found. Please verify that the scanner is connected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                //Set the scan properties
                switch (mSLib.ScannerType)
                {
                    case CSlibConst.CSSN_1000:
                    case CSlibConst.CSSN_4000:
                        mSLibEx.InOutScan = 0;
                        break;
                    case CSlibConst.CSSN_3000:
                        mSLibEx.InOutScan = 1;
                        break;
                    default:
                        MessageBox.Show("The scanner you using cannot scan passports", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                }

                mSLib.Resolution = 300;
                mSLib.ScannerColorScheme = CSlibConst.TRUECOLOR;
                mSLib.ScanHeight = 500;
                mSLib.ScanWidth = 300;
                mSLibEx.Duplex = 0;
                mSLib.ScanToFileEx(base.ImageFilePath);       //Scan the card
                int lastError = mSLib.LastErrorStatus;
                if (lastError != CSlibConst.SLIB_TRUE)
                {
                    switch (lastError)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_GENERAL_FAIL:
                            MessageBox.Show("ERROR: General failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_CANCELED_BY_USER:
                            MessageBox.Show("ERROR: Scan canceled by the user", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_NOT_FOUND:
                            MessageBox.Show("ERROR: Scanner not found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_HARDWARE_ERROR:
                            MessageBox.Show("ERROR: Hardware failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_FED_ERROR:
                            MessageBox.Show("ERROR: Paper feed problem", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANABORT:
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("ERROR: Scanner aborted", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_NO_PAPER:
                            MessageBox.Show("ERROR: No paper found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PAPER_JAM:
                            MessageBox.Show("ERROR: Paper Jammed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_FILE_IO_ERROR:
                            MessageBox.Show("ERROR: Hardware IO failure", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_PRINTER_PORT_USED:
                            MessageBox.Show("ERROR: Printer port already used by other utility (for parallel models only)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_OUT_OF_MEMORY:
                            MessageBox.Show("ERROR: Out of memory", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                            MessageBox.Show("ERROR: Scanner type is not supported", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }
                else
                {
                    mImage.RotateImage("", CImageConsts.ANGLE_180, CImageConsts.SAVE_TO_FILE, ""); //This will roate the internal image and make it ready to process
                    mImage.RotateImage("", CImageConsts.ANGLE_0, CImageConsts.SAVE_TO_FILE, base.ImageFilePath);	//This will rotate the local image that you want to display
                    return ExtractDataPassport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private PassportData ExtractDataPassport()
        {
            try
            {
                long retVal = mPassport.Process("");
                switch (retVal)
                {
                    case CLicense.LICENSE_EXPIRED:
                        MessageBox.Show("ERROR: Licance expired!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CLicense.LICENSE_INVALID:
                        MessageBox.Show("ERROR: Licence does not match this type of library", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case CSlibConst.SLIB_ERR_INVALID_SCANNER:
                        MessageBox.Show("ERROR: Scanner is not connected/responding", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        //Get fresh data from OCR	
                        PassportData data = new PassportData();
                        data.RawImage = base.GetRwaImage();
                        data.NameFirst = mPassport.NameFirst;
                        data.NameLast = mPassport.NameLast;
                        return data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }
        #endregion
    }

    public enum ScanType
    {
        DLByOCR,
        DLByBarcode,
        DLByMagnetic,
        Passport
    }
}
