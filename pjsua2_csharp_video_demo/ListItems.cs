using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjsua2_csharp_video_demo
{
    public class ListItems
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public ListItems(string key,string value)
        {
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
}
