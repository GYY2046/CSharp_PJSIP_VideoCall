
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class PJProcess
    {
        private bool callThreadFlag = true;
        public Queue<CallUserCommand> CallUserCommands = new Queue<CallUserCommand>();
        public Queue<FormReceiveCommand> FormRCommand = new Queue<FormReceiveCommand>();
        //private List<string> remoteIPList;
        private object queueLock = new object();
        private object currentCallLock = new object();
        public object FormRQueueLock = new object();
        private VideoHandleValue threadValue;
        private Thread videoThread;
        private UserAccount userAccount;
        VideoPreview video;
        UserCall call;
        CallOpParam callOpParam;
        VideoWindow window = null;
        InCommingCallEventArgs incommingParam;
        public event EventHandler<EventArgs> OnReceiveInCommingCall;
        public event EventHandler<EventArgs> OnDisconnectedCall;
        public event EventHandler<InCommingMessageEventArgs> OnReceiveMessage;
        public event EventHandler<MessageResultEventArgs> OnSendMessageResult;
        public event EventHandler<VolumeChangedEventArgs> OnVolumeChange;
        public event EventHandler<MicChangedEventArgs> OnMicChange;
        /// <summary>
        /// 没有找到摄像头
        /// </summary>
        public event EventHandler<CameraNotFountEventArgs> OnNoCamera;

        private RingBack ringBack;
        private string remoteIP;
        private string localIP;
        private bool isStopPreview;
        private string wavFilePath;
        private Dictionary<string, UserBuddy> buddyDics;
        private object lockBuddyDics = new object();
        private string messageRemoteIP;
        private string message;
        VideoPreviewOpParam currentVideoPreviewOpParam;
        VideoDevInfoVector2 videoDevInfos;
        log4net.ILog Log;
        public Endpoint ep;
        DebugLog debugLog;
        /// <summary>
        /// 视频窗口信息
        /// </summary>
        private VideoHandleValue VideoViewInfo;
        /// <summary>
        /// 音量大小
        /// </summary>
        public int SetVolumeValue { get; private set; }

        public int GetVolumeValue;
        private float MicLevel;
        private string CameraName;
        private InCommingCallEventArgs inComming;
        //private LogTrace _log;
        public PJProcess()
        {
            callThreadFlag = true;
            isStopPreview = true;
            Log = log4net.LogManager.GetLogger("pjsip");
            Log.Info($"初始化!{Environment.NewLine}");
            RegisterDll.RegisterBinaries();
        }
        /// <summary>
        /// 设置视频预览窗信息
        /// </summary>
        /// <param name="viewInfo"></param>
        public void SetVideoViewInfo(VideoHandleValue viewInfo)
        {
            VideoViewInfo = viewInfo;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(string localIp, string wavPath, string cameraName)
        {
            localIP = localIp;
            wavFilePath = wavPath;
            videoThread = null;
            buddyDics = new Dictionary<string, UserBuddy>();
            videoThread = new Thread(new ThreadStart(startPreview));
            CameraName = cameraName;
            videoThread.Name = "videoThread";
            videoThread.Start();
            Log.Info("启动轮询线程");
        }
        /// <summary>
        /// 打开预览，弃用
        /// </summary>
        /// <param name="value"></param>
        [Obsolete]
        public void StartPreview(VideoHandleValue value)
        {
            Log.Info("接收到打开预览命令");
            this.threadValue = value;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.StartPreview);
            }

        }
        /// <summary>
        /// 启动预览
        /// </summary>
        public void StartPreview()
        {
            Log.Info("接收到打开预览命令");
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.StartPreview);
            }
        }
        public void StopPreview()
        {
            Log.Info("接收到停止预览命令");

            if (!isStopPreview)
            {
                lock (queueLock)
                {
                    CallUserCommands.Enqueue(CallUserCommand.StopPreview);
                }
            }
            //if(ringBack != null)
            //{
            //    ringBack.ringStop();
            //}
            isStopPreview = true;
        }
        public void MakeCall(string remoteIp)
        {
            Log.Info($"接收到通话命令:{remoteIp}");
            remoteIP = remoteIp;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.MakeCall);
            }
        }
        public void HangCall()
        {
            Log.Info("接收到挂断命令");
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.HangCall);
            }
        }
        public void Exit()
        {
            Log.Info("接收到退出命令");
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.ExitThread);
            }
        }
        /// <summary>
        /// 显示或隐藏预览
        /// </summary>
        /// <param name="isShow"></param>
        public void ShowPrev(bool isShow)
        {
            Log.Info($"接收到预览窗口命令：{isShow}");
            lock (queueLock)
            {
                CallUserCommands.Enqueue(isShow ? CallUserCommand.ShowPrev : CallUserCommand.HidePrev);
            }
        }
        /// <summary>
        /// 接听，弃用
        /// </summary>
        /// <param name="value"></param>
        [Obsolete]
        public void AnswerCall(VideoHandleValue value)
        {
            Log.Info("接收到应答命令");
            this.threadValue = value;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.AnswerCall);
            }
        }
        /// <summary>
        /// 接听
        /// </summary>
        public void AnswerCall()
        {
            Log.Info("接收到应答命令");
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.AnswerCall);
            }
        }
        public void SendMessage(string ip, string messageModel)
        {
            Log.Info($"接收到发送消息命令：{ip}");
            messageRemoteIP = ip;
            message = messageModel;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.SendMesssage);
            }
        }

        public void GetVolume()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.GetVolume);
            }
        }
        public void SetVolume(int volume)
        {
            SetVolumeValue = volume;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.SetVolume);
            }
        }

        public void PlayVoice()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.PlayVoice);
            }
        }
        public void StopVoice()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.StopVoice);
            }
        }
        public void GetMicLevel()
        {
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.GetMicLevel);
            }

        }
        public void SetMicLevel(float level)
        {
            MicLevel = level;
            lock (queueLock)
            {
                CallUserCommands.Enqueue(CallUserCommand.SetMicLevel);
            }
        }
        private void InCommingCall(InCommingCallEventArgs inCommingCallEventArgs)
        {
            lock(queueLock)
            {
                inComming = inCommingCallEventArgs;
                CallUserCommands.Enqueue(CallUserCommand.InCommingCall);

            }
        }
        /// <summary>
        /// 初始化线程
        /// </summary>
        private void startPreview()
        {

            try
            {
                Log.Info($"启动线程");
                ep = new Endpoint();
                ep.libCreate();
                Log.Debug($"创建EndPoint成功");
                EpConfig epConfig = new EpConfig();
                epConfig.logConfig.level = 5;
                epConfig.logConfig.consoleLevel = 6;
                debugLog = new DebugLog();
                debugLog.Log = Log;// log4net.LogManager.GetLogger("pjsip");
                epConfig.logConfig.writer = debugLog;// new DebugLog();
                //epConfig.uaConfig.maxCalls = 1;

                //epConfig.uaConfig.threadCnt = 2;
                Thread.Sleep(200);//频率过快容易报此线程未注册到PJSIP的错误
                ep.libInit(epConfig);
                epConfig.Dispose();
                Log.Debug($"EndPoint初始化成功");
                //新启动线程的时候必须注册到PJSIP中
                if (!ep.libIsThreadRegistered())
                {
                    Log.Debug($"EndPoint注册线程成功");
                    //Thread.CurrentThread.Name = "prevVideoThread";
                    var threadName = Thread.CurrentThread.Name;
                    ep.libRegisterThread(threadName);
                }
                TransportConfig tcfg = new TransportConfig();
                tcfg.port = 5060;
                //ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
                ep.libStart();

                //var mediaPorts = ep.mediaEnumPorts2();
                //var videoPorts = ep.mediaEnumVidPorts();
                //var mediaDev = ep.audDevManager().enumDev2();

                //视频支持720P，后续优化看是否支持1080P
                var vidCodec = ep.videoCodecEnum2();
                foreach (var item in vidCodec)
                {
                    Log.Info($"{item.codecId}-{item.desc}-{item.priority}");
                }
                //ep.codecGetParam()
                //ep.codecSetPriority("speex/32000", 140);
                ep.codecSetPriority("opus/48000", 131);
                var vidParam = ep.getVideoCodecParam("H264");
                vidParam.encFmt.height = 720;
                vidParam.encFmt.width = 1280;
                vidParam.encFmt.fpsDenum = 1;
                vidParam.encFmt.fpsNum = 60;
                vidParam.encFmt.avgBps = 1024000;
                vidParam.encFmt.maxBps = 2048000;


                vidParam.decFmt.height = 720;
                vidParam.decFmt.width = 1280;
                vidParam.decFmt.fpsDenum = 1;
                vidParam.decFmt.fpsNum = 60;
                vidParam.decFmt.avgBps = 1024000;
                vidParam.decFmt.maxBps = 2048000;
                //vidParam.decFmtp[0].name = "profile-level-id";
                //vidParam.decFmtp[0].val = "42e01f";

                foreach (var item in vidParam.decFmtp)
                {
                    Log.Info($"{item.name}-{item.val}");
                    if (item.name == "profile-level-id")
                    {
                        // item.val = "42e028";
                        item.val = "42e01f";
                    }
                }
                ep.setVideoCodecParam("H264", vidParam);
                vidParam.Dispose();

                Log.Debug($"启动pjlib库成功");

                AccountConfig accountConfig = new AccountConfig();
                accountConfig.idUri = "sip:" + localIP;//本机sip
                //查找指定的摄像头
                int id = -1;
                if (FindCamera(out id))
                    accountConfig.videoConfig.defaultCaptureDevice = id;
                //accountConfig.regConfig.registrarUri = "sip:10.171.48.26";
                //accountConfig.videoConfig.autoShowIncoming = true;
                //accountConfig.videoConfig.autoTransmitOutgoing = true;
                //accountConfig.callConfig.
                //accountConfig.mwiConfig.enabled = true;
                //accountConfig.mwiConfig.expirationSec = (uint)30;
                userAccount = new UserAccount();
                userAccount.OnInCommingCall += UserAccount_OnInCommingCall;
                userAccount.OnInCommingMessage += UserAccount_OnInCommingMessage;
                userAccount.OnSendMessageResult += UserAccount_OnSendMessageResult;
                userAccount.create(accountConfig);
                Log.Debug($"创建Account成功");
                ringBack = new RingBack(wavFilePath);
                Log.Debug($"响铃创建成功");

                int val = 0;
                while (callThreadFlag)
                {
                    try
                    {
                        val++;
                        if (val > (5 * 600))
                        {//日志可查看线程是否还在运行
                            val = 0;
                            Log.Debug($"命令线程轮询中");
                        }
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
                                    //startPreviewWindow();
                                }
                                break;
                            case CallUserCommand.StopPreview:
                                {
                                    //Log.Info("停止预览开始");
                                    //if (currentVideoPreviewOpParam != null)
                                    //{
                                    //    currentVideoPreviewOpParam.window.handle.Dispose();
                                    //    currentVideoPreviewOpParam.window.Dispose();
                                    //    currentVideoPreviewOpParam.Dispose();
                                    //    currentVideoPreviewOpParam = null;
                                    //}
                                    //if (videoDevInfos != null)
                                    //{
                                    //    videoDevInfos.Dispose();
                                    //    videoDevInfos = null;
                                    //}
                                    //if (video != null)
                                    //{
                                    //    video.stop();
                                    //    // ringBack.ringStop();
                                    //    video.Dispose();
                                    //}
                                    //if (window != null)
                                    //{                                        
                                    //    window.Dispose();
                                    //}
                                    //Log.Info("停止预览成功");
                                }
                                break;
                            case CallUserCommand.MakeCall:
                                {
                                    try
                                    {
                                        lock (currentCallLock)
                                        {
                                            if (call != null)
                                            {
                                                var status = call.getInfo();
                                                if (status != null && status.media != null && status.media.Count > 0 && status.media[0].status == pjsua_call_media_status.PJSUA_CALL_MEDIA_ACTIVE)
                                                {
                                                    Log.Info($"正在通话中不允许拨打电话");
                                                    return;
                                                }
                                            }
                                            Log.Info($"开始拨打电话:{remoteIP}");
                                            if (call != null)
                                            {
                                                call.Dispose();
                                                call = null;
                                            }
                                            int tmpId = -1;
                                            if (!FindCamera(out tmpId))
                                            {
                                                Log.Info($"开始拨打电话:{remoteIP} 失败");
                                                break;
                                            }
                                            //弃用方法
                                            //call = new UserCall(userAccount, threadValue.RemoteHandle);
                                            call = new UserCall(userAccount, VideoViewInfo.RemoteView);
                                            call.LocalvideoViewInfo = VideoViewInfo.LocalView;

                                            if (callOpParam != null)
                                            {
                                                callOpParam.Dispose();
                                            }
                                            callOpParam = new CallOpParam(true);
                                            var remoteSipUri = $"sip:{remoteIP}";
                                            call.OnDisconnectedCall += Call_OnDisconnectedCall;
                                            //call.OnStartPreview += Call_OnStartPreview;
                                            call.makeCall(remoteSipUri, callOpParam);
                                        }
                                        Log.Info($"拨打电话:{remoteIP}成功");
                                    }
                                    catch (Exception ex)
                                    {
                                        Log.Error($"拨打电话异常：{ex}");
                                    }
                                }
                                break;
                            case CallUserCommand.HangCall:
                                {
                                    Log.Info($"开始挂断电话");
                                    ringBack.ringStop();
                                    lock (currentCallLock)
                                    {
                                        if (call != null)
                                        {
                                            if (call.isActive())
                                            {
                                                if (callOpParam != null)
                                                {
                                                    callOpParam.Dispose();
                                                }
                                                if (call.videoPreview != null)
                                                {
                                                    call.videoPreview.stop();
                                                    call.videoPreview.Dispose();
                                                    call.videoPreview = null;
                                                }
                                                callOpParam = new CallOpParam(true);
                                                call.hangup(callOpParam);
                                                callOpParam.Dispose();
                                                call.Dispose();

                                                //call = null;
                                            }
                                        }
                                        call = null;
                                    }
                                    Log.Info($"挂断电话成功");
                                }
                                break;
                            case CallUserCommand.AnswerCall:
                                {
                                    Log.Info($"开始接听电话");
                                    var e = incommingParam;
                                    //startPreviewWindow();
                                    ringBack.ringStop();
                                    lock (currentCallLock)
                                    {
                                        call.viewInfo = VideoViewInfo.RemoteView;
                                        call.LocalvideoViewInfo = VideoViewInfo.LocalView;
                                        if (callOpParam != null)
                                        {
                                            callOpParam.Dispose();
                                        }
                                        callOpParam = new CallOpParam(true);
                                        //callOpParam.opt.videoCount = 1;
                                        int tmpId = -1;
                                        if (!FindCamera(out tmpId))
                                        {
                                            callOpParam.statusCode = pjsip_status_code.PJSIP_SC_REJECTED;
                                            call.answer(this.callOpParam);
                                            HangCall();
                                            break;
                                        }
                                        callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
                                        call.answer(this.callOpParam);

                                    }
                                    ////call = new UserCall(e.InCommingAccount, threadValue.RemoteHandle,e.InCommingCallId);
                                    //call = new UserCall(e.InCommingAccount, VideoViewInfo.RemoteView, e.InCommingCallId);
                                    //call.OnDisconnectedCall += Call_OnDisconnectedCall;
                                    ////call.RemoteViewHandle = threadValue.RemoteHandle;
                                    //if (callOpParam != null)
                                    //{
                                    //    callOpParam.Dispose();
                                    //}
                                    //callOpParam = new CallOpParam(true);
                                    //callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
                                    //call.answer(callOpParam);

                                    Log.Info($"接听电话成功");

                                }
                                break;
                            //case CallUserCommand.InCommingCall:
                            //    {
                            //        if (inComming != null)
                            //        {
                            //            Log.Info("接听到电话");
                            //            lock (currentCallLock)
                            //            {
                            //                if (call != null)
                            //                {
                            //                    if (call.isActive())
                            //                    {
                            //                        var param = new CallOpParam(true);
                            //                        inComming.InCommingCall.hangup(param);
                            //                        inComming.InCommingCall.Dispose();
                            //                        param.Dispose();
                            //                        param = null;
                            //                        inComming = null;
                            //                    }
                            //                    else
                            //                    {
                            //                        call.OnDisconnectedCall -= Call_OnDisconnectedCall;
                            //                        call.Dispose();
                            //                        call = null;

                            //                    }

                            //                }
                            //                if (OnReceiveInCommingCall != null)
                            //                {
                            //                    OnReceiveInCommingCall(this, new EventArgs());
                            //                }
                            //                call = inComming.InCommingCall;
                            //                call.OnDisconnectedCall += Call_OnDisconnectedCall;
                            //                ringBack.ringStart();
                            //                int tmpId = -1;
                            //                if (!FindCamera(out tmpId))
                            //                {
                            //                    HangCall();
                            //                    //return;
                            //                }
                            //            }
                            //        }
                            //    }
                            //    break;
                            case CallUserCommand.SendMesssage:
                                {
                                    Log.Info($"开始发送消息：{messageRemoteIP}");
                                    UserBuddy sendBuddy;
                                    if (string.IsNullOrEmpty(messageRemoteIP))
                                    {
                                        break;
                                    }
                                    if (!buddyDics.ContainsKey(messageRemoteIP))
                                    {
                                        BuddyConfig buddyConfig = new BuddyConfig();
                                        buddyConfig.uri = $"sip:{messageRemoteIP}";

                                        UserBuddy buddy = new UserBuddy();
                                        buddy.create(userAccount, buddyConfig);
                                        buddy.subscribePresence(true);
                                        buddy.OnBuddyStateChange += Buddy_OnBuddyStateChange;
                                        //buddy.BuddyInfo = buddy.getInfo();
                                        buddyDics.Add(messageRemoteIP, buddy);

                                        sendBuddy = buddy;
                                        buddyConfig.Dispose();
                                    }
                                    else
                                    {
                                        sendBuddy = buddyDics[messageRemoteIP];
                                    }
                                    //MessageModel message = new MessageModel();

                                    SendInstantMessageParam im = new SendInstantMessageParam();
                                    im.content = message;//Newtonsoft.Json.JsonConvert.SerializeObject(message);
                                    im.contentType = "text/plain";
                                    sendBuddy.sendInstantMessage(im);
                                    im.Dispose();
                                    Log.Info($"发送消息成功");
                                }
                                break;
                            case CallUserCommand.GetVolume:
                                {

                                    GetVolumeValue = (int)ep.audDevManager().getOutputVolume();
                                    if (OnVolumeChange != null)
                                        OnVolumeChange(null, new VolumeChangedEventArgs(GetVolumeValue));
                                    //GetVolumeValue = (int)ep.audDevManager().getOutputLatency();
                                    //Debug.Write(GetVolumeValue);
                                    //var bb = ep.audDevManager().getOutputSignal();
                                    //ep.audDevManager().setOutputVolume((uint)0, true);
                                }
                                break;
                            case CallUserCommand.SetVolume:
                                {
                                    // GetVolumeValue = (int)ep.audDevManager().getOutputVolume();
                                    ep.audDevManager().setOutputVolume((uint)SetVolumeValue, true);
                                    GetVolumeValue = (int)ep.audDevManager().getOutputVolume();
                                    if (OnVolumeChange != null)
                                        OnVolumeChange(null, new VolumeChangedEventArgs(GetVolumeValue));
                                }
                                break;
                            case CallUserCommand.PlayVoice:
                                {
                                    ringBack.ringStart();
                                }
                                break;
                            case CallUserCommand.StopVoice:
                                {
                                    ringBack.ringStop();
                                }
                                break;
                            case CallUserCommand.GetMicLevel:
                                {
                                    lock (currentCallLock)
                                    {
                                        if (call != null && call.isActive())
                                        {
                                            var level = call.GetMicLevel();
                                            if (OnMicChange != null)
                                            {
                                                OnMicChange(null, new MicChangedEventArgs(level));
                                            }
                                        }
                                    }
                                }
                                break;
                            case CallUserCommand.SetMicLevel:
                                {
                                    lock (currentCallLock)
                                    {
                                        if (call != null && call.isActive())
                                        {
                                            call.SetMicLevel(MicLevel);
                                            var level = call.GetMicLevel();
                                            if (OnMicChange != null)
                                            {
                                                OnMicChange(null, new MicChangedEventArgs(level));
                                            }
                                        }
                                    }
                                }
                                break;
                            case CallUserCommand.ExitThread:
                                {

                                    callThreadFlag = false;
                                }
                                break;
                            case CallUserCommand.ShowPrev:
                                {
                                    if (window != null)
                                        window.Show(true);
                                }
                                break;
                            case CallUserCommand.HidePrev:
                                {
                                    if (window != null)
                                        window.Show(false);
                                }
                                break;
                            default:
                                Thread.Sleep(200);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //_log.WriteErrLog($"音视频异常：{ex}");
                        //Thread.Sleep(200);                        
                        //throw ex;
                        Log.Error(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {

                Log.Info($"开始退出线程");
                lock (currentCallLock)
                {
                    if (call != null)
                    {
                        call.Dispose();
                        call = null;
                    }
                }
                if (ringBack != null)
                {
                    ringBack.Dispose();
                }
                if (buddyDics != null && buddyDics.Count > 0)
                {
                    foreach (var item in buddyDics)
                    {
                        item.Value.Dispose();
                    }
                }
                if (userAccount != null)
                    userAccount.Dispose();
                if (ep != null)
                {
                    ep.hangupAllCalls();
                    ep.libStopWorkerThreads();
                    ep.libDestroy();
                    ep.Dispose();
                    ep = null;
                }
                Log.Info($"退出线程完毕！");
            }

        }

        private void Call_OnStartPreview(object sender, EventArgs e)
        {
            StartPreview();

        }

        /// <summary>
        /// 带外消息发送结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserAccount_OnSendMessageResult(object sender, MessageResultEventArgs e)
        {

            if (OnSendMessageResult != null)
            {
                OnSendMessageResult(sender, e);
            }
        }

        /// <summary>
        /// 接收到消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserAccount_OnInCommingMessage(object sender, InCommingMessageEventArgs e)
        {
            if (OnReceiveMessage != null)
            {
                OnReceiveMessage(sender, e);
            }

        }

        /// <summary>
        /// 伙伴在线状态变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buddy_OnBuddyStateChange(object sender, BuddyStateEventArgs e)
        {
            //Debug.WriteLine($"{e.Info.uri}->{e.Info.presStatus.statusText}");
            //lock (lockBuddyDics)
            //{
            //    foreach (var item in buddyDics)
            //    {
            //        if (e.Info.uri.Contains(item.Key))
            //        {
            //            item.Value.BuddyInfo = e.Info;
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserAccount_OnInCommingCall(object sender, InCommingCallEventArgs e)
        {
            try
            {
                //InCommingCall(e);
                Log.Info("接听到电话");
                incommingParam = e;
                lock (currentCallLock)
                {
                    if (call != null)
                    {
                        if (call.isActive())
                        {
                            var param = new CallOpParam(true);
                            e.InCommingCall.hangup(param);
                            e.InCommingCall.Dispose();
                            param.Dispose();
                            param = null;
                            e = null;
                            return;
                        }
                        call.Dispose();
                        call.OnDisconnectedCall -= Call_OnDisconnectedCall;
                        call = null;

                    }
                    if (OnReceiveInCommingCall != null)
                    {
                        OnReceiveInCommingCall(this, new EventArgs());
                    }
                    call = e.InCommingCall;
                    call.OnDisconnectedCall += Call_OnDisconnectedCall;
                }
                ringBack.ringStart();
                int tmpId = -1;
                if (!FindCamera(out tmpId))
                {
                    HangCall();
                    return;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"接收到来电异常：{ex}");
            }

        }

        private void Call_OnDisconnectedCall(object sender, EventArgs e)
        {
            try
            {
                //call.hangup(callOpParam);
                Log.Info("挂断电话");
                if (OnDisconnectedCall != null)
                {
                    OnDisconnectedCall(this, e);
                }
                lock (currentCallLock)
                {
                    if (call != null)
                    {

                        if (callOpParam != null)
                        {
                            callOpParam.Dispose();
                        }
                        if (call.videoPreview != null)
                        {
                            call.videoPreview.stop();
                            call.videoPreview.Dispose();
                            call.videoPreview = null;
                        }
                        call.OnDisconnectedCall -= Call_OnDisconnectedCall;
                        call.Dispose();
                        call = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Info($"挂断电话异常：{ex}");
            }
        }
        /// <summary>
        /// 根据摄像头名称查找摄像头
        /// </summary>
        /// <param name="name">摄像头名称</param>
        /// <param name="id">摄像头ID</param>
        /// <returns></returns>
        private bool FindCamera(out int id)
        {
            var videoDev = ep.vidDevManager().enumDev2();
            id = -1;
            foreach (var item in videoDev)
            {
                Log.Info($"摄像头名称：{item.name}");
                if (item.name.ToLower() == CameraName.ToLower())
                {
                    Log.Info($"找到摄像头：name:{item.name}-ID:{item.id}");
                    id = item.id;
                    return true;
                }
            }
            if (OnNoCamera != null)
            {
                Log.Info($"未找到摄像头，名称：{CameraName}");
                OnNoCamera(null, new CameraNotFountEventArgs(CameraName));
            }
            return false;
        }
        private void startPreviewWindow()
        {
            Log.Info("启动预览窗口");
            if (videoDevInfos != null)
            {
                videoDevInfos.Dispose();
                videoDevInfos = null;
            }
            videoDevInfos = Endpoint.instance().vidDevManager().enumDev2();
            //var epdev = Endpoint.instance().vidDevManager().enumDev2();
            if (video != null)
                video.Dispose();
            //video = new VideoPreview(epdev[0].id);
            //video = new VideoPreview(videoDevInfos[0].id);
            video = new VideoPreview((int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_CAPTURE_DEV);

            if (currentVideoPreviewOpParam != null)
            {
                currentVideoPreviewOpParam.window.handle.Dispose();
                currentVideoPreviewOpParam.window.Dispose();
                currentVideoPreviewOpParam.Dispose();
                currentVideoPreviewOpParam = null;
            }
            //foreach (var item in videoDevInfos)
            //{
            //    Log.Info($"id-{item.id},name-{item.name},dir-{item.dir},caps-{item.caps},driver-{item.driver},fmt-{item.fmt}");
            //}
            currentVideoPreviewOpParam = new VideoPreviewOpParam();
            var tt = currentVideoPreviewOpParam.format;
            currentVideoPreviewOpParam.rendId = (int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            //videoDevInfos[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            //epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            currentVideoPreviewOpParam.window = new VideoWindowHandle();
            currentVideoPreviewOpParam.window.handle = new WindowHandle();
            currentVideoPreviewOpParam.show = false;
            currentVideoPreviewOpParam.window.handle.setWindow(VideoViewInfo.LocalView.Handle);
            //currentVideoPreviewOpParam.window.handle.setWindow(threadValue.LocalHandle);

            video.start(currentVideoPreviewOpParam);

            var tmp = video.getVideoMedia().getPortInfo().format;
            Log.Debug("预览窗口启动成功");
            //VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
            //videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
            //videoPreviewOpParam.window = new VideoWindowHandle();
            //videoPreviewOpParam.window.handle = new WindowHandle();
            //videoPreviewOpParam.show = true;
            //videoPreviewOpParam.window.handle.setWindow(threadValue.LocalHandle);

            //video.start(videoPreviewOpParam);
            if (window != null)
            {
                window.Dispose();
            }

            window = video.getVideoWindow();
            MediaSize size = new MediaSize();
            //size.h = (uint)300;// this.panelCamera.Height;
            //size.w = (uint)400;//this.panelCamera.Width;
            size.h = (uint)VideoViewInfo.LocalView.Height;
            size.w = (uint)VideoViewInfo.LocalView.Width;
            window.setSize(size);
            //window.Show(false);
            Log.Debug("预览窗口设置成功");
            size.Dispose();
            isStopPreview = false;
        }
    }
}
