using ATSCore;
using ATSCore.EntityStates;
using ATSCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Impl
{
    public class Person : IClient, ISubscriber
    {
        private decimal _accountMoney;
        private IList<CallInfo> _calls;
        private IPort _port;
        private ITariffPlan _tariffPlan;
        private IContract _contract;

        public int PhoneNumber => Contract.PhoneNumber;
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => new StringBuilder().Append(FirstName).Append(" ").Append(LastName).ToString();
        public ITerminal Terminal { get; set; }
        public IPort Port
        {
            get => _port;
            set
            {
                _port = value;
                _port.PhoneNumber = Contract.PhoneNumber;
                Terminal.Connect(_port);
            }
        }
        public ITariffPlan TariffPlan { get => _tariffPlan; set { _tariffPlan = value; } }
        public SubscriberState State { get; set; }
        public IEnumerable<CallInfo> GetAllCalls => _calls;
        public decimal AccountMoney
        {
            get => _accountMoney;
            set
            {
                _accountMoney = value;
                if (_accountMoney < 0)
                {
                    _accountMoney = 0;
                }
            }
        }
        public IContract Contract { get => _contract; set => _contract = value; }
        public Person()
        {
            _calls = new List<CallInfo>();
        }
        public Person(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public IEnumerable<CallInfo> GetCallsBy(CallType callType)
        {
            return _calls.Where(c => c.callType == callType);
        }
        public IEnumerable<CallInfo> GetCallsBy(int phoneNumber)
        {
            return _calls.Where(c => c.SourcePhoneNumber == phoneNumber || c.TargetPhoneNumber == phoneNumber);
        }
        public void Call(int phoneNumber)
        {
            Terminal.Call(phoneNumber);
        }
        public void Call(ISubscriber subscriber)
        {
            Terminal.Call(subscriber.Port.PhoneNumber);
        }
        public void Reject()
        {
            Terminal.Reject();
        }
        public void Answer()
        {

            Terminal.Answer();
        }
        public void Drop()
        {
            Terminal.Drop();
        }

        public void CommitCall(CallInfo callInfo)
        {

            if (callInfo.callType == CallType.OutGoing)
            {
                decimal _coast = (decimal)callInfo.CallDuration * TariffPlan.CallCoastPerSec;
                AccountMoney -= _coast;
                callInfo.Coast = _coast;
            }

            _calls.Add(callInfo);

        }

        public void SetContact(IContract contract)
        {
            _contract = contract;
            _tariffPlan = Contract.TariffPlan;
        }
    }
}
