using ATS;
using ATS.Impl;
using ATSCore;
using BillingSystem;
using Terminal;

namespace ATSDemo.Impl
{
    class DependencyManager : IDependancyManager
    {
        public IAts GetAts => new Ats();

        public IBilling GetBillingSystem => new CallBillingSystem();

        public IPort GetPort => new Port();

        public ISubscriber GetSubscriber => new Subscriber();

        public ITariffPlan GetRatePlan => new NormalRatePlan();

        public ITerminal GetTerminal => new CallTerminal(phoneNumber:"+123456789");
    }
}
