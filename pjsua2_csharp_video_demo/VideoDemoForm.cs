using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjsua2_csharp_video_demo
{
    public partial class VideoDemoForm : Form
    {
        PJProcess pjProcess;
        VideoWindows videoWindows;
        public VideoDemoForm()
        {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            pjProcess = new PJProcess();
            pjProcess.Init();
            pjProcess.OnReceiveInCommingCall += PjProcess_OnReceiveInCommingCall;
        }

        private void PjProcess_OnReceiveInCommingCall(object sender, EventArgs e)
        {
            
        }

        private void btnStartPreview_Click(object sender, EventArgs e)
        {
            videoWindows = new VideoWindows();
            videoWindows.Show();
            videoWindows.Visible = true;
            ThreadValue v = new ThreadValue();
            v.LocalHandle = videoWindows.panelLocal.Handle.ToInt64();
            v.RemoteHandle = videoWindows.panelRemote.Handle.ToInt64();
            pjProcess.StartPreview(v);
        }

        private void btnStopPreview_Click(object sender, EventArgs e)
        {
            pjProcess.StopPreview();
            videoWindows.Close();
        }

        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            pjProcess.MakeCall();
        }

        private void btnHangCall_Click(object sender, EventArgs e)
        {
            pjProcess.HangCall();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            pjProcess.Exit();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            videoWindows = new VideoWindows();
            videoWindows.Show();
            videoWindows.Visible = true;
            ThreadValue v = new ThreadValue();
            v.LocalHandle = videoWindows.panelLocal.Handle.ToInt64();
            v.RemoteHandle = videoWindows.panelRemote.Handle.ToInt64();
            pjProcess.AnswerCall(v);
        }
    }
}
