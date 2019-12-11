using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public static class Configuration
    {
        public static IAtsable GetAts { get; }
        public static IBillingable GetBilling { get; }
        public static ITerminalable GetTerminal { get; }
        public static IPortable GetPort { get; }

    }
}
