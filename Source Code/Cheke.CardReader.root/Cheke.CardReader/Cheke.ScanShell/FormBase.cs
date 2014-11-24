using System;
using System.IO;
using System.Windows.Forms;
using Cheke.CardData;

namespace Cheke.ScanShell
{
    public delegate void ProcessDriverLicensesHandler(DriverLicenseData data);
    public delegate void ProcessPassportHandler(PassportData data);
    public delegate void ProcessBarcodeHandler(string barcode);

    public partial class FormBase : Form
    {
        private string _imageFilePath = string.Empty;

        protected NetScanW.CImageClass mImage;
        protected NetScanWex.CImageClass mImageEx;
        protected NetScanW.IdDataClass mIdData;
        protected NetScanWex.IdDataClass mIdDataEx;
        protected NetScanW.SLibExClass mSLib;
        protected NetScanWex.SLibExClass mSLibEx;

        public FormBase()
        {
            InitializeComponent();
        }

        public FormBase(Control parent)
        {
            this.InitializeComponent();

            this.SetParent(parent);
        }

        protected string ImageFilePath
        {
            get { return _imageFilePath; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(this.DesignMode)
                return;

            this.Cursor = Cursors.WaitCursor;
            bool ret = this.LoadSdk();
            this.Cursor = Cursors.Default;

            if(!ret)
            {
                this.UnLoadSdk();
                this.Close();
            }

            this._imageFilePath = string.Format(@"{0}ChekeScanShell.bmp", System.IO.Path.GetTempPath());
            this.TimerAutoScan.Enabled = true;
        }

       

        /// <summary>
        /// This sub will load the sdk and intilaized it with the license key
        /// </summary>
        /// <returns></returns>
        protected virtual bool LoadSdk()
        {
            try
            {
                mSLib = new NetScanW.SLibExClass();
                mSLibEx = new NetScanWex.SLibExClass();

                mIdData = new NetScanW.IdDataClass();
                mIdDataEx = new NetScanWex.IdDataClass();

                mImage = new NetScanW.CImageClass();
                mImageEx = new NetScanWex.CImageClass();

                //For faster loading of the sdk you can set the scanner ttype that you want
                mSLibEx.DefaultScanner = CSlibConst.CSSN_1000;

                //The Slib object should be the first to initilaized
                int ret = mSLib.InitLibrary(CLicense.LICENSE_VALUE);
                if (ret != CLicense.LICENSE_VALID)
                {
                    switch (ret)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("Error: License Expired! - Library not loaded (SLib)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CSlibConst.SLIB_LIBRARY_ALREADY_INITIALIZED:
                            MessageBox.Show("Error: Library is already loaded.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_SCANNER_NOT_FOUND:
                            MessageBox.Show("Error: The scanner is not connected to the PC. Please connect and re-start the application.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case CSlibConst.SLIB_ERR_DRIVER_NOT_FOUND:
                            MessageBox.Show("Error: The scanner's driver was not found. Please re-install the driver and re-start the application.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }

                //The IdData object should be the second to initilaized
                ret = mIdData.InitLibrary(CLicense.LICENSE_VALUE);        
                if (ret != CLicense.LICENSE_VALID)
                {
                    switch (ret)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("Error: License Expired! - Library not loaded (SLib)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("Error: License Invalid for SDK (IdData)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                            MessageBox.Show("Error: License Invalid for ID Library!  (IdData)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CSlibConst.GENERAL_ERR_PLUG_NOT_FOUND:
                            MessageBox.Show("Error: The scanner is not attached or license expired.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                    }
                }

                //The Image object should be the first to initilaized
                ret = mImage.InitLibrary(CLicense.LICENSE_VALUE);         
                if (ret != CLicense.LICENSE_VALID)
                {
                    switch (ret)
                    {
                        case CLicense.LICENSE_EXPIRED:
                            MessageBox.Show("Error: License Expired! - Library not loaded (Image)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_INVALID:
                            MessageBox.Show("Error: License Invalid for SDK (Image)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        case CLicense.LICENSE_DOES_NOT_MATCH_LIBRARY:
                            MessageBox.Show("Error: License Invalid for ID Library!  (Image)", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
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

        /// <summary>
        /// Unload the SDK libraries and free all it's resources
        /// </summary>
        protected virtual void UnLoadSdk()
        {
            try
            {
                TimerAutoScan.Enabled = false;

                //The Slib object should be the first to uninitilaized
                if (mSLibEx != null)
                {
                    mSLibEx.UnInit();
                }

                mSLibEx = null;
                mSLib = null;

                mIdDataEx = null;
                mIdData = null;

                mImageEx = null;
                mImage = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void Scan()
        {
        }

        private void TimerAutoScan_Tick(object sender, EventArgs e)
        {
            TimerAutoScan.Enabled = false;
            if (CheckPaperInTray())
            {
                this.Scan();
            }
            TimerAutoScan.Enabled = true;
        }

        private bool CheckPaperInTray()
        {
            bool ret = false;

            //This will check the scanner if it's contain a paper in it
            try
            {
                int retVal;
                switch (mSLib.ScannerType)
                {
                    case CSlibConst.CSSN_NONE:
                        retVal = 0;
                        break;
                    case CSlibConst.CSSN_1000:
                    case CSlibConst.CSSN_4000:
                        if (mSLib.PressedButton > 0)
                            retVal = CSlibConst.SLIB_TRUE;
                        else
                            retVal = CSlibConst.SLIB_FALSE;
                        break;
                    default:
                        retVal = mSLib.PaperInTray;
                        break;
                }
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
                    case CSlibConst.SLIB_FALSE:
                        break;
                    case CSlibConst.SLIB_TRUE:
                        ret = true;
                        break;
                }
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

        public void CalibrateScannerEx()
        {
            this.mSLibEx.CalibrateScannerEx();
        }

        protected byte[] GetRwaImage()
        {
            if (this.ImageFilePath.Length == 0)
                return null;

            try
            {
                using (FileStream file = new FileStream(this.ImageFilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, data.Length);
                    return data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SetParent(Control panel)
        {
            if (this.DesignMode)
                return;

            if (panel == null)
            {
                this.TopLevel = true;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.TopLevel = false;
                this.Parent = panel;
                this.Dock = DockStyle.Fill;
            }
        }
    }
}
