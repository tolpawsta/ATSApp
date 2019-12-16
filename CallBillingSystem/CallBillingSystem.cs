using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class CallBillingSystem:IBilling
    {
        IEnumerable<ISubscriber> subscribers { get; }

    }
}
