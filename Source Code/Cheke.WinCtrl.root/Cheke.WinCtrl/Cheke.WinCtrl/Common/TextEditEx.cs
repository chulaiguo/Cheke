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
using DevExpress.Utils;
using Cheke.WinCtrl.Utils;
using DevExpress.XtraEditors.Mask;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(true)]
    [DefaultEvent("EditValueChanged")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(TextEdit))]
    public partial class TextEditEx : EditorBase
    {
        private string _customizeTooltip = string.Empty;

        private TextEdit textEdit1;
        private ToolTipController tooltipCtrl;
        private bool _selectAllTag = false;

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

        public TextEditEx()
        {
            this.textEdit1 = new TextEdit();
            this.tooltipCtrl = new ToolTipController();
            this.tooltipCtrl.InitialDelay = 0;
            this.textEdit1.ToolTipController = tooltipCtrl;
            this.textEdit1.EditValueChanged += textEdit_EditValueChanged;
            this.textEdit1.MouseUp += textEdit1_MouseUp;
            this.textEdit1.GotFocus += textEdit1_GotFocus;
            this.textEdit1.Click += textEdit1_Click;
            base.AddEditor(this.textEdit1);
            this.RegisterEvents();

            InitializeComponent();
        }

        private void textEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this._selectAllTag)
            {
                this.textEdit1.SelectAll();
            }

            this._selectAllTag = false;
        }

        private void textEdit1_GotFocus(object sender, EventArgs e)
        {
            this._selectAllTag = true;
            this.textEdit1.SelectAll();
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            if (this.Properties.Mask.MaskType != MaskType.None)
            {
                this.textEdit1.SelectAll();
            }
        }

        protected override int EditorHeight
        {
            get { return this.textEdit1 == null ? base.EditorHeight : this.textEdit1.Height; }
        }

        protected override bool FixedHeight
        {
            get { return true; }
        }

        public override void BindingData(object obj, string dataMember)
        {
            this.DataBindings.Clear();
            this.DataBindings.Add("EditValue", obj, dataMember);

            if (this.Properties.Mask.MaskType == MaskType.None)
            {
                if (FormMainBase.Instance != null && FormMainBase.Instance.ShowEditorTooltip)
                {
                    this._customizeTooltip = FormUtil.GetCustomizeRules(obj, dataMember);
                }
            }
        }

        public override void RefreshDataBinding()
        {
            if (this.DataBindings.Count == 0)
                return;

            this.DataBindings[0].ReadValue();
        }

        internal override void EnableTooltip(bool enable)
        {
            if(enable)
            {
                this.textEdit1.ToolTip = this._customizeTooltip;
            }
            else
            {
                this.textEdit1.ToolTip = string.Empty;
                this.tooltipCtrl.HideHint();
            }
        }

        private void textEdit_EditValueChanged(object sender, EventArgs e)
        {
            if(this.DesignMode)
                return;

            if(!this.textEdit1.Visible || this.textEdit1.Properties.ReadOnly || !this.textEdit1.Enabled)
                return;

            if (FormMainBase.Instance == null || this.Parent == null || !FormMainBase.Instance.ShowEditorTooltip
                || this._customizeTooltip.Length == 0)
                return;

            string tip = string.Empty;
            if (this.textEdit1.Properties.Mask.MaskType == MaskType.None)
            {
                tip = string.Format("You typed {0} character(s) for {1}. {2}", this.textEdit1.Text.Length,
                                           this.Title, Environment.NewLine);
            }
                
            tip += this._customizeTooltip;
            this.tooltipCtrl.ShowHint(tip, this.Parent.PointToScreen(new Point(this.Left, this.Bottom)));
        }

        #region Property Members

        public new Color BackColor
        {
            get
            {
                return this.textEdit1.BackColor;
            }
            set
            {
                this.textEdit1.BackColor = value;
            }
        }

        [Description("Gets or sets a value indicating whether the user can focus this control using the TAB key.")]
        [Category("Behavior")]
        [DefaultValue(true)]
        public new Boolean TabStop
        {
            get
            {
                return this.textEdit1.TabStop;
            }
            set
            {
                this.textEdit1.TabStop = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextBoxMaskBox MaskBox
        {
            get
            {
                return this.textEdit1.MaskBox;
            }
        }

        public Boolean IsEditorActive
        {
            get
            {
                return this.textEdit1.IsEditorActive;
            }
        }

        [Browsable(false)]
        public Boolean IsNeedFocus
        {
            get
            {
                return this.textEdit1.IsNeedFocus;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Gets an object containing this editor's settings.")]
        [Category("Properties")]
        public RepositoryItemTextEdit Properties
        {
            get
            {
                return this.textEdit1.Properties;
            }
        }

        [Browsable(false)]
        public String EditorTypeName
        {
            get
            {
                return this.textEdit1.EditorTypeName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Int32 SelectionStart
        {
            get
            {
                return this.textEdit1.SelectionStart;
            }
            set
            {
                this.textEdit1.SelectionStart = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Int32 SelectionLength
        {
            get
            {
                return this.textEdit1.SelectionLength;
            }
            set
            {
                this.textEdit1.SelectionLength = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SelectedText
        {
            get
            {
                return this.textEdit1.SelectedText;
            }
            set
            {
                this.textEdit1.SelectedText = value;
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
                return this.textEdit1.Text;
            }
            set
            {
                this.textEdit1.Text = value;
            }
        }

        [Browsable(false)]
        public Boolean CanUndo
        {
            get
            {
                return this.textEdit1.CanUndo;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get
            {
                return this.textEdit1.BackgroundImage;
            }
            set
            {
                this.textEdit1.BackgroundImage = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImageLayout BackgroundImageLayout
        {
            get
            {
                return this.textEdit1.BackgroundImageLayout;
            }
            set
            {
                this.textEdit1.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding
        {
            get
            {
                return this.textEdit1.Padding;
            }
            set
            {
                this.textEdit1.Padding = value;
            }
        }

        [DefaultValue(null)]
        [Description("Gets or sets an object that controls the look and feel of the popup menus.")]
        [Category("BarManager")]
        public IDXMenuManager MenuManager
        {
            get
            {
                return this.textEdit1.MenuManager;
            }
            set
            {
                this.textEdit1.MenuManager = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ErrorText
        {
            get
            {
                return this.textEdit1.ErrorText;
            }
            set
            {
                this.textEdit1.ErrorText = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.textEdit1.ErrorIconAlignment;
            }
            set
            {
                this.textEdit1.ErrorIconAlignment = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image ErrorIcon
        {
            get
            {
                return this.textEdit1.ErrorIcon;
            }
            set
            {
                this.textEdit1.ErrorIcon = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IPopupServiceControl ServiceObject
        {
            get
            {
                return this.textEdit1.ServiceObject;
            }
            set
            {
                this.textEdit1.ServiceObject = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InplaceType InplaceType
        {
            get
            {
                return this.textEdit1.InplaceType;
            }
            set
            {
                this.textEdit1.InplaceType = value;
            }
        }

        [Browsable(false)]
        public Boolean IsLoading
        {
            get
            {
                return this.textEdit1.IsLoading;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Boolean IsModified
        {
            get
            {
                return this.textEdit1.IsModified;
            }
            set
            {
                this.textEdit1.IsModified = value;
            }
        }

        [Browsable(false)]
        public Object OldEditValue
        {
            get
            {
                return this.textEdit1.OldEditValue;
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
                return this.textEdit1.EditValue;
            }
            set
            {
                this.textEdit1.EditValue = value;
            }
        }

        [Browsable(false)]
        public Boolean EditorContainsFocus
        {
            get
            {
                return this.textEdit1.EditorContainsFocus;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public BindingManagerBase BindingManager
        {
            get
            {
                return this.textEdit1.BindingManager;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.textEdit1.LookAndFeel;
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
                return this.textEdit1.BorderStyle;
            }
            set
            {
                this.textEdit1.BorderStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Appearance")]
        [Description("Gets or sets the editor content's foreground color.")]
        public new Color ForeColor
        {
            get
            {
                return this.textEdit1.ForeColor;
            }
            set
            {
                this.textEdit1.ForeColor = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets the font used to display editor contents.")]
        public new Font Font
        {
            get
            {
                return this.textEdit1.Font;
            }
            set
            {
                this.textEdit1.Font = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenu ContextMenu
        {
            get
            {
                return this.textEdit1.ContextMenu;
            }
            set
            {
                this.textEdit1.ContextMenu = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.textEdit1.ContextMenuStrip;
            }
            set
            {
                this.textEdit1.ContextMenuStrip = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String AccessibleName
        {
            get
            {
                return this.textEdit1.AccessibleName;
            }
            set
            {
                this.textEdit1.AccessibleName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get
            {
                return this.textEdit1.AccessibleRole;
            }
            set
            {
                this.textEdit1.AccessibleRole = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new String AccessibleDefaultActionDescription
        {
            get
            {
                return this.textEdit1.AccessibleDefaultActionDescription;
            }
            set
            {
                this.textEdit1.AccessibleDefaultActionDescription = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new String AccessibleDescription
        {
            get
            {
                return this.textEdit1.AccessibleDescription;
            }
            set
            {
                this.textEdit1.AccessibleDescription = value;
            }
        }

        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("")]
        public Boolean EnterMoveNextControl
        {
            get
            {
                return this.textEdit1.EnterMoveNextControl;
            }
            set
            {
                this.textEdit1.EnterMoveNextControl = value;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean CanShowDialog
        {
            get
            {
                return this.textEdit1.CanShowDialog;
            }
        }

        #endregion

        #region Register Event

        private void RegisterEvents()
        {
            this.textEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.textEdit1_Spin);
            this.textEdit1.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.textEdit1_InvalidValue);
            this.textEdit1.PropertiesChanged += new System.EventHandler(this.textEdit1_PropertiesChanged);
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            this.textEdit1.Modified += new System.EventHandler(this.textEdit1_Modified);
            this.textEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.textEdit1_EditValueChanging);
            this.textEdit1.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.textEdit1_ParseEditValue);
            this.textEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.textEdit1_FormatEditValue);
            this.textEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.textEdit1_CustomDisplayText);
            this.textEdit1.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.textEdit1_QueryAccessibilityHelp);
            this.textEdit1.ForeColorChanged += new System.EventHandler(this.textEdit1_ForeColorChanged);
            this.textEdit1.BackColorChanged += new System.EventHandler(this.textEdit1_BackColorChanged);
            this.textEdit1.FontChanged += new System.EventHandler(this.textEdit1_FontChanged);
        }
        #endregion

        #region Event Methods

        private void textEdit1_Spin(object sender, SpinEventArgs e)
        {
            if (this.Spin != null)
            {
                this.Spin(sender, e);
            }
        }

        private void textEdit1_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (this.InvalidValue != null)
            {
                this.InvalidValue(sender, e);
            }
        }

        private void textEdit1_PropertiesChanged(object sender, EventArgs e)
        {
            if (this.PropertiesChanged != null)
            {
                this.PropertiesChanged(sender, e);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.EditValueChanged != null)
            {
                this.EditValueChanged(sender, e);
            }
        }

        private void textEdit1_Modified(object sender, EventArgs e)
        {
            if (this.Modified != null)
            {
                this.Modified(sender, e);
            }
        }

        private void textEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (this.EditValueChanging != null)
            {
                this.EditValueChanging(sender, e);
            }
        }

        private void textEdit1_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.ParseEditValue != null)
            {
                this.ParseEditValue(sender, e);
            }
        }

        private void textEdit1_FormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (this.FormatEditValue != null)
            {
                this.FormatEditValue(sender, e);
            }
        }

        private void textEdit1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.CustomDisplayText != null)
            {
                this.CustomDisplayText(sender, e);
            }
        }

        private void textEdit1_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {
            if (this.QueryAccessibilityHelp != null)
            {
                this.QueryAccessibilityHelp(sender, e);
            }
        }

        private void textEdit1_ForeColorChanged(object sender, EventArgs e)
        {
            if (this.ForeColorChanged != null)
            {
                this.ForeColorChanged(sender, e);
            }
        }

        private void textEdit1_BackColorChanged(object sender, EventArgs e)
        {
            if (this.BackColorChanged != null)
            {
                this.BackColorChanged(sender, e);
            }
        }

        private void textEdit1_FontChanged(object sender, EventArgs e)
        {
            if (this.FontChanged != null)
            {
                this.FontChanged(sender, e);
            }
        }

        #endregion
    }
}