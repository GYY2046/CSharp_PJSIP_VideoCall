using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
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
    public class UserAccount : Account
    {
        public event EventHandler<InCommingCallEventArgs> OnInCommingCall;
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
            AccountInfo accountInfo = getInfo();
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

            //call.Dispose();
            //ringBack.ringStart();
            //if (AnswerEvent.WaitOne(10000))
            //{
            //    if (IsAnswer)
            //    {
            //        callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
            //        call.answer(callOpParam);
            //    }
            //    else
            //    {
            //        callOpParam.statusCode = pjsip_status_code.PJSIP_SC_DECLINE;
            //        call.answer(callOpParam);
            //    }
            //}
            //else
            //{
            //    callOpParam.statusCode = pjsip_status_code.PJSIP_SC_BUSY_HERE;
            //    call.answer(callOpParam);
            //}
            //ringBack.ringStop();
            //base.onIncomingCall(prm);
        }
    }
}
