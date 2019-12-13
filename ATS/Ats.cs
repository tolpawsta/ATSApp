using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Ats : IAts
    {
        IList<string> phoneNumbers;
        Dictionary<IPort, ITerminalable> portTerminalPairs;
        IList<ISubscriber> subscribers { get; set; }
        IList<IRatePlan> ratePlans;
        public Ats()
        {
            subscribers = new List<ISubscriber>();
            ratePlans = new List<IRatePlan>();
        }
        public ISubscriber ConcludeContractWith(IClientable client)
        {
            subscribers.Add(client);
        }
    }
}
