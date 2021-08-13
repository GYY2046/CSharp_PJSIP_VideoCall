using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    
    public class UserCall : Call
    {
        public event EventHandler<EventArgs> OnCallDisconnected;
        public long RemoteViewHandle { get; set; }
        private bool _disposed = false;
        private RingBack ringBack;
        public UserCall(Account account, long handle,int callId = -1) : base(account,callId)
        {
            RemoteViewHandle = handle;
            ringBack = new RingBack();
        }

        public UserCall(Account account,int callId):base(account,callId)
        {      
        }

        public override void onCallState(OnCallStateParam prm)
        {
            //CallOpParam callOpParam = new CallOpParam(true);
            //callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
            //this.answer(callOpParam);
            
            var callInfo = getInfo();
            if (callInfo.state == pjsip_inv_state.PJSIP_INV_STATE_DISCONNECTED)
            {
                if (OnCallDisconnected != null)
                {
                    OnCallDisconnected(this, new EventArgs);
                }
            }
                //}else if(callInfo.state == pjsip_inv_state.PJSIP_INV_STATE_CALLING || callInfo.state == pjsip_inv_state.PJSIP_INV_STATE_INCOMING)
                //{
                //    if (ringBack != null)
                //        ringBack.ringStart();
                //}
                //else if(callInfo.state == pjsip_inv_state.PJSIP_INV_STATE_CONFIRMED || callInfo.state == pjsip_inv_state.PJSIP_INV_STATE_CONNECTING)
                //{
                //    if (ringBack != null)
                //        ringBack.ringStop();
                //}
           base.onCallState(prm);
        }    

        public override void onCallMediaState(OnCallMediaStateParam prm)
        {
            var ci = getInfo();
            for (uint i = 0; i < ci.media.Count; i++)
            {
                if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_AUDIO)
                {
                    var media = getAudioMedia((int)i);

                    if (media != null)
                    {
                        AudioMedia aud_med = (AudioMedia)media;
                        AudDevManager mgr = Endpoint.instance().audDevManager();
                        aud_med.startTransmit(mgr.getPlaybackDevMedia());
                        mgr.getCaptureDevMedia().startTransmit(aud_med);
                    }
                }
                else if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_VIDEO)
                {
                    var callID = ci.id;
                    //获取远程视频信息
                    var inCommingWid = ci.media[(int)i].videoWindow;

                    var window = new VideoWindowHandle();
                    window.handle = new WindowHandle();
                    //window.handle.setWindow(Form1.RemoteVideoPanelHandle);                  
                    window.handle.setWindow(RemoteViewHandle);
                    //设置远程视频的显示窗体
                    inCommingWid.setWindow(window);

                    //var epdev = Endpoint.instance().vidDevManager().enumDev2();
                    //VideoPreview video = new VideoPreview(epdev[0].id);
                    //VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
                    //videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
                    //videoPreviewOpParam.window = new VideoWindowHandle();
                    //videoPreviewOpParam.window.handle = new WindowHandle();

                    ////videoPreviewOpParam.window.type = new SWIGTYPE_p_pjmedia_vid_dev_hwnd_type((long)1);

                    //videoPreviewOpParam.show = true;


                    //videoPreviewOpParam.window.handle.setWindow(Form1.LocalVideoPanelHandle);
                    //video.start(videoPreviewOpParam);

                    //var call_dec_port = getDecodingVideoMedia(-1);
                    //var call_enc_port = getEncodingVideoMedia(-1);
                    //var mgr = Endpoint.instance().vidDevManager();


                    //VideoMediaTransmitParam transmit_param = new VideoMediaTransmitParam();
                    //call_dec_port.startTransmit(call_enc_port, transmit_param);
                    ////call_enc_port.startTransmit(inCommingWid.getVideoMedia(), transmit_param);
                    //inCommingWid.Show(true);


                    //var info = ci.media[(int)i].videoWindow.getInfo();
                    //var window = new VideoWindow(info.renderDeviceId);

                    //window.Show(true);
                    //VideoMediaTransmitParam transmit_param = new VideoMediaTransmitParam();
                    //var remoteMedia = getDecodingVideoMedia((int)i);
                    //var localMedia = getEncodingVideoMedia((int)i);
                    //remoteMedia.startTransmit(localMedia, transmit_param);
                    ////localMedia.startTransmit(remoteMedia, transmit_param);
                    //var remoteVideoWindow = ci.media[(int)i].videoWindow;
                    //var window = new VideoWindowHandle();
                    //window.handle = new WindowHandle();
                    //window.handle.setWindow(Form1.RemoteVideoPanelHandle);
                    //remoteVideoWindow.setWindow(window);
                    //remoteVideoWindow.Show(true);
                    //if (videoMedia != null)
                    //{


                    //    var devMgr = Endpoint.instance().vidDevManager();
                    //    var list = devMgr.enumDev2();

                    //    //ci.media[(int)i]
                    //    var vidId = vidGetStreamIdx();
                    //    var cap = ci.media[vidId].videoCapDev;

                    //    var remoteVideoWindow = ci.media[(int)i].videoWindow;
                    //    var remoteMedia = remoteVideoWindow.getVideoMedia();

                    //    var window = new VideoWindowHandle();
                    //    window.handle = new WindowHandle();
                    //    window.handle.setWindow(Form1.RemoteVideoPanelHandle);
                    //    remoteVideoWindow.setWindow(window);
                    //    remoteVideoWindow.Show(true);


                    //    //VideoPreview video = new VideoPreview(epdev[0].id);
                    //    //VideoPreviewOpParam videoPreviewOpParam = new VideoPreviewOpParam();
                    //    //videoPreviewOpParam.rendId = epdev[1].id;//(int)pjmedia_vid_dev_std_index.PJMEDIA_VID_DEFAULT_RENDER_DEV;
                    //    //videoPreviewOpParam.window = new VideoWindowHandle();
                    //    //videoPreviewOpParam.window.handle = new WindowHandle();

                    //    ////videoPreviewOpParam.window.type = new SWIGTYPE_p_pjmedia_vid_dev_hwnd_type((long)1);

                    //    //videoPreviewOpParam.show = true;


                    //    //videoPreviewOpParam.window.handle.setWindow(ptr);
                    //    //video.start(videoPreviewOpParam);
                    //}


                }

                base.onCallMediaState(prm);
            }

        }

        public new void  Dispose()
        {
            Dispose(true);
            base.Dispose();
            GC.SuppressFinalize(this); //标记gc不在调用析构函数
        }
        ~UserCall()
        {
            Dispose(false);
        }

        private new void Dispose(bool disposing)
        {
            if (_disposed) return; //如果已经被回收，就中断执行
            if (disposing)
            {
                base.Dispose();
            }
            _disposed = true;
        }
    }
}
