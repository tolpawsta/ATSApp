using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public class CallInfo
    {
        public int TargetPhoneNumber { get; set; }
        public int SourcePhoneNumber { get; set; }
        public DateTime CallDateTime { get; set; }
        public double CallDuration { get; set; }
        public double LimitCallDuraction { get; set; }
        public CallType callType { get; set; }

        public CallInfo(int sourcePhoneNumber, int targetPhoneNumber)
        {
            SourcePhoneNumber = sourcePhoneNumber;
            TargetPhoneNumber = targetPhoneNumber;
        }
        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"Source phone: {SourcePhoneNumber} ")
                .AppendLine($"Target phone: {TargetPhoneNumber} ")
                .AppendLine($"Date-time: {CallDateTime.ToString("d")} - {CallDateTime.ToString("t")}")
                .AppendLine($"Call duraction: {CallDuration} ")
                .AppendLine($"Call type: {callType}")
                .ToString();
                
        }

    }
}
