using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSCore
{
    public interface IPort
    {
        int PhoneNumber { get; set; }
        CallInfo CurrentCallInfo { get; set; }
        event Action<CallInfo> OnCall;
        event Action<CallInfo> OnReject;
        event Action<CallInfo> OnInComingCall;
        event Action<CallInfo> OnDrop;
        event Action<string> OnCallResponce;
        PortState PortState { get; set; }
        void Coll(int targetPhoneNumber);
        void Reject(CallInfo callInfo);
        void Drop(CallInfo callInfo);
        void ChangeState();
        void CallResponce(string message);
        void InComingCall(CallInfo callInfo);
    }
}
