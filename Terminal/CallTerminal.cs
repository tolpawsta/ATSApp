using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class CallTerminal : ITerminal
    {

        private CallInfo _callInfo;

        public IPort Port { get; set; }
        public TerminalState State { get; set; }

        public CallTerminal()
        {

        }

        public void Answer()
        {
            _callInfo = Port.CurrentCallInfo;
            _callInfo.CallDateTime = DateTime.Now;
        }

        public void Call(int targetPhoneNumber)
        {
            Port.Coll(targetPhoneNumber);
        }

        public void Connect(IPort port)
        {
            Port = port;
            State = TerminalState.On;
            Port = port;
            Port.PortState = PortState.Connected;
            Port.OnInComingCall += Port_InComingCall;
            Port.OnCallResponce += Port_OnCallResponce;
        }

        private void Port_OnCallResponce(string message)
        {
            Console.WriteLine(message);
        }

        private void Port_InComingCall(CallInfo callInfo)
        {
            Console.WriteLine($"Incoming call ...{_callInfo.SourcePhoneNumber}");
        }

        public void Reject()
        {
            if (_callInfo != null)
            {
                _callInfo.CallDuration = _callInfo.LimitCallDuraction - new Random().Next((int)_callInfo.LimitCallDuraction);
                Port.Reject(_callInfo);
            }
        }
        public void Drop()
        {
            _callInfo.CallDuration = 0;
            Port.Drop(_callInfo);
        }
    }
}
