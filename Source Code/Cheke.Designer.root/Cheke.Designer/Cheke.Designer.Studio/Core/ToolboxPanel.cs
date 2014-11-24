using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Cheke.Designer.Studio.Properties;

namespace Cheke.Designer.Studio.Core
{
    [ToolboxItem(false)]
    public partial class ToolboxPanel : UserControl
    {
        private IDesignerHost _designerHost = null;
        private int _selectedIndex = 0; // the index of the currently selected tool

        public ToolboxPanel()
        {
            InitializeComponent();
        }

        public IDesignerHost DesignerHost
        {
            get { return _designerHost; }
            set { _designerHost = value; }
        }

        public void AddToolboxCategory(string categoryName)
        {
            if(this.IsCategoryExist(categoryName))
                return;

            TabPage page = new TabPage();
            page.Name = string.Format("tab{0}", categoryName);
            page.Text = categoryName;

            ListBox listBox = new ListBox();
            listBox.Name = string.Format("lst{0}", categoryName);
            //listBox.ItemHeight = 18;
            listBox.AllowDrop = true;
            listBox.BackColor = Color.LightSlateGray;
            listBox.Dock = DockStyle.Fill;
            listBox.DrawMode = DrawMode.OwnerDrawVariable;
            listBox.MouseDown += listBox_MouseDown;
            listBox.DrawItem += listBox_DrawItem;
            listBox.MeasureItem += listBox_MeasureItem;
            listBox.KeyDown += listBox_KeyDown;

            ToolboxItem pointer = new ToolboxItem();
            pointer.DisplayName = "Pointer";
            pointer.Bitmap = Resources.PointerHS;
            listBox.Items.Add(pointer);
            listBox.SelectedIndex = 0;

            page.Controls.Add(listBox);
            this.tabControl1.Controls.Add(page);
        }

        public void AddToolboxItem(string categoryName, Type toolType)
        {
            ListBox listBox = this.GetCategoryListBox(categoryName);
            if(listBox == null)
                return;

            listBox.Items.Add(new ToolboxItem(toolType));
        }

        public void AddToolboxItem(string categoryName, Type toolType, string displayName)
        {
            ListBox listBox = this.GetCategoryListBox(categoryName);
            if (listBox == null)
                return;

            ToolboxItem tbi = new ToolboxItem(toolType);
            tbi.DisplayName = displayName;
            listBox.Items.Add(tbi);
        }

        public string SelectedCategory
        {
            get { return this.tabControl1.SelectedTab.Text; }
        }

        public ToolboxItem SelectToolboxItem
        {
            get
            {
                ListBox listBox = this.tabControl1.SelectedTab.Controls[0] as ListBox;
                if(listBox != null)
                {
                    return listBox.Items[listBox.SelectedIndex] as ToolboxItem;
                }

                return null;
            }
        }

        public CategoryNameCollection CategoryNames
        {
            get
            {
                string[] categories = new string[this.tabControl1.TabPages.Count];
                for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    categories[i] = this.tabControl1.TabPages[i].Text;
                }
                return new CategoryNameCollection(categories);
            }
        }

