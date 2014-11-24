using System.Collections;
using System.Drawing.Design;

namespace Cheke.Designer.Studio.Core
{
    public class ToolboxServiceImpl : ToolboxService
    {
        private readonly ToolboxPanel _toolBox = null;

        public ToolboxServiceImpl(ToolboxPanel toolbox)
        {
            this._toolBox = toolbox;
        }

        public ToolboxPanel ToolBox
        {
            get { return _toolBox; }
        }

        protected override IList GetItemContainers()
        {
            return this._toolBox.GetAllTools();
        }

        protected override IList GetItemContainers(string categoryName)
        {
            return this._toolBox.GetToolsFromCategory(categoryName);
        }

        protected override void Refresh()
        {
            this._toolBox.Refresh();
        }

        protected override CategoryNameCollection CategoryNames
        {
            get { return this._toolBox.CategoryNames; }
        }

        protected override string SelectedCategory
        {
            get { return this._toolBox.SelectedCategory; }
            set { }
        }

        protected override ToolboxItemContainer SelectedItemContainer
        {
            get
            {
                ToolboxItem item = this._toolBox.SelectToolboxItem;
                if (item.TypeName.Length > 0)
                {
                    return new ToolboxItemContainer(this._toolBox.SelectToolboxItem);
                }

                return null;
            }
            set
            {
                if(value == null)
                {
                    this._toolBox.SelectPointer();
                }
            }
        }
    }
}