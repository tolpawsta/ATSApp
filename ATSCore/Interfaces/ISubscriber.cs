using ATSCore.EntityStates;
using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface ISubscriber
    {
        int PhoneNumber { get; }
        IContract Contract { get; }
        ITerminal Terminal { get; set; }
        IPort Port { get; set; }
        string FullName { get; }
        ITariffPlan TariffPlan { get; set; }
        SubscriberState subscriberState { get; set; }
        IEnumerable<CallInfo> GetAllCalls { get; }
        IEnumerable<CallInfo> GetCallsBy(CallType callType);
        IEnumerable<CallInfo> GetCallsBy(int phoneNumber);
        decimal AccountMoney { get; set; }
        void Call(int phoneNumber);
        void Reject();
        void Answer();
        void Drop();



    }
}
