using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Cheke.Designer.Controls
{
    [ToolboxBitmap(typeof (Label))]
    public class TextControlBase : ToolboxControlBase
    {
        #region Variables
        private string _text;
        private bool _isVertical = false;
        private bool _hasBorder = false;
        private Color _borderColor = Color.Black;
        private int _borderWidth = 1;
        private HorizontalAlignment _align = HorizontalAlignment.Center;
        #endregion

        #region Constructor
        public TextControlBase()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            this.Size = new Size(105, 12);
        }
        #endregion

        #region Properties

        [Browsable(true)]
        [Description("Display Text"), Category("Appearance")]
        public override string Text
        {
            get { return this._text; }
            set
            {
                this._text = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [DisplayName("Vertical")]
        public bool IsVertical
        {
            get { return this._isVertical; }
            set
            {
                if (this._isVertical != value)
                {
                    this._isVertical = value;
                    if (value)
                    {
                        if (this.Width > this.Height)
                        {
                            this.SwitchWidthHeight();
                        }
                    }
                    else
                    {
                        if (this.Width < this.Height)
                        {
                            this.SwitchWidthHeight();
                        }
                    }

                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        [DisplayName("Border")]
        public bool HasBorder
        {
            get { return this._hasBorder; }
            set
            {
                if (this._hasBorder != value)
                {
                    this._hasBorder = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return this._borderColor; }
            set
            {
                if (this._borderColor != value)
                {
                    this._borderColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get { return this._borderWidth; }
            set
            {
                if (this._borderWidth != value)
                {
                    this._borderWidth = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public HorizontalAlignment Align
        {
            get { return this._align; }
            set
            {
                if (this._align != value)
                {
                    this._align = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Method
        public override void PaintToDC(Graphics g, RectangleF rect)
        {
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            //draw background
            SolidBrush backBrush = new SolidBrush(this.BackColor);
            g.FillRectangle(backBrush, rect);

            //draw frame
            float borderWidth = 0;
            if (this.HasBorder)
            {
                borderWidth = GetPixelWidth(g, this.BorderWidth);
            }
            if (borderWidth > 0)
            {
                Pen pen = new Pen(this.BorderColor, borderWidth);
                pen.DashStyle = DashStyle.Solid;
                float pading = borderWidth / 2.0F;
                if(pading < 1)
                {
                    g.DrawRectangle(pen, rect.Left, rect.Top, rect.Width-1, rect.Height-1);
                }
                else
                {
                    g.DrawRectangle(pen, rect.Left + pading, rect.Top + pading, rect.Width - pading*2, rect.Height - pading*2);
                }

                rect = new RectangleF(rect.Left + borderWidth, rect.Top + borderWidth, rect.Width - borderWidth * 2, rect.Height - borderWidth * 2);
            }
            
            //draw text
            Font font = GetPixelFont(g, this.Font);
            Brush foreBrush = new SolidBrush(this.ForeColor);

            StringFormat sf = new StringFormat();
            switch (this.Align)
            {
                case HorizontalAlignment.Left:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case HorizontalAlignment.Right:
                    sf.Alignment = StringAlignment.Far;
                    break;
                default:
                    sf.Alignment = StringAlignment.Center;
                    break;
            }
            sf.LineAlignment = StringAlignment.Center;
            if (this.IsVertical)
            {
                sf.FormatFlags = StringFormatFlags.DirectionVertical;
            }
            g.DrawString(this._text, font, foreBrush, rect, sf);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintToDC(e.Graphics, this.ClientRectangle);
        }
        #endregion
    }
}