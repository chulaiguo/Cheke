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
    [ToolboxBitmap(typeof(MemoExEdit))]
    public partial class MemoExEditEx : EditorBase
    {
        private MemoExEdit memoExEdit1;

        public MemoExEditEx()
        {
            this.memoExEdit1 = new MemoExEdit();
            base.AddEditor(this.memoExEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        protected override int EditorHeight
        {
            get { return this.memoExEdit1 == null ? base.EditorHeight : this.memoExEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.memoExEdit1.DataBindings.Clear();
            this.memoExEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.memoExEdit1.DataBindings.Count == 0)
                return;

            this.memoExEdit1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Description("Enables you to specify whether an attempt to close the popup window will succeed. ")]
        [Category("Events")]
        public event CancelEventHandler QueryCloseUp;
        [Category("Events")]
        [Description("Occurs after the editor's popup window has been opened.")]
        public event EventHandler Popup;
        [Description("Enables you to specify whether an attempt to open the popup window will succeed.")]
        [Category("Events")]
        public event CancelEventHandler QueryPopUp;
        [Category("Events")]
        [Description("Enables you to specify whether the modifications performed within the editor's popup window should be accepted by the editor.")]
        public event CloseUpEventHandler CloseUp;
        [Category("Events")]
        [Description("Allows you to perform specific actions with respect to how the popup window was closed.")]
        public event ClosedEventHandler Closed;
        [Description("Occurs when a button editor's button is clicked.")]
        [Category("Events")]
        public event ButtonPressedEventHandler ButtonClick;
        [Category("Events")]
        [Description("Occurs when pressing an editor button.")]
        public event ButtonPressedEventHandler ButtonPressed;
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
                return this.memoExEdit1.EditorTypeName;
            }
        }

        [Description("Gets an object containing settings specific to the extended memo editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Properties")]
        public RepositoryItemMemoExEdit Properties
        {
            get
            {
                return this.memoExEdit1.Properties;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the text lines to be displayed in the dropdown window of an extended memo edit control.")]
        [Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design", typeof(UITypeEditor))]
        public String[] Lines
        {
            get
            {
                return this.memoExEdit1.Lines;
            }
            set
            {
                this.memoExEdit1.Lines = value;
            }
        }

        [Browsable(false)]
        public Boolean IsPopupOpen
        {
            get
            {
                return this.memoExEdit1.IsPopupOpen;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.memoExEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        [Description("Gets a value indicating whether a container needs to set focus to the editor when it works as an inplace control.")]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.memoExEdit1.IsNeedFocus;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.memoExEdit1.BackColor;
            }
            set
            {
                this.memoExEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.memoExEdit1.TabStop;
            }
            set
            {
                this.memoExEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.memoExEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.memoExEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.memoExEdit1.SelectionStart;
            }
            set
            {
                this.memoExEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.memoExEdit1.SelectionLength;
            }
            set
            {
                this.memoExEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.memoExEdit1.SelectedText;
            }
            set
            {
                this.memoExEdit1.SelectedText = value;
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
                return this.memoExEdit1.Text;
            }
            set
            {
                this.memoExEdit1.Text = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.memoExEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.memoExEdit1.BackgroundImage;
            }
            set
            {
                this.memoExEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.memoExEdit1.BackgroundImageLayout;
            }
            set
            {
                this.memoExEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.memoExEdit1.Padding;
            }
            set
            {
                this.memoExEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.memoExEdit1.MenuManager;
            }
            set
            {
                this.memoExEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.memoExEdit1.ErrorText;
            }
            set
            {
                this.memoExEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.memoExEdit1.ErrorIconAlignment;
            }
            set
            {
                this.memoExEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.memoExEdit1.ErrorIcon;
            }
            set
            {
                this.memoExEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.memoExEdit1.ServiceObject;
            }
            set
            {
                this.memoExEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.memoExEdit1.InplaceType;
            }
            set
            {
                this.memoExEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.memoExEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.memoExEdit1.IsModified;
            }
            set
            {
                this.memoExEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.memoExEdit1.OldEditValue;
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
                return this.memoExEdit1.EditValue;
            }
            set
            {
                this.memoExEdit1.EditValue = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.memoExEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.memoExEdit1.LookAndFeel;
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
                return this.memoExEdit1.BorderStyle;
            }
            set
            {
                this.memoExEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.memoExEdit1.ForeColor;
            }
            set
            {
                this.memoExEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.memoExEdit1.Font;
            }
            set
            {
                this.memoExEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.memoExEdit1.ContextMenu;
            }
            set
            {
                this.memoExEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.memoExEdit1.ContextMenuStrip;
            }
            set
            {
                this.memoExEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.memoExEdit1.AccessibleName;
            }
            set
            {
                this.memoExEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.memoExEdit1.AccessibleRole;
            }
            set
            {
                this.memoExEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.memoExEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.memoExEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.memoExEdit1.AccessibleDescription;
            }
            set
            {
                this.memoExEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.memoExEdit1.EnterMoveNextControl;
            }
            set
            {
                this.memoExEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.memoExEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.memoExEdit1.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.memoExEdit1_QueryCloseUp);
            this.memoExEdit1.Popup += new System.EventHandler(this.memoExEdit1_Popup);
            this.memoExEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.memoExEdit1_QueryPopUp);
            this.memoExEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.memoExEdit1_CloseUp);
            this.memoExEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.memoExEdit1_Closed);
            this.memoExEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.memoExEdit1_ButtonClick);
            this.memoExEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.memoExEdit1_ButtonPressed);
            this.memoExEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.memoExEdit1_Spin);
            this.memoExEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.memoExEdit1_InvalidValue);
            this.memoExEdit1.PropertiesChanged += new System.EventHandler(this.memoExEdit1_PropertiesChanged);
            this.memoExEdit1.EditValueChanged += new System.EventHandler(this.memoExEdit1_EditValueChanged);
            this.memoExEdit1.Modified += new System.EventHandler(this.memoExEdit1_Modified);
            this.memoExEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.memoExEdit1_EditValueChanging);
            this.memoExEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.memoExEdit1_ParseEditValue);
            this.memoExEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.memoExEdit1_FormatEditValue);
            this.memoExEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.memoExEdit1_CustomDisplayText);
            this.memoExEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.memoExEdit1_QueryAccessibilityHelp);
            this.memoExEdit1.ForeColorChanged += new System.EventHandler(this.memoExEdit1_ForeColorChanged);
            this.memoExEdit1.BackColorChanged += new System.EventHandler(this.memoExEdit1_BackColorChanged);
            this.memoExEdit1.FontChanged += new System.EventHandler(this.memoExEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void memoExEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (this.QueryCloseUp != null)
            {
                this.QueryCloseUp(sender, e);
            }
        }

        private void memoExEdit1_Popup(object sender, EventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup(sender, e);
            }
        }

        private void memoExEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.QueryPopUp != null)
            {
                this.QueryPopUp(sender, e);
            }
        }

        private void memoExEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (this.CloseUp != null)
            {
                this.CloseUp(sender, e);
            }
        }

        private void memoExEdit1_Closed(object sender, ClosedEventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        private void memoExEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(sender, e);
            }
        }

        private void memoExEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonPressed != null)
            {
                this.ButtonPressed(sender, e);
            }
        }

        private void memoExEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void memoExEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void memoExEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void memoExEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void memoExEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void memoExEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void memoExEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void memoExEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void memoExEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void memoExEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void memoExEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void memoExEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void memoExEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}