using System;
using System.Windows.Forms;
using Cheke.CardData;

namespace Cheke.ScanShell
{
    public partial class FormScanPassportBase : FormBase
    {
        private NetScanW.CPassportClass mPassport;
        private NetScanWex.CPassportClass mPassportEx;

        public event ProcessPassportHandler ProcessPassport;

        public FormScanPassportBase()
        {
            InitializeComponent();
        }

        public FormScanPassportBase(Control parent)
            : base(parent)
        {
            this.InitializeComponent();
        }

        protected override bool LoadSdk()
        {
            if(!base.LoadSdk())
                return false;

            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected override void UnLoadSdk()
        {
            base.UnLoadSdk();

            try
            {
                mPassportEx = null;
                mPassport = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Scan()
        {
            this.Cursor = Cursors.WaitCursor;
            PassportData data = this.ScanPassport();
            this.UpdateUI(data);
            this.OnProcessPassport(data);
            this.Cursor = Cursors.Default;
        }

        protected virtual void OnProcessPassport(PassportData data)
        {
            if (data != null && this.ProcessPassport != null)
            {
                this.ProcessPassport(data);
            }
        }

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

        protected virtual void UpdateUI(PassportData data)
        {
           
        }
    }
}
