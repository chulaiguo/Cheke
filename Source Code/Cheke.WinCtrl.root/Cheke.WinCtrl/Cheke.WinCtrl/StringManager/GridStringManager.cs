using System.Reflection;
using Cheke.Translation;

namespace Cheke.WinCtrl.StringManager
{
    internal class GridStringManager : StringManagerBase
    {
        private const string _BackgroundImagesMenu = "&Background Images";
        private const string _BatchAppendMenu = "Batch Append Ctrl+Q";
        private const string _BatchEditAllMenu = "All...";
        private const string _BatchEditMenu = "Batch Edit Ctrl+E";
        private const string _BlueBackgroundMenu = "Blue";
        private const string _CopyMenu = "Copy Ctrl+C";
        private const string _CutMenu = "Cut Ctrl+X";
        private const string _DeleteEventsMenu = "Deleted...";
        private const string _EditEventsMenu = "New/Changed...";
        private const string _EditMenu = "Edit";
        private const string _ExportMenu = "Export To";
        private const string _ExportToHTMLMenu = "Export To HTML";
        private const string _ExportToMHTMenu = "Export To MHT";
        private const string _ExportToPDFMenu = "Export To PDF";
        private const string _ExportToRTFMenu = "Export To RTF";
        private const string _ExportToTXTMenu = "Export To TXT";
        private const string _ExportToXLSMenu = "Export To XLS";
        private const string _ExportToCSVMenu = "Export To CSV";
        private const string _ExportToXLSXMenu = "Export To XLSX";
        private const string _GreenBackgroundMenu = "Green";
        private const string _HistoryMenu = "DBEdit Events";
        private const string _LookAndFeelMenu = "&Look And Feel";
        private const string _MulticopyMenu = "Multicopy... Ctrl+M";
        private const string _NoneBackgroundMenu = "(None)";
        private const string _PasteMenu = "Paste Ctrl+V";
        private const string _PinkBackgroundMenu = "Pink";
        private const string _PreviewMenu = "&Preview...";
        private const string _RefreshMenu = "&Refresh";
        private const string _RestoreLayoutMenu = "Restore &Default Layout";
        private const string _SaveLayoutMenu = "Save Customized &Layout";
        private const string _DeleteLayoutMenu = "&Delete Customized Layout";
        private const string _ConfigureLayoutMenu = "&Configure Customized Layout";
        private const string _SaveMenu = "&Save Changes";
        private const string _RecoverDeletedItemMenu = "&Recover Deleted Item(s)";
        private const string _SkinMenu = "S&kins";
        private const string _StyleSchemaMenu = "S&tyle Schema";
        private const string _WorldBackgroundMenu = "World";
        private const string _YellowBackgroundMenu = "Yellow";
        private const string _RecordCountMenu = "Record Count";

        private const string _DeleteWarning = "Are you sure you want to delete the following records?";
        private const string _AppendRecordsWarning = "You can't append {0} records, please change the append count.";

        private const string _BatchEdit_Actived = "Actived";
        private const string _BatchEdit_Caption = "Caption";
        private const string _BatchEdit_Value = "Value";
        private const string _BatchEdit_FillSeries = "FillSeries";

        public static string BatchEdit_Actived
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEdit_Actived); }
        }

        public static string BatchEdit_Caption
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEdit_Caption); }
        }

        public static string BatchEdit_Value
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEdit_Value); }
        }

        public static string BatchEdit_FillSeries
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEdit_FillSeries); }
        }

        public static string BackgroundImagesMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BackgroundImagesMenu); }
        }

        public static string BatchAppendMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchAppendMenu); }
        }

        public static string BatchEditAllMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEditAllMenu); }
        }


        public static string BatchEditMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BatchEditMenu); }
        }


        public static string BlueBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _BlueBackgroundMenu); }
        }


        public static string CopyMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CopyMenu); }
        }


        public static string CutMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _CutMenu); }
        }


        public static string DeleteEventsMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DeleteEventsMenu); }
        }

        public static string EditEventsMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _EditEventsMenu); }
        }


        public static string EditMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _EditMenu); }
        }


        public static string RecordCountMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RecordCountMenu); }
        }

        public static string ExportMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportMenu); }
        }


        public static string ExportToHTMLMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToHTMLMenu); }
        }


        public static string ExportToMHTMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToMHTMenu); }
        }

        public static string ExportToPDFMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToPDFMenu); }
        }


        public static string ExportToRTFMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToRTFMenu); }
        }


        public static string ExportToTXTMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToTXTMenu); }
        }


        public static string ExportToXLSMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToXLSMenu); }
        }

        public static string ExportToCSVMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToCSVMenu); }
        }

        public static string ExportToXLSXMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ExportToXLSXMenu); }
        }

        public static string GreenBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _GreenBackgroundMenu); }
        }


        public static string HistoryMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _HistoryMenu); }
        }


        public static string LookAndFeelMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _LookAndFeelMenu); }
        }


   

        public static string MulticopyMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _MulticopyMenu); }
        }


        public static string NoneBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _NoneBackgroundMenu); }
        }


        public static string PasteMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _PasteMenu); }
        }


        public static string PinkBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _PinkBackgroundMenu); }
        }

        public static string PreviewMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _PreviewMenu); }
        }

        public static string RefreshMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RefreshMenu); }
        }

        public static string RestoreLayoutMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RestoreLayoutMenu); }
        }

        public static string DeleteLayoutMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DeleteLayoutMenu); }
        }

        public static string SaveLayoutMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SaveLayoutMenu); }
        }

        public static string ConfigureLayoutMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _ConfigureLayoutMenu); }
        }

        public static string SaveMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SaveMenu); }
        }


        public static string RecoverDeletedItemMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _RecoverDeletedItemMenu); }
        }


        public static string SkinMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _SkinMenu); }
        }

        public static string StyleSchemaMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _StyleSchemaMenu); }
        }

        public static string WorldBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _WorldBackgroundMenu); }
        }


        public static string YellowBackgroundMenu
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _YellowBackgroundMenu); }
        }

        public static string DeleteWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _DeleteWarning); }
        }

        public static string AppendRecordsWarning
        {
            get { return Translate(MethodBase.GetCurrentMethod().Name, _AppendRecordsWarning); }
        }

        public static void GetTranslateString()
        {
           GetTranslateString(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}