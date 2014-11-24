using System.Globalization;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.StringManager;
using DevExpress.XtraEditors;

namespace Cheke.WinCtrl.Utils
{
    internal static class MessageBoxUtil
    {
        internal static void ShowMessage(string message, string title)
        {
            ShowMessage(message, title, MessageBoxIcon.Information);
        }

        internal static void ShowWarningMessage(string warning, string title)
        {
            ShowMessage(warning, title, MessageBoxIcon.Warning);
        }

        internal static void ShowErrorMessage(string error, string title)
        {
            ShowMessage(error, title, MessageBoxIcon.Error);
        }

        internal static void ShowErrorMessage(Result result, string title)
        {
            ShowMessage(result.ToString(), title, MessageBoxIcon.Error);
        }

        internal static DialogResult ShowQuestion(string question, string title)
        {
            return ShowYesNoQuestion(question, title, false);
        }

        internal static DialogResult ShowSaveDataWarning(string title)
        {
            return ShowYesNoQuestion(UIStringManager.SaveDataWarning, title, true);
        }

        internal static DialogResult ShowDeleteDataWarning(string title)
        {
            return ShowYesNoQuestion(UIStringManager.DeleteDataWarning, title, false);
        }

        internal static DialogResult ShowRefreshAllWarning(string title)
        {
            return ShowYesNoQuestion(UIStringManager.RefreshAllWarning, title, false);
        }

        internal static DialogResult ShowRefreshDataWarning(string title)
        {
            return ShowYesNoQuestion(UIStringManager.RefreshDataWarning, title, false);
        }

        internal static DialogResult ShowCancelDataWarning(string title)
        {
            return ShowYesNoQuestion(UIStringManager.CancelDataWarning, title, false);
        }

        internal static void ShowDeleteDataOKInfo(string title)
        {
            ShowMessage(UIStringManager.DeleteDataOKInfo, title);
        }

        internal static void ShowNoReactiveWarning(string title)
        {
            ShowMessage(UIStringManager.NoReactiveWarning, title);
        }

        internal static void ShowNoAddNewPrivilegeWarning(string title)
        {
            ShowWarningMessage(UIStringManager.HasNotAddNewPrivilege, title);
        }

        internal static void ShowNoDeletePrivilegeWarning(string title)
        {
            ShowWarningMessage(UIStringManager.HasNotDeletePrivilege, title);
        }

        internal static void ShowNoEditPrivilegeWarning(string title)
        {
            ShowWarningMessage(UIStringManager.HasNotEditPrivilege, title);
        }

        internal static void ShowNoViewPrivilegeWarning(string title)
        {
            ShowWarningMessage(UIStringManager.HasNotViewPrivilege, title);
        }

        internal static void ShowNoReactivePrivilegeWarning(string title)
        {
            ShowWarningMessage(UIStringManager.HasNotReactivePrivilege, title);
        }

        internal static void ShowFocusedViewDataRecords(int count)
        {
            ShowMessage(string.Format(UIStringManager.FocusedViewDataRecords, count), count.ToString(CultureInfo.InvariantCulture));
        }

        private static void ShowMessage(string message, string title, MessageBoxIcon type)
        {
            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, type);
        }

        private static DialogResult ShowYesNoQuestion(string question, string title, bool firstDefault)
        {
            return XtraMessageBox.Show(question, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                firstDefault ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2);
        }
    }
}