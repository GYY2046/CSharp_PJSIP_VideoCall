using friVideoCall.ScreenDet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace friVideoCall
{
    public partial class Video : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        //public PJProcess PJProcess { get; set; }            
        Point pt;
        public delegate void AnswerEventHandler();
        public event AnswerEventHandler OnAnswerEvent;
        public delegate void RejectEventHandler();
        public event RejectEventHandler OnRejectEvent;
        public Video()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置挂断状态
        /// </summary>
        public void SetReject()
        {
            this.btnAnswer.Enabled = false;
            this.btnAnswer.Visible = false;
            //this.btnReject
            this.tableLayoutPanel1.SetColumnSpan(this.btnReject, 2);
        }
        public void ShowForm(int screenIndex, int x = 0, int y = 0, int width = 800, int height = 600)
        {
            ScreenDetection.RefreshActualScreens();
            //this.StartPosition = FormStartPosition.Manual;
            var screenList = ScreenDetection.ActualScreens;
            MonitorInfo monitorInfo = new MonitorInfo();
            var CurrentMonitor = new MonitorInfo();
            Application.DoEvents();
            if (screenList.Count >= 2)
            {
                if ((screenList.Count >= screenIndex) && screenIndex > 0)
                {
                    CurrentMonitor = screenList[screenIndex - 1];
                }
                else
                {
                    CurrentMonitor = screenList[0];
                }
            }
            else
            {
                CurrentMonitor = screenList[0];
            }
            this.Width = width;
            this.Height = height;
            var newX = 0;
            var newY = 0;
            if (x == 0 && y == 0)
            {
                newX = (int)((CurrentMonitor.Bounds.X + CurrentMonitor.Bounds.Width / 2.0) - this.Width / 2);
                newY = (int)((CurrentMonitor.Bounds.Y + CurrentMonitor.Bounds.Height / 2.0) - this.Height / 2);
            }
            else
            {
                newX = (int)(CurrentMonitor.Bounds.X + x);
                newY = (int)(CurrentMonitor.Bounds.Y + y);
            }
            this.Location = new Point(newX, newY);

            this.StartPosition = FormStartPosition.Manual;



            //var list = Screen.AllScreens;
            //this.Width = width;
            //this.Height = height;
            //foreach (var item in list)
            //{
            //    if (item.Primary == isPrimary)
            //    {
            //        var newX = 0;
            //        var newY = 0;
            //        if (x == 0 && y == 0)
            //        {
            //            newX = (int)((item.WorkingArea.X + item.WorkingArea.Width / 2.0) - this.Width / 2);
            //            newY = (int)((item.WorkingArea.Y + item.WorkingArea.Height / 2.0) - this.Height / 2);
            //        }
            //        else
            //        {
            //            newX = (int)(item.WorkingArea.X + x);
            //            newY = (int)(item.WorkingArea.Y + y);
            //        }
            //        this.Location = new Point(newX, newY);

            //        this.StartPosition = FormStartPosition.Manual;
            //    }
            //}
        }
        /// <summary>
        /// 设置视频弹窗在那个屏幕显示
        /// true - 在主屏幕显示
        /// false - 在第二屏幕显示
        /// 两个显示器分辨目前必须一致，才能达到居中显示的效果
        /// </summary>
        /// <param name="isPrimary"></param>
        public void ShowForm(bool isPrimary, int x=0,int y=0,int width=800,int height=600)
        {
            var list = Screen.AllScreens;
            this.Width = width;
            this.Height = height;
            foreach (var item in list)
            {
                if (item.Primary == isPrimary)
                {
                    var newX = 0;
                    var newY = 0;
                    if (x == 0 && y == 0)
                    {
                        newX = (int)((item.WorkingArea.X + item.WorkingArea.Width / 2.0) - this.Width / 2);
                        newY = (int)((item.WorkingArea.Y + item.WorkingArea.Height / 2.0) - this.Height / 2);
                    }
                    else
                    {
                        newX = (int)(item.WorkingArea.X + x);
                        newY = (int)(item.WorkingArea.Y + y);
                    }
                    this.Location = new Point(newX, newY);

                    this.StartPosition = FormStartPosition.Manual;
                }
            }
        }
        private void panelLocal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int px = Cursor.Position.X - pt.X;
                int py = Cursor.Position.Y - pt.Y;
                var newPoint = new Point(panelLocal.Location.X + px, panelLocal.Location.Y + py);
                if (newPoint.X < 0 || newPoint.Y < 0)
                    return;
                if (newPoint.X + panelLocal.Width > panelRemote.Width
                   || newPoint.Y + panelLocal.Height > panelRemote.Height)
                    return;
                panelLocal.Location = newPoint;
                pt = Cursor.Position;
            }
        }

        private void panelLocal_MouseDown(object sender, MouseEventArgs e)
        {
            pt = Cursor.Position;

        }

        private void panelRemote_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;//改变鼠标样式
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        /// <summary>
        /// 接听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            //PJProcess.AnswerCall();
            if(OnAnswerEvent != null)
            {
                OnAnswerEvent();
            }
        }
        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReject_Click(object sender, EventArgs e)
        {
            //PJProcess.HangCall();
            if(OnRejectEvent != null)
            {
                OnRejectEvent();
            }
        }

        private void panelRemote_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
