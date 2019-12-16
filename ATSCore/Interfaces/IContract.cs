using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore.Interfaces
{
    public interface IContract
    {
        ISubscriber Subscriber { get; set}
        int PhoneNumber { get; }
        ITariffPlan TariffPlan { get; }
    }
}
