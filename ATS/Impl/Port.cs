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
        public PortState PortState { get; set; }
        public int PhoneNumber { get; }
        public CallInfo CurrentCallInfo { get; set; }

        public Port(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
            PortState = PortState.Disconnected;
        }
        public void Coll(int targerPhoneNumber)
        {
            CurrentCallInfo = new CallInfo(PhoneNumber, targerPhoneNumber);
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
        public void ChangeState()
        {
            throw new NotImplementedException();
        }
        void InComingCall(CallInfo callInfo)
        { CurrentCallInfo = callInfo;
            OnInComingCall?.Invoke(CurrentCallInfo);
        }
    }
}
