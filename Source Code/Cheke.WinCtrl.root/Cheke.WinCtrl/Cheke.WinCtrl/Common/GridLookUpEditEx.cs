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
using DevExpress.XtraGrid.Views.Grid;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(GridLookUpEdit))]
    [DefaultEvent("EditValueChanged")]
    [DefaultProperty("Text")]
    public partial class GridLookUpEditEx : EditorBase
    {
        private GridLookUpEdit gridLookUpEdit1;
        private GridView gridLookUpEdit1View = null;

        #region Event Members

        [Description("Occurs when a new value entered into the edit box is validated.")]
        [Category("Events")]
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
        [Description("Allows you to perform specific actions with respect to how the popup window was closed.")]
        [Category("Events")]
        public event ClosedEventHandler Closed;
        [Category("Events")]
        [Description("Occurs when a button editor's button is clicked.")]
        public event ButtonPressedEventHandler ButtonClick;
        [Description("Occurs when pressing an editor button.")]
        [Category("Events")]
        public event ButtonPressedEventHandler ButtonPressed;
        [Category("Events")]
        [Description("Occurs when either the UP or DOWN ARROW key is pressed or the mouse wheel is rotated.")]
        public event SpinEventHandler Spin;
        [Description("Enables an appropriate response to be provided when invalid values are entered.")]
        [Category("Events")]
        public event InvalidValueExceptionEventHandler InvalidValue;
        [Description("Fires immediately after any editor's property value has changed.")]
        [Category("Events")]
        public event EventHandler PropertiesChanged;
        [Description("Fires immediately after the edit value has been changed.")]
        [Category("Events")]
        public event EventHandler EditValueChanged;
        [Category("Events")]
        [Description("Fires when the user starts to modify the edit value.")]
        public event EventHandler Modified;
        [Description("Fires when an end-user starts to modify the editor's value.")]
        [Category("Events")]
        public event ChangingEventHandler EditValueChanging;
        [Category("Events")]
        [Description("Enables you to convert the value entered to the value that will be stored by the editor.")]
        public event ConvertEditValueEventHandler ParseEditValue;
        [Category("Events")]
        [Description("Enables you to format the editor's value.")]
        public event ConvertEditValueEventHandler FormatEditValue;
        [Category("Events")]
        [Description("Enables custom display text to be provided for an editor.")]
        public event CustomDisplayTextEventHandler CustomDisplayText;
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
        #endregion

        public GridLookUpEditEx()
        {
            this.gridLookUpEdit1 = new GridLookUpEdit();
            this.gridLookUpEdit1View = new GridView();
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            base.AddEditor(this.gridLookUpEdit1);

            this.gridLookUpEdit1.Properties.NullText = "N/A";

            InitializeComponent();
            this.RegisterEvents();
        }

        protected override int EditorHeight
        {
            get { return this.gridLookUpEdit1 == null ? base.EditorHeight : this.gridLookUpEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.gridLookUpEdit1.DataBindings.Clear();
            this.gridLookUpEdit1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.gridLookUpEdit1.DataBindings.Count == 0)
                return;

            this.gridLookUpEdit1.DataBindings[0].ReadValue();
        }

        #region Property Members

        [Description("Gets the class name of the current editor. ")]
        public String EditorTypeName
        {
            get
            {
                return this.gridLookUpEdit1.EditorTypeName;
            }
        }

        [Category("Properties")]
        [Description("Specifies settings specific to the current editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RepositoryItemGridLookUpEdit Properties
        {
            get
            {
                return this.gridLookUpEdit1.Properties;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public String AutoSearchText
        {
            get
            {
                return this.gridLookUpEdit1.AutoSearchText;
            }
            set
            {
                this.gridLookUpEdit1.AutoSearchText = value;
            }
        }

        [Browsable(false)]
        public Boolean IsPopupOpen
        {
            get
            {
                return this.gridLookUpEdit1.IsPopupOpen;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.gridLookUpEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        [Description("Gets a value indicating whether a container needs to set focus to the editor when it works as an inplace control.")]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.gridLookUpEdit1.IsNeedFocus;
            }
        }

        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        public new Boolean TabStop
        {
            get
            {
                return this.gridLookUpEdit1.TabStop;
            }
            set
            {
                this.gridLookUpEdit1.TabStop = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.gridLookUpEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.gridLookUpEdit1.IsEditorActive;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionStart
        {
            get
            {
                return this.gridLookUpEdit1.SelectionStart;
            }
            set
            {
                this.gridLookUpEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.gridLookUpEdit1.SelectionLength;
            }
            set
            {
                this.gridLookUpEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.gridLookUpEdit1.SelectedText;
            }
            set
            {
                this.gridLookUpEdit1.SelectedText = value;
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        [Description("Gets or sets the text displayed in the edit box.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        [Category("Appearance")]
        public override String Text
        {
            get
            {
                return this.gridLookUpEdit1.Text;
            }
            set
            {
                this.gridLookUpEdit1.Text = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.gridLookUpEdit1.CanUndo;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether focus is moved to the next control in the TAB order when the ENTER key is pressed.")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.gridLookUpEdit1.EnterMoveNextControl;
            }
            set
            {
                this.gridLookUpEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Image BackgroundImage
        {
            get
            {
                return this.gridLookUpEdit1.BackgroundImage;
            }
            set
            {
                this.gridLookUpEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.gridLookUpEdit1.BackgroundImageLayout;
            }
            set
            {
                this.gridLookUpEdit1.BackgroundImageLayout = value;
            }
        }

        [DefaultValue(null)]
        [Category("BarManager")]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.gridLookUpEdit1.MenuManager;
            }
            set
            {
                this.gridLookUpEdit1.MenuManager = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public String ErrorText
        {
            get
            {
                return this.gridLookUpEdit1.ErrorText;
            }
            set
            {
                this.gridLookUpEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.gridLookUpEdit1.ErrorIconAlignment;
            }
            set
            {
                this.gridLookUpEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.gridLookUpEdit1.ErrorIcon;
            }
            set
            {
                this.gridLookUpEdit1.ErrorIcon = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.gridLookUpEdit1.ServiceObject;
            }
            set
            {
                this.gridLookUpEdit1.ServiceObject = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public InplaceType InplaceType
        {
            get
            {
                return this.gridLookUpEdit1.InplaceType;
            }
            set
            {
                this.gridLookUpEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.gridLookUpEdit1.IsLoading;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Boolean IsModified
        {
            get
            {
                return this.gridLookUpEdit1.IsModified;
            }
            set
            {
                this.gridLookUpEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.gridLookUpEdit1.OldEditValue;
            }
        }

        [TypeConverter(typeof(ObjectEditorTypeConverter))]
        [DefaultValue(null)]
        [Description("Gets or sets the editor's value.")]
        [Bindable(true)]
        [RefreshProperties(RefreshProperties.All)]
        [Localizable(true)]
        [Category("Data")]
        [Editor(typeof(UIObjectEditor), typeof(UITypeEditor))]
        public Object EditValue
        {
            get
            {
                return this.gridLookUpEdit1.EditValue;
            }
            set
            {
                this.gridLookUpEdit1.EditValue = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.gridLookUpEdit1.BindingManager;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.gridLookUpEdit1.LookAndFeel;
            }
        }

        [Description("Gets or sets the editor's border style.")]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        public new BorderStyles BorderStyle
        {
            get
            {
                return this.gridLookUpEdit1.BorderStyle;
            }
            set
            {
                this.gridLookUpEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the background color of an enabled editor.")]
        [Category("Appearance")]
        public new Color BackColor
        {
            get
            {
                return this.gridLookUpEdit1.BackColor;
            }
            set
            {
                this.gridLookUpEdit1.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.gridLookUpEdit1.ForeColor;
            }
            set
            {
                this.gridLookUpEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.gridLookUpEdit1.Font;
            }
            set
            {
                this.gridLookUpEdit1.Font = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.gridLookUpEdit1.ContextMenu;
            }
            set
            {
                this.gridLookUpEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.gridLookUpEdit1.ContextMenuStrip;
            }
            set
            {
                this.gridLookUpEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleName
        {
            get
            {
                return this.gridLookUpEdit1.AccessibleName;
            }
            set
            {
                this.gridLookUpEdit1.AccessibleName = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.gridLookUpEdit1.AccessibleRole;
            }
            set
            {
                this.gridLookUpEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.gridLookUpEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.gridLookUpEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.gridLookUpEdit1.AccessibleDescription;
            }
            set
            {
                this.gridLookUpEdit1.AccessibleDescription = value;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.gridLookUpEdit1.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.gridLookUpEdit1_ProcessNewValue);
            this.gridLookUpEdit1.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_QueryCloseUp);
            this.gridLookUpEdit1.Popup += new System.EventHandler(this.gridLookUpEdit1_Popup);
            this.gridLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_QueryPopUp);
            this.gridLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.gridLookUpEdit1_CloseUp);
            this.gridLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.gridLookUpEdit1_Closed);
            this.gridLookUpEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit1_ButtonClick);
            this.gridLookUpEdit1.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit1_ButtonPressed);
            this.gridLookUpEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.gridLookUpEdit1_Spin);
            this.gridLookUpEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gridLookUpEdit1_InvalidValue);
            this.gridLookUpEdit1.PropertiesChanged += new System.EventHandler(this.gridLookUpEdit1_PropertiesChanged);
            this.gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.gridLookUpEdit1_EditValueChanged);
            this.gridLookUpEdit1.Modified += new System.EventHandler(this.gridLookUpEdit1_Modified);
            this.gridLookUpEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.gridLookUpEdit1_EditValueChanging);
            this.gridLookUpEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.gridLookUpEdit1_ParseEditValue);
            this.gridLookUpEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.gridLookUpEdit1_FormatEditValue);
            this.gridLookUpEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.gridLookUpEdit1_CustomDisplayText);
            this.gridLookUpEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.gridLookUpEdit1_QueryAccessibilityHelp);
        }
        #endregion

        #region Event Methods

        private void gridLookUpEdit1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            if (this.ProcessNewValue != null)
            {
                this.ProcessNewValue(sender, e);
            }
        }

        private void gridLookUpEdit1_QueryCloseUp(object sender, CancelEventArgs e)
        {
            if (this.QueryCloseUp != null)
            {
                this.QueryCloseUp(sender, e);
            }
        }

        private void gridLookUpEdit1_Popup(object sender, EventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup(sender, e);
            }
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.QueryPopUp != null)
            {
                this.QueryPopUp(sender, e);
            }
        }

        private void gridLookUpEdit1_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (this.CloseUp != null)
            {
                this.CloseUp(sender, e);
            }
        }

        private void gridLookUpEdit1_Closed(object sender, ClosedEventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        private void gridLookUpEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(sender, e);
            }
        }

        private void gridLookUpEdit1_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (this.ButtonPressed != null)
            {
                this.ButtonPressed(sender, e);
            }
        }

        private void gridLookUpEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void gridLookUpEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void gridLookUpEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void gridLookUpEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void gridLookUpEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void gridLookUpEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void gridLookUpEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void gridLookUpEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void gridLookUpEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        #endregion
    }
}
