using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Impl
{
   public static class BillingSystemExtention
    {
        public static void AddRange(this IList<IContract> sourceContracts, IList<IContract> targetContracts)
        {
            foreach (var item in targetContracts)
            {
                sourceContracts.Add(item);
            }
           
        }
    }
}
