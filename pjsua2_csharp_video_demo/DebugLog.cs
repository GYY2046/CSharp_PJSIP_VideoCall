using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class DebugLog : LogWriter
    {
        
        override public void write(LogEntry entry)
        {
            Debug.WriteLine($"{entry.level} - {entry.msg}");
            //Console.WriteLine(entry.msg);
        }

    }
}
