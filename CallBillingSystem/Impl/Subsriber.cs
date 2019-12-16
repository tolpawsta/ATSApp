using ATSCore;
using ATSCore.EntityStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBillingSystem.Impl
{
    class Subsriber : ISubscriber
    {
        decimal _accountMoney;
        IList<CallInfo> Calls { get; }
        IClient client;
        public Subsriber()
        {
            Calls = new List<CallInfo>();
        }
        public Subsriber(IClient client,ITerminal terminal, ITariffPlan tariffPlan):this()
        {
            this.client = client;
            this.Terminal = terminal;
            this.TariffPlan = tariffPlan;
        }

        public ITerminal Terminal { get ; set ; }

        public string FullName => client.FullName;

        public ITariffPlan TariffPlan { get; set; }

        public SubscriberState subscriberState { get; set; }

        public IEnumerable<CallInfo> GetAllCalls => Calls;

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
        public IEnumerable<CallInfo> GetCallsBy(CallType callType)
        {
            return Calls.Where(c => c.callType == callType);
        }

        public IEnumerable<CallInfo> GetCallsBy(int phoneNumber)
        {
            return Calls.Where(c => c.SourcePhoneNumber == phoneNumber || c.TargetPhoneNumber == phoneNumber);
        }
    }
}
