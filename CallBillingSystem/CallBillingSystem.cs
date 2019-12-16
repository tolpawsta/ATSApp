using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore.Interfaces;

namespace BillingSystem
{
    public class CallBillingSystem : IBilling
    {
        public IList<ISubscriber> Subscribers { get; }
        public IList<IContract> Contracts { get; set; }
        public CallBillingSystem()
        {
            this.Subscribers = new List<ISubscriber>();
        }

        public CallBillingSystem(IList<IContract> contracts):this()
        {
            this.Contracts = contracts;
        }

        public ISubscriber GetSubscriberBy(int sourcePhoneNumber)
        {
            ISubscriber subscriber = Subscribers.FirstOrDefault(s => s.Terminal.Port.PhoneNumber == sourcePhoneNumber);
            if (subscriber != null)
                subscriber.subscriberState = (subscriber.AccountMoney == 0) ? SubscriberState.Blocked : SubscriberState.Allowed;
            return subscriber;
        }
    }
}
