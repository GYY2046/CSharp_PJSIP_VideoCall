using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class UserCall : Call
    {
        public long RemoteViewHandle { get; set; }
        public event EventHandler<EventArgs> OnDisconnectedCall;
        //public event EventHandler<EventArgs> OnStartPreview;
        private bool _disposed = false;
        //private RingBack ringBack;
        private VideoWindow currentVideo;
        private AudioMedia currentAudio;
        private AudDevManager currentAudDev;
        private VideoWindowHandle currentVideoWindow;
        public  VideoViewInfo viewInfo;
        public VideoViewInfo LocalvideoViewInfo;
        public VideoPreview videoPreview;
        //public UserCall(Account account, long handle,int callId = -1) : base(account,callId)
        public UserCall(Account account, VideoViewInfo videoViewInfo, int callId = -1) : base(account, callId)
        {
            // RemoteViewHandle = handle;
            viewInfo = videoViewInfo;
            //ringBack = new RingBack();
        }

        public UserCall(Account account,int callId):base(account,callId)
        {      
        }
        /// <summary>
        /// 获取本地麦克风级别
        /// </summary>
        /// <returns></returns>
        public float GetMicLevel()
        {
            if (currentAudio != null)
            {
                return (float)currentAudio.getRxLevel();
            }
            else
                return (float)0;
        }
        /// <summary>
        /// 设置麦克风级别
        /// </summary>
        /// <param name="level"></param>
        public void SetMicLevel(float level)
        {
            if(currentAudio != null)
            {
                //currentAudio.adjustRxLevel(level);
                currentAudio.adjustRxLevel(level);
            }
        }

        public override void onCallState(OnCallStateParam prm)
        {
            var infor = getInfo();
            if (infor.state == pjsip_inv_state.PJSIP_INV_STATE_DISCONNECTED)
            {
                if(currentVideoWindow!= null)
                {
                    currentVideoWindow.Dispose();
                    currentVideoWindow = null;
                }
                if (currentAudDev != null)
                {
                    currentAudDev.Dispose();
                    currentAudDev = null;
                }
                if(currentAudio!= null)
                {
                    currentAudio.Dispose();
                    currentAudio = null;
                }
                if(currentVideo != null)
                {
                    currentVideo.Dispose();
                    currentVideo = null;
                }
                //if (videoPreview != null)
                //{
                //    videoPreview.stop();
                //    videoPreview.Dispose();
                //    videoPreview = null;
                //}
                if (OnDisconnectedCall != null)
                {
                    OnDisconnectedCall(this, new EventArgs());
                }
            }
            base.onCallState(prm); 
        }    

        public override void onCallMediaState(OnCallMediaStateParam prm)
        {
            var ci = getInfo();
            for (uint i = 0; i < ci.media.Count; i++)
            {
                if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_AUDIO)
                {
                    if (currentAudio != null)
                        currentAudio.Dispose();
                    currentAudio= getAudioMedia((int)i);

                    if (currentAudio != null)
                    {
                        //AudioMedia aud_med = (AudioMedia)currentAudio;
                        if(currentAudDev!= null)
                        {
                            currentAudDev.Dispose();
                        }
                        //currentAudDev = Endpoint.instance().audDevManager();
                        currentAudDev = Endpoint.instance().audDevManager();
                        currentAudio.startTransmit(currentAudDev.getPlaybackDevMedia());
                        //currentAudio.adjustRxLevel(0.0f);
                        currentAudDev.getCaptureDevMedia().startTransmit(currentAudio);


                        //AudDevManager mgr = Endpoint.instance().audDevManager();
                        //mgr = Endpoint.instance().audDevManager();
                        //currentAudio.startTransmit(mgr.getPlaybackDevMedia());
                        //mgr.getCaptureDevMedia().startTransmit(currentAudio);
                        //aud_med.Dispose();
                    }
                }
                else if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_VIDEO)
                {
                    var callID = ci.id;
                    //获取远程视频信息
                    if (currentVideo != null)
                    if (currentVideo != null)
                            currentVideo.Dispose();
                    currentVideo = ci.media[(int)i].videoWindow;
                    //var dir = ci.media[(int)i].dir;
                    if (currentVideoWindow!= null)
                    {                        
                        currentVideoWindow.handle.Dispose();
                        currentVideoWindow.Dispose();
                    }

                    //var encMedia = getEncodingVideoMedia(-1);
                    //var decMedia = getDecodingVideoMedia(-1);
                    //decMedia.startTransmit(encMedia, new VideoMediaTransmitParam());

                    //开始将采集到的视频流推送到远端
                    vidSetStream(pjsua_call_vid_strm_op.PJSUA_CALL_VID_STRM_START_TRANSMIT,new CallVidSetStreamParam());
                    currentVideoWindow = new VideoWindowHandle();
                    currentVideoWindow.handle = new WindowHandle();
                    //window.handle.setWindow(Form1.RemoteVideoPanelHandle);                  
                    //currentVideoWindow.handle.setWindow(RemoteViewHandle);
                    currentVideoWindow.handle.setWindow(viewInfo.Handle);
                    //设置接收到示视频流呈现窗口
                    MediaSize size = new MediaSize();
                    size.h = (uint)viewInfo.Height;
                    size.w = (uint)viewInfo.Width;
                    currentVideo.setSize(size);
                    //设置远程视频的显示窗体
                    currentVideo.setWindow(currentVideoWindow);
                    size.Dispose();


                    //var currentVideoPreviewOpParam = new VideoPreviewOpParam();
                    // currentVideoPreviewOpParam.rendId = (int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
                    // //videoDevInfos[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
                    // //epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
                    // currentVideoPreviewOpParam.window = new VideoWindowHandle();
                    // currentVideoPreviewOpParam.window.handle = new WindowHandle();
                    // currentVideoPreviewOpParam.show = true;
                    // //currentVideoPreviewOpParam.window.handle.setWindow(VideoViewInfo.LocalView.Handle);
                    // //currentVideoPreviewOpParam.window.handle.setWindow(threadValue.LocalHandle);

                    // video.start(currentVideoPreviewOpParam);
                    //video.getVideoWindow().getInfo().renderDeviceId
                    //var pId = currentVideo.getVideoMedia().getPortId();
                    //var reEncMeida = getEncodingVideoMedia(pId);
                    //decMedia.startTransmit(reEncMeida, new VideoMediaTransmitParam());
                    //.startTransmit(encMedia, new VideoMediaTransmitParam());


                    //获取本地采集的视频流并设置预览
                    videoPreview = new VideoPreview((int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_CAPTURE_DEV);
                    var currentVideoPreviewOpParam = new VideoPreviewOpParam();
                    //Debug时必须为False，不然报错，原因不清楚
                    currentVideoPreviewOpParam.show = false;
                    currentVideoPreviewOpParam.window = new VideoWindowHandle();
                    currentVideoPreviewOpParam.window.handle = new WindowHandle();
                    currentVideoPreviewOpParam.window.handle.setWindow(LocalvideoViewInfo.Handle);
                    //currentVideoPreviewOpParam.show = true;
                    videoPreview.start(currentVideoPreviewOpParam);
                    //video.getVideoWindow().Show(true);
                    //设置本地预览窗口
                    var localWindow = videoPreview.getVideoWindow();
                    MediaSize localSize = new MediaSize();
                    //size.h = (uint)300;// this.panelCamera.Height;
                    //size.w = (uint)400;//this.panelCamera.Width;
                    localSize.h = (uint)LocalvideoViewInfo.Height;
                    localSize.w = (uint)LocalvideoViewInfo.Width;
                    localWindow.setSize(localSize);
                    //window.Show(false);
                    localSize.Dispose();
                    localWindow.Dispose();
                    //if (OnStartPreview != null)
                    //    OnStartPreview(null, new EventArgs());

                }

                base.onCallMediaState(prm);
            }

        }

        public new void  Dispose()
        {

            Dispose(true);
            base.Dispose();
            GC.SuppressFinalize(this);         //标记gc不在调用析构函数
            

        }
        ~UserCall()
        {
            Dispose(false);
        }

        private new void Dispose(bool disposing)
        {

            lock (this)
            {
                if (_disposed) return; //如果已经被回收，就中断执行

                if (disposing)
                {
                    if (currentVideo != null)
                        currentVideo.Dispose();
                    if (currentAudio != null)
                        currentAudio.Dispose();
                    if (currentAudDev != null)
                        currentAudDev.Dispose();
                    if (currentVideoWindow != null)
                        currentVideoWindow.Dispose();
                    base.Dispose();
                }
                _disposed = true;
            }


        }
    }
}
