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
    [ToolboxBitmap(typeof(LookUpEdit))]
    public partial class LookUpEditEx : EditorBase
    {
        private LookUpEdit lookUpEdit1;

        public LookUpEditEx()
        {
            this.lookUpEdit1 = new LookUpEdit();
            base.AddEditor(this.lookUpEdit1);
            this.lookUpEdit1.Properties.NullText = "N/A";
            this.RegisterEvents();

            InitializeComponent();
        }

        protected override int EditorHeight
        {
            get { return this.lookUpEdit1 == null ? base.EditorHeight : this.lookUpEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.lookUpEdit1.DataBindings.Clear();
            this.lookUpEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.lookUpEdit1.DataBindings.Count == 0)
                return;

            this.lookUpEdit1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Category("Events")]
        [Description("Occurs when retrieving values for fields not found in the RepositoryItemLookUpEditBase.DataSource.")]
        public event GetNotInListValueEventHandler GetNotInListValue;
        [Category("Events")]
        [Description("Occurs after a record(s) in the RepositoryItemLookUpEditBase.DataSource has been changed.")]
        public event ListChangedEventHandler ListChanged;
        [Category("Events")]
        [Description("Occurs when a new value entered into the edit box is validated.")]
        public event ProcessNewValueEventHandler ProcessNewValue;
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 ItemIndex
        {
            get
            {
                return this.lookUpEdit1.ItemIndex;
            }
            set
            {
                this.lookUpEdit1.ItemIndex = value;
            }
        }

        [Browsable(false)]
        public Boolean IsDisplayTextValid
        {
            get
            {
                return this.lookUpEdit1.IsDisplayTextValid;
            }
        }

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.lookUpEdit1.EditorTypeName;
            }
        }

        [Description("Specifies settings specific to the current editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Properties")]
        public RepositoryItemLookUpEdit Properties
        {
            get
            {
                return this.lookUpEdit1.Properties;
            }
        }

        [Browsable(false)]
        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override String Text
        {
            get
            {
                return this.lookUpEdit1.Text;
            }
            set
            {
                this.lookUpEdit1.Text = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String AutoSearchText
        {
            get
            {
                return this.lookUpEdit1.AutoSearchText;
            }
            set
            {
                this.lookUpEdit1.AutoSearchText = value;
            }
        }

        [Browsable(false)]
        public Boolean IsPopupOpen
        {
            get
            {
                return this.lookUpEdit1.IsPopupOpen;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.lookUpEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        [Description("Gets a value indicating whether a container needs to set focus to the editor when it works as an inplace control.")]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.lookUpEdit1.IsNeedFocus;
            }
        }

        public new Color BackColor
        {
            get
            {
                return this.lookUpEdit1.BackColor;
            }
            set
            {
                this.lookUpEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.lookUpEdit1.TabStop;
            }
            set
            {
                this.lookUpEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.lookUpEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.lookUpEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.lookUpEdit1.SelectionStart;
            }
            set
            {
                this.lookUpEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.lookUpEdit1.SelectionLength;
            }
            set
            {
                this.lookUpEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.lookUpEdit1.SelectedText;
            }
            set
            {
                this.lookUpEdit1.SelectedText = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.lookUpEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.lookUpEdit1.BackgroundImage;
            }
            set
            {
                this.lookUpEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.lookUpEdit1.BackgroundImageLayout;
            }
            set
            {
                this.lookUpEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.lookUpEdit1.Padding;
            }
            set
            {
                this.lookUpEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.lookUpEdit1.MenuManager;
            }
            set
            {
                this.lookUpEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.lookUpEdit1.ErrorText;
            }
            set
            {
                this.lookUpEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.lookUpEdit1.ErrorIconAlignment;
            }
            set
            {
                this.lookUpEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.lookUpEdit1.ErrorIcon;
            }
            set
            {
                this.lookUpEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.lookUpEdit1.ServiceObject;
            }
            set
            {
                this.lookUpEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.lookUpEdit1.InplaceType;
            }
            set
            {
                this.lookUpEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.lookUpEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.lookUpEdit1.IsModified;
            }
            set
            {
                this.lookUpEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.lookUpEdit1.OldEditValue;
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
                return this.lookUpEdit1.EditValue;
            }
            set
            {
                this.lookUpEdit1.EditValue = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.lookUpEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.lookUpEdit1.LookAndFeel;
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
                return this.lookUpEdit1.BorderStyle;
            }
            set
            {
                this.lookUpEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.lookUpEdit1.ForeColor;
            }
            set
            {
                this.lookUpEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.lookUpEdit1.Font;
            }
            set
            {
                this.lookUpEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.lookUpEdit1.ContextMenu;
            }
            set
            {
                this.lookUpEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.lookUpEdit1.ContextMenuStrip;
            }
            set
            {
                this.lookUpEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.lookUpEdit1.AccessibleName;
            }
            set
            {
                this.lookUpEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.lookUpEdit1.AccessibleRole;
            }
            set
            {
                this.lookUpEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.lookUpEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.lookUpEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.lookUpEdit1.AccessibleDescription;
            }
            set
            {
                this.lookUpEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.lookUpEdit1.EnterMoveNextControl;
            }
            set
            {
                this.lookUpEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.lookUpEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.lookUpEdit1.GetNotInListValue += new DevExpress.XtraEditors.Controls.GetNotInListValueEventHandler(this.lookUpEdit1_GetNotInListValue);
            this.lookUpEdit1.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.lookUpEdit1_ListChanged);
            this.lookUpEdit1.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.lookUpEdit1_ProcessNewValue);
            this.lookUpEdit1.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.lookUpEdit1_QueryCloseUp);
            this.lookUpEdit1.Popup += new System.EventHandler(this.lookUpEdit1_Popup);
            this.lookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.lookUpEdit1_QueryPopUp);
            this.lookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.lookUpEdit1_CloseUp);
            this.lookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.lookUpEdit1_Closed);
            this.lookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpEdit1_ButtonClick);
            this.lookUpEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpEdit1_ButtonPressed);
            this.lookUpEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.lookUpEdit1_Spin);
            this.lookUpEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.lookUpEdit1_InvalidValue);
            this.lookUpEdit1.PropertiesChanged += new System.EventHandler(this.lookUpEdit1_PropertiesChanged);
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            this.lookUpEdit1.Modified += new System.EventHandler(this.lookUpEdit1_Modified);
            this.lookUpEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.lookUpEdit1_EditValueChanging);
            this.lookUpEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.lookUpEdit1_ParseEditValue);
            this.lookUpEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.lookUpEdit1_FormatEditValue);
            this.lookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.lookUpEdit1_CustomDisplayText);
            this.lookUpEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.lookUpEdit1_QueryAccessibilityHelp);
            this.lookUpEdit1.ForeColorChanged += new System.EventHandler(this.lookUpEdit1_ForeColorChanged);
            this.lookUpEdit1.BackColorChanged += new System.EventHandler(this.lookUpEdit1_BackColorChanged);
            this.lookUpEdit1.FontChanged += new System.EventHandler(this.lookUpEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void lookUpEdit1_GetNotInListValue(object sender, GetNotInListValueEventArgs e)
        {
            if (this.GetNotInListValue != null)
            {
                this.GetNotInListValue(sender, e);
            }
        }

        private void lookUpEdit1_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (this.ListChanged != null)
            {
                this.ListChanged(sender, e);
            }
        }

        private void lookUpEdit1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (this.ProcessNewValue != null)
            {
                this.ProcessNewValue(sender, e);
            }
        }

        private void lookUpEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (this.QueryCloseUp != null)
            {
                this.QueryCloseUp(sender, e);
            }
        }

        private void lookUpEdit1_Popup(object sender, EventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup(sender, e);
            }
        }

        private void lookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.QueryPopUp != null)
            {
                this.QueryPopUp(sender, e);
            }
        }

        private void lookUpEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (this.CloseUp != null)
            {
                this.CloseUp(sender, e);
            }
        }

        private void lookUpEdit1_Closed(object sender, ClosedEventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        private void lookUpEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(sender, e);
            }
        }

        private void lookUpEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonPressed != null)
            {
                this.ButtonPressed(sender, e);
            }
        }

        private void lookUpEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void lookUpEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void lookUpEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void lookUpEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void lookUpEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void lookUpEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void lookUpEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void lookUpEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void lookUpEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void lookUpEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void lookUpEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void lookUpEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}