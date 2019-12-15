using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class CallBillingSystem : IBilling
    {
        public ICollection<ISubscriber> subscribers { get; }

    }
}
