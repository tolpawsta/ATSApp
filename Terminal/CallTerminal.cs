using ATSCore;
using ATSCore.EntityStates;
using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class CallTerminal : ITerminal
    {
        private IViewable _view;
        private CallInfo _callInfo;

        public IPort Port { get; set; }
        public TerminalState State { get; set; }

        public CallTerminal(IViewable view)
        {
            _view = view;
        }

        public void Answer()
        {
            Port.State = PortState.Busy;
            _callInfo = Port.CurrentCallInfo;
            _callInfo.CallDateTime = DateTime.Now;
            _view.Show("The conversation began ...");
            _view.Show(_callInfo.ToString());
        }

        public void Call(int targetPhoneNumber)
        {
            Port.Coll(targetPhoneNumber);
            _callInfo = Port.CurrentCallInfo;
        }

        public void Connect(IPort port)
        {
            Port = port;
            State = TerminalState.On;
            Port = port;
            Port.State = PortState.Connected;
            Port.OnInComingCall += Port_InComingCall;
            Port.OnCallResponce += Port_OnCallResponce;
        }

        private void Port_OnCallResponce(string message)
        {
            _view.Show(message);
        }

        private void Port_InComingCall(CallInfo callInfo)
        {
            _callInfo = callInfo;
            _view.Show($"Incoming call ...{callInfo.SourcePhoneNumber}");
        }

        public void Reject()
        {
            if (_callInfo != null)
            {
                _callInfo.CallDuration = _callInfo.LimitCallDuraction *(1-new Random().NextDouble());
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
