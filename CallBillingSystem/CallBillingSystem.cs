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
                subscriber.subscriberState = (subscriber.AccountMoney == 0) ? SubscriberState.Blocked : SubscriberState.Allowed;
            return subscriber;
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscriber.Contract = Contracts.FirstOrDefault();
            Contracts.Remove(subscriber.Contract);
            _subscribers.Add(subscriber);
        }
    }
}
