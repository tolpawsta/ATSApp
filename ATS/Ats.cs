using ATSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    public class Ats : IAts
    {
        
        ICollection<ITerminal> terminals;
        ICollection<IPort> ports;
        
        IBilling _billingSystem;
        public Ats(ICollection<ITerminal> terminals, ICollection<IPort> ports,IBilling billingSystem)
        {
            this.terminals = terminals;
            this.ports = ports;
            _billingSystem = billingSystem;
        }

        public ISubscriber ConcludeContractWith(IClientable client)
        {
            ISubscriber subscriber = client as ISubscriber;
            _billingSystem.subscribers.Add(subscriber);
            ITerminal terminal = terminals.FirstOrDefault();
            terminals.Remove(terminal);
            StartPortListen(terminal.Port);
            subscriber.terminal = terminal;
            return subscriber;
        }
        private void StartPortListen(IPort port)
        {
            port.OnCall += Port_OnCall;
            port.OnDrop += Port_OnDrop;
            port.OnReject += Port_OnReject;
        }
        private void StopPortListen(IPort port)
        {
            port.OnCall -= Port_OnCall;
            port.OnDrop -= Port_OnDrop;
            port.OnReject -= Port_OnReject;
        }
        private void Port_OnReject(CallInfo callInfo)
        {
            
        }

        private void Port_OnDrop(CallInfo callInfo)
        {
            
        }

        private void Port_OnCall(CallInfo callInfo)
        {
            var subsriber = _billingSystem.GetSubscriberBy(callInfo.SourcePhoneNumber);

        }
    }
}
