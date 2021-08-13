using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pj_csharp_console_demo
{
    public class MyAccount : Account
    {
        ~MyAccount()
        {
            Console.WriteLine("*** Account is being deleted");
        }
        public override void onRegState(OnRegStateParam prm)
        {
            base.onRegState(prm);
            AccountInfo ai = getInfo();
            Console.WriteLine("***" + (ai.regIsActive ? "" : "Un") +
                          "Register: code=" + prm.code);
        }

        public override void onIncomingCall(OnIncomingCallParam prm)
        {
            base.onIncomingCall(prm);
            var call = new MyCall(this, prm.callId);
            var callOpParam = new CallOpParam();
            callOpParam.statusCode = pjsip_status_code.PJSIP_SC_OK;
            call.answer(callOpParam);
        }
    }

    public class MyLogWriter : LogWriter
    {
        override public void write(LogEntry entry)
        {
            Console.WriteLine(entry.msg);
        }
    }
    class MyCall : Call
    {
        public MyCall(Account acc, int call_id) : base(acc, call_id) { }

        public MyCall(Account acc) : base(acc) { }

        public override void onCallState(OnCallStateParam prm)
        {
            base.onCallState(prm);
            var ci = this.getInfo();
            if (ci.state == pjsip_inv_state.PJSIP_INV_STATE_DISCONNECTED)
            {
                Dispose();
            }
        }

        public override void onCallMediaState(OnCallMediaStateParam prm)
        {
            base.onCallMediaState(prm);
            var ci = getInfo();
            for (uint i = 0; i < ci.media.Count; i++)
            {
                if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_AUDIO)
                {
                    var media = getAudioMedia((int)i);
                   
                    if (media != null)
                    {
                        AudioMedia aud_med = (AudioMedia)media;
                        AudDevManager mgr = Program.ep.audDevManager();
                        aud_med.startTransmit(mgr.getPlaybackDevMedia());
                        mgr.getCaptureDevMedia().startTransmit(aud_med);
                    }
                }
                else if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_VIDEO)
                {
                    var videoMedia = getDecodingVideoMedia((int)i); 

                }


                //if (ci.media[(int)i].type == pjmedia_type.PJMEDIA_TYPE_AUDIO)
                //{
                     
                //    var audMed = AudioMedia.typecastFromMedia(this.getMedia(i));
                //    var mgr = Endpoint.instance().audDevManager();
                //    audMed.startTransmit(mgr.getPlaybackDevMedia());
                //    mgr.getCaptureDevMedia().startTransmit(audMed);
                //}
                //else
                //{
                //    throw new ApplicationException("现在仅支持音频哦亲");
                //}
            }
        }
    }
    class Program
    {
        public static Endpoint ep;
        static void Main(string[] args)
        {

            try
            {
                string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                //获取和设置当前目录(该进程从中启动的目录)的完全限定目录
                string path2 = System.Environment.CurrentDirectory;
                //获取应用程序的当前工作目录
                string path3 = System.IO.Directory.GetCurrentDirectory();
                ep = new Endpoint();

                ep.libCreate();
                MyLogWriter writer = new MyLogWriter();
                // Init library
                EpConfig epConfig = new EpConfig();
                epConfig.logConfig.writer = writer;
                ep.libInit(epConfig);
                //var devList = ep.vidDevManager().enumDev2();
                //Window window = Window.GetWindow(this);
                //var wih = new WindowInteropHelper(window);
                //IntPtr hWnd = wih.Handle;
                // Create transport
                TransportConfig tcfg = new TransportConfig();
                tcfg.port = 5060;
                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP,
                           tcfg);
                ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP,
                           tcfg);

                // Start library
                ep.libStart();
                Console.WriteLine("*** PJSUA2 STARTED ***");

                // Add account
                AccountConfig accCfg = new AccountConfig();
                accCfg.idUri = "sip:169.254.119.169";
                accCfg.regConfig.registrarUri = "sip:169.254.119.169";
                accCfg.sipConfig.authCreds.Add(
                    new AuthCredInfo("digest", "*", "1001", 0, "1001"));
                MyAccount acc = new MyAccount();
                acc.create(accCfg);
                MyCall call = new MyCall(acc);
                CallOpParam callOpParam = new CallOpParam();
                callOpParam.opt = new CallSetting();

                call.makeCall("sip:169.254.105.220", callOpParam);
                Console.ReadKey();

                Console.WriteLine("*** DESTROYING PJSUA2 ***");
                // Explicitly delete account when unused
                acc.Dispose();
                ep.libDestroy();
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine("Exception: " + err.Message);
            }
            Console.ReadKey();
        }
    }
}
