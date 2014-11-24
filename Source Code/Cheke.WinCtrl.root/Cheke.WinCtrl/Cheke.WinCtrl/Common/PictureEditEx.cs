using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Editors;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(true)]
    [DefaultEvent("EditValueChanged")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(PictureEdit))]
    public partial class PictureEditEx : EditorBase
    {
        private PictureEdit pictureEdit1;

        public PictureEditEx()
        {
            this.pictureEdit1 = new PictureEdit();
            base.AddEditor(this.pictureEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.pictureEdit1.DataBindings.Clear();
            this.pictureEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.pictureEdit1.DataBindings.Count == 0)
                return;

            this.pictureEdit1.DataBindings[0].ReadValue();
        }

        public void LoadImage()
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(this.openFileDialog1.FileName);
                this.pictureEdit1.Image = img;
                this.pictureEdit1.Focus();
            }
        }

        #region Event Members

        [Category("Events")]
        [Description("Occurs after the value of the PictureEdit.Image property has been changed.")]
        public event EventHandler ImageChanged;
        [Category("Events")]
        [Description("Fires when an asynchronous image load operation is completed, been canceled, or raised an exception.")]
        public event EventHandler LoadCompleted;
        [Category("Events")]
        [Description("Fires when the RepositoryItemPictureEdit.ZoomPercent property is changed.")]
        public event EventHandler ZoomPercentChanged;
        [Description("Enables an appropriate response to be provided when invalid values are entered.")]
        [Category("Events")]
        public event InvalidValueExceptionEventHandler InvalidValue;
        [Category("Events")]
        [Description("Fires immediately after any editor's property value has changed.")]
        public event EventHandler PropertiesChanged;
        [Category("Events")]
        [Description("Fires immediately after the edit value has been changed.")]
        public event EventHandler EditValueChanged;
        [Description("Fires when the user starts to modify the edit value.")]
        [Category("Events")]
        public event EventHandler Modified;
        [Category("Events")]
        [Description("Fires when the editor's value is about to be changed.")]
        public event ChangingEventHandler EditValueChanging;
        [Description("Enables you to convert the value entered to the value that will be stored by the editor.")]
        [Category("Events")]
        public event ConvertEditValueEventHandler ParseEditValue;
        [Category("Events")]
        [Description("Enables you to format the editor's value.")]
        public event ConvertEditValueEventHandler FormatEditValue;
        [Description("Enables custom display text to be provided for an editor.")]
        [Category("Events")]
        public event CustomDisplayTextEventHandler CustomDisplayText;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event EventHandler BackColorChanged;
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged;
        #endregion

        #region Property Members

        [Category("Appearance")]
        [Bindable(false)]
        [Description("Sets or gets the image displayed by the editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public Image Image
        {
            get
            {
                return this.pictureEdit1.Image;
            }
            set
            {
                this.pictureEdit1.Image = value;
            }
        }

        [Category("Behavior")]
        [Description("Gets or sets a value indicating whether the user can tab to the picture editor.")]
        [DefaultValue(false)]
        public new Boolean TabStop
        {
            get
            {
                return this.pictureEdit1.TabStop;
            }
            set
            {
                this.pictureEdit1.TabStop = value;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.pictureEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.pictureEdit1.EditorTypeName;
            }
        }

        [Description("Gets an object containing properties and methods specific to the picture editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Properties")]
        public RepositoryItemPictureEdit Properties
        {
            get
            {
                return this.pictureEdit1.Properties;
            }
        }

        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override String Text
        {
            get
            {
                return this.pictureEdit1.Text;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean LoadInProgess
        {
            get
            {
                return this.pictureEdit1.LoadInProgess;
            }
        }

        public Object EditValue
        {
            get
            {
                return this.pictureEdit1.EditValue;
            }
            set
            {
                this.pictureEdit1.EditValue = value;
            }
        }

        public new Cursor Cursor
        {
            get
            {
                return this.pictureEdit1.Cursor;
            }
            set
            {
                this.pictureEdit1.Cursor = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.pictureEdit1.Padding;
            }
            set
            {
                this.pictureEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.pictureEdit1.MenuManager;
            }
            set
            {
                this.pictureEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.pictureEdit1.ErrorText;
            }
            set
            {
                this.pictureEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.pictureEdit1.ErrorIconAlignment;
            }
            set
            {
                this.pictureEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.pictureEdit1.ErrorIcon;
            }
            set
            {
                this.pictureEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.pictureEdit1.ServiceObject;
            }
            set
            {
                this.pictureEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.pictureEdit1.InplaceType;
            }
            set
            {
                this.pictureEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.pictureEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.pictureEdit1.IsModified;
            }
            set
            {
                this.pictureEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.pictureEdit1.IsNeedFocus;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.pictureEdit1.OldEditValue;
            }
        }

        [Browsable(false)]
        public Boolean IsEditorActive
        {
            get
            {
                return this.pictureEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.pictureEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.pictureEdit1.LookAndFeel;
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        [Category("Appearance")]
        [Description("Gets or sets the editor's border style.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BorderStyles BorderStyle
        {
            get
            {
                return this.pictureEdit1.BorderStyle;
            }
            set
            {
                this.pictureEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the background color of an enabled editor.")]
        public new Color BackColor
        {
            get
            {
                return this.pictureEdit1.BackColor;
            }
            set
            {
                this.pictureEdit1.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.pictureEdit1.ForeColor;
            }
            set
            {
                this.pictureEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.pictureEdit1.Font;
            }
            set
            {
                this.pictureEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.pictureEdit1.ContextMenu;
            }
            set
            {
                this.pictureEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.pictureEdit1.ContextMenuStrip;
            }
            set
            {
                this.pictureEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.pictureEdit1.AccessibleName;
            }
            set
            {
                this.pictureEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.pictureEdit1.AccessibleRole;
            }
            set
            {
                this.pictureEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.pictureEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.pictureEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.pictureEdit1.AccessibleDescription;
            }
            set
            {
                this.pictureEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.pictureEdit1.EnterMoveNextControl;
            }
            set
            {
                this.pictureEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.pictureEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.pictureEdit1.ImageChanged += new System.EventHandler(this.pictureEdit1_ImageChanged);
            this.pictureEdit1.LoadCompleted += new System.EventHandler(this.pictureEdit1_LoadCompleted);
            this.pictureEdit1.ZoomPercentChanged += new System.EventHandler(this.pictureEdit1_ZoomPercentChanged);
            this.pictureEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.pictureEdit1_InvalidValue);
            this.pictureEdit1.PropertiesChanged += new System.EventHandler(this.pictureEdit1_PropertiesChanged);
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            this.pictureEdit1.Modified += new System.EventHandler(this.pictureEdit1_Modified);
            this.pictureEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.pictureEdit1_EditValueChanging);
            this.pictureEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.pictureEdit1_ParseEditValue);
            this.pictureEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.pictureEdit1_FormatEditValue);
            this.pictureEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.pictureEdit1_CustomDisplayText);
            this.pictureEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.pictureEdit1_QueryAccessibilityHelp);
            this.pictureEdit1.ForeColorChanged += new System.EventHandler(this.pictureEdit1_ForeColorChanged);
            this.pictureEdit1.BackColorChanged += new System.EventHandler(this.pictureEdit1_BackColorChanged);
            this.pictureEdit1.FontChanged += new System.EventHandler(this.pictureEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void pictureEdit1_ImageChanged(object sender, EventArgs e)
        {
            if (this.ImageChanged != null)
            {
                this.ImageChanged(sender, e);
            }
        }

        private void pictureEdit1_LoadCompleted(object sender, EventArgs e)
        {
            if (this.LoadCompleted != null)
            {
                this.LoadCompleted(sender, e);
            }
        }

        private void pictureEdit1_ZoomPercentChanged(object sender, EventArgs e)
        {
            if (this.ZoomPercentChanged != null)
            {
                this.ZoomPercentChanged(sender, e);
            }
        }

        private void pictureEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void pictureEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void pictureEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void pictureEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void pictureEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void pictureEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void pictureEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void pictureEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void pictureEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void pictureEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void pictureEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}