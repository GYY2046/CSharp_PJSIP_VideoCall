using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class pjsua2VideoCall
    {
        private Endpoint ep;

        public void Init()
        {
            ep = new Endpoint();
            ep.libCreate();

            EpConfig epConfig = new EpConfig();
            epConfig.logConfig.level = 6;
            epConfig.logConfig.writer = new DebugLog();

            ep.libInit(epConfig);

            TransportConfig tcfg = new TransportConfig();
            tcfg.port = 5060;

            ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_UDP, tcfg);
            ep.transportCreate(pjsip_transport_type_e.PJSIP_TRANSPORT_TCP, tcfg);
            // Start library
            ep.libStart();
        }

       
    }
}
