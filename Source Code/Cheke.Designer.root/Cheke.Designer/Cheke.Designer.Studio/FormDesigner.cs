using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using Cheke.Designer.Controls;
using Cheke.Designer.Controls.Core;
using Cheke.Designer.Controls.Utils;
using Cheke.Designer.Studio.Core;

namespace Cheke.Designer.Studio
{
    public partial class FormDesigner : Form
    {
        private readonly ToolboxCollection _tooboxList = null;
        private readonly bool _fixedDesigner = false;
        private HostSurface _hostSurface = null;
        private int _width = 0;
        private int _height = 0;
        private byte[] _template = null;
        private bool _editorMode = false;
        private readonly ICustomizeSerialize _customize = null;

        public FormDesigner()
        {
            InitializeComponent();
        }

        public FormDesigner(ToolboxCollection tooboxList, bool fixedDesigner, float widthInches, float heightInches, ICustomizeSerialize customize)
        {
            InitializeComponent();

            this._tooboxList = tooboxList;
            this._fixedDesigner = fixedDesigner;
            this._width = this.InchesToXPixel(widthInches);
            this._height = this.InchesToYPixel(heightInches);

            this._customize = customize;
        }

        public byte[] Template
        {
            get { return _template; }
            set { _template = value; }
        }

        public void ShowEditorMode()
        {
            this._editorMode = true;

            this.ShowInTaskbar = false;
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.menuStrip1.Visible = false;
            //this.btnExit.Visible = true;
        }

        private void FormDesigner_Load(object sender, EventArgs e)
        {
            if(this.DesignMode)
                return;

            this.InitDesigner();
            this.AddMessageFilter();
            this.LoadDesigner();
        }

        private void InitDesigner()
        {
            if (this.Template != null)
            {
                MemoryStream stream = new MemoryStream(this.Template);
                Control hostControl = new Control();
                ControlSerialization.DeserializeHostControl(stream, hostControl);
                this._width = hostControl.Width > 0 ? hostControl.Width : this._width;
                this._height = hostControl.Height > 0 ? hostControl.Height : this._height;
            }

            if(this._fixedDesigner)
            {
                FixedHostControl.FixedWidth = this._width;
                FixedHostControl.FixedHeight = this._height;
            }
           
            this._hostSurface = new HostSurface(this._width, this._height);
            this._hostSurface.Initialize();

            //Toolbox
            this.toolboxPanel1.AddToolboxCategory("Default");
            foreach (Toolbox item in this._tooboxList)
            {
                this.toolboxPanel1.AddToolboxItem("Default", item.ToolType, item.DisplayName);
            }
            this.toolboxPanel1.DesignerHost = this._hostSurface.DesignerHost;
            this._hostSurface.AddService(typeof(IToolboxService), new ToolboxServiceImpl(this.toolboxPanel1));
            
            //Property
            this._hostSurface.AddService(typeof(PropertyGrid), this.propertyGrid1);

            if (this._fixedDesigner)
            {
                this._hostSurface.BeginLoad(typeof (FixedHostControl), this.pnlClient);
            }
            else
            {
                this._hostSurface.BeginLoad(typeof (HostControl), this.pnlClient);
            }
        }

        private void AddMessageFilter()
        {
            MessageFilter filter = new MessageFilter(this._hostSurface);
            Application.AddMessageFilter(filter);
        }

        private void LoadDesigner()
        {
            if (this.Template == null)
                return;

            MemoryStream stream = new MemoryStream(this.Template);
            ControlSerialization serialize = new ControlSerialization(this._hostSurface.DesignerHost, this._customize);
            serialize.LoadFromStream(stream);
        }

        private void SaveDesigner()
        {
            if (!this._editorMode)
                return;

            MemoryStream stream = new MemoryStream();
            ControlSerialization serialize = new ControlSerialization(this._hostSurface.DesignerHost, this._customize);
            serialize.SaveToStream(stream);

            this.Template = stream.ToArray();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this._editorMode)
                return;

            string question = "Are you sure you want to exit?";
            if(System.Windows.Forms.DialogResult.Yes != MessageBox.Show(question, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            this.SaveDesigner();
        }

        private int InchesToXPixel(float inches)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return (int)(inches * g.DpiX);
            }
        }

        private int InchesToYPixel(float inches)
        {
            using (Graphics g = this.CreateGraphics())
            {
                return (int)(inches * g.DpiY);
            }
        } 

        #region File Menu

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            ControlSerialization serialize = new ControlSerialization(this._hostSurface.DesignerHost, this._customize);
            serialize.LoadFromFile(this.openFileDialog1.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            ControlSerialization serialize = new ControlSerialization(this._hostSurface.DesignerHost, this._customize);
            serialize.SaveToFile(this.saveFileDialog1.FileName);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._hostSurface.RootComponent != null)
            {
                MemoryStream stream = new MemoryStream();
                ControlSerialization serialize = new ControlSerialization(this._hostSurface.DesignerHost, null);
                serialize.SaveToStream(stream);

                FormPreview print = new FormPreview(stream.ToArray(), true, null, null);
                print.EnablePrint = true;
                print.ShowDialog();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Edit Menu
        private void menuCut_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Cut);
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Copy);
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Paste);
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Undo);
        }

        private void menuRedo_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Redo);
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.Delete);
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.SelectAll);
        }
        #endregion

        #region Layout Menu
        private void menuLeft_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignLeft);
        }

        private void menuRight_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignRight);
        }

        private void menuCenter_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignHorizontalCenters);
        }

        private void menuTop_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignTop);
        }

        private void menuMiddle_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignVerticalCenters);
        }

        private void menuBottom_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.AlignBottom);
        }

        private void menuBringToFront_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.BringToFront);
        }

        private void menuSendToBack_Click(object sender, EventArgs e)
        {
            this._hostSurface.PerformCommand(StandardCommands.SendToBack);
        }
        #endregion

        #region View Menu
        private void menuToolboxWindow_Click(object sender, EventArgs e)
        {
            this.menuToolboxWindow.Checked = !this.menuToolboxWindow.Checked;
            this.splitContainer1.Panel1Collapsed = !this.menuToolboxWindow.Checked;
        }

        private void menuPropertyWindow_Click(object sender, EventArgs e)
        {
            this.menuPropertyWindow.Checked = !this.menuPropertyWindow.Checked;
            this.splitContainer2.Panel2Collapsed = !this.menuPropertyWindow.Checked;
        }
        #endregion

        #region Help Menu
        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAboutBox dlg = new FormAboutBox();
            dlg.ShowDialog();
        }
        #endregion
    }
}