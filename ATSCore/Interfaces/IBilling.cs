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
        IList<ISubscriber> Subscribers { get; }
        IList<IContract> Contracts { get; set; }
        ISubscriber GetSubscriberBy(int sourcePhoneNumber);
    }
}
