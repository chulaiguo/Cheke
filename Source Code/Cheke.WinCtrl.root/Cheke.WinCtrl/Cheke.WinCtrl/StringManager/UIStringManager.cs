using System.Reflection;
using Cheke.Translation;

namespace Cheke.WinCtrl.StringManager
{
    internal class UIStringManager : StringManagerBase
    {
        private const string _OKButton_Caption = "&OK";
        private const string _CancelButton_Caption = "&Cancel";
        private const string _CloseButton_Caption = "&Close";
        private const string _SaveButton_Caption = "&Save";
        private const string _NextButton_Caption = "&Next >";
        private const string _FinishButton_Caption = "&Finish";
        private const string _YesButton_Caption = "&Yes";
        private const string _NoButton_Caption = "&No";
        private const string _DetailButton_Caption = "&Detail";
        private const string _RefreshButton_Caption = "&Refresh";

        private const string _Common_UpdateList = "Update List";
        private const string _Common_InsertList = "Insert List";
        private const string _Common_DeleteList = "Delete List";

        private const string _Common_InsertRecords = "  Inserting {0} record(s)";
        private const string _Common_UdapteRecords = "  Updating {0} record(s)";
        private const string _Common_DeleteRecords = "  Deleting {0} record(s)";

        private const string _CancelDataWarning = "Are you sure you want to discard these changes?";
        private const string _DeleteDataOKInfo = "The record has been deleted successfully.";
        private const string _DeleteDataWarning = "Are you sure you want to delete this record?";
        private const string _HasNotAddNewPrivilege = "You do not have sufficient security privileges to add new data. Please contact your administrator.";
        private const string _HasNotDeletePrivilege = "You do not have sufficient security privileges to delete data. Please contact your administrator.";
        private const string _HasNotEditPrivilege = "You do not have sufficient security privileges to edit data. Please contact your administrator.";
        private const string _HasNotReactivePrivilege = "You do not have sufficient security privileges to reactive data. Please contact your administrator.";
        private const string _HasNotViewPrivilege = "You do not have sufficient security privileges to view data. Please contact your administrator.";

        private const string _NoReactiveWarning = "The data can't be reactived.";
        private const string _NotImplementedWarning = "The method or operation is not implemented.";
        private const string _RefreshAllWarning = "Refreshing All would lose all changes. Are you sure you wish to refresh?";
        private const string _RefreshDataWarning = "Refreshing would lose these changes. Are you sure you wish to refresh?";
        private const string _SaveDataWarning = "You have some unsaved data, would you like to save it now?";
        private const string _SaveDataSuccess = "The data that you have changed has been saved successfully.";

        private const string _CancelWizardWarning = "Are you sure you want to cancel this wizard?";
        private const string _SearchDataWaiting = "Search Data. Please Wait...";
        private const string _UnselectWarning = "Please select a item in the list.";

        private const string _CreatedTag = "Created By [{0}] At [{1:MM/dd/yyyy HH:mm:ss}]";
        private const string _ModifiedTag = "Modified By [{0}] At [{1:MM/dd/yyyy HH:mm:ss}]";

        private const string _FocusedViewDataRecords = "The focused view has {0} record(s).";
        private const string _CloseApplicationQuestion = "Are you sure you want to close the application?";

        private const string _DataNotExistWarning = "The data does't exist and this form will be closed.";
        private const string _DataInactiveQuestion = "The data is inactive now, are you sure you want to continue? If NOT, this form will be closed.";

        private const string _TotalRecordsFormat = "Total records: {0}";
        private const string _ApplyStyleWaiting = "Apply Style. Please Wait...";

        public static string Common_UpdateList
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_UpdateList); }
        }

        public static string Common_InsertRecords
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_InsertRecords); }
        }

        public static string Common_UdapteRecords
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_UdapteRecords); }
        }

        public static string Common_DeleteRecords
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_DeleteRecords); }
        }

        public static string Common_InsertList
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_InsertList); }
        }

        public static string Common_DeleteList
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _Common_DeleteList); }
        }

        public static string YesButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _YesButton_Caption); }
        }

        public static string NoButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _NoButton_Caption); }
        }

        public static string DetailButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DetailButton_Caption); }
        }

        public static string RefreshButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RefreshButton_Caption); }
        }

        public static string ApplyStyleWaiting
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ApplyStyleWaiting); }
        }

        public static string TotalRecordsFormat
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _TotalRecordsFormat); }
        }

        public static string DataInactiveQuestion
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DataInactiveQuestion); }
        }

        public static string DataNotExistWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DataNotExistWarning); }
        }

        public static string NextButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _NextButton_Caption); }
        }

        public static string FinishButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FinishButton_Caption); }
        }

        public static string CancelButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CancelButton_Caption); }
        }

        public static string CloseButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CloseButton_Caption); }
        }

        public static string SaveButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SaveButton_Caption); }
        }

        public static string OKButton_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _OKButton_Caption); }
        }

        public static string CloseApplicationQuestion
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CloseApplicationQuestion); }
        }

        public static string FocusedViewDataRecords
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _FocusedViewDataRecords); }
        }

        public static string SaveDataSuccess
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SaveDataSuccess); }
        }

        public static string CreatedTag
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CreatedTag); }
        }

        public static string ModifiedTag
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ModifiedTag); }
        }

        public static string UnselectWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _UnselectWarning); }
        }

        public static string SearchDataWaiting
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SearchDataWaiting); }
        }

        public static string CancelWizardWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CancelWizardWarning); }
        }

        public static string CancelDataWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CancelDataWarning); }
        }

        public static string DeleteDataOKInfo
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DeleteDataOKInfo); }
        }

        public static string DeleteDataWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DeleteDataWarning); }
        }

        public static string HasNotAddNewPrivilege
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HasNotAddNewPrivilege); }
        }

        public static string HasNotDeletePrivilege
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HasNotDeletePrivilege); }
        }

        public static string HasNotEditPrivilege
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HasNotEditPrivilege); }
        }

        public static string HasNotReactivePrivilege
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HasNotReactivePrivilege); }
        }

        public static string HasNotViewPrivilege
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HasNotViewPrivilege); }
        }

        public static string NoReactiveWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _NoReactiveWarning); }
        }

        public static string NotImplementedWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _NotImplementedWarning); }
        }

        public static string RefreshAllWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RefreshAllWarning); }
        }

        public static string RefreshDataWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RefreshDataWarning); }
        }

        public static string SaveDataWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SaveDataWarning); }
        }

        public static void GetTranslateString()
        {
            GetTranslateString(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}