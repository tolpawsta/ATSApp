using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore;

namespace ATS.Impl
{
    public class NormalRatePlan : ITariffPlan
    {
        private const decimal  SimpleCoastPerSec= 100;
        public decimal CallCoastPerSec { get; }

        public NormalRatePlan()
        {
            CallCoastPerSec = SimpleCoastPerSec;
        }
        public NormalRatePlan(decimal callCoastPerSec)
        {
            CallCoastPerSec = callCoastPerSec;
        }
    }
}
