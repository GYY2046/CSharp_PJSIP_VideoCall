using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace friVideoCall.ScreenDet
{
    /// <summary>
    /// 屏幕检测
    /// </summary>
    public class ScreenDetection
    {
        /// <summary>
        /// 显示屏幕消息编码
        /// </summary>
        public const int WM_DISPLAYCHANGE = 0x007e;
        [DllImport("user32")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lpRect, MonitorEnumProc callback, int dwData);
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="hDesktop"></param>
        /// <param name="hdc"></param>
        /// <param name="pRect"></param>
        /// <param name="dwData"></param>
        /// <returns></returns>
        private delegate bool MonitorEnumProc(IntPtr hDesktop, IntPtr hdc, ref Rect pRect, int dwData);
        /// <summary>
        /// 当前屏幕信息
        /// </summary>
        public static List<MonitorInfo> ActualScreens = new List<MonitorInfo>();
        /// <summary>
        /// 结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        /// <summary>
        /// 当前屏幕发生变化时检测屏幕信息
        /// </summary>
        public static void RefreshActualScreens()
        {
            ActualScreens.Clear();
            MonitorEnumProc callback = (IntPtr hDesktop, IntPtr hdc, ref Rect prect, int d) =>
            {
                ActualScreens.Add(new MonitorInfo()
                {
                    Bounds = new Rectangle()
                    {
                        X = prect.left,
                        Y = prect.top,
                        Width = prect.right - prect.left,
                        Height = prect.bottom - prect.top,
                    },
                    IsPrimary = (prect.left == 0) && (prect.top == 0),
                });
                return true;
            };
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, callback, 0);
        }
    }
    /// <summary>
    /// 屏幕信息
    /// </summary>
    public class MonitorInfo
    {
        public bool IsPrimary = false;
        public Rectangle Bounds = new Rectangle();
    }
}
