using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public class IPortable
    {
        event Action<string, string> onColl;
        event Action<string, string> onReject;
        PortState portState { get; set; }

    }
}
