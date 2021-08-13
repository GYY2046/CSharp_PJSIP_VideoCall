using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class VideoHandleValue
    {
        /// <summary>
        /// 本地预览窗口
        /// </summary>
        public VideoViewInfo LocalView { get; set; }
        /// <summary>
        /// 远端预览窗口
        /// </summary>
        public VideoViewInfo RemoteView { get; set; }
        /// <summary>
        /// 弃用
        /// </summary>
        [Obsolete]
        public long LocalHandle { get; set; }
        /// <summary>
        /// 弃用
        /// </summary>
        [Obsolete]
        public long RemoteHandle { get; set; }
    }
    public class VideoViewInfo
    {
        public long Handle { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public enum FormReceiveCommand
    {
        /// <summary>
        /// 接收到来电
        /// </summary>
        ReceiveInCommingCall
    }
    public enum CallUserCommand
    {
        /// <summary>
        /// 启动预览窗口
        /// </summary>
        StartPreview,
        /// <summary>
        /// 停止预览并停止摄像头
        /// </summary>
        StopPreview,
        /// <summary>
        /// 接听
        /// </summary>
        AnswerCall,
        /// <summary>
        /// 拒绝
        /// </summary>
        RejectCall,
        /// <summary>
        /// 拨打
        /// </summary>
        MakeCall,
        /// <summary>
        /// 挂断
        /// </summary>
        HangCall,
        /// <summary>
        /// 发送及时消息
        /// </summary>
        SendMesssage,
        /// <summary>
        /// 退出线程
        /// </summary>
        ExitThread,
        /// <summary>
        /// 获得音量大小
        /// </summary>
        GetVolume,
        /// <summary>
        /// 设置音量大小
        /// </summary>
        SetVolume,
        /// <summary>
        /// 播放声音
        /// </summary>
        PlayVoice,
        /// <summary>
        /// 停止播放
        /// </summary>
        StopVoice,
        /// <summary>
        /// 获取麦克风级别
        /// </summary>
        GetMicLevel,
        /// <summary>
        /// 设置麦克风级别
        /// </summary>
        SetMicLevel,
        /// <summary>
        /// 显示预览
        /// </summary>
        ShowPrev,
        /// <summary>
        /// 隐藏预览
        /// </summary>
        HidePrev,
        /// <summary>
        /// 接听到电话
        /// </summary>
        InCommingCall,
        /// <summary>
        /// 默认命令，只做休眠不做任何操作
        /// </summary>
        Default
    }
}
