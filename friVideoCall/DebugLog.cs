
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class DebugLog : LogWriter
    {
        public log4net.ILog Log { get; set; }
        //public LogTrace Log { get; set; }
        override public void write(LogEntry entry)
        {
            Log.Debug($"{entry.level} - {entry.threadId} - {entry.threadName} - {entry.msg}");
            //Log.WriteLog($"{entry.level} - {entry.threadId} - {entry.threadName} - {entry.msg}");
            Debug.WriteLine($"{entry.level} - {entry.msg}");
            //Console.WriteLine(entry.msg);
        }

    }
}
