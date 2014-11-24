using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Cheke.Designer.Controls
{
    [ToolboxItem(true)]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(ShapeControlBase), "Resources.ShapeControlBase.bmp")]
    public class ShapeControlBase : ToolboxControlBase
    {
        #region Variables
        private ShapeType _shape = ShapeType.Rectangle;

        private DashStyle _borderDashStyle = DashStyle.Solid;
        private Color _borderColor = Color.FromArgb(255, 255, 0, 0);
        private int _borderWidth = 3;

        private bool _useGradient = true;
        private Color _centerColor = Color.FromArgb(100, 255, 0, 0);
        private Color _surroundColor = Color.FromArgb(100, 0, 255, 255);

        #endregion

        #region Constructor
        public ShapeControlBase()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            //Using of Double Buffer allow for smooth rendering 
            //minizing flickering
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);

            //set the default backcolor and font
            this.BackColor = Color.FromArgb(0, 255, 255, 255);
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            
            this.Size = new Size(80, 80);
        }
        #endregion

        #region Properties
        [Browsable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Back Color")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Fore Color")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Font")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Border Style")]
        [DefaultValue(DashStyle.Solid)]
        public DashStyle BorderDashStyle
        {
            get { return _borderDashStyle; }
            set
            {
                _borderDashStyle = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Border Color")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Border Width")]
        [DefaultValue(3)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                this._borderWidth = value;

                if (this._borderWidth < 0)
                    this._borderWidth = 0;

                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Using Gradient to fill Shape")]
        [DefaultValue(true)]
        public bool UseGradient
        {
            get { return _useGradient; }
            set
            {
                _useGradient = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Color at center")]
        public Color CenterColor
        {
            get { return _centerColor; }
            set
            {
                _centerColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Color at the edges of the Shape")]
        public Color SurroundColor
        {
            get { return _surroundColor; }
            set
            {
                _surroundColor = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Appearance"), Description("Select Shape")]
        [DefaultValue(ShapeType.Rectangle)]
        public ShapeType Shape
        {
            get { return _shape; }
            set
            {
                _shape = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Method
        private GraphicsPath CreateGraphicsPath(ShapeType shape, Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            switch (shape)
            {
                //case ShapeType.CustomPie:
                //    path.AddPie(0, 0, width, height, 180, 270);
                //    break;
                case ShapeType.CustomPolygon:
                    path.AddPolygon(new Point[]
                                        {
                                            new Point(rect.Left, rect.Top),
                                            new Point(rect.Left + rect.Width/2, rect.Top + rect.Height/4),
                                            new Point(rect.Left + rect.Width, rect.Top),
                                            new Point(rect.Left + (rect.Width*3)/4, rect.Top + rect.Height/2),
                                            new Point(rect.Left + rect.Width, rect.Top + rect.Height),
                                            new Point(rect.Left + rect.Width/2, rect.Top + (rect.Height*3)/4),
                                            new Point(rect.Left, rect.Top + rect.Height),
                                            new Point(rect.Left + rect.Width/4, rect.Top + rect.Height/2)
                                        }
                        );
                    break;
                case ShapeType.Diamond:
                    path.AddPolygon(new Point[]
                                        {
                                            new Point(rect.Left, rect.Top + rect.Height/2),
                                            new Point(rect.Left + rect.Width/2, rect.Top),
                                            new Point(rect.Left + rect.Width, rect.Top + rect.Height/2),
                                            new Point(rect.Left + rect.Width/2, rect.Top + rect.Height)
                                        });
                    break;

                case ShapeType.Rectangle:
                    path.AddRectangle(new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height));
                    break;

                case ShapeType.Ellipse:
                    path.AddEllipse(rect.Left, rect.Top, rect.Width, rect.Height);
                    break;

                case ShapeType.TriangleUp:
                    path.AddPolygon(new Point[] { new Point(rect.Left, rect.Top + rect.Height), new Point(rect.Left + rect.Width, rect.Top + rect.Height), new Point(rect.Left + rect.Width / 2, rect.Top) });
                    break;

                case ShapeType.TriangleDown:
                    path.AddPolygon(new Point[] { new Point(rect.Left, rect.Top), new Point(rect.Left + rect.Width, rect.Top), new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height) });
                    break;

                case ShapeType.TriangleLeft:
                    path.AddPolygon(new Point[] { new Point(rect.Left + rect.Width, rect.Top), new Point(rect.Left, rect.Top + rect.Height / 2), new Point(rect.Left + rect.Width, rect.Top + rect.Height) });
                    break;

                case ShapeType.TriangleRight:
                    path.AddPolygon(new Point[] { new Point(rect.Left, rect.Top), new Point(rect.Left + rect.Width, rect.Top + rect.Height / 2), new Point(rect.Left, rect.Top + rect.Height) });
                    break;
                default:
                    path.AddRectangle(new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height));
                    break;
            }

            return path;
        }

        public override void PaintToDC(Graphics g, RectangleF rect)
        {
            float borderWidth = GetPixelWidth(g, this.BorderWidth);
            Font font = GetPixelFont(g, this.Font);
            rect = new RectangleF(rect.Left + borderWidth, rect.Top + borderWidth, rect.Width - borderWidth * 2, rect.Height - borderWidth * 2);

            GraphicsPath path = this.CreateGraphicsPath(this.Shape, new Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height));

            //Rendering with Gradient
            if (this.UseGradient)
            {
                PathGradientBrush br = new PathGradientBrush(path);
                br.CenterColor = this.CenterColor;
                br.SurroundColors = new Color[] {this.SurroundColor};
                g.FillPath(br, path);
            }

            //Rendering with Border
            if (borderWidth > 0)
            {
                Pen p = new Pen(this.BorderColor, borderWidth * 2);
                p.DashStyle = this.BorderDashStyle;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawPath(p, path);
                p.Dispose();
            }

            //Rendering the text to be at the center of the shape
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.DrawString(this.Text, font, new SolidBrush(this.ForeColor), rect, sf);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintToDC(e.Graphics, this.ClientRectangle);
            base.OnPaint(e);
        }
        #endregion
    }

    public enum ShapeType
    {
        Rectangle,
        Diamond,
        Ellipse,
        TriangleUp,
        TriangleDown,
        TriangleLeft,
        TriangleRight,
        CustomPolygon,
        //CustomPie
    }
}