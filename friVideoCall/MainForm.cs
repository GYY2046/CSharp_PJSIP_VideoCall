using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace friVideoCall
{
    public partial class MainForm : Form
    {
        PJProcess pjProcess;
        VideoFormStatusCommand currentVideoFormStatus;
        //VideoWindows videoWindows;
        Video videoWindows;
        //private string remoteIP;
        private log4net.ILog Log;
        public MainForm()
        {
            InitializeComponent();
            btnAnswer.Enabled = false;
            this.txtLocalIP.Text = ConfigurationManager.AppSettings["localIP"].ToString();
            this.txtRemoteIP.Text = ConfigurationManager.AppSettings["remoteIP"].ToString();
            Log = log4net.LogManager.GetLogger("MainForm");
           // RegisterDll.RegisterBinaries();
        }

        private void PjProcess_OnSendMessageResult(object sender, MessageResultEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PjProcess_OnReceiveMessage(object sender, InCommingMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PjProcess_OnDisconnectedCall(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            pjProcess.StopPreview();
            this.BeginInvoke(new Action(() =>
            {
                currentVideoFormStatus = VideoFormStatusCommand.MakeCall;                
                if (videoWindows != null)
                {
                    videoWindows.Close();
                    videoWindows.Dispose();
                    videoWindows = null;
                }
            }));
        }

        private void PjProcess_OnReceiveInCommingCall(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.btnAnswer.BeginInvoke(new Action(() =>
            {
                btnAnswer.Enabled = true;
            }));
        }

        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            videoWindows = new Video();
            //videoWindows.StartPosition = FormStartPosition.CenterScreen;
            //设置视频弹窗在那个屏幕显示
            videoWindows.ShowForm(false);
            videoWindows.Show();

            VideoHandleValue v = new VideoHandleValue();
            v.LocalView = new VideoViewInfo
            {
                // Handle = videoWindows.panelRemote.Handle.ToInt64(),
                Handle = videoWindows.panelLocal.Handle.ToInt64(),
                Width = videoWindows.panelLocal.Width,
                Height = videoWindows.panelLocal.Height
            };
            v.RemoteView = new VideoViewInfo
            {
                //Handle = videoWindows.panelLocal.Handle.ToInt64(),
                Handle = videoWindows.panelRemote.Handle.ToInt64(),
                Width = videoWindows.panelRemote.Width,
                Height = videoWindows.panelRemote.Height
            };

            pjProcess.SetVideoViewInfo(v);
            //1.启动本地预览
            //pjProcess.StartPreview();
            //Thread.Sleep(100);
            //2.拨打电话
            pjProcess.MakeCall(this.txtRemoteIP.Text);

            currentVideoFormStatus = VideoFormStatusCommand.HangCall;

        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            btnAnswer.Enabled = false;
            pjProcess.HangCall();
            pjProcess.StopPreview();
            if (videoWindows != null)
            {
                videoWindows.Close();
                videoWindows.Dispose();
                videoWindows = null;
            }
            currentVideoFormStatus = VideoFormStatusCommand.MakeCall;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Info("初始化");
                string path = System.IO.Directory.GetCurrentDirectory();
                var audioPath = Path.Combine(path, @"Resources\Audio.wav");
                pjProcess = new PJProcess();
                pjProcess.Init(this.txtLocalIP.Text, audioPath, this.txtCanmerName.Text);
                pjProcess.OnReceiveInCommingCall += PjProcess_OnReceiveInCommingCall;
                pjProcess.OnDisconnectedCall += PjProcess_OnDisconnectedCall;
                pjProcess.OnReceiveMessage += PjProcess_OnReceiveMessage;
                pjProcess.OnSendMessageResult += PjProcess_OnSendMessageResult;
                pjProcess.OnVolumeChange += PjProcess_OnVolumeChange;
                pjProcess.OnMicChange += PjProcess_OnMicChange;
                pjProcess.OnNoCamera += PjProcess_OnNoCamera;
                       
            }
            catch(Exception ex)
            {
                Log.Info(ex);
                Log.Error(ex);
            }
        }

        private void PjProcess_OnNoCamera(object sender, CameraNotFountEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (videoWindows != null)
                {
                    videoWindows.Close();
                    videoWindows.Dispose();
                    videoWindows = null;
                }

                MessageBox.Show($"未找到摄像头：{e.CameraName}");
            }));


        }

        private void PjProcess_OnMicChange(object sender, MicChangedEventArgs e)
        {
            this.lMic.BeginInvoke(new Action(() =>
            {
                this.lMic.Text = $"级别：{e.Level}";
            }));
        }

        private void PjProcess_OnVolumeChange(object sender, VolumeChangedEventArgs e)
        {
            this.lVolume.BeginInvoke(new Action(() =>
            {
                this.lVolume.Text = $"音量：{pjProcess.GetVolumeValue}";
            }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(pjProcess != null)
                pjProcess.Exit();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            videoWindows = new Video();
            videoWindows.StartPosition = FormStartPosition.CenterScreen;
            videoWindows.Show(this);
            VideoHandleValue v = new VideoHandleValue();
            v.LocalView = new VideoViewInfo
            {
                Handle = videoWindows.panelLocal.Handle.ToInt64(),
                Width = videoWindows.panelLocal.Width,
                Height = videoWindows.panelLocal.Height
            };
            v.RemoteView = new VideoViewInfo
            {
                Handle = videoWindows.panelRemote.Handle.ToInt64(),
                Width = videoWindows.panelRemote.Width,
                Height = videoWindows.panelRemote.Height
            };
            pjProcess.SetVideoViewInfo(v);
            pjProcess.AnswerCall();
            btnAnswer.Enabled = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(pjProcess != null)
                pjProcess.Exit();
        }

        private void btnExchangePanel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnStartPanel_Click(object sender, EventArgs e)
        {
            
            VideoForm = new Video();
            VideoForm.Show();
        }

        private Video VideoForm;

        private void btnGetVoice_Click(object sender, EventArgs e)
        {

            pjProcess.GetVolume();
        
        }
        private int volume = 20;
        private void btnSetVolume_Click(object sender, EventArgs e)
        {
            volume += 20;
            if (volume > 100)
                volume = 0;
            pjProcess.SetVolume(volume);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            pjProcess.PlayVoice();
        }

        private void btnStopPlay_Click(object sender, EventArgs e)
        {
            pjProcess.StopVoice();
        }

        private void btnGetMic_Click(object sender, EventArgs e)
        {
            pjProcess.GetMicLevel();
            
        }

        float level = 0.0f;
        private void btnSetMic_Click(object sender, EventArgs e)
        {
            level += 0.5f;
            if (level > 1.0f)
                level = 0.0f;
            //0.0f 是麦克风静音
            pjProcess.SetMicLevel(level);
        }

        private void btnShowPrev_Click(object sender, EventArgs e)
        {
            pjProcess.ShowPrev(true);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            pjProcess.ShowPrev(false);
        }
    }
}
