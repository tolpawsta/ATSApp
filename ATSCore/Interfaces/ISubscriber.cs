using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface ISubscriber
    {
        ITerminal terminal { get; set; }
        string FullName { get; }
        ITariffPlan tariffPlan { get; set; }
       SubscriberState subscriberState { get; }
        IEnumerable<CallInfo> GetAllCalls { get; }
        IEnumerable<CallInfo> GetCallsBy(Func<CallInfo,bool> predicate);


    }
}
