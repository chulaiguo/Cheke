using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Drawing;

namespace Cheke.WinCtrl.Common
{
    [ToolboxItem(false)]
    public partial class EditorBase : UserControlBase
    {
        private bool _isDirty = false;
        private bool _enableDirtyColor = false;
        private BaseEdit _innerEditor = null;

        private Orientation _orientation = Orientation.Vertical;

        public EditorBase()
        {
            InitializeComponent();
        }

        protected void AddEditor(BaseEdit editor)
        {
            if(this.panel1 == null || editor == null)
                return;

            this.panel1.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;
            editor.EditValueChanged += IsDirty_EditValueChanged;
            this._innerEditor = editor;
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (this.FixedHeight)
            {
                this.Height = this.InnerHeight;
            }
        }

        internal virtual void EnableTooltip(bool enable)
        {
        }

        internal bool IsDirty
        {
            get { return this._isDirty; }
            set
            {
                if(this._isDirty == value)
                    return;

                this._isDirty = value;
                if (this.panel1.Controls.Count > 0)
                {
                    this.panel1.Controls[0].BackColor = this._isDirty ? Color.LightYellow : Color.Empty;
                }
            }
        }

        internal bool EnableDirtyColor
        {
            get { return this._enableDirtyColor; }
            set { this._enableDirtyColor = value; }
        }

        private void IsDirty_EditValueChanged(object sender, EventArgs e)
        {
            if (this.DesignMode || !this.EnableDirtyColor)
                return;

            BaseEdit edit = sender as BaseEdit;
            if (edit == null || edit.Tag != null)
                return;

            if (!edit.Visible || edit.Properties.ReadOnly || !edit.Enabled)
                return;

            this.IsDirty = true;
        }

        protected override int InnerHeight
        {
            get
            {
                if (this.TitleVisible && this.Orientation == Orientation.Vertical)
                {
                    return this.TitleHeight + this.EditorHeight + this.Padding.Top + this.Padding.Bottom;
                }
                
                return this.EditorHeight + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected virtual int EditorHeight
        {
            get { return 20; }
        }

        protected internal int TitleHeight
        {
            get { return this.label1 == null ? 13 : this.label1.Height; }
        }

        [Browsable(false)]
        public virtual bool ReadOnly
        {
            get
            {
                RepositoryItem repositoryItem = this.GetProperties();
                if (repositoryItem != null)
                {
                    return repositoryItem.ReadOnly;
                }

                return false;
            }
            set
            {
                RepositoryItem repositoryItem = this.GetProperties();
                if (repositoryItem != null)
                {
                    repositoryItem.ReadOnly = value;
                }
            }
        }
        
        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue("Title")]
        [RefreshProperties(RefreshProperties.All)]
        public virtual string Title
        {
            get
            {
                if (this.label1 == null)
                    return "Title";

                return this.label1.Text;
            }
            set
            {
                if(this.label1 == null)
                    return;

                this.label1.Text = value;
                this.TitleVisible = this.label1.Text.Length > 0;
            }
        }

        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue(150)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int EditWidth
        {
            get
            {
                if (this.panel1 == null)
                    return 150;

                return this.panel1.Width;
            }
            set
            {
                if(this.panel1 == null)
                    return;

                this.Width += value - this.panel1.Width;
            }
        }

        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool TitleVisible
        {
            get
            {
                if(this.label1 == null)
                    return true;

                return this.label1.Visible;
            }
            set
            {
                if(this.label1 == null)
                    return;

                if (this.label1.Visible != value)
                {
                    if(value)
                    {
                        if(this.label1.Text.Length == 0)
                        {
                            this.label1.Text = "Title";
                        }
                    }
                    else
                    {
                        this.label1.Text = string.Empty;
                    }
                }

                this.SetControlSize(this._orientation, value);
            }
        }

        [Category("Cheke")]
        [Browsable(true)]
        [DefaultValue(Orientation.Vertical)]
        public virtual Orientation Orientation
        {
            get { return this._orientation; }
            set
            {
                if (this._orientation != value)
                {
                    this.SetControlSize(value, this.TitleVisible);
                }
            }
        }

        public BaseEdit InnerEditor
        {
            get { return _innerEditor; }
        }

        public RepositoryItem GetProperties()
        {
            if (this.panel1 == null || this.panel1.Controls.Count == 0)
                return null;

            BaseEdit edit = this.panel1.Controls[0] as BaseEdit;
            if (edit == null)
                return null;

            return edit.Properties;
        }

        public virtual void BindingData(object obj, string dataMember)
        {
        }

        public virtual void RefreshDataBinding()
        {
        }

        private void SetControlSize(Orientation orientation, bool titleVisible)
        {
            if (this.panel1 == null || this.label1 == null)
                return;

            int labelWidth = titleVisible ? this.label1.Width : 0;
            int labelHeight = titleVisible ? this.label1.Height : 0;
            int panelWidth = this.panel1.Width;
            int panelHeight = this.panel1.Height;

            this._orientation = orientation;
            this.label1.Visible = titleVisible;
            switch (orientation)
            {
                case Orientation.Vertical:
                    this.label1.Dock = DockStyle.Top;
                    if (this.FixedHeight)
                    {
                        this.Height = labelHeight + panelHeight;
                    }
                    this.Width = panelWidth;
                    break;
                case Orientation.Horizontal:
                    this.label1.Dock = DockStyle.Left;
                    if (this.FixedHeight)
                    {
                        this.Height = panelHeight;
                    }
                    this.Width = labelWidth + panelWidth;
                    break;
                default:
                    break;
            }
        }
    }
}