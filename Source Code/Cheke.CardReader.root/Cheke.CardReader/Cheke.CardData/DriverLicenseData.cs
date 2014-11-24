namespace Cheke.CardData
{
    public class DriverLicenseData
    {
        private string _address1 = string.Empty;
        private string _address2 = string.Empty;
        private int _age = 0;
        private string _benefitCardIssuer = string.Empty;
        private string _branchOfService = string.Empty;
        private string _CACID = string.Empty;
        private string _city = string.Empty;
        private string _state = string.Empty;
        private string _dateOfBirth = string.Empty;
        private string _DLID_Formatted = string.Empty;
        private string _DLID_Jurisdiction = string.Empty;
        private string _DLID_JurisdictionAbbrv = string.Empty;
        private string _DLID_Raw = string.Empty;
        private string _DOD_EDI = string.Empty;
        private string _DODStatus = string.Empty;
        private string _driverClassCodes = string.Empty;
        private string _endorsementCodes = string.Empty;
        private string _expirationDate = string.Empty;

        private string _eyeColor = string.Empty;
        private string _gender = string.Empty;
        private string _hairColor = string.Empty;
        private string _height_Cm = string.Empty;
        private string _height_FtIn = string.Empty;
        private string _issueDate = string.Empty;
        private string _jurisdiction = string.Empty;
        private string _mediaType = string.Empty;
        private string _name_First = string.Empty;
        private string _name_Last = string.Empty;
        private string _name_Middle = string.Empty;
        private string _organDonor = string.Empty;
        private string _photoType = string.Empty;
        private string _postalCode = string.Empty;
        private string _rank = string.Empty;
        private string _restrictionCodes = string.Empty;
        private string _serialNumber = string.Empty;
        private string _socialSecurityNumber = string.Empty;

        private string _sponsorBranchOfService = string.Empty;
        private string _sponsorDODStatus = string.Empty;
        private string _sponsorRank = string.Empty;
        private int _uniqueID = 0;
        private string _weight_Kg = string.Empty;
        private string _weight_Lbs = string.Empty;

        private byte[] _rawImage = null;
        private byte[] _faceImage = null;
        private byte[] _signImage = null;

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string BenefitCardIssuer
        {
            get { return _benefitCardIssuer; }
            set { _benefitCardIssuer = value; }
        }

        public string BranchOfService
        {
            get { return _branchOfService; }
            set { _branchOfService = value; }
        }

        public string CACID
        {
            get { return _CACID; }
            set { _CACID = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string DLIDFormatted
        {
            get { return _DLID_Formatted; }
            set { _DLID_Formatted = value; }
        }

        public string DLIDJurisdiction
        {
            get { return _DLID_Jurisdiction; }
            set { _DLID_Jurisdiction = value; }
        }

        public string DLIDJurisdictionAbbrv
        {
            get { return _DLID_JurisdictionAbbrv; }
            set { _DLID_JurisdictionAbbrv = value; }
        }

        public string DLIDRaw
        {
            get { return _DLID_Raw; }
            set { _DLID_Raw = value; }
        }

        public string DODEDI
        {
            get { return _DOD_EDI; }
            set { _DOD_EDI = value; }
        }

        public string DODStatus
        {
            get { return _DODStatus; }
            set { _DODStatus = value; }
        }

        public string DriverClassCodes
        {
            get { return _driverClassCodes; }
            set { _driverClassCodes = value; }
        }

        public string EndorsementCodes
        {
            get { return _endorsementCodes; }
            set { _endorsementCodes = value; }
        }

        public string ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        public string EyeColor
        {
            get { return _eyeColor; }
            set { _eyeColor = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string HairColor
        {
            get { return _hairColor; }
            set { _hairColor = value; }
        }

        public string HeightCm
        {
            get { return _height_Cm; }
            set { _height_Cm = value; }
        }

        public string HeightFtIn
        {
            get { return _height_FtIn; }
            set { _height_FtIn = value; }
        }

        public string IssueDate
        {
            get { return _issueDate; }
            set { _issueDate = value; }
        }

        public string Jurisdiction
        {
            get { return _jurisdiction; }
            set { _jurisdiction = value; }
        }

        public string MediaType
        {
            get { return _mediaType; }
            set { _mediaType = value; }
        }

        public string NameFirst
        {
            get { return _name_First; }
            set { _name_First = value; }
        }

        public string NameLast
        {
            get { return _name_Last; }
            set { _name_Last = value; }
        }

        public string NameMiddle
        {
            get { return _name_Middle; }
            set { _name_Middle = value; }
        }

        public string OrganDonor
        {
            get { return _organDonor; }
            set { _organDonor = value; }
        }

        public string PhotoType
        {
            get { return _photoType; }
            set { _photoType = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        public string RestrictionCodes
        {
            get { return _restrictionCodes; }
            set { _restrictionCodes = value; }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public string SocialSecurityNumber
        {
            get { return _socialSecurityNumber; }
            set { _socialSecurityNumber = value; }
        }

        public string SponsorBranchOfService
        {
            get { return _sponsorBranchOfService; }
            set { _sponsorBranchOfService = value; }
        }

        public string SponsorDodStatus
        {
            get { return _sponsorDODStatus; }
            set { _sponsorDODStatus = value; }
        }

        public string SponsorRank
        {
            get { return _sponsorRank; }
            set { _sponsorRank = value; }
        }

        public int UniqueID
        {
            get { return _uniqueID; }
            set { _uniqueID = value; }
        }

        public string WeightKg
        {
            get { return _weight_Kg; }
            set { _weight_Kg = value; }
        }

        public string WeightLbs
        {
            get { return _weight_Lbs; }
            set { _weight_Lbs = value; }
        }

        public byte[] FaceImage
        {
            get { return _faceImage; }
            set { _faceImage = value; }
        }

        public byte[] SignImage
        {
            get { return _signImage; }
            set { _signImage = value; }
        }

        public byte[] RawImage
        {
            get { return _rawImage; }
            set { _rawImage = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}