using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATSCore;

namespace ATS.Impl
{
    public class SimpleTariffPlan : ITariffPlan
    {
        private const decimal  SimpleCoastPerSec= 100;
        public decimal CallCoastPerSec { get; }

        public SimpleTariffPlan()
        {
            CallCoastPerSec = SimpleCoastPerSec;
        }
        public SimpleTariffPlan(decimal callCoastPerSec)
        {
            CallCoastPerSec = callCoastPerSec;
        }
    }
}
