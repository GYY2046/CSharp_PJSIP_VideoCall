
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace friVideoCall
{
   public class InCommingCallEventArgs : EventArgs
    {
        public int InCommingCallId;
        public UserAccount InCommingAccount;
        public UserCall InCommingCall;
        public InCommingCallEventArgs(int callId,UserAccount inCommingAccount, UserCall inCall)
        {
            InCommingCallId = callId;
            InCommingAccount = inCommingAccount;
            InCommingCall = inCall;
        }
    }
    public class CameraNotFountEventArgs : EventArgs
    {
        public string CameraName { get; private set; }
        public CameraNotFountEventArgs(string name)
        {
            CameraName = name;
        }
    }
    public class VolumeChangedEventArgs : EventArgs
    {
        public int Volume { get; private set; }
        public VolumeChangedEventArgs(int v)
        {
            Volume = v;
        }
    }
    public class MicChangedEventArgs : EventArgs
    {
        public float Level { get; private set; }
        public MicChangedEventArgs(float v)
        {
            Level = v;
        }
    }    
    public class InCommingMessageEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public InCommingMessageEventArgs(string message)
        {
            Message = message;
        }
    }
    public class MessageResultEventArgs:EventArgs
    {
        public string Message { get; private set; }
        public bool Result { get; private set; }
        public MessageResultEventArgs(string message, bool result)
        {
            Message = message;
            Result = result;
        }
    }
    public class UserAccount : Account
    {
        public event EventHandler<InCommingCallEventArgs> OnInCommingCall;
        public event EventHandler<InCommingMessageEventArgs> OnInCommingMessage;
        public event EventHandler<MessageResultEventArgs> OnSendMessageResult;

        //public AutoResetEvent AnswerEvent;

        //public bool IsAnswer;
        //public long RemoteHandle { get; set; }
        //private RingBack ringBack;
        public UserAccount() : base()
        {
            //AnswerEvent = new AutoResetEvent(false);
            //IsAnswer = false;
            //ringBack = new RingBack();
        }
        public override void onRegState(OnRegStateParam prm)
        {
            base.onRegState(prm);
        }

        public override void onIncomingCall(OnIncomingCallParam prm)
        {           
            var call = new UserCall(this, prm.callId);
           
            var callOpParam = new CallOpParam(true);
            callOpParam.statusCode = pjsip_status_code.PJSIP_SC_RINGING;
            call.answer(callOpParam);

            if (OnInCommingCall != null)
            {
                OnInCommingCall(this, new InCommingCallEventArgs(prm.callId, this,call));
            }
            callOpParam.Dispose();


        }
        /// <summary>
        /// 接收到消息触发
        /// </summary>
        /// <param name="prm"></param>
        public override void onInstantMessage(OnInstantMessageParam prm)
        {
            if(OnInCommingMessage!= null)
            {
                var message =prm.msgBody;
                OnInCommingMessage(this, new InCommingMessageEventArgs(message));
            }
            //Debug.WriteLine($"{prm.fromUri} to {prm.toUri} content {prm.msgBody}");
            //base.onInstantMessage(prm);
        }
        /// <summary>
        /// 及时消息发送结果
        /// </summary>
        /// <param name="prm"></param>
        public override void onInstantMessageStatus(OnInstantMessageStatusParam prm)
        {
            if(OnSendMessageResult!=null)
            {
                var message = prm.msgBody;
                if (prm.code == pjsip_status_code.PJSIP_SC_OK)
                {
                   
                    OnSendMessageResult(this, new MessageResultEventArgs(message, true));
                }
                else
                {
                    OnSendMessageResult(this, new MessageResultEventArgs(message, false));
                }
            }
            //Debug.WriteLine($"{prm.toUri} to {prm.reason} content {prm.msgBody}");
           // Debug.WriteLine($"******************code: {prm.code.ToString()}");
            //base.onInstantMessageStatus(prm);
        }
    }
}
