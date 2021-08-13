using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class PJProcess
    {
        private bool callThreadFlag = true;
        public Queue<CallUserCommand> CallUserCommands = new Queue<CallUserCommand>();
        public Queue<FormReceiveCommand> FormRCommand = new Queue<FormReceiveCommand>();
        private object queueLock = new object();
        public object FormRQueueLock = new object();
        private ThreadValue threadValue;
        private Thread videoThread;
        private UserAccount userAccount;
        VideoPreview video;
        UserCall call;
        CallOpParam callOpParam;
        VideoWindow window = null;
        InCommingCallEventArgs incommingParam;
        public event EventHandler<EventArgs> OnReceiveInCommingCall;
        public event EventHandler<EventArgs> OnDisconnectedCall;
        private RingBack ringBack;
        public PJProcess()
        {
            callThreadFlag = true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            videoThread = null;
            videoThread = new Thread(new ThreadStart(startPreview));
            videoThread.Name = "videoThread";
            videoThread.Start();
        }
        public void StartPreview(ThreadValue value)
        {
            this.threadValue = value;
            lock(queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.StartPreview);
            }
        }
        public void StopPreview()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.StopPreview);
            }
        }
        public void MakeCall()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.MakeCall);
            }
        }
        public void HangCall()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.HangCall);
            }
        }
        public void Exit()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.ExitThread);
            }
        }
        public void AnswerCall(ThreadValue value)
        {
            this.threadValue = value;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.AnswerCall);
            }
        }
        /// <summary>
        /// 初始化线程
        /// </summary>
        private void startPreview()
        {
            var ep = new Endpoint();
            try
            {
                ep.libCreate();


                EpConfig epConfig = new EpConfig();
                epConfig.logConfig.level = 6;
                epConfig.logConfig.writer = new DebugLog();
                //epConfig.uaConfig.threadCnt = 2;
                Thread.Sleep(200);//频率过快容易报此线程未注册到PJSIP的错误
                ep.libInit(epConfig);

                //新启动线程的时候必须注册到PJSIP中
                if (!ep.libIsThreadRegistered())
                {
                    //Thread.CurrentThread.Name = "prevVideoThread";
                    var threadName = Thread.CurrentThread.Name;
                    ep.libRegisterThread(threadName);
                }
                TransportConfig tcfg = new TransportConfig();
                tcfg.port = 5060;

                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
                ep.libStart();

                AccountConfig accountConfig = new AccountConfig();
                accountConfig.idUri = "sip:10.171.48.26";//本机sip
                //accountConfig.regConfig.registrarUri = "sip:10.171.48.26";
                accountConfig.videoConfig.autoShowIncoming = true;
                accountConfig.videoConfig.autoTransmitOutgoing = true;
                userAccount = new UserAccount();
                userAccount.OnInCommingCall += UserAccount_OnInCommingCall;
                userAccount.create(accountConfig);
                ringBack = new RingBack();


                while (callThreadFlag)
                {
                    CallUserCommand command = CallUserCommand.Default;
                    if (CallUserCommands.Count > 0)
                    {
                        lock (queueLock)
                        {
                            command = CallUserCommands.Dequeue();
                        }
                    }
                    else
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                    switch (command)
                    {
                        case CallUserCommand.StartPreview:
                            {
                                startPreviewWindow();
                            }
                            break;
                        case CallUserCommand.StopPreview:
                            {
                                video.stop();
                                video.Dispose();
                                window.Dispose();
                            }
                            break;
                        case CallUserCommand.MakeCall:
                            {
                                call = new UserCall(userAccount, threadValue.RemoteHandle);
                                callOpParam = new CallOpParam(true);
                                call.makeCall($"sip:10.171.48.27", callOpParam);
                            }
                            break;
                        case CallUserCommand.HangCall:
                            {
                                if (call.isActive())
                                {
                                    call.hangup(callOpParam);
                                    call.OnCallDisconnected -= Call_OnCallDisconnected;
                                    call.Dispose();
                                }
                            }
                            break;
                        case CallUserCommand.AnswerCall:
                            {
                                var e = incommingParam;
                                startPreviewWindow();
                                ringBack.ringStop();
                                // call = new UserCall(e.InCommingAccount, threadValue.RemoteHandle,e.InCommingCallId);
                                call.RemoteViewHandle = threadValue.RemoteHandle;
                                callOpParam = new CallOpParam(true);
                                callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
                                call.answer(callOpParam);
                                
                            }
                            break;
                        case CallUserCommand.ExitThread:
                            {
                                callThreadFlag = false;
                            }
                            break;
                        default:
                            Thread.Sleep(200);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally {
                if(call!= null)
                {
                    call.OnCallDisconnected -= Call_OnCallDisconnected;
                    call.Dispose();
                }
                if(ringBack != null)
                {
                    ringBack.Dispose();
                }
                ep.hangupAllCalls();
                ep.libStopWorkerThreads();
                ep.libDestroy();
                ep.Dispose();
                ep = null;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserAccount_OnInCommingCall(object sender, InCommingCallEventArgs e)
        {
            if (OnReceiveInCommingCall != null)
            {
                OnReceiveInCommingCall(this, new EventArgs());
            }
            incommingParam = e;
            call = e.InCommingCall;
            call.OnCallDisconnected += Call_OnCallDisconnected;
            ringBack.ringStart();
            //var callParam = e.InCommingCallParam;
            //call = null;
            //startPreviewWindow();
            //call = new UserCall(e.InCommingAccount, threadValue.RemoteHandle, e.InCommingCallParam.callId);
            //callOpParam = new CallOpParam(true);

            //call.answer(callOpParam);

        }
        /// <summary>
        /// 通话已断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Call_OnCallDisconnected(object sender, EventArgs e)
        {
            if (OnDisconnectedCall != null)
            {
                OnDisconnectedCall(this, e);
            }
        }

        private void startPreviewWindow()
        {
            var epdev = Endpoint.instance().vidDevManager().enumDev2();
            video = new VideoPreview(epdev[0].id);
            VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
            videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            videoPreviewOpParam.window = new VideoWindowHandle();
            videoPreviewOpParam.window.handle = new WindowHandle();
            videoPreviewOpParam.show = true;
            videoPreviewOpParam.window.handle.setWindow(threadValue.LocalHandle);

            video.start(videoPreviewOpParam);

            window = video.getVideoWindow();
            MediaSize size = new MediaSize();
            size.h = (uint)400;// this.panelCamera.Height;
            size.w = (uint)400;//this.panelCamera.Width;
            window.setSize(size);
        }
    }
}
