using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class ThreadValue
    {
        public long LocalHandle { get; set; }
        public long RemoteHandle { get; set; }
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
        /// 退出线程
        /// </summary>
        ExitThread,
        /// <summary>
        /// 默认命令，只做休眠不做任何操作
        /// </summary>
        Default
    }
}
