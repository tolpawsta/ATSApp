using ATSCore;
using ATSCore.EntityStates;
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
        public Ats(ICollection<ITerminal> terminals, ICollection<IPort> ports, IBilling billingSystem)
        {
            this.terminals = terminals;
            this.ports = ports;
            _billingSystem = billingSystem;
        }

        public ISubscriber ConcludeContractWith(IClient client)
        {
            ISubscriber subscriber = client as ISubscriber;
            _billingSystem.subscribers.Add(subscriber);
            ITerminal terminal = terminals.FirstOrDefault();
            terminals.Remove(terminal);
            StartPortListen(terminal.Port);
            subscriber.Terminal = terminal;
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
            ISubscriber subscriber = _billingSystem.GetSubscriberBy(callInfo.SourcePhoneNumber);
            ISubscriber targetSubscriber = _billingSystem.GetSubscriberBy(callInfo.TargetPhoneNumber);

        }

        private void Port_OnDrop(CallInfo callInfo)
        {

        }

        private void Port_OnCall(CallInfo callInfo)
        {
            ISubscriber subscriber = _billingSystem.GetSubscriberBy(callInfo.SourcePhoneNumber);
            ISubscriber targetSubscriber = _billingSystem.GetSubscriberBy(callInfo.TargetPhoneNumber);
            if (subscriber == null)
                throw new NullReferenceException($"Subscriber with phoneNumber {callInfo.SourcePhoneNumber} not found!");
            if (targetSubscriber == null)
                throw new NullReferenceException($"Subscriber with phoneNumber {callInfo.TargetPhoneNumber} not found!");
            if (subscriber.subscriberState == SubscriberState.Blocked)
            {
                subscriber.Terminal.Port.CallResponce("Your phone number is bloked.");
                return;
            }
            if (targetSubscriber.subscriberState == SubscriberState.Blocked)
            {
                subscriber.Terminal.Port.CallResponce("The subscriber you are calling is temporarily blocked.");
                return;
            }
            IPort targetPort = targetSubscriber.Terminal.Port;
            if (targetPort.PortState== PortState.Busy)
            {
                subscriber.Terminal.Port.CallResponce("The subscriber you are calling is busy.");
            }
            else if (targetPort.PortState == PortState.Disconnected)
            {
                subscriber.Terminal.Port.CallResponce("The subscribers terminal you are calling is off or offline.");
            }
            

        }
    }
}
