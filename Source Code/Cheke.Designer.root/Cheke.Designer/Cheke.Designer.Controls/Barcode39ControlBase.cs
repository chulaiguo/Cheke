using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Cheke.Designer.Controls
{
    public enum AlignType
    {
        Left, Center, Right
    }

    public enum BarCodeWeight
    {
        Small = 1, Medium, Large
    }

    [ToolboxBitmap(typeof(Barcode39ControlBase), "Resources.Barcode39ControlBase.bmp")]
    public class Barcode39ControlBase : ToolboxControlBase
    {
        #region Variables
        private string _code = "12345678";
        private int _leftMargin = 10;
        private int _topMargin = 10;
        private int _barCodeHeight = 30;
        private bool _showHeader = false;
        private bool _showFooter = true;
        private string _headerText = "Header Text";
        private AlignType _vertAlign = AlignType.Center;
        private BarCodeWeight _weight = BarCodeWeight.Small;
        private Font _headerFont = new Font("Courier", 18);
        private Font _footerFont = new Font("Courier", 8);
        private bool _isVertical = false;
        #endregion

        #region Constructor
        public Barcode39ControlBase()
        {
            this.Size = new Size(180, 55);
        }
        #endregion

        #region Properties
        
        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(AlignType.Center)]
        public AlignType VertAlign
        {
            get { return _vertAlign; }
            set { _vertAlign = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public string BarCode
        {
            get { return _code; }
            set { _code = value.ToUpper(); this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(30)]
        public int BarCodeHeight
        {
            get { return _barCodeHeight; }
            set { _barCodeHeight = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(10)]
        public int LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(10)]
        public int TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool ShowHeader
        {
            get { return _showHeader; }
            set { _showHeader = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowFooter
        {
            get { return _showFooter; }
            set { _showFooter = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [DefaultValue("Header Text")]
        public string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; this.Invalidate(); }
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
        [DefaultValue(BarCodeWeight.Small)]
        public BarCodeWeight Weight
        {
            get { return _weight; }
            set { _weight = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Font HeaderFont
        {
            get { return _headerFont; }
            set { _headerFont = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [Category("Appearance")]
        public Font FooterFont
        {
            get { return _footerFont; }
            set { _footerFont = value; this.Invalidate(); }
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
            GraphicsState state = null;
            if (this._isVertical)
            {
                g.SetClip(rect);
                state = g.Save();
                Matrix RotationTransform = new Matrix(1, 0, 0, 1, 1, 1); //rotation matrix

                PointF TheRotationPoint = new PointF(rect.X, rect.Y);
                RotationTransform.RotateAt(90, TheRotationPoint);
                g.Transform = RotationTransform;

                if (this.VertAlign == AlignType.Left)
                {
                    g.TranslateTransform(0, -rect.Width);
                }
                else if (this.VertAlign == AlignType.Center)
                {
                    g.TranslateTransform((rect.Height - rect.Width)/2, -rect.Width);
                }
                else
                {
                    g.TranslateTransform(rect.Height - rect.Width, -rect.Width);
                }
            }

            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            Font font = GetPixelFont(g, this.Font);
            Font headerFont = GetPixelFont(g, this.HeaderFont);
            Font footerFont = GetPixelFont(g, this.FooterFont);
            int leftMargin = (int)GetPixelWidth(g, this.LeftMargin);
            int topMargin = (int)GetPixelHeight(g, this.TopMargin);
            int height = (int)GetPixelHeight(g, this.BarCodeHeight);
            int weight = (int)GetPixelWidth(g, (int)this.Weight);

            const string intercharacterGap = "0";
            string str = '*' + _code.ToUpper() + '*';
            int strLength = str.Length;
            for (int i = 0; i < _code.Length; i++)
            {
                if (alphabet39.IndexOf(_code[i]) == -1 || _code[i] == '*')
                {
                    g.DrawString("INVALID BAR CODE TEXT", font, Brushes.Red, rect.Left, rect.Top);
                    return;
                }
            }

            string encodedString = "";
            for (int i = 0; i < strLength; i++)
            {
                if (i > 0)
                    encodedString += intercharacterGap;

                encodedString += coded39Char[alphabet39.IndexOf(str[i])];
            }

            int encodedStringLength = encodedString.Length;
            int widthOfBarCodeString = 0;
            const double wideToNarrowRatio = 3;
            if (this.VertAlign != AlignType.Left)
            {
                for (int i = 0; i < encodedStringLength; i++)
                {
                    if (encodedString[i] == '1')
                        widthOfBarCodeString += (int)(wideToNarrowRatio * weight);
                    else
                        widthOfBarCodeString += weight;
                }
            }

            int x;
            int yTop;
            SizeF hSize = g.MeasureString(_headerText, headerFont);
            SizeF fSize = g.MeasureString(_code, footerFont);

            int headerX;
            int footerX;
            if (this.VertAlign == AlignType.Left)
            {
                x = leftMargin;
                headerX = leftMargin;
                footerX = leftMargin;
            }
            else if (this.VertAlign == AlignType.Center)
            {
                x = (int)((rect.Width - widthOfBarCodeString) / 2);
                headerX = (int)((rect.Width - hSize.Width) / 2);
                footerX = (int)((rect.Width - fSize.Width) / 2);
            }
            else
            {
                x = Width - widthOfBarCodeString - leftMargin;
                headerX = (int)(rect.Width - hSize.Width - leftMargin);
                footerX = (int)(rect.Width - fSize.Width - leftMargin);
            }

            if (this.ShowHeader)
            {
                yTop = (int)hSize.Height + topMargin;
                g.DrawString(this.HeaderText, headerFont, Brushes.Black, rect.Left + headerX, rect.Top + topMargin);
            }
            else
            {
                yTop = topMargin;
            }

            int wid;
            for (int i = 0; i < encodedStringLength; i++)
            {
                if (encodedString[i] == '1')
                    wid = (int)(wideToNarrowRatio * weight);
                else
                    wid = weight;

                g.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, rect.Left + x,  rect.Top + yTop, wid, height);

                x += wid;
            }

            yTop += height;
            if (this.ShowFooter)
            {
                g.DrawString(this.BarCode, footerFont, Brushes.Black, rect.Left + footerX, rect.Top + yTop);
            }

            if (this._isVertical)
            {
                if (state != null)
                {
                    g.Restore(state);
                }
                g.ResetClip();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.PaintToDC(e.Graphics, this.ClientRectangle);
            base.OnPaint(e);
        }
        #endregion

        #region Const Variables
        private const string alphabet39 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";
        private string[] coded39Char = 
		{
			/* 0 */ "000110100", 
			/* 1 */ "100100001", 
			/* 2 */ "001100001", 
			/* 3 */ "101100000",
			/* 4 */ "000110001", 
			/* 5 */ "100110000", 
			/* 6 */ "001110000", 
			/* 7 */ "000100101",
			/* 8 */ "100100100", 
			/* 9 */ "001100100", 
			/* A */ "100001001", 
			/* B */ "001001001",
			/* C */ "101001000", 
			/* D */ "000011001", 
			/* E */ "100011000", 
			/* F */ "001011000",
			/* G */ "000001101", 
			/* H */ "100001100", 
			/* I */ "001001100", 
			/* J */ "000011100",
			/* K */ "100000011", 
			/* L */ "001000011", 
			/* M */ "101000010", 
			/* N */ "000010011",
			/* O */ "100010010", 
			/* P */ "001010010", 
			/* Q */ "000000111", 
			/* R */ "100000110",
			/* S */ "001000110", 
			/* T */ "000010110", 
			/* U */ "110000001", 
			/* V */ "011000001",
			/* W */ "111000000", 
			/* X */ "010010001", 
			/* Y */ "110010000", 
			/* Z */ "011010000",
			/* - */ "010000101", 
			/* . */ "110000100", 
			/*' '*/ "011000100",
			/* $ */ "010101000",
			/* / */ "010100010", 
			/* + */ "010001010", 
			/* % */ "000101010", 
			/* * */ "010010100" 
		};
        #endregion
    }
}