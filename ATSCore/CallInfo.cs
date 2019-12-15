using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public class CallInfo:IComparable
    {
        public int TargetPhoneNumber { get; set; }
        public int SourcePhoneNumber { get; set; }
        public DateTime CallDateTime { get; set; }
        public double CallDuration { get; set; }
        public double LimitCallDuraction { get; set; }

        public CallInfo(int sourcePhoneNumber, int targetPhoneNumber)
        {
            SourcePhoneNumber = sourcePhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
        }

        public int CompareTo(object obj)
        {
            var compareCallinfo = obj as CallInfo;
            if (compareCallinfo == null) return 1;
            if (compareCallinfo.TargetPhoneNumber == this.TargetPhoneNumber) return 0;
        }
    }
}
