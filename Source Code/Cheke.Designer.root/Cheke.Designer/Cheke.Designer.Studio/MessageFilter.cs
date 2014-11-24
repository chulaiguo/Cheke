using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Cheke.Designer.Studio
{
    public class MessageFilter : IMessageFilter
    {
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_KEYDOWN = 0x0100;   

        private HostSurface _hostSurface;
        private Control _hostView;
        private Control _hostControl;
        private IMenuCommandService _commandService;

        public MessageFilter(HostSurface host)
        {
            this._hostSurface = host;
            this._hostView = this._hostSurface.View as Control;
            this._hostControl = this._hostSurface.DesignerHost.RootComponent as Control;
            this._commandService = host.GetService(typeof (IMenuCommandService)) as IMenuCommandService;
        }

        #region Implementation of IMessageFilter

        public bool PreFilterMessage(ref Message m)
        {
            if (this._hostView == null || !this._hostView.Focused)
                return false;

            switch (m.Msg)
            {
                case WM_LBUTTONDBLCLK:
                    this.ProcessLButtonDbClickMessage(ref m);
                    break;
                case WM_KEYDOWN:
                    this.ProcessKeyDownMessage(ref m);
                    break;
            }

            // Never filter the message
            return false;
        }

        private void ProcessLButtonDbClickMessage(ref Message m)
        {
            //this.ShowFocusedControl();
        }

        private void ProcessKeyDownMessage(ref Message m)
        {
            if (this._commandService == null)
                return;

            switch (((int)m.WParam) | ((int)Control.ModifierKeys))
            {
                case (int)Keys.Up:
                    this._commandService.GlobalInvoke(MenuCommands.KeyMoveUp);
                    break;
                case (int)Keys.Down:
                    this._commandService.GlobalInvoke(MenuCommands.KeyMoveDown);
                    break;
                case (int)Keys.Right:
                    this._commandService.GlobalInvoke(MenuCommands.KeyMoveRight);
                    break;
                case (int)Keys.Left:
                    this._commandService.GlobalInvoke(MenuCommands.KeyMoveLeft);
                    break;
                case (int)(Keys.Control | Keys.Up):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeUp);
                    break;
                case (int)(Keys.Control | Keys.Down):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeDown);
                    break;
                case (int)(Keys.Control | Keys.Right):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeRight);
                    break;
                case (int)(Keys.Control | Keys.Left):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeLeft);
                    break;
                case (int)(Keys.Shift | Keys.Up):
                    this._commandService.GlobalInvoke(MenuCommands.KeySizeHeightIncrease);
                    break;
                case (int)(Keys.Shift | Keys.Down):
                    this._commandService.GlobalInvoke(MenuCommands.KeySizeHeightDecrease);
                    break;
                case (int)(Keys.Shift | Keys.Right):
                    this._commandService.GlobalInvoke(MenuCommands.KeySizeWidthIncrease);
                    break;
                case (int)(Keys.Shift | Keys.Left):
                    this._commandService.GlobalInvoke(MenuCommands.KeySizeWidthDecrease);
                    break;
                case (int)(Keys.Control | Keys.Shift | Keys.Up):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeHeightIncrease);
                    break;
                case (int)(Keys.Control | Keys.Shift | Keys.Down):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeHeightDecrease);
                    break;
                case (int)(Keys.Control | Keys.Shift | Keys.Right):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeWidthIncrease);
                    break;
                case (int)(Keys.ControlKey | Keys.Shift | Keys.Left):
                    this._commandService.GlobalInvoke(MenuCommands.KeyNudgeWidthDecrease);
                    break;
                case (int)(Keys.Escape):
                    this._commandService.GlobalInvoke(MenuCommands.KeyCancel);
                    break;
                case (int)(Keys.Shift | Keys.Escape):
                    this._commandService.GlobalInvoke(MenuCommands.KeyReverseCancel);
                    break;
                case (int)(Keys.Enter):
                    this._commandService.GlobalInvoke(MenuCommands.KeyDefaultAction);
                    break;
            }
        }

        private void ShowFocusedControl()
        {
            Control child = this.GetFocusedChild();
            if (child != null)
            {
                MessageBox.Show(child.Name);
            }
        }

        private Control GetFocusedChild()
        {
            Point p = this._hostControl.PointToClient(Control.MousePosition);
            foreach (Control item in this._hostControl.Controls)
            {
                if (item.Bounds.Contains(p))
                    return item;
            }

            return null;
        }
        #endregion
    }
}