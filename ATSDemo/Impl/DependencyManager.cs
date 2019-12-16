using System.Collections.Generic;
using ATS;

using ATS.Impl;
using ATSCore;
using Terminal;

namespace ATSDemo.Impl
{
    class DependencyManager : IDependancyManager
    {
        public IAts GetAts(ICollection<ITerminal> terminals, ICollection<IPort> ports, IBilling billingSystem)
        {
            return new Ats(terminals,ports,billingSystem);
        }

        public IBilling GetBillingSystem()
        {
            return new BillingSystem.CallBillingSystem();
        }

        public IClient GetPerson(string firstName, string lastName)
        {
            return new Person(firstName, lastName);
        }

        public IPort GetPort(int phoneNumber)
        {
            return new Port(phoneNumber);
        }

        public ITariffPlan GetRatePlan(decimal callCoastPerSec)
        {
           return new NormalRatePlan(callCoastPerSec);
        }

        public ITerminal GetTerminal(IPort port)
        {
           return new CallTerminal(port);
        }
    }
}
