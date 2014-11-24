using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cheke.Designer.Controls.Settings;

namespace Cheke.Designer.Controls.Core
{
    public class PrintControl
    {
        private const int SRCCOPY = 13369376;
        private readonly Control _control = null;
        private readonly PrintDocument _printDocument = null;
        private readonly PrintPreviewDialog _previewDlg = null;

        public PrintControl(Control control)
        {
            this._control = control;

            this._printDocument = new PrintDocument();
            this._previewDlg = new PrintPreviewDialog();
            this._previewDlg.Document = this._printDocument;

            this._printDocument.PrintPage += PrintDocument_PrintPage;
            this._printDocument.BeginPrint += PrintDocument_BeginPrint;
        }

        public void Print()
        {
            UserSetting setting = UserSetting.LoadSetting();
            if(setting.UseDefaultPrinter)
            {
                this._printDocument.Print();
            }
            else
            {
                if(setting.RememberChoosedPrinter && setting.PrinterName.Length > 0)
                {
                    this._printDocument.PrinterSettings.PrinterName = setting.PrinterName;
                    this._printDocument.Print();
                }
                else
                {
                     PrintDialog dlg = new PrintDialog();
                     dlg.Document = this._printDocument;
                     dlg.UseEXDialog = true;
                     if (dlg.ShowDialog() != DialogResult.OK)
                         return;

                     if (setting.RememberChoosedPrinter && setting.PrinterName != dlg.PrinterSettings.PrinterName)
                     {
                         setting.PrinterName = dlg.PrinterSettings.PrinterName;
                         setting.Save();
                     }

                     this._printDocument.Print();
                }
            }
        }

        public void Preview()
        {
            this._previewDlg.ShowDialog();
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            this._printDocument.DefaultPageSettings.Landscape = this._control.Width > this._control.Height;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            //background
            float clientWidth = ToolboxControlBase.GetPixelWidth(e.Graphics, this._control.Width);
            float clientHeight = ToolboxControlBase.GetPixelHeight(e.Graphics, this._control.Height);
            e.Graphics.FillRectangle(new SolidBrush(this._control.BackColor), 0, 0, clientWidth, clientHeight);
            if (this._control.BackgroundImage != null)
            {
                this.DrawHostBackground(e, clientWidth, clientHeight);
            }

            //paint objs
            for (int i = this._control.Controls.Count -1; i >= 0; i--)
            {
                ToolboxControlBase child = this._control.Controls[i] as ToolboxControlBase;
                if(child == null)
                    continue;

                float left = ToolboxControlBase.GetPixelWidth(e.Graphics, child.Left);
                float top = ToolboxControlBase.GetPixelHeight(e.Graphics, child.Top);
                float width = ToolboxControlBase.GetPixelWidth(e.Graphics, child.Width);
                float height = ToolboxControlBase.GetPixelHeight(e.Graphics, child.Height);
                RectangleF rect = new RectangleF(left, top, width, height);
                child.PaintToDC(e.Graphics, rect);
            }
        }

        private void DrawHostBackground(PrintPageEventArgs e, float clientWidth, float clientHeight)
        {
            Image image = this._control.BackgroundImage;
            switch (this._control.BackgroundImageLayout)
            {
                case ImageLayout.Stretch:
                    {
                        RectangleF dst = new RectangleF(0, 0, clientWidth, clientHeight);
                        RectangleF src = new RectangleF(0, 0, image.Width, image.Height);
                        e.Graphics.DrawImage(image, dst, src, GraphicsUnit.Pixel); 
                    }
                    break;
                case ImageLayout.Zoom:
                    {
                        float x;
                        float y;
                        float width;
                        float height;
                        if (image.Width / clientWidth >= image.Height / clientHeight)
                        {
                            width = clientWidth;
                            height = width * image.Height / image.Width;

                            x = 0;
                            y = (clientHeight - height)/2;
                            if(y < 0)
                            {
                                y = 0;
                            }
                        }
                        else
                        {
                            height = clientHeight;
                            width = height * image.Width / image.Height;

                            y = 0;
                            x = (clientWidth - width)/2;
                            if(x < 0)
                            {
                                x = 0;
                            }
                        }

                        RectangleF dst = new RectangleF(x, y, width, height);
                        RectangleF src = new RectangleF(0, 0, image.Width, image.Height);
                        e.Graphics.DrawImage(image, dst, src, GraphicsUnit.Pixel); 
                    }
                    break;
                case ImageLayout.None:
                    {
                        float width;
                        float height;
                        if (image.Width > clientWidth)
                        {
                            width = clientWidth;
                        }
                        else
                        {
                            width = image.Width;
                        }

                        if (image.Height > clientHeight)
                        {
                            height = clientHeight;
                        }
                        else
                        {
                            height = image.Height;
                        }

                        RectangleF dst = new RectangleF(0, 0, width, height);
                        RectangleF src = new RectangleF(0, 0, width, height);
                        e.Graphics.DrawImage(image, dst, src, GraphicsUnit.Pixel);
                    }
                    break;
                case ImageLayout.Center:
                    {
                        float x;
                        float y;
                        float width;
                        float height;
                        if (image.Width > clientWidth)
                        {
                            x = 0;
                            width = clientWidth;
                        }
                        else
                        {
                            x = (clientWidth - image.Width)/2;
                            width = image.Width;
                        }

                        if (image.Height > clientHeight)
                        {
                            y = 0;
                            height = clientHeight;
                        }
                        else
                        {
                            y = (clientHeight - image.Height)/2;
                            height = image.Height;
                        }

                        RectangleF dst = new RectangleF(x, y, width, height);
                        RectangleF src = new RectangleF(0, 0, width, height);
                        e.Graphics.DrawImage(image, dst, src, GraphicsUnit.Pixel);
                    }
                    break;
                case ImageLayout.Tile:
                    {
                        float xCount = clientWidth/image.Width;
                        float yCount = clientHeight/image.Height;
                        for (float i = 0; i < xCount; i++)
                        {
                            float x = i*image.Width;
                            if(i >= clientWidth)
                                continue;

                            float width;
                            if(clientWidth - x < image.Width)
                            {
                                width = clientWidth - x;
                            }
                            else
                            {
                                width = image.Width;
                            }

                            for (float j = 0; j < yCount; j++)
                            {
                                float y = j*image.Height;
                                if(y >= clientHeight)
                                    continue;

                                float height;
                                if(clientHeight - y < image.Height)
                                {
                                    height = clientHeight - y;
                                }
                                else
                                {
                                    height = image.Height;
                                }

                                RectangleF dst = new RectangleF(x, y, width, height);
                                RectangleF src = new RectangleF(0, 0, width, height);
                                e.Graphics.DrawImage(image, dst, src, GraphicsUnit.Pixel);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }


        public Bitmap GetFormImage()
        {
            Graphics src = this._control.CreateGraphics();
            Bitmap frmImage = new Bitmap(this._control.Width, this._control.Height, src);
            Graphics dst = Graphics.FromImage(frmImage);

            IntPtr srcDC = src.GetHdc();
            IntPtr dstDC = dst.GetHdc();
            BitBlt(dstDC, 0, 0, this._control.Width, this._control.Height, srcDC, 0, 0, SRCCOPY);

            src.ReleaseHdc(srcDC);
            dst.ReleaseHdc(dstDC);

            return frmImage;
        }

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(
            IntPtr hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc,
            int nXSrc,
            int nYSrc,
            Int32 dwRop
            );
    }
}