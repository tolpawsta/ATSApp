using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore;

namespace ATS.Impl
{
    class NormaRatePlan : IRatePlan
    {
        public decimal CallCoastPerSec { get; }

        public NormaRatePlan(decimal callCoastPerSec)
        {
            CallCoastPerSec = callCoastPerSec;
        }
    }
}
