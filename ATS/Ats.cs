using ATS.Impl;
using ATSCore;
using ATSCore.Controllers;
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

        IList<ITerminal> terminals;
        IList<IPort> ports;

        IBilling _billingSystem;
        public Ats(IList<ITerminal> terminals, IList<IPort> ports, IBilling billingSystem)
        {
            this.terminals = terminals;
            this.ports = ports;
            _billingSystem = billingSystem;
        }

        public ISubscriber ConcludeContractWith(IClient client)
        {
            if (!PortTerminalController.CheckFreePortTerminal(terminals, ports))
                throw new NullReferenceException("Sorry, there is no free port or terminal.");
            ISubscriber subscriber = client as ISubscriber;
            _billingSystem.AddSubscriber(subscriber);
            subscriber.Terminal = terminals.First();
            terminals.Remove(subscriber.Terminal);
            subscriber.Port = ports.First();
            ports.Remove(subscriber.Port);
            StartPortListen(subscriber.Port);
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
            subscriber.Port.CallResponce($"{subscriber.FullName}: call rejected with {targetSubscriber.FullName}");
            targetSubscriber.Port.CallResponce($"{targetSubscriber.FullName}: call rejected with {subscriber.FullName}");
            CallController.CallCommit(callInfo, _billingSystem);
            
        }

        private void Port_OnDrop(CallInfo callInfo)
        {
            ISubscriber subscriber = _billingSystem.GetSubscriberBy(callInfo.SourcePhoneNumber);
            ISubscriber targetSubscriber = _billingSystem.GetSubscriberBy(callInfo.TargetPhoneNumber);
            CallController.CallCommit(callInfo, _billingSystem);
            subscriber.Port.CallResponce($"{targetSubscriber.FullName} droped the call...");

        }

        private void Port_OnCall(CallInfo callInfo)
        {
            ISubscriber subscriber = _billingSystem.GetSubscriberBy(callInfo.SourcePhoneNumber);
            ISubscriber targetSubscriber = _billingSystem.GetSubscriberBy(callInfo.TargetPhoneNumber);
            if (subscriber == null)
                throw new NullReferenceException($"Subscriber with phoneNumber {callInfo.SourcePhoneNumber} not found!");
            if (targetSubscriber == null)
                throw new NullReferenceException($"Subscriber with phoneNumber {callInfo.TargetPhoneNumber} not found!");
            if (subscriber.State == SubscriberState.Blocked)
            {
                subscriber.Port.CallResponce("Your phone number is bloked.");
                return;
            }
            if (targetSubscriber.State == SubscriberState.Blocked)
            {
                subscriber.Port.CallResponce("The subscriber you are calling is temporarily blocked.");
                return;
            }
            if (CallController.CheckStatePortsSubscribers(subscriber, targetSubscriber))
            {
                callInfo.LimitCallDuraction = _billingSystem.GetLimitCallDuraction(subscriber);
                targetSubscriber.Port.InComingCall(callInfo);
            }


        }

    }
}
