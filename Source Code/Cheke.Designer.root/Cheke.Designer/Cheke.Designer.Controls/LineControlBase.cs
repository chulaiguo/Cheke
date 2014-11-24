using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cheke.Designer.Controls
{
    [ToolboxBitmap(typeof (LineControlBase), "Resources.LineControlBase.bmp")]
    public class LineControlBase : ToolboxControlBase
    {
        #region Variables
        private LineCap _endCap = LineCap.Flat;
        private bool _isVerticalLine = false;
        private Color _lineColor = Color.Black;
        private DashStyle _lineStyle = DashStyle.Solid;
        private LineCap _startCap = LineCap.Flat;
        #endregion

        #region Constructor
        public LineControlBase()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.Size = new Size(180, 3);
        }
        #endregion

        #region Properties
        [Browsable(true)]
        [Category("Appearance")]
        public Color LineColor
        {
            get { return this._lineColor; }
            set
            {
                this._lineColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(3)]
        public int LineWidth
        {
            get { return this.IsVerticalLine ? this.Width : this.Height;}
            set
            {
                if (this.IsVerticalLine)
                {
                    this.Width = value;
                }
                else
                {
                    this.Height = value;
                }

                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(DashStyle.Solid)]
        public DashStyle LineStyle
        {
            get { return _lineStyle; }
            set
            {
                _lineStyle = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(LineCap.Flat)]
        public LineCap StartCap
        {
            get { return _startCap; }
            set
            {
                _startCap = value;
                this.Refresh();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(LineCap.Flat)]
        public LineCap EndCap
        {
            get { return _endCap; }
            set
            {
                _endCap = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsVerticalLine
        {
            get { return _isVerticalLine; }
            set
            {
                if (this._isVerticalLine != value)
                {
                    this._isVerticalLine = value;
                    this.SwitchWidthHeight();

                    this.Invalidate();
                }
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        #endregion

        #region Method
        public override void PaintToDC(Graphics g, RectangleF rect)
        {
            using (Pen pen = new Pen(this.LineColor))
            {
                if (this.LineStyle == DashStyle.Custom)
                {
                    pen.DashStyle = DashStyle.Solid;
                }
                else
                {
                    pen.DashStyle = this.LineStyle;
                }

                pen.StartCap = this.StartCap;
                pen.EndCap = this.EndCap;
                if (this.IsVerticalLine)
                {
                    pen.Width = rect.Width;
                    g.DrawLine(pen, rect.Left + rect.Width / 2, rect.Top, rect.Left + rect.Width / 2, rect.Top + rect.Height);
                }
                else
                {
                    pen.Width = rect.Height;
                    g.DrawLine(pen, rect.Left, rect.Top + rect.Height / 2, rect.Left + rect.Width, rect.Top + rect.Height / 2);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintToDC(e.Graphics, this.ClientRectangle);
            base.OnPaint(e);
        }
        #endregion
    }
}