using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore;
using ATSCore.Interfaces;

namespace BillingSystem.Impl
{
    public class Contract : IContract
    {
       
        public int PhoneNumber { get; }
        public ITariffPlan TariffPlan { get; }
        public ISubscriber Subscriber { get ; set; }

        public Contract(ITariffPlan tariffPlan, int phoneNumber)
        {
            TariffPlan = tariffPlan;
            PhoneNumber = phoneNumber;
        }
    }
}
