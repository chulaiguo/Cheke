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
    [ToolboxBitmap(typeof(MemoEdit))]
    public partial class MemoEditEx : EditorBase
    {
        private MemoEdit memoEdit1;

        public MemoEditEx()
        {
            this.memoEdit1 = new MemoEdit();
            base.AddEditor(this.memoEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.memoEdit1.DataBindings.Clear();
            this.memoEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.memoEdit1.DataBindings.Count == 0)
                return;

            this.memoEdit1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Category("Events")]
        [Description("Occurs when either the UP or DOWN ARROW key is pressed or the mouse wheel is rotated.")]
        public event SpinEventHandler Spin;
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

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.memoEdit1.EditorTypeName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the lines of text within a memo edit control.")]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design", typeof(UITypeEditor))]
        [Category("Appearance")]
        public String[] Lines
        {
            get
            {
                return this.memoEdit1.Lines;
            }
            set
            {
                this.memoEdit1.Lines = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Gets an object containing properties and methods specific to a memo editor.")]
        [Category("Properties")]
        public RepositoryItemMemoEdit Properties
        {
            get
            {
                return this.memoEdit1.Properties;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.memoEdit1.BackColor;
            }
            set
            {
                this.memoEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.memoEdit1.TabStop;
            }
            set
            {
                this.memoEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.memoEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.memoEdit1.IsEditorActive;
            }
        }

        [Browsable(false)]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.memoEdit1.IsNeedFocus;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.memoEdit1.SelectionStart;
            }
            set
            {
                this.memoEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.memoEdit1.SelectionLength;
            }
            set
            {
                this.memoEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.memoEdit1.SelectedText;
            }
            set
            {
                this.memoEdit1.SelectedText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [Bindable(true)]
        [Description("Gets or sets the text displayed in the edit box.")]
        [Category("Appearance")]
        public override String Text
        {
            get
            {
                return this.memoEdit1.Text;
            }
            set
            {
                this.memoEdit1.Text = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.memoEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.memoEdit1.BackgroundImage;
            }
            set
            {
                this.memoEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.memoEdit1.BackgroundImageLayout;
            }
            set
            {
                this.memoEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.memoEdit1.Padding;
            }
            set
            {
                this.memoEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.memoEdit1.MenuManager;
            }
            set
            {
                this.memoEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.memoEdit1.ErrorText;
            }
            set
            {
                this.memoEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.memoEdit1.ErrorIconAlignment;
            }
            set
            {
                this.memoEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.memoEdit1.ErrorIcon;
            }
            set
            {
                this.memoEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.memoEdit1.ServiceObject;
            }
            set
            {
                this.memoEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.memoEdit1.InplaceType;
            }
            set
            {
                this.memoEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.memoEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.memoEdit1.IsModified;
            }
            set
            {
                this.memoEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.memoEdit1.OldEditValue;
            }
        }

        [Editor(typeof(UIObjectEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ObjectEditorTypeConverter))]
        [Description("Gets or sets the editor's value.")]
        [Bindable(true)]
        [Localizable(true)]
        [Category("Data")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(null)]
        public Object EditValue
        {
            get
            {
                return this.memoEdit1.EditValue;
            }
            set
            {
                this.memoEdit1.EditValue = value;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.memoEdit1.EditorContainsFocus;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.memoEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.memoEdit1.LookAndFeel;
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
                return this.memoEdit1.BorderStyle;
            }
            set
            {
                this.memoEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.memoEdit1.ForeColor;
            }
            set
            {
                this.memoEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.memoEdit1.Font;
            }
            set
            {
                this.memoEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.memoEdit1.ContextMenu;
            }
            set
            {
                this.memoEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.memoEdit1.ContextMenuStrip;
            }
            set
            {
                this.memoEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.memoEdit1.AccessibleName;
            }
            set
            {
                this.memoEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.memoEdit1.AccessibleRole;
            }
            set
            {
                this.memoEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.memoEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.memoEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.memoEdit1.AccessibleDescription;
            }
            set
            {
                this.memoEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.memoEdit1.EnterMoveNextControl;
            }
            set
            {
                this.memoEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.memoEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.memoEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.memoEdit1_Spin);
            this.memoEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.memoEdit1_InvalidValue);
            this.memoEdit1.PropertiesChanged += new System.EventHandler(this.memoEdit1_PropertiesChanged);
            this.memoEdit1.EditValueChanged += new System.EventHandler(this.memoEdit1_EditValueChanged);
            this.memoEdit1.Modified += new System.EventHandler(this.memoEdit1_Modified);
            this.memoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoEdit1_EditValueChanging);
            this.memoEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.memoEdit1_ParseEditValue);
            this.memoEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.memoEdit1_FormatEditValue);
            this.memoEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.memoEdit1_CustomDisplayText);
            this.memoEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.memoEdit1_QueryAccessibilityHelp);
            this.memoEdit1.ForeColorChanged += new System.EventHandler(this.memoEdit1_ForeColorChanged);
            this.memoEdit1.BackColorChanged += new System.EventHandler(this.memoEdit1_BackColorChanged);
            this.memoEdit1.FontChanged += new System.EventHandler(this.memoEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void memoEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void memoEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void memoEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void memoEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void memoEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void memoEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void memoEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void memoEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void memoEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void memoEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void memoEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void memoEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}