using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cheke.Designer.Controls
{
    [ToolboxItem(false)]
    public class ToolboxControlBase : Control
    {
        protected void SwitchWidthHeight()
        {
            int switchValue = this.Width;
            this.Width = this.Height;
            this.Height = switchValue;
        }

        #region Property Members

        [Browsable(false)]
        public new string AccessibleDescription
        {
            get { return base.AccessibleDescription; }
            set { base.AccessibleDescription = value; }
        }

        [Browsable(false)]
        public new string AccessibleName
        {
            get { return base.AccessibleName; }
            set { base.AccessibleName = value; }
        }


        [Browsable(false)]
        public new AccessibleRole AccessibleRole
        {
            get { return base.AccessibleRole; }
            set { base.AccessibleRole = value; }
        }

        [Browsable(false)]
        public new Boolean AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        [Browsable(false)]
        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set { base.Cursor = value; }
        }

        [Browsable(false)]
        public override DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        [Browsable(false)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }

        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }

        [Browsable(false)]
        public override AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Browsable(false)]
        public new RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        [Browsable(false)]
        public new Boolean CausesValidation
        {
            get { return base.CausesValidation; }
            set { base.CausesValidation = value; }
        }

        [Browsable(false)]
        public new ContextMenuStrip ContextMenuStrip
        {
            get { return base.ContextMenuStrip; }
            set { base.ContextMenuStrip = value; }
        }


        [Browsable(false)]
        public new ControlBindingsCollection DataBindings
        {
            get { return base.DataBindings; }
        }


        [Browsable(false)]
        public new Boolean Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        [Browsable(false)]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }

        [Browsable(false)]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }

        [Browsable(false)]
        public new ISite Site
        {
            get { return base.Site; }
            set { base.Site = value; }
        }

        [Browsable(false)]
        public new Int32 TabIndex
        {
            get { return base.TabIndex; }
            set { base.TabIndex = value; }
        }

        [Browsable(false)]
        public new Boolean TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        [Browsable(false)]
        public new Object Tag
        {
            get { return base.Tag; }
            set { base.Tag = value; }
        }


        [Browsable(false)]
        public new Boolean UseWaitCursor
        {
            get { return base.UseWaitCursor; }
            set { base.UseWaitCursor = value; }
        }

        [Browsable(false)]
        public new Boolean Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; }
        }

        [Browsable(false)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        #endregion

        public virtual void PaintToDC(Graphics g, RectangleF rect)
        {
        }

        public static Font GetPixelFont(Graphics g, Font font)
        {
            float fontSize;
            switch (font.Unit)
            {
                case GraphicsUnit.Point:
                    fontSize = (font.Size / 72.0F) * g.DpiY;
                    break;
                case GraphicsUnit.Pixel:
                case GraphicsUnit.World:
                    fontSize = font.Size * (g.DpiY / 96);
                    break;
                case GraphicsUnit.Inch:
                    fontSize = font.Size * g.DpiY;
                    break;
                case GraphicsUnit.Millimeter:
                    fontSize = (font.Size / 25.4F) * g.DpiY;
                    break;
                case GraphicsUnit.Document:
                    fontSize = (font.Size / 300.0F) * g.DpiY;
                    break;
                default:
                    fontSize = font.Size;
                    break;
            }

            return new Font(font.FontFamily, fontSize, font.Style, GraphicsUnit.Pixel);
        }

        public static float GetPixelWidth(Graphics g, float width)
        {
            return (g.DpiX / 96.0F)*width;
        }

        public static float GetPixelHeight(Graphics g, float height)
        {
            return (g.DpiY / 96.0F) * height;
        }
    }
}