using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (CalcEdit))]
	[DefaultEvent("EditValueChanged")]
	[DefaultProperty("Text")]
    public partial class CalcEditEx : EditorBase
    {
        private CalcEdit calcEdit1;

        public CalcEditEx()
        {
            this.calcEdit1 = new CalcEdit();
            base.AddEditor(this.calcEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        protected override int EditorHeight
        {
            get { return this.calcEdit1 == null ? base.EditorHeight : this.calcEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.calcEdit1.DataBindings.Clear();
            this.calcEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.calcEdit1.DataBindings.Count == 0)
                return;

            this.calcEdit1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Category("Events")]
        [Description("Occurs after the value of the CalcEdit.Value property has been changed.")]
        public event EventHandler ValueChanged;
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
                return this.calcEdit1.EditorTypeName;
            }
        }

        [Category("Properties")]
        [Description("Gets a RepositoryItemCalcEdit object containing properties specific to the CalcEdit editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RepositoryItemCalcEdit Properties
        {
            get
            {
                return this.calcEdit1.Properties;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(false)]
        [Browsable(false)]
        public override String Text
        {
            get
            {
                return this.calcEdit1.Text;
            }
            set
            {
                this.calcEdit1.Text = value;
            }
        }

        [Description("Gets or sets the editor's decimal value.")]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        public Decimal Value
        {
            get
            {
                return this.calcEdit1.Value;
            }
            set
            {
                this.calcEdit1.Value = value;
            }
        }

        [Browsable(false)]
        public Object EditValue
        {
            get
            {
                return this.calcEdit1.EditValue;
            }
            set
            {
                this.calcEdit1.EditValue = value;
            }
        }

        [Browsable(false)]
        public Boolean IsPopupOpen
        {
            get
            {
                return this.calcEdit1.IsPopupOpen;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.calcEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        [Description("Gets a value indicating whether a container needs to set focus to the editor when it works as an inplace control.")]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.calcEdit1.IsNeedFocus;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.calcEdit1.BackColor;
            }
            set
            {
                this.calcEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.calcEdit1.TabStop;
            }
            set
            {
                this.calcEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.calcEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.calcEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.calcEdit1.SelectionStart;
            }
            set
            {
                this.calcEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.calcEdit1.SelectionLength;
            }
            set
            {
                this.calcEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.calcEdit1.SelectedText;
            }
            set
            {
                this.calcEdit1.SelectedText = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.calcEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.calcEdit1.BackgroundImage;
            }
            set
            {
                this.calcEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.calcEdit1.BackgroundImageLayout;
            }
            set
            {
                this.calcEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.calcEdit1.Padding;
            }
            set
            {
                this.calcEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.calcEdit1.MenuManager;
            }
            set
            {
                this.calcEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.calcEdit1.ErrorText;
            }
            set
            {
                this.calcEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.calcEdit1.ErrorIconAlignment;
            }
            set
            {
                this.calcEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.calcEdit1.ErrorIcon;
            }
            set
            {
                this.calcEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.calcEdit1.ServiceObject;
            }
            set
            {
                this.calcEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.calcEdit1.InplaceType;
            }
            set
            {
                this.calcEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.calcEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.calcEdit1.IsModified;
            }
            set
            {
                this.calcEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.calcEdit1.OldEditValue;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.calcEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.calcEdit1.LookAndFeel;
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
                return this.calcEdit1.BorderStyle;
            }
            set
            {
                this.calcEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.calcEdit1.ForeColor;
            }
            set
            {
                this.calcEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.calcEdit1.Font;
            }
            set
            {
                this.calcEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.calcEdit1.ContextMenu;
            }
            set
            {
                this.calcEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.calcEdit1.ContextMenuStrip;
            }
            set
            {
                this.calcEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.calcEdit1.AccessibleName;
            }
            set
            {
                this.calcEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.calcEdit1.AccessibleRole;
            }
            set
            {
                this.calcEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.calcEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.calcEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.calcEdit1.AccessibleDescription;
            }
            set
            {
                this.calcEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.calcEdit1.EnterMoveNextControl;
            }
            set
            {
                this.calcEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.calcEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.calcEdit1.ValueChanged += new System.EventHandler(this.calcEdit1_ValueChanged);
            this.calcEdit1.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.calcEdit1_QueryCloseUp);
            this.calcEdit1.Popup += new System.EventHandler(this.calcEdit1_Popup);
            this.calcEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.calcEdit1_QueryPopUp);
            this.calcEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.calcEdit1_CloseUp);
            this.calcEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.calcEdit1_Closed);
            this.calcEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.calcEdit1_ButtonClick);
            this.calcEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.calcEdit1_ButtonPressed);
            this.calcEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.calcEdit1_Spin);
            this.calcEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.calcEdit1_InvalidValue);
            this.calcEdit1.PropertiesChanged += new System.EventHandler(this.calcEdit1_PropertiesChanged);
            this.calcEdit1.EditValueChanged += new System.EventHandler(this.calcEdit1_EditValueChanged);
            this.calcEdit1.Modified += new System.EventHandler(this.calcEdit1_Modified);
            this.calcEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.calcEdit1_EditValueChanging);
            this.calcEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.calcEdit1_ParseEditValue);
            this.calcEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.calcEdit1_FormatEditValue);
            this.calcEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.calcEdit1_CustomDisplayText);
            this.calcEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.calcEdit1_QueryAccessibilityHelp);
            this.calcEdit1.ForeColorChanged += new System.EventHandler(this.calcEdit1_ForeColorChanged);
            this.calcEdit1.BackColorChanged += new System.EventHandler(this.calcEdit1_BackColorChanged);
            this.calcEdit1.FontChanged += new System.EventHandler(this.calcEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void calcEdit1_ValueChanged(object sender, EventArgs e)
        {
            if (this.ValueChanged != null)
            {
                this.ValueChanged(sender, e);
            }
        }

        private void calcEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (this.QueryCloseUp != null)
            {
                this.QueryCloseUp(sender, e);
            }
        }

        private void calcEdit1_Popup(object sender, EventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup(sender, e);
            }
        }

        private void calcEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.QueryPopUp != null)
            {
                this.QueryPopUp(sender, e);
            }
        }

        private void calcEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (this.CloseUp != null)
            {
                this.CloseUp(sender, e);
            }
        }

        private void calcEdit1_Closed(object sender, ClosedEventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        private void calcEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(sender, e);
            }
        }

        private void calcEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonPressed != null)
            {
                this.ButtonPressed(sender, e);
            }
        }

        private void calcEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void calcEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void calcEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void calcEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void calcEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void calcEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void calcEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void calcEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void calcEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void calcEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void calcEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void calcEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void calcEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion

    }
}