using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore.Interfaces;
using BillingSystem.Impl;

namespace BillingSystem
{
    public class CallBillingSystem : IBilling
    {
        private IList<ISubscriber> _subscribers;
        public IEnumerable<ISubscriber> Subscribers => _subscribers;
        public IList<IContract> Contracts { get; set; }
        public CallBillingSystem()
        {
            _subscribers = new List<ISubscriber>();
        }

        public CallBillingSystem(IList<IContract> contracts):this()
        {
            this.Contracts = contracts;
        }

        public ISubscriber GetSubscriberBy(int sourcePhoneNumber)
        {
            ISubscriber subscriber = _subscribers.FirstOrDefault(s => s.Terminal.Port.PhoneNumber == sourcePhoneNumber);
            if (subscriber != null)
                subscriber.State = (subscriber.AccountMoney == 0) ? SubscriberState.Blocked : SubscriberState.Allowed;
            return subscriber;
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscriber.SetContact(Contracts.FirstOrDefault());
            Contracts.Remove(subscriber.Contract);
            _subscribers.Add(subscriber);
        }

        public double GetLimitCallDuraction(ISubscriber subscriber)
        {
            return Convert.ToDouble(subscriber.AccountMoney/subscriber.TariffPlan.CallCoastPerSec);
        }

        public void CommitCall(CallInfo callInfo)
        {
            ISubscriber subscriber = GetSubscriberBy(callInfo.SourcePhoneNumber);
            ISubscriber targetSubscriber = GetSubscriberBy(callInfo.TargetPhoneNumber);
            callInfo.callType = CallType.OutGoing;
            subscriber.CommitCall(callInfo);
            callInfo.callType = CallType.InComing;
            targetSubscriber.CommitCall(callInfo);
        }

        public IEnumerable<CallInfo> GetAllCallsOrderedByDuraction(ISubscriber subscriber)
        {

           return subscriber.GetAllCalls.OrderBy(c => c.CallDuration);
        }

        public IEnumerable<CallInfo> GetAllSubscriberInComingCalls(ISubscriber subscriber)
        {
            return subscriber.GetCallsBy(CallType.InComing);
        }
    }
}
