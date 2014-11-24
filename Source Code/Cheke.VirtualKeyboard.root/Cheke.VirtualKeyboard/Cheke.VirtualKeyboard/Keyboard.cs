using System.Runtime.InteropServices;

namespace Cheke.VirtualKeyboard
{
    internal class Keyboard
    {
        private const uint KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern void keybd_event(
            byte bVk,
            byte bScan,
            uint dwFlags,
            uint dwExtraInfo
            );

        [DllImport("user32.dll")]
        private static extern byte MapVirtualKey(byte wCode, int wMap);


        public static bool GetState(VirtualKeys Key)
        {
            return (GetKeyState((int) Key) == 1);
        }

        public static void SendKey(VirtualKeys Key)
        {
            byte bScan = MapVirtualKey((byte) Key, 0);
            keybd_event((byte) Key, bScan, 0, 0);
            System.Threading.Thread.Sleep(100);
            keybd_event((byte) Key, bScan, KEYEVENTF_KEYUP, 0);
        }

        public static void PressControlKey(VirtualKeys Key)
        {
            keybd_event((byte)Key, MapVirtualKey((byte)Key, 0), 0, 0);
            System.Threading.Thread.Sleep(100);
        }

        public static void ReleaseControlKey(VirtualKeys Key)
        {
            keybd_event((byte)Key, MapVirtualKey((byte)Key, 0), KEYEVENTF_KEYUP, 0);
            System.Threading.Thread.Sleep(100);
        }
    }
}