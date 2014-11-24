using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cheke.Designer.Controls
{
    public enum RotateAngleType
    {
        Degree_0 = 0,
        Degree_90 = 1,
        Degree_180 = 2,
        Degree_270 = 3
    }

    [ToolboxBitmap(typeof(PictureBox))]
    public class PictureControlBase : ToolboxControlBase
    {
        #region Variables
        private Image _image = null;
        private RotateAngleType _rotateType = RotateAngleType.Degree_0;
        private bool _hasBorder = false;
        private Color _borderColor = Color.Red;
        private int _borderWidth = 4;
        #endregion

        #region Constructor
        public PictureControlBase()
        {
            this.Size = new Size(100, 120);
            this._image = Cheke.Designer.Controls.Properties.Resources.DefaultImage;
        }
        #endregion

        #region Properties

        [Browsable(true)]
        [Description("Image"), Category("Appearance")]
        public Image Picture
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Description("Rotation Angle"), Category("Appearance")]
        [DefaultValue(RotateAngleType.Degree_0)]
        [DisplayName("Rotate")]
        public RotateAngleType RotateType
        {
            get { return _rotateType; }
            set
            {
                _rotateType = value;
                if (_rotateType == RotateAngleType.Degree_90 || _rotateType == RotateAngleType.Degree_270)
                {
                    if (this.Width < this.Height)
                    {
                        this.SwitchWidthHeight();
                    }
                }
                if (_rotateType == RotateAngleType.Degree_0 || _rotateType == RotateAngleType.Degree_180)
                {
                    if (this.Width > this.Height)
                    {
                        this.SwitchWidthHeight();
                    }
                }
                this.Invalidate();
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
                if(this._borderColor != value)
                {
                    this._borderColor = value;
                    this.Invalidate();
                }
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(4)]
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

        #endregion

        #region Method
        public override void PaintToDC(Graphics g, RectangleF rect)
        {
            if (this.Picture == null)
                return;

            Image cloneImage = this.Picture.Clone() as Image;
            if (cloneImage == null)
                return;

            float borderWidth = 0;
            if (this.HasBorder)
            {
                borderWidth = GetPixelWidth(g, this.BorderWidth);
            }
            if (borderWidth > 0)
            {
                rect = new RectangleF(rect.Left + borderWidth, rect.Top + borderWidth, rect.Width - borderWidth * 2, rect.Height - borderWidth * 2);
            }
            
            cloneImage.RotateFlip((RotateFlipType) this.RotateType);

            float left;
            float top;
            float width;
            float height;
            if (cloneImage.Width / rect.Width >= cloneImage.Height / rect.Height)
            {
                width = rect.Width;
                height = cloneImage.Height*width/cloneImage.Width;

                left = rect.Left;
                top = rect.Top + (rect.Height - height)/2;
            }
            else
            {
                height = rect.Height;
                width = cloneImage.Width * height / cloneImage.Height;

                left = rect.Left + (rect.Width - width) / 2;
                top = rect.Top;
            }
            g.DrawImage(cloneImage, new RectangleF(left, top, width, height));

            if (borderWidth > 0)
            {
                this.DrawBorder(g, borderWidth, left, top, width, height);
            }
        }

        private void DrawBorder(Graphics g, float borderWidth, float left, float top, float width, float height)
        {
            Pen pen = new Pen(this.BorderColor, borderWidth);
            pen.DashStyle = DashStyle.Solid;
            pen.LineJoin = LineJoin.Round;
            float pading = borderWidth/2;
            g.DrawRectangle(pen, left - pading, top - pading, width + pading, height + pading);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.PaintToDC(e.Graphics, this.ClientRectangle);
            base.OnPaint(e);
        }
        #endregion
    }
}