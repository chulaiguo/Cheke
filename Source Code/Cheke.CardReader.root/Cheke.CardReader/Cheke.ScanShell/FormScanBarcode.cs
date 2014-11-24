using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cheke.ScanShell
{
    public partial class FormScanBarcode : FormBase
    {
        private NetScanW.CBarCodeClass mBarCode;
        private NetScanWex.CBarCodeClass mBarCodeEx;

        public event ProcessBarcodeHandler ProcessBarcode;

        public FormScanBarcode()
        {
            InitializeComponent();
        }

        protected override bool LoadSdk()
        {
            if(!base.LoadSdk())
                return false;

            try
            {
                mBarCode = new NetScanW.CBarCodeClass();
                mBarCodeEx = new NetScanWex.CBarCodeClass();

                int ret = mBarCode.InitLibrary(CLicense.LICENSE_VALUE);
                if (ret != CLicense.LICENSE_VALID)
                {
                    switch (ret)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("Error: License Expired! - Library not loaded (BarCode)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("Error: License Invalid for SDK (BarCode)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                            MessageBox.Show("Error: License Invalid for ID Library!  (BarCode)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                            MessageBox.Show("Error: The scanner is not attached or license expired. (BarCode)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                mBarCodeEx = null;
                mBarCode = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Scan()
        {
            this.Cursor = Cursors.WaitCursor;
            this.ScanBarcode();
            this.Cursor = Cursors.Default;

            if (ProcessBarcode != null)
            {
                string barcode = this.txtBC1DBarcode.Text.Trim();
                if (barcode.Length > 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.ProcessBarcode(barcode);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void ScanBarcode()
        {
            try
            {
                //verify that te scanner is connected
                int status = mSLib.IsScannerValid;
                if (status == CSlibConst.SLIB_ERR_INVALID_SCANNER)
                {
                    MessageBox.Show("The scanner is not found. Please verify that the scanner is connected", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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
                    ExtractDataBarcode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExtractDataBarcode()
        {
            try
            {
                this.ResetBarcodeFields();
                this.DisplayImage(base.ImageFilePath); //Display the image in the image tab

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
                        txtBC1DBarcode.Text = mBarCodeEx.Data1D;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetBarcodeFields()
        {
            PictureBox1.Image = null;

            this.txtBC1DBarcode.Text = string.Empty;
        }

        private void DisplayImage(string strImagePath)
        {
            if (strImagePath == "")
                return;

            try
            {
                System.IO.Stream img = new System.IO.FileStream(strImagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                PictureBox1.Image = Image.FromStream(img);
                img.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ResetBarcodeFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.UnLoadSdk();
            this.Cursor = Cursors.Default;

            this.Close();
        }
    }
}
