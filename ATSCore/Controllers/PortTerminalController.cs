using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore.Controllers
{
    public class PortTerminalController
    {
       public static bool CheckFreePortTerminal(IList<ITerminal> terminals,IList<IPort> ports)
        {
            var terminal = terminals.First();
            var port = ports.First();
            return terminal != null && port != null;
        }
    }
}
