using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Impl
{
    public class Port : IPort
    {
        public event Action<string, string, string> onCall;
        public event Action<string, string, string> onReject;
        public PortState PortState { get; set; }
        public Port()
        {
            PortState = PortState.Disconnected;
            
        }

        public void Coll(string outgoingPhoneNumber, string incomingPhoneNumber, string callInformation)
        {
            
                onCall?.Invoke(outgoingPhoneNumber, incomingPhoneNumber, callInformation);
            
            
        }

        public void Reject(string outgoingPhoneNumber, string incomingPhoneNumber, string callInformation)
        {
            onReject?.Invoke(outgoingPhoneNumber, incomingPhoneNumber, callInformation);
        }
    }
}
