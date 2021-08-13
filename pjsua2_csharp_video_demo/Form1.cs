using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pjsua2_csharp_video_demo
{
    //public class UserEventArgs : EventArgs
    //{
    //    public long IntPtr { get; set; }
    //}
        
    public partial class Form1 : Form
    {
        //[DllImport("SDL2.dll")]
        //public static extern int GetWindowTextLength(IntPtr hWnd);

        //const uint SDL_INIT_VIDEO = 32;
        ////[DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        //[DllImport("SDL2.dll")]
        //public static extern int SDL_Init(uint flags);
        ///* data refers to some native window type, IntPtr to an SDL_Window* */

        //[DllImport("SDL2.dll")]
        //public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);
        //public Endpoint ep;
        //UserAccount userAccount; //= new UserAccount();
        //public delegate void StartVideoDel(UserEventArgs handle);
        //Delegate Delegate;
        //Action<long> actionDelegate; //= startPreview;
        //Thread videoThread;
        public static long RemoteVideoPanelHandle ;
        public static long LocalVideoPanelHandle;
        //UserCall call;
        //CallOpParam callOpParam;
        //SDLPreview sDLPreview;
        //Task task;
        VideoWindows videoWindows;
        //VideoPreview video;
        //bool closePrevView = false;
        //bool callThreadFlag = true;
        //Queue<CallUserCommand> callUserCommands = new Queue<CallUserCommand>();

        //object queueLock = new object();
        PJProcess pjProcess;
        public Form1()
        {
            InitializeComponent();
            //actionDelegate = startPreview;
            
            //videoThread = new Thread(new ParameterizedThreadStart(startPreview));
           // videoThread.Name = "videoThread";
            //RemoteVideoPanelHandle = this.panelRemoteVideo.Handle.ToInt64();
            //LocalVideoPanelHandle = this.previewPanel.Handle.ToInt64();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            //ep = new Endpoint();

            //ep.libCreate();
            ////if (!ep.libIsThreadRegistered())
            ////    ep.libRegisterThread(videoThread.Name);
            ////    ep.libRegisterThread(videoThread.Name);
            ////LogConfig logConfig = new LogConfig();

            //EpConfig epConfig = new EpConfig();
            //epConfig.logConfig.level = 6;
            //epConfig.logConfig.writer = new DebugLog();
            //epConfig.uaConfig.threadCnt = 2;
            //ep.libInit(epConfig);
            ////if(!ep.libIsThreadRegistered())
            ////ep.libRegisterThread(videoThread.Name);
            ////if (!ep.libIsThreadRegistered())
            //TransportConfig tcfg = new TransportConfig();
            //tcfg.port = 5060;

            //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
            //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
            //// Start library
            ////ep.libCreate();

            //ep.libStart();

            //userAccount = new UserAccount();

            pjProcess = new PJProcess();
            pjProcess.Init();
            this.btnInit.Text = "初始化成功";
            //this.btnInit.Enabled = false;
        }
        /// <summary>
        /// 获取摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCamra_Click(object sender, EventArgs e)
        {
            //var videoList = ep.vidDevManager().enumDev2();
            //foreach (var item in videoList)
            //{
            //    ListItems listItems = new ListItems(item.id.ToString(), item.name);
            //    comboxCamre.Items.Add(listItems);
            //}
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {

            //var selectCamera = (ListItems)comboxCamre.SelectedItem;
            //var epdev = ep.vidDevManager().enumDev2();

            //VideoPreview video = new VideoPreview(epdev[0].id);
            //VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
            //videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;

            //videoPreviewOpParam.window = new VideoWindowHandle();
            //videoPreviewOpParam.show = true;
            //videoPreviewOpParam.window.handle = new WindowHandle();
            //videoPreviewOpParam.window.handle.setWindow(this.previewPanel.Handle.ToInt64());
            //Debug.WriteLine(this.previewPanel.Handle);
            //Debug.WriteLine(this.previewPanel.Handle.ToInt64());
            //var handle = this.previewPanel.Handle.ToInt64();
            videoWindows = new VideoWindows();
            videoWindows.Show();
            videoWindows.Visible = true;
            //sDLPreview = new SDLPreview();
            //sDLPreview.Show();

            //this.Controls.Add(sDLPreview);
            ThreadValue v = new ThreadValue();
            v.LocalHandle = videoWindows.panelLocal.Handle.ToInt64();
            v.RemoteHandle = videoWindows.panelRemote.Handle.ToInt64();
            pjProcess.StartPreview(v);
            //var handle = videoWindows.panelLocal.Handle.ToInt64();

            //videoThread = null;
            //videoThread = new Thread(new ParameterizedThreadStart(startPreview));
            //videoThread.Name = "videoThread";

            //var threadValue = new ThreadValue();
            //threadValue.LocalHandle = videoWindows.panelLocal.Handle.ToInt64();
            //threadValue.RemoteHandle = videoWindows.panelRemote.Handle.ToInt64();
            //videoThread.Start(threadValue);

            //lock (queueLock)
            //{
            //    callUserCommands.Enqueue(CallUserCommand.StartPreview);
            //}
            //this.BeginInvoke(actionDelegate, handle);
            //Thread t = new Thread(() =>
            //{
            //    ////preview.start(videoPreviewOpParam);
            //    //var ep = new Endpoint();
            //    //ep.libCreate();
            //    ////LogConfig logConfig = new LogConfig();

            //    //EpConfig epConfig = new EpConfig();
            //    //epConfig.logConfig.level = 6;
            //    //epConfig.logConfig.writer = new DebugLog();

            //    //ep.libInit(epConfig);

            //    //TransportConfig tcfg = new TransportConfig();
            //    //tcfg.port = 5060;

            //    //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
            //    //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
            //    //// Start library
            //    //ep.libStart();
            //    //VideoPreview video = new VideoPreview((int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_CAPTURE_DEV);           
            //    var epdev = ep.vidDevManager().enumDev2();

            //    VideoPreview video = new VideoPreview(epdev[0].id);
            //    VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
            //    videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            //    videoPreviewOpParam.window = new VideoWindowHandle();
            //    videoPreviewOpParam.window.handle = new WindowHandle();

            //    //videoPreviewOpParam.window.type = new SWIGTYPE_p_pjmedia_vid_dev_hwnd_type((long)1);

            //    videoPreviewOpParam.show = true;


            //    videoPreviewOpParam.window.handle.setWindow(handle);
            //    video.start(videoPreviewOpParam);
            //    var window = video.getVideoWindow();
            //    window.getInfo();
            //    //window.rotate(90);
            //    //var epdev = ep.vidDevManager().getOutputWindowFlags(-1);
            //    //window.Show(false);

            //    //MediaCoordinate coordinate = new MediaCoordinate();
            //    //coordinate.x = 0;// this.panelCamera.Top;
            //    //coordinate.y = 0;// this.panelCamera.Left;
            //    //window.setPos(coordinate);

            //    //MediaSize size = new MediaSize();
            //    //size.h = (uint)200;//this.panelCamera.Height;
            //    //size.w = (uint)200;//this.panelCamera.Width;
            //    //window.setSize(size);

            //    //var intPtr = EmbedControl.FindWindow(null, "pjmedia-SDL video");
            //    //EmbedControl.SetParent(intPtr, this.panelCamera.Handle);
            //    ////window.getInfo().isNative = false;
            //    //window.Show(true);

            //    //window.Show(true);
            //});
            //t.Start();
            //window.setFullScreen(true);
            //window.rotate(90);

            //VideoWindowHandle windowHandle = new VideoWindowHandle();
            //windowHandle.handle = new WindowHandle();
            //windowHandle.handle.setWindow(this.panelCamera.Handle.ToInt64());

            //window.setWindow(windowHandle);
            //window.rotate(90);

            //windowInfo.winHandle.handle.setWindow(this.panelCamera.Handle.ToInt64());
            //window.Show(true);


            //var windowInfo = window.getInfo();
            //windowInfo.isNative = false;
            //windowInfo.      
        }
        /// <summary>
        /// 预览线程
        /// </summary>
        /// <param name="value"></param>
        private void startPreview(object value )
        {
            //var v = value as ThreadValue;
            //closePrevView = false;

            //var ep = new Endpoint();
            //ep.libCreate();

            //EpConfig epConfig = new EpConfig();
            //epConfig.logConfig.level = 6;
            //epConfig.logConfig.writer = new DebugLog();
            //epConfig.uaConfig.threadCnt = 2;
            //Thread.Sleep(200);//频率过快容易报此线程未注册到PJSIP的错误
            //ep.libInit(epConfig);

            ////新启动线程的时候必须注册到PJSIP中
            //if (!ep.libIsThreadRegistered())
            //{
            //    //Thread.CurrentThread.Name = "prevVideoThread";
            //    var threadName = Thread.CurrentThread.Name;
            //    ep.libRegisterThread(threadName);
            //}
            //TransportConfig tcfg = new TransportConfig();
            //tcfg.port = 5060;

            //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
            //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
            //// Start library
            ////ep.libCreate();

            //ep.libStart();

            //userAccount = new UserAccount();
            //long ptr = (long)v.LocalHandle;

            //VideoWindow window = null;
            //while (callThreadFlag)
            //{
            //    CallUserCommand command = CallUserCommand.Default;
            //    if (callUserCommands.Count > 0)
            //    {
            //        lock (queueLock)
            //        {
            //            command = callUserCommands.Dequeue();
            //        }
            //    }
            //    else
            //    {
            //        Thread.Sleep(200);
            //        continue;
            //    }
            //    switch (command)
            //    {
            //        case CallUserCommand.StartPreview:
            //            {
            //                var epdev = ep.vidDevManager().enumDev2();
            //                video = null;
            //                video = new VideoPreview(epdev[0].id);
            //                VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
            //                videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            //                videoPreviewOpParam.window = new VideoWindowHandle();
            //                videoPreviewOpParam.window.handle = new WindowHandle();
            //                videoPreviewOpParam.show = true;
            //                videoPreviewOpParam.window.handle.setWindow(ptr);

            //                video.start(videoPreviewOpParam);

            //                window = video.getVideoWindow();
            //                MediaSize size = new MediaSize();
            //                size.h = (uint)400;// this.panelCamera.Height;
            //                size.w = (uint)400;//this.panelCamera.Width;
            //                window.setSize(size);
            //            }
            //            break;
            //        case CallUserCommand.StopPreview:
            //            {
            //                video.stop();
            //                video.Dispose();
            //                window.Dispose();
            //            }
            //            break;
            //        case CallUserCommand.MakeCall:
            //            {
            //                var remoteIP = this.textRemoteIP.Text;
            //                AccountConfig accountConfig = new AccountConfig();
            //                accountConfig.idUri = "sip:10.171.48.27";
            //                accountConfig.regConfig.registrarUri = "sip:10.171.48.26";
            //                accountConfig.videoConfig.autoShowIncoming = true;
            //                accountConfig.videoConfig.autoTransmitOutgoing = true;
            //                userAccount.create(accountConfig);
            //                call = new UserCall(userAccount,v.RemoteHandle);
            //                callOpParam = new CallOpParam(true);
            //                call.makeCall($"sip:10.171.48.27", callOpParam);
            //            }
            //            break;
            //        case CallUserCommand.HangCall:
            //            {
            //                if (call.isActive())
            //                {
            //                    call.hangup(callOpParam);
            //                }
            //            }
            //            break;
            //        case CallUserCommand.ExitThread:
            //            {
            //                callThreadFlag = false;
            //            }
            //            break;
            //        case CallUserCommand.Default:
            //            Thread.Sleep(200);
            //            break;
            //        default:
            //            Thread.Sleep(200);
            //            break;
            //    }
            //}

            //ep.libStopWorkerThreads();
            //ep.libDestroy();
            //ep.Dispose();
            //ep = null;

        }
        /// <summary>
        /// 拨打电话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeCall_Click(object sender, EventArgs e)
        {
            pjProcess.MakeCall();
            //lock (queueLock)
            //{
            //    callUserCommands.Enqueue(CallUserCommand.MakeCall);
            //}
            // call.makeCall($"sip:169.254.91.114",callOpParam);

        }
        /// <summary>
        /// 挂断电话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopCall_Click(object sender, EventArgs e)
        {
            pjProcess.HangCall();
            //lock (queueLock)
            //{
            //    callUserCommands.Enqueue(CallUserCommand.HangCall);
            //}
            //if (call.isActive())
            //{
            //    //CallOpParam callOpParam = new CallOpParam(true);
            //    call.hangup(callOpParam);
            //    //this.previewPanel.IsAccessible = true;
            //    this.previewPanel.Refresh();
            //    this.previewPanel.Visible = true;
            //    //this.panelRemoteVideo.IsAccessible = true;
            //    this.panelRemoteVideo.Refresh();
            //    this.panelRemoteVideo.Visible = true;
            //}
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDestroy_Click(object sender, EventArgs e)
        {
            pjProcess.Exit();
        }

        private void panelRemoteVideo_VisibleChanged(object sender, EventArgs e)
        {
            //if (!this.panelRemoteVideo.Visible)
            //    this.panelRemoteVideo.Visible = true;
        }
        /// <summary>
        /// 接听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnInitCall_Click(object sender, EventArgs e)
        {
            //var remoteIP = this.textRemoteIP.Text;
            //AccountConfig accountConfig = new AccountConfig();
            //accountConfig.idUri = "sip:169.254.119.169";
            ////accountConfig.regConfig = new AccountRegConfig();


            //accountConfig.regConfig.registrarUri = "sip:169.255.91.114";

            //accountConfig.videoConfig.autoShowIncoming = true;
            //accountConfig.videoConfig.autoTransmitOutgoing = true;
            

            ////AuthCredInfo cred = new AuthCredInfo("digest", "*", "1001", 0, "1234");
            ////accountConfig.sipConfig.authCreds.Add(cred);

            //userAccount.create(accountConfig);

            ////call = new UserCall(userAccount);
            //callOpParam = new CallOpParam(true);
        }

        private void btnStopPreview_Click(object sender, EventArgs e)
        {
            //closePrevView = true;
            //lock (queueLock)
            //{
            //    callUserCommands.Enqueue(CallUserCommand.StopPreview);
            //}
            pjProcess.StopPreview();
            videoWindows.Close();
            videoWindows.Dispose();
        }
    }
}
