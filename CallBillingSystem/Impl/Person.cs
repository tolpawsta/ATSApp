using ATSCore;
using ATSCore.EntityStates;
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
        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => new StringBuilder().Append(FirstName).Append(" ").Append(LastName).ToString();

        public ITerminal Terminal { get; set; }
        public ITariffPlan TariffPlan { get; set; }
        public SubscriberState subscriberState { get; set; }

        public IEnumerable<CallInfo> GetAllCalls => _calls;

        public decimal AccountMoney
        {
            get => _accountMoney; 
            set
            {
                _accountMoney = value;
                if (_accountMoney<0)
                {
                    _accountMoney = 0;
                }
            }
        }

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
    }
}
