using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface IPort
    {
        
        event Action<string, string,string> onCall;
        event Action<string, string,string> onReject;
        PortState PortState { get; set; }
        void Coll(string outgoingPhoneNumber, string incomingPhoneNumber, string callInformation);
        void Reject(string outgoingPhoneNumber, string incomingPhoneNumber, string callInformation);

    }
}
