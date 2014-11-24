using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Cheke.ImageProcessing
{
    public static class Processing
    {
        public static Bitmap CropImage(Bitmap bmpIn, int startX, int startY, int width, int height)
        {
            if (bmpIn == null)
                return null;

            if (startX >= bmpIn.Width || startY >= bmpIn.Height)
                return null;

            if (startX + width > bmpIn.Width)
            {
                width = bmpIn.Width - startX;
            }

            if (startY + height > bmpIn.Height)
            {
                height = bmpIn.Height - startY;
            }

            try
            {
                Bitmap bmpOut = new Bitmap(width, height, bmpIn.PixelFormat);
                using (Graphics g = Graphics.FromImage(bmpOut))
                {
                    g.DrawImage(bmpIn, new Rectangle(0, 0, width, height),
                                new Rectangle(startX, startY, width, height), GraphicsUnit.Pixel);
                }

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap ResizeImage(Bitmap bmpIn, int newWidth, int newHeight)
        {
            if (bmpIn == null)
                return null;

            try
            {
                float width;
                float height;
                if (bmpIn.Width / (float)newWidth >= bmpIn.Height / (float)newHeight)
                {
                    width = newWidth;
                    height = bmpIn.Height * width / bmpIn.Width;
                }
                else
                {
                    height = newHeight;
                    width = bmpIn.Width * height / bmpIn.Height;
                }

                Bitmap bmpOut = new Bitmap((int)width, (int)height);
                using (Graphics g = Graphics.FromImage(bmpOut))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bmpIn, new Rectangle(0, 0, (int)width, (int)height),
                                new Rectangle(0, 0, bmpIn.Width, bmpIn.Height), GraphicsUnit.Pixel);
                }

                return bmpOut;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap ColorBalance(Bitmap bmp, float percent)
        {
            if (bmp == null || percent >=1 || percent <= -1 )
                return null;

            try
            {
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                
                unsafe
                {
                    byte* ptr = (byte*)srcData.Scan0.ToPointer();
                    int nOffset = srcData.Stride - bmp.Width * 3;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            int b = (int)(ptr[0] * percent);
                            if (b > 255) b = 255;
                            if (b < 0) b = 0;

                            int g = (int)(ptr[1] * percent);
                            if (g > 255) g = 255;
                            if (g < 0) g = 0;

                            int r = (int)(ptr[2] * percent);
                            if (r > 255) r = 255;
                            if (r < 0) r = 0;

                            ptr[0] = (byte)b;
                            ptr[1] = (byte)g;
                            ptr[2] = (byte)r;

                            ptr += 3;
                        }

                        ptr += nOffset;
                    }
                } 

                bmp.UnlockBits(srcData);
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap ColorBalance(Bitmap bmp, int rVal, int gVal, int bVal)
        {
            if (bmp == null)
                return null;

            if (rVal > 255 || rVal < -255 || gVal > 255 || gVal < -255 || bVal > 255 || bVal < -255)
                return null;

            try
            {
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)srcData.Scan0.ToPointer();
                    int nOffset = srcData.Stride - bmp.Width * 3;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            int b = ptr[0] + bVal;
                            if (b > 255) b = 255;
                            if (b < 0) b = 0;

                            int g = ptr[1] + gVal;
                            if (g > 255) g = 255;
                            if (g < 0) g = 0;

                            int r = ptr[2] + rVal;
                            if (r > 255) r = 255;
                            if (r < 0) r = 0;

                            ptr[0] = (byte)b;
                            ptr[1] = (byte)g;
                            ptr[2] = (byte)r;

                            ptr += 3;
                        }

                        ptr += nOffset;
                    }
                }

                bmp.UnlockBits(srcData);
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap Gray(Bitmap bmp)
        {
            if (bmp == null)
                return null;

            try
            {
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)srcData.Scan0.ToPointer();
                    int nOffset = srcData.Stride - bmp.Width * 3;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            ptr[0] = ptr[1] = ptr[2] = (byte)(.299 * ptr[2] + .587 * ptr[1] + .114 * ptr[0]);

                            ptr += 3;
                        }

                        ptr += nOffset;
                    }
                }

                bmp.UnlockBits(srcData);
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap Invert(Bitmap bmp)
        {
            if (bmp == null)
                return null;

            try
            {
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* ptr = (byte*)srcData.Scan0.ToPointer();
                    int nOffset = srcData.Stride - bmp.Width * 3;
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            ptr[0] = (byte)(255 - ptr[0]);
                            ptr[1] = (byte)(255 - ptr[1]);
                            ptr[2] = (byte)(255 - ptr[2]);

                            ptr += 3;
                        }

                        ptr += nOffset;
                    }
                }

                bmp.UnlockBits(srcData);
                return bmp;
            }
            catch
            {
                return null;
            }
        }

        public static Bitmap Emboss(Bitmap bmp)
        {
            if (bmp == null)
                return null;

            try
            {
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* ptr = (byte*)srcData.Scan0.ToPointer();
                    int nOffset = srcData.Stride - bmp.Width * 3;
                    for (int y = 0; y < bmp.Height - 1; y++)
                    {
                        for (int x = 0; x < bmp.Width - 1; x++)
                        {
                            int b = Math.Abs(ptr[0] - ptr[0 + srcData.Stride + 1] + 128);
                            int g = Math.Abs(ptr[1] - ptr[1 + srcData.Stride + 1] + 128);
                            int r = Math.Abs(ptr[2] - ptr[2 + srcData.Stride + 1] + 128);

                            if (b > 255) b = 255;
                            if (g > 255) g = 255;
                            if (r > 255) r = 255;

                            ptr[0] = (byte) b;
                            ptr[1] = (byte) g;
                            ptr[2] = (byte) r;

                            ptr += 3;
                        }

                        ptr += nOffset;
                    }
                }

                bmp.UnlockBits(srcData);
                return bmp;
            }
            catch
            {
                return null;
            }
        }
    }
}