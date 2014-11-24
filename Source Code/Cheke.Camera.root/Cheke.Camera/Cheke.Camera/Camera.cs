using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Cheke.Camera
{
    public class Camera
    {
        private const int WM_USER = 0x400;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CAP_START = WM_USER;
        private const int WM_CAP_STOP = WM_CAP_START + 68;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        private const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
        private const int WM_CAP_CopyToClipBorad = WM_CAP_START + 30;
        private const int WM_CAP_SEQUENCE = WM_CAP_START + 62;
        private const int WM_CAP_FILE_SET_CAPTURE_FILEA = WM_CAP_START + 20;
        private const int WM_CAP_SET_OVERLAY = WM_CAP_START + 51;
        private const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
        private const int WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6;
        private const int WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2;
        private const int WM_CAP_SET_CALLBACK_STATUSA = WM_CAP_START + 3;
        private const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;

        private IntPtr _hWnd = IntPtr.Zero;
        private bool _isStart = false;

        private readonly IntPtr _controlPtr;
        private readonly int _width;
        private readonly int _height;
        private readonly int _left;
        private readonly int _top;

        public Camera(IntPtr handle, int left, int top, int width, int height)
        {
            this._controlPtr = handle;
            this._width = width;
            this._height = height;
            this._left = left;
            this._top = top;
        }

        public void Start()
        {
            if (this._isStart)
                return;

            this._isStart = true;
            byte[] lpszName = new byte[100];
            this._hWnd = capCreateCaptureWindowA(lpszName, WS_CHILD | WS_VISIBLE, this._left, this._top, this._width, this._height, this._controlPtr, 0);
            if (this._hWnd.ToInt32() != 0)
            {
                SendMessage(this._hWnd, WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, 0);
                SendMessage(this._hWnd, WM_CAP_SET_CALLBACK_ERROR, 0, 0);
                SendMessage(this._hWnd, WM_CAP_SET_CALLBACK_STATUSA, 0, 0);
                SendMessage(this._hWnd, WM_CAP_DRIVER_CONNECT, 0, 0);
                SendMessage(this._hWnd, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(this._hWnd, WM_CAP_SET_PREVIEWRATE, 66, 0);
                SendMessage(this._hWnd, WM_CAP_SET_OVERLAY, 1, 0);
                SendMessage(this._hWnd, WM_CAP_SET_PREVIEW, 1, 0);
            }

            return;
        }

        public void Stop()
        {
            if (!this._isStart)
                return;

            SendMessage(this._hWnd, WM_CAP_DRIVER_DISCONNECT, 0, 0);
            this._isStart = false;
        }

        public void GrabImage(string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            SendMessage(this._hWnd, WM_CAP_SAVEDIB, 0, hBmp.ToInt32());
        }

        public Image GrabImage()
        {
            string fileName = System.IO.Path.GetTempFileName();
            this.GrabImage(fileName);
            byte[] buffer = File.ReadAllBytes(fileName);
            File.Delete(fileName);
            if(buffer.Length == 0)
                return null;

            MemoryStream stream = new MemoryStream(buffer);
            return Image.FromStream(stream);
        }

        public void CopyToClipBorad()
        {
            SendMessage(this._hWnd, WM_CAP_CopyToClipBorad, 0, 0);
        }

        public Image GetImageFromClipBorad()
        {
            Image retImage = null;

            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
            {
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    retImage = (Image)iData.GetData(DataFormats.Bitmap);
                }
                else if (iData.GetDataPresent(DataFormats.Dib))
                {
                    retImage = (Image)iData.GetData(DataFormats.Dib);
                }
            }

            return retImage;
        }

        public void Kinescope(string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            SendMessage(this._hWnd, WM_CAP_FILE_SET_CAPTURE_FILEA, 0, hBmp.ToInt32());
            SendMessage(this._hWnd, WM_CAP_SEQUENCE, 0, 0);
        }

        public void StopKinescope()
        {
            SendMessage(this._hWnd, WM_CAP_STOP, 0, 0);
        }

        [DllImport("avicap32.dll")]
        private static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);

        [DllImport("User32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}