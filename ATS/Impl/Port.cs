using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Impl
{
    public class Port : IPort
    {
        public event Action<CallInfo> OnCall;
        public event Action<CallInfo> OnReject;
        public event Action<CallInfo> OnInComingCall;
        public event Action<CallInfo> OnDrop;
        public event Action<string> OnCallResponce;

        public PortState State { get; set; }
        public int PhoneNumber { get; set; }
        public CallInfo CurrentCallInfo { get; set; }

        public Port()
        {
            
            State = PortState.Disconnected;
        }
        public void Coll(int targerPhoneNumber)
        {
            CurrentCallInfo = new CallInfo(PhoneNumber, targerPhoneNumber);
            State = PortState.Busy;
            OnCall?.Invoke(CurrentCallInfo);
        }
        public void Reject(CallInfo callInfo)
        {
            OnReject?.Invoke(callInfo);
        }
        public void Drop(CallInfo callInfo)
        {
            OnDrop?.Invoke(callInfo);
        }
       
       public void InComingCall(CallInfo callInfo)
        { CurrentCallInfo = callInfo;
            OnInComingCall?.Invoke(CurrentCallInfo);
        }

        public void CallResponce(string message)
        {
            OnCallResponce?.Invoke(message);
        }
    }
}
