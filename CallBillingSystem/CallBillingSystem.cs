using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class CallBillingSystem : IBilling
    {
        public IList<ISubscriber> subscribers { get; }

        public ISubscriber GetSubscriberBy(int sourcePhoneNumber)
        {
            ISubscriber subscriber = subscribers.FirstOrDefault(s => s.Terminal.Port.PhoneNumber == sourcePhoneNumber);
            if(subscriber!=null)            
            subscriber.subscriberState = (subscriber.AccountMoney == 0) ? SubscriberState.Blocked : SubscriberState.Allowed;
            return subscriber;
        }
    }
}
