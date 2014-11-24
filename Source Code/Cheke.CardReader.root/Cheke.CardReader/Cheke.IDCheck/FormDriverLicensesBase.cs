using System;
using System.Windows.Forms;
using Cheke.CardData;
using IntelliCheck.DeviceController;

namespace Cheke.IDCheck
{
    public partial class FormDriverLicensesBase : FormBase
    {
        private ControllerClass _controller;

        private delegate void DataAvailableDelegate();
        private delegate void ControllerErrorDelegate(int errorcode, string msg);
        public event ProcessDriverLicensesHandler ProcessDriverLicenses;

        public FormDriverLicensesBase()
        {
            InitializeComponent();
        }

        public FormDriverLicensesBase(Control parent)
            : base(parent)
        {
            this.InitializeComponent();
        }

        protected override bool Initialize()
        {
            if(!base.Initialize())
                return false;

            if (!this.SetupController())
                return false;

            if(!this.LoadLicense())
                return false;

            this._controller.Enabled = true;
            return true;
        }
       
        private bool SetupController()
        {
            try
            {
                this._controller = new ControllerClass();
                this._controller.DataAvailable += Controller_DataAvailable;
                this._controller.ControllerError += Controller_ControllerError;

                return true;
            }
            catch (Exception ex)
            {
                base.ShowErrorMessage(ex.Message);
                return false;
            }
        }

        private bool LoadLicense()
        {
            // Set the License File
            string license = string.Format("{0}\\IDCheckLicense.txt", Application.StartupPath);
            this._controller.LicenseFile = license;

            //LoadJurisTable
            JeTableLoadStatus_t status = this._controller.LoadJurisTable("98HP6-N5MFA-FXGF2-R2D45", string.Empty);
            if (status == JeTableLoadStatus_t.JeTableLoad_OK)
                return true;

            string error;
            switch (status)
            {
                case JeTableLoadStatus_t.JeTableLoad_BadFile:
                    error = "Bad File";
                    break;
                case JeTableLoadStatus_t.JeTableLoad_EidMismatch:
                    error = "Eid Mismatch";
                    break;
                case JeTableLoadStatus_t.JeTableLoad_LoadTimedOut:
                    error = "Load Timed Out";
                    break;
                default:
                    error = "Internal Error";
                    break;
           }

            base.ShowErrorMessage(error);
            return false;
        }

        public void SetupCOMPorts(string portName)
        {
            if(portName.Length < 4)
                return;

            try
            {
                int iPort;
                if(!int.TryParse(portName.Substring(3), out iPort))
                {
                    iPort = 0;
                }
                this._controller.ComPort = iPort;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set COM Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #region Retrive Data
        private void Controller_DataAvailable()
        {
            if (this.InvokeRequired)
            {
                DataAvailableDelegate pDel = new DataAvailableDelegate(Controller_DataAvailable);
                this.Invoke(pDel);
            }
            else
            {              
                // Get a Reference to the Jurisdiction Engine Data Object
                JurisdictionData lData = this._controller.Jurisdiction_Data;

                DriverLicenseData data = new DriverLicenseData();
                data.UniqueID =  lData.UniqueID;
                data.SerialNumber = lData.SerialNumber;
                data.MediaType = lData.MediaType;
                data.DLIDJurisdictionAbbrv = lData.DLID_JurisdictionAbbrv;
                data.DLIDJurisdiction = lData.DLID_Jurisdiction;
                data.DLIDFormatted = lData.DLID_Formatted;
                data.DLIDRaw = lData.DLID_Raw;
                data.NameFirst = lData.Name_First;
                data.NameMiddle = lData.Name_Middle;
                data.NameLast = lData.Name_Last;
                data.Address1 = lData.Address1;
                data.Address2 = lData.Address2;
                data.City = lData.City;
                data.Jurisdiction = lData.Jurisdiction;
                data.PostalCode = lData.PostalCode;
                data.ExpirationDate = lData.ExpirationDate;
                data.DateOfBirth = lData.DateOfBirth;
                data.Age = lData.Age;
                data.Gender = lData.Gender;
                data.EyeColor = lData.EyeColor;
                data.HairColor = lData.HairColor;
                data.HeightFtIn = lData.Height_FtIn;
                data.HeightCm = lData.Height_Cm;
                data.WeightLbs = lData.Weight_Lbs;
                data.WeightKg = lData.Weight_Kg;
                data.IssueDate = lData.IssueDate;
                data.OrganDonor = lData.OrganDonor;
                data.DriverClassCodes = lData.DriverClassCodes;
                data.EndorsementCodes = lData.EndorsementCodes;
                data.RestrictionCodes = lData.RestrictionCodes;
                data.SocialSecurityNumber = lData.SocialSecurityNumber;
                data.CACID =  lData.CACID;
                data.DODEDI = lData.DOD_EDI;
                data.Rank = lData.Rank;
                data.DODStatus = lData.DODStatus;
                data.BranchOfService = lData.BranchOfService;
                data.SponsorRank = lData.SponsorRank;
                data.SponsorDodStatus = lData.SponsorDODStatus;
                data.SponsorBranchOfService = lData.SponsorBranchOfService;
                data.BenefitCardIssuer = lData.BenefitCardIssuer;

                // Look for Personal Id data. (Photo, Fingerprint, etc..)
                // Currently the only info stored is Photo.
                for (int i = 0; i <= lData.PersonalIdCount - 1; i++)
                {
                    //If we have a Personal Identifier and its a JPG then Display it
                    if ((lData.get_PersonalIdType(i) == "P") && (lData.get_PersonalIdFormat(i) == "JFIF"))
                    {
                        Array photo = lData.get_PersonalIdData(i);
                        data.FaceImage = new byte[photo.Length];
                        photo.CopyTo(data.FaceImage, 0);
                    }
                }

                //Update UI
                this.UpdateUI(data);

                //ProcessDriverLicenses
                this.OnProcessDriverLicenses(data);
            }
        }

        protected virtual void OnProcessDriverLicenses(DriverLicenseData data)
        {
            if (this.ProcessDriverLicenses != null)
            {
                this.Cursor = Cursors.WaitCursor;
                this.ProcessDriverLicenses(data);
                this.Cursor = Cursors.Default;
            }
        }

        protected virtual void UpdateUI(DriverLicenseData data)
        {
        }

        private void Controller_ControllerError(int errode, string msg)
        {
            if (this.InvokeRequired)
            {
                ControllerErrorDelegate pDel = new ControllerErrorDelegate(Controller_ControllerError);
                this.Invoke(pDel, new object[] { errode, msg });
            }
            else
            {
                base.ShowErrorMessage(msg);
            }
        }
        #endregion
    }
}
