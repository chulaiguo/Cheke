namespace Cheke.WinCtrl.GridControlBuddy
{
    public class GridMenuOptions
    {
        private bool _showBasicMenu = true;
        private bool _showColumnMenu = true;

        private bool _showApplicationMenu = true;

        private bool _showPreviewMenu = true;
        private bool _showRefreshMenu = true;
        private bool _showSaveMenu = true;
        private bool _showRecoverDeletedItemsMenu = true;

        private bool _showEditMenu = true;

        private bool _showHistoryMenu = true;
        private bool _showExportMenu = true;

        private bool _showLayoutMenu = true;
        private bool _showGridStyleMenu = true;

        public bool ShowExportMenu
        {
            get { return _showExportMenu; }
            set { _showExportMenu = value; }
        }

        public bool ShowLayoutMenu
        {
            get { return _showLayoutMenu; }
            set { _showLayoutMenu = value; }
        }

        public bool ShowGridStyleMenu
        {
            get { return _showGridStyleMenu; }
            set { _showGridStyleMenu = value; }
        }

        public bool ShowPreviewMenu
        {
            get { return _showPreviewMenu; }
            set { _showPreviewMenu = value; }
        }

        public bool ShowColumnMenu
        {
            get { return _showColumnMenu; }
            set { _showColumnMenu = value; }
        }

        public bool ShowBasicMenu
        {
            get { return _showBasicMenu; }
            set { _showBasicMenu = value; }
        }

        public bool ShowSaveMenu
        {
            get { return _showSaveMenu; }
            set { _showSaveMenu = value; }
        }

        public bool ShowRefreshMenu
        {
            get { return _showRefreshMenu; }
            set { _showRefreshMenu = value; }
        }

        public bool ShowHistoryMenu
        {
            get { return _showHistoryMenu; }
            set { _showHistoryMenu = value; }
        }

        public bool ShowEditMenu
        {
            get { return _showEditMenu; }
            set { _showEditMenu = value; }
        }

        public bool ShowRecoverDeletedItemsMenu
        {
            get { return _showRecoverDeletedItemsMenu; }
            set { _showRecoverDeletedItemsMenu = value; }
        }

        public bool ShowApplicationMenu
        {
            get { return _showApplicationMenu; }
            set { _showApplicationMenu = value; }
        }
    }
}