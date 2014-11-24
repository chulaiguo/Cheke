using System.Windows.Forms.Design;

namespace Cheke.WinCtrl.Designer
{
    public class AutoHeightDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                selectionRules &= ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable);
                return selectionRules;
            }
        }
    }
}