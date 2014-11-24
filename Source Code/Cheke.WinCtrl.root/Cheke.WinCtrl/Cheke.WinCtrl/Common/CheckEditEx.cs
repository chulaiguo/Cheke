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
    [DefaultEvent("CheckedChanged")]
    [DefaultProperty("Checked")]
    [ToolboxBitmap(typeof(CheckEdit))]
    public partial class CheckEditEx : EditorBase
    {
        private CheckEdit checkEdit1;

        public CheckEditEx()
        {
            this.checkEdit1 = new CheckEdit();
            base.AddEditor(this.checkEdit1);
            base.Title = string.Empty;
            this.RegisterEvents();

            InitializeComponent();
        }

        protected override int EditorHeight
        {
            get { return this.checkEdit1 == null ? base.EditorHeight : this.checkEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.checkEdit1.DataBindings.Clear();
            this.checkEdit1.DataBindings.Add("EditValue", obj, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void RefreshDataBinding()
        {
            if (this.checkEdit1.DataBindings.Count == 0)
                return;

            this.checkEdit1.DataBindings[0].ReadValue();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DefaultValue("")]
        public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DefaultValue(false)]
        public override bool TitleVisible
        {
            get { return base.TitleVisible; }
            set { base.TitleVisible = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DefaultValue(Orientation.Vertical)]
        public override Orientation Orientation
        {
            get { return base.Orientation; }
            set { base.Orientation = value; }
        }

        #region Event Members

        [Category("Events")]
        [Description("Enables you to provide a custom conversion of the CheckEdit.EditValue property value to the appropriate check state.")]
        public event QueryCheckStateByValueEventHandler QueryCheckStateByValue;
        [Category("Events")]
        [Description("Enables you to provide custom conversion of the current check state to the appropriate CheckEdit.EditValue property value .")]
        public event QueryValueByCheckStateEventHandler QueryValueByCheckState;
        [Description("Occurs when the CheckEdit.Checked property value has been changed.")]
        [Category("Events")]
        public event EventHandler CheckedChanged;
        [Category("Events")]
        [Description("Occurs after the CheckEdit.CheckState property value was changed.")]
        public event EventHandler CheckStateChanged;
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

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Properties")]
        [DefaultValue(false)]
        [Description("")]
        [RefreshProperties(RefreshProperties.All)]
        public Boolean AutoSizeInLayoutControl
        {
            get
            {
                return this.checkEdit1.AutoSizeInLayoutControl;
            }
            set
            {
                this.checkEdit1.AutoSizeInLayoutControl = value;
            }
        }

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.checkEdit1.EditorTypeName;
            }
        }

        [Category("Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Gets an object containing properties, methods and events specific to a check editor.")]
        public RepositoryItemCheckEdit Properties
        {
            get
            {
                return this.checkEdit1.Properties;
            }
        }

        [Bindable(false)]
        [Category("Appearance")]
        [Description("Gets or sets the text label associated with a check editor.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override String Text
        {
            get
            {
                return this.checkEdit1.Text;
            }
            set
            {
                this.checkEdit1.Text = value;
            }
        }

        [Browsable(false)]
        public new Size PreferredSize
        {
            get
            {
                return this.checkEdit1.PreferredSize;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the style used to draw the check editor's border.")]
        [DefaultValue(BorderStyles.NoBorder)]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new BorderStyles BorderStyle
        {
            get
            {
                return this.checkEdit1.BorderStyle;
            }
            set
            {
                this.checkEdit1.BorderStyle = value;
            }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Object EditValue
        {
            get
            {
                return this.checkEdit1.EditValue;
            }
            set
            {
                this.checkEdit1.EditValue = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the state of the check editor.")]
        [RefreshProperties(RefreshProperties.All)]
        [DefaultValue(CheckState.Unchecked)]
        public CheckState CheckState
        {
            get
            {
                return this.checkEdit1.CheckState;
            }
            set
            {
                this.checkEdit1.CheckState = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [Category("Appearance")]
        [RefreshProperties(RefreshProperties.All)]
        [Description("Gets or sets a value indicating whether a check editor is checked.")]
        public Boolean Checked
        {
            get
            {
                return this.checkEdit1.Checked;
            }
            set
            {
                this.checkEdit1.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.checkEdit1.Padding;
            }
            set
            {
                this.checkEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.checkEdit1.MenuManager;
            }
            set
            {
                this.checkEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.checkEdit1.ErrorText;
            }
            set
            {
                this.checkEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.checkEdit1.ErrorIconAlignment;
            }
            set
            {
                this.checkEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.checkEdit1.ErrorIcon;
            }
            set
            {
                this.checkEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.checkEdit1.ServiceObject;
            }
            set
            {
                this.checkEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.checkEdit1.InplaceType;
            }
            set
            {
                this.checkEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.checkEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.checkEdit1.IsModified;
            }
            set
            {
                this.checkEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.checkEdit1.IsNeedFocus;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.checkEdit1.OldEditValue;
            }
        }

        public new Boolean TabStop
        {
            get
            {
                return this.checkEdit1.TabStop;
            }
            set
            {
                this.checkEdit1.TabStop = value;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.checkEdit1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        public Boolean IsEditorActive
        {
            get
            {
                return this.checkEdit1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.checkEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.checkEdit1.LookAndFeel;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the background color of an enabled editor.")]
        public new Color BackColor
        {
            get
            {
                return this.checkEdit1.BackColor;
            }
            set
            {
                this.checkEdit1.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.checkEdit1.ForeColor;
            }
            set
            {
                this.checkEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.checkEdit1.Font;
            }
            set
            {
                this.checkEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.checkEdit1.ContextMenu;
            }
            set
            {
                this.checkEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.checkEdit1.ContextMenuStrip;
            }
            set
            {
                this.checkEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.checkEdit1.AccessibleName;
            }
            set
            {
                this.checkEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.checkEdit1.AccessibleRole;
            }
            set
            {
                this.checkEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.checkEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.checkEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.checkEdit1.AccessibleDescription;
            }
            set
            {
                this.checkEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.checkEdit1.EnterMoveNextControl;
            }
            set
            {
                this.checkEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.checkEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.checkEdit1.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(this.checkEdit1_QueryCheckStateByValue);
            this.checkEdit1.QueryValueByCheckState += new DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventHandler(this.checkEdit1_QueryValueByCheckState);
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            this.checkEdit1.CheckStateChanged += new System.EventHandler(this.checkEdit1_CheckStateChanged);
            this.checkEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.checkEdit1_InvalidValue);
            this.checkEdit1.PropertiesChanged += new System.EventHandler(this.checkEdit1_PropertiesChanged);
            this.checkEdit1.EditValueChanged += new System.EventHandler(this.checkEdit1_EditValueChanged);
            this.checkEdit1.Modified += new System.EventHandler(this.checkEdit1_Modified);
            this.checkEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.checkEdit1_EditValueChanging);
            this.checkEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.checkEdit1_ParseEditValue);
            this.checkEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.checkEdit1_FormatEditValue);
            this.checkEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkEdit1_CustomDisplayText);
            this.checkEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.checkEdit1_QueryAccessibilityHelp);
            this.checkEdit1.ForeColorChanged += new System.EventHandler(this.checkEdit1_ForeColorChanged);
            this.checkEdit1.BackColorChanged += new System.EventHandler(this.checkEdit1_BackColorChanged);
            this.checkEdit1.FontChanged += new System.EventHandler(this.checkEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void checkEdit1_QueryCheckStateByValue(object sender, QueryCheckStateByValueEventArgs e)
        {
            if (this.QueryCheckStateByValue != null)
            {
                this.QueryCheckStateByValue(sender, e);
            }
        }

        private void checkEdit1_QueryValueByCheckState(object sender, QueryValueByCheckStateEventArgs e)
        {
            if (this.QueryValueByCheckState != null)
            {
                this.QueryValueByCheckState(sender, e);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckedChanged != null)
            {
                this.CheckedChanged(sender, e);
            }
        }

        private void checkEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.CheckStateChanged != null)
            {
                this.CheckStateChanged(sender, e);
            }
        }

        private void checkEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void checkEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void checkEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void checkEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void checkEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void checkEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void checkEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void checkEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void checkEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void checkEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void checkEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void checkEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}