using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface IBilling
    {
        void AddSubscriber(ISubscriber subscriber);
        IEnumerable<ISubscriber> Subscribers { get; }
        IList<IContract> Contracts { get; set; }
        ISubscriber GetSubscriberBy(int sourcePhoneNumber);
        double GetLimitCallDuraction(ISubscriber subscriber);
        void CommitCall(CallInfo callInfo);
        IEnumerable<CallInfo> GetAllCallsOrderedByDuraction(ISubscriber subscriber);
        IEnumerable<CallInfo> GetAllSubscriberInComingCalls(ISubscriber subscriber);
        
    }
}
