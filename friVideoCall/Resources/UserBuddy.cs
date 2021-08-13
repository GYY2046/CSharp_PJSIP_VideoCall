using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace friVideoCall
{
    public class UserBuddy : Buddy
    {
        public event EventHandler<BuddyStateEventArgs> OnBuddyStateChange;
        public BuddyInfo BuddyInfo { get; set; }
        public UserBuddy()
        {
        }
        public override void onBuddyState()
        {
            var bi = getInfo();

            Debug.WriteLine($"{bi.contact} {bi.presStatus.statusText}");
            if (OnBuddyStateChange != null)
            {
                OnBuddyStateChange(this, new BuddyStateEventArgs(bi));
            }
            base.onBuddyState();
        }
    }
    public class BuddyStateEventArgs :EventArgs
    {
        public BuddyStateEventArgs(BuddyInfo buddyInfo)
        {
            this.Info = buddyInfo;
        }
        public BuddyInfo Info { get;  }
    }
}
