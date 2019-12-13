using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
  public interface IAts
    {
        //Dictionary<>
        ISubscriber ConcludeContractWith(IClientable client);
        void TerminateContractWith(ISubscriber subscriber);
        

    }
}
