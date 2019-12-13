using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class CallTerminal : ITerminalable
    {
        
        public string PhoneNumber { get; }
        public IPort Port { get; }

        public CallTerminal(string phoneNumber, IPort port)
        {
            PhoneNumber = phoneNumber;
            Port = port;
            Port.PortState = PortState.Connected;
        }

        public void Answer()
        {
            throw new NotImplementedException();
        }

        public void Call(string phoneNumber)
        {
            Port.Coll(PhoneNumber, phoneNumber, "OutCallTo");
        }

        public void Connect(IPort port)
        {
            throw new NotImplementedException();
        }

        public void Reject()
        {
            throw new NotImplementedException();
        }
    }
}