        public ToolboxItem[] GetToolsFromCategory(string category)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab.Text != category)
                    continue;

                ListBox listBox = tab.Controls[0] as ListBox;
                if (listBox == null)
                    return null;

                ToolboxItem[] tools = new ToolboxItem[listBox.Items.Count];
                listBox.Items.CopyTo(tools, 0);
                return tools;
            }

            return null;
        }

        public ToolboxItem[] GetAllTools()
        {
            ArrayList toolsAL = new ArrayList();
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                ListBox list = tab.Controls[0] as ListBox;
                if (list != null)
                {
                    toolsAL.Add(list.Items);
                }
            }

            ToolboxItem[] tools = new ToolboxItem[toolsAL.Count];
            toolsAL.CopyTo(tools);
            return tools;
        }

        #region ListBox Events

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null || listBox.SelectedIndex < 0)
                return;

            Rectangle lastSelectedBounds = listBox.GetItemRectangle(this._selectedIndex);
            this._selectedIndex = listBox.IndexFromPoint(e.X, e.Y); // change our selection
            listBox.SelectedIndex = this._selectedIndex;

            listBox.Invalidate(lastSelectedBounds); // clear highlight from last selection
            listBox.Invalidate(listBox.GetItemRectangle(this._selectedIndex)); // highlight new one

            if (e.Clicks == 2)
            {
                IToolboxUser tbu = this.DesignerHost.GetDesigner(this.DesignerHost.RootComponent) as IToolboxUser;
                if (tbu != null)
                {
                    tbu.ToolPicked((ToolboxItem) (listBox.Items[listBox.SelectedIndex]));
                }
            }
            else if (e.Clicks < 2)
            {
                ToolboxItem tbi = listBox.Items[listBox.SelectedIndex] as ToolboxItem;
                if (tbi == null)
                    return;

                IToolboxService tbs = this.DesignerHost.GetService(typeof (IToolboxService)) as IToolboxService;
                if (tbs == null)
                    return;

                // The IToolboxService serializes ToolboxItems by packaging them in DataObjects.
                DataObject d = tbs.SerializeToolboxItem(tbi) as DataObject;
                if (tbi.TypeName.Length > 0)
                {
                    listBox.DoDragDrop(d, DragDropEffects.Copy);
                }
                else
                {
                    listBox.DoDragDrop(d, DragDropEffects.None);
                }
            }
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null)
                return;

            ToolboxItem tbi = listBox.Items[e.Index] as ToolboxItem;
            if (tbi == null)
                return;

            // If this tool is the currently selected tool, draw it with a highlight.
            if (this._selectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(Brushes.DarkSlateGray, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.LightSlateGray, e.Bounds);
            }

            Rectangle BitmapBounds =
                new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, tbi.Bitmap.Width, e.Bounds.Height);
            Rectangle StringBounds =
                new Rectangle(e.Bounds.Location.X + BitmapBounds.Width, e.Bounds.Location.Y,
                              e.Bounds.Width - BitmapBounds.Width, e.Bounds.Height);
            e.Graphics.DrawImage(tbi.Bitmap, BitmapBounds);
            e.Graphics.DrawString(tbi.DisplayName, listBox.Font, Brushes.White, StringBounds);
        }


        private void listBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null)
                return;

            ToolboxItem tbi = listBox.Items[e.Index] as ToolboxItem;
            if (tbi == null)
                return;

            Size textSize = e.Graphics.MeasureString(tbi.DisplayName, listBox.Font).ToSize();
            e.ItemWidth = tbi.Bitmap.Width + textSize.Width;
            if (tbi.Bitmap.Height > textSize.Height)
            {
                e.ItemHeight = tbi.Bitmap.Height;
            }
            else
            {
                e.ItemHeight = textSize.Height;
            }
        }


        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null || listBox.SelectedIndex <= 0)
                return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ToolboxItem tbi = listBox.Items[listBox.SelectedIndex] as ToolboxItem;
                    if (tbi == null)
                        return;

                    IToolboxUser tbu = this.DesignerHost.GetDesigner(this.DesignerHost.RootComponent) as IToolboxUser;
                    if (tbu != null)
                    {
                        tbu.ToolPicked((ToolboxItem) (listBox.Items[listBox.SelectedIndex]));
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region TableControl

        private bool IsCategoryExist(string categoryName)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab.Text == categoryName)
                    return true;
            }

            return false;
        }

        private ListBox GetCategoryListBox(string categoryName)
        {
            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab.Text != categoryName)
                    continue;

                return tab.Controls[0] as ListBox;
            }

            return null;
        }

        public void SelectPointer()
        {
            ListBox listBox = this.tabControl1.SelectedTab.Controls[0] as ListBox;
            if (listBox == null)
                return;

            listBox.Invalidate(listBox.GetItemRectangle(listBox.SelectedIndex));
            this._selectedIndex = 0;
            listBox.SelectedIndex = 0;
            listBox.Invalidate(listBox.GetItemRectangle(listBox.SelectedIndex));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPointer();
        }

        #endregion
    }
}