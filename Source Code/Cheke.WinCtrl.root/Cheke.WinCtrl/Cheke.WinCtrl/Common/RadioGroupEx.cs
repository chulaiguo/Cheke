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
    [DefaultEvent("SelectedIndexChanged")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(RadioGroup))]
    public partial class RadioGroupEx : EditorBase
    {
        private RadioGroup radioGroup1;

        public RadioGroupEx()
        {
            this.radioGroup1 = new RadioGroup();
            base.AddEditor(this.radioGroup1);
            this.RegisterEvents();

            InitializeComponent();
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.radioGroup1.DataBindings.Clear();
            this.radioGroup1.DataBindings.Add("EditValue", obj, dataMember);
        }

        public override void RefreshDataBinding()
        {
            if (this.radioGroup1.DataBindings.Count == 0)
                return;

            this.radioGroup1.DataBindings[0].ReadValue();
        }

        #region Event Members

        [Category("Events")]
        [Description("Occurs when changing the index of the selected value in the radio group editor.")]
        public event EventHandler SelectedIndexChanged;
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
        [RefreshProperties(RefreshProperties.All)]
        [Description("")]
        [Category("Properties")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Boolean AutoSizeInLayoutControl
        {
            get
            {
                return this.radioGroup1.AutoSizeInLayoutControl;
            }
            set
            {
                this.radioGroup1.AutoSizeInLayoutControl = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the the selected item's index.")]
        [Category("Appearance")]
        public Int32 SelectedIndex
        {
            get
            {
                return this.radioGroup1.SelectedIndex;
            }
            set
            {
                this.radioGroup1.SelectedIndex = value;
            }
        }

        [Bindable(false)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override String Text
        {
            get
            {
                return this.radioGroup1.Text;
            }
            set
            {
                this.radioGroup1.Text = value;
            }
        }

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.radioGroup1.EditorTypeName;
            }
        }

        [Description("Gets an object providing properties specific to a radio group editor.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Properties")]
        public RepositoryItemRadioGroup Properties
        {
            get
            {
                return this.radioGroup1.Properties;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.radioGroup1.Padding;
            }
            set
            {
                this.radioGroup1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.radioGroup1.MenuManager;
            }
            set
            {
                this.radioGroup1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.radioGroup1.ErrorText;
            }
            set
            {
                this.radioGroup1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.radioGroup1.ErrorIconAlignment;
            }
            set
            {
                this.radioGroup1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.radioGroup1.ErrorIcon;
            }
            set
            {
                this.radioGroup1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.radioGroup1.ServiceObject;
            }
            set
            {
                this.radioGroup1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.radioGroup1.InplaceType;
            }
            set
            {
                this.radioGroup1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.radioGroup1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.radioGroup1.IsModified;
            }
            set
            {
                this.radioGroup1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.radioGroup1.IsNeedFocus;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.radioGroup1.OldEditValue;
            }
        }

        public new Boolean TabStop
        {
            get
            {
                return this.radioGroup1.TabStop;
            }
            set
            {
                this.radioGroup1.TabStop = value;
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
                return this.radioGroup1.EditValue;
            }
            set
            {
                this.radioGroup1.EditValue = value;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.radioGroup1.EditorContainsFocus;
            }
        }

        [Browsable(false)]
        public Boolean IsEditorActive
        {
            get
            {
                return this.radioGroup1.IsEditorActive;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.radioGroup1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.radioGroup1.LookAndFeel;
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
                return this.radioGroup1.BorderStyle;
            }
            set
            {
                this.radioGroup1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the background color of an enabled editor.")]
        public new Color BackColor
        {
            get
            {
                return this.radioGroup1.BackColor;
            }
            set
            {
                this.radioGroup1.BackColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.radioGroup1.ForeColor;
            }
            set
            {
                this.radioGroup1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.radioGroup1.Font;
            }
            set
            {
                this.radioGroup1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.radioGroup1.ContextMenu;
            }
            set
            {
                this.radioGroup1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.radioGroup1.ContextMenuStrip;
            }
            set
            {
                this.radioGroup1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.radioGroup1.AccessibleName;
            }
            set
            {
                this.radioGroup1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.radioGroup1.AccessibleRole;
            }
            set
            {
                this.radioGroup1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.radioGroup1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.radioGroup1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.radioGroup1.AccessibleDescription;
            }
            set
            {
                this.radioGroup1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.radioGroup1.EnterMoveNextControl;
            }
            set
            {
                this.radioGroup1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.radioGroup1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.radioGroup1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.radioGroup1_InvalidValue);
            this.radioGroup1.PropertiesChanged += new System.EventHandler(this.radioGroup1_PropertiesChanged);
            this.radioGroup1.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
            this.radioGroup1.Modified += new System.EventHandler(this.radioGroup1_Modified);
            this.radioGroup1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.radioGroup1_EditValueChanging);
            this.radioGroup1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.radioGroup1_ParseEditValue);
            this.radioGroup1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.radioGroup1_FormatEditValue);
            this.radioGroup1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.radioGroup1_CustomDisplayText);
            this.radioGroup1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.radioGroup1_QueryAccessibilityHelp);
            this.radioGroup1.ForeColorChanged += new System.EventHandler(this.radioGroup1_ForeColorChanged);
            this.radioGroup1.BackColorChanged += new System.EventHandler(this.radioGroup1_BackColorChanged);
            this.radioGroup1.FontChanged += new System.EventHandler(this.radioGroup1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(sender, e);
            }
        }

        private void radioGroup1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void radioGroup1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void radioGroup1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void radioGroup1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void radioGroup1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void radioGroup1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void radioGroup1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void radioGroup1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void radioGroup1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void radioGroup1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void radioGroup1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}