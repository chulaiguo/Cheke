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
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(true)]
    [DefaultEvent("EditValueChanged")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(DateEdit))]
    public partial class DateEditEx : EditorBase
    {
        private DateEdit dateEdit1;

        public DateEditEx()
        {
            this.dateEdit1 = new DateEdit();
            base.AddEditor(this.dateEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        protected override int EditorHeight
        {
            get { return this.dateEdit1 == null ? base.EditorHeight : this.dateEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.dateEdit1.DataBindings.Clear();
            this.dateEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.dateEdit1.DataBindings.Count == 0)
                return;

            this.dateEdit1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Description("Provides the ability to custom paint day cells in the dropdown calendar.")]
        [Category("Events")]
        public event CustomDrawDayNumberCellEventHandler DrawItem;
        [Category("Events")]
        [Description("Occurs after the value of the DateEdit.DateTime property has been changed.")]
        public event EventHandler DateTimeChanged;
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
                return this.dateEdit1.EditorTypeName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Gets settings specific to the date editor.")]
        [Category("Properties")]
        public RepositoryItemDateEdit Properties
        {
            get
            {
                return this.dateEdit1.Properties;
            }
        }

        [Description("Gets or sets the date/time value edited within the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(false)]
        [Category("Appearance")]
        public DateTime DateTime
        {
            get
            {
                return this.dateEdit1.DateTime;
            }
            set
            {
                this.dateEdit1.DateTime = value;
            }
        }

        [Browsable(false)]
        [Bindable(false)]
        public override String Text
        {
            get
            {
                return this.dateEdit1.Text;
            }
        }

        [Browsable(false)]
        public Boolean IsPopupOpen
        {
            get
            {
                return this.dateEdit1.IsPopupOpen;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.dateEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        [Description("Gets a value indicating whether a container needs to set focus to the editor when it works as an inplace control.")]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.dateEdit1.IsNeedFocus;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.dateEdit1.BackColor;
            }
            set
            {
                this.dateEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.dateEdit1.TabStop;
            }
            set
            {
                this.dateEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.dateEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.dateEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.dateEdit1.SelectionStart;
            }
            set
            {
                this.dateEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.dateEdit1.SelectionLength;
            }
            set
            {
                this.dateEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.dateEdit1.SelectedText;
            }
            set
            {
                this.dateEdit1.SelectedText = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.dateEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.dateEdit1.BackgroundImage;
            }
            set
            {
                this.dateEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.dateEdit1.BackgroundImageLayout;
            }
            set
            {
                this.dateEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.dateEdit1.Padding;
            }
            set
            {
                this.dateEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.dateEdit1.MenuManager;
            }
            set
            {
                this.dateEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.dateEdit1.ErrorText;
            }
            set
            {
                this.dateEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.dateEdit1.ErrorIconAlignment;
            }
            set
            {
                this.dateEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.dateEdit1.ErrorIcon;
            }
            set
            {
                this.dateEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.dateEdit1.ServiceObject;
            }
            set
            {
                this.dateEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.dateEdit1.InplaceType;
            }
            set
            {
                this.dateEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.dateEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.dateEdit1.IsModified;
            }
            set
            {
                this.dateEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.dateEdit1.OldEditValue;
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
                return this.dateEdit1.EditValue;
            }
            set
            {
                this.dateEdit1.EditValue = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.dateEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.dateEdit1.LookAndFeel;
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
                return this.dateEdit1.BorderStyle;
            }
            set
            {
                this.dateEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.dateEdit1.ForeColor;
            }
            set
            {
                this.dateEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.dateEdit1.Font;
            }
            set
            {
                this.dateEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.dateEdit1.ContextMenu;
            }
            set
            {
                this.dateEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.dateEdit1.ContextMenuStrip;
            }
            set
            {
                this.dateEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.dateEdit1.AccessibleName;
            }
            set
            {
                this.dateEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.dateEdit1.AccessibleRole;
            }
            set
            {
                this.dateEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.dateEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.dateEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.dateEdit1.AccessibleDescription;
            }
            set
            {
                this.dateEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.dateEdit1.EnterMoveNextControl;
            }
            set
            {
                this.dateEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.dateEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.dateEdit1.DrawItem += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.dateEdit1_DrawItem);
            this.dateEdit1.DateTimeChanged += new System.EventHandler(this.dateEdit1_DateTimeChanged);
            this.dateEdit1.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.dateEdit1_QueryCloseUp);
            this.dateEdit1.Popup += new System.EventHandler(this.dateEdit1_Popup);
            this.dateEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.dateEdit1_QueryPopUp);
            this.dateEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.dateEdit1_CloseUp);
            this.dateEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.dateEdit1_Closed);
            this.dateEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dateEdit1_ButtonClick);
            this.dateEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dateEdit1_ButtonPressed);
            this.dateEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.dateEdit1_Spin);
            this.dateEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.dateEdit1_InvalidValue);
            this.dateEdit1.PropertiesChanged += new System.EventHandler(this.dateEdit1_PropertiesChanged);
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            this.dateEdit1.Modified += new System.EventHandler(this.dateEdit1_Modified);
            this.dateEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.dateEdit1_EditValueChanging);
            this.dateEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.dateEdit1_ParseEditValue);
            this.dateEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.dateEdit1_FormatEditValue);
            this.dateEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.dateEdit1_CustomDisplayText);
            this.dateEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.dateEdit1_QueryAccessibilityHelp);
            this.dateEdit1.ForeColorChanged += new System.EventHandler(this.dateEdit1_ForeColorChanged);
            this.dateEdit1.BackColorChanged += new System.EventHandler(this.dateEdit1_BackColorChanged);
            this.dateEdit1.FontChanged += new System.EventHandler(this.dateEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void dateEdit1_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            if (this.DrawItem != null)
            {
                this.DrawItem(sender, e);
            }
        }

        private void dateEdit1_DateTimeChanged(object sender, EventArgs e)
        {
            if (this.DateTimeChanged != null)
            {
                this.DateTimeChanged(sender, e);
            }
        }

        private void dateEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (this.QueryCloseUp != null)
            {
                this.QueryCloseUp(sender, e);
            }
        }

        private void dateEdit1_Popup(object sender, EventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup(sender, e);
            }
        }

        private void dateEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.QueryPopUp != null)
            {
                this.QueryPopUp(sender, e);
            }
        }

        private void dateEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (this.CloseUp != null)
            {
                this.CloseUp(sender, e);
            }
        }

        private void dateEdit1_Closed(object sender, ClosedEventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        private void dateEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(sender, e);
            }
        }

        private void dateEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonPressed != null)
            {
                this.ButtonPressed(sender, e);
            }
        }

        private void dateEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void dateEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void dateEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void dateEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void dateEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void dateEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void dateEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void dateEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void dateEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void dateEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void dateEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void dateEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}