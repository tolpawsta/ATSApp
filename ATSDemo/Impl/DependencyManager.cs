using System.Collections.Generic;

using ATS;

using ATS.Impl;
using ATSCore;
using ATSCore.Interfaces;
using BillingSystem.Impl;
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

        public IContract GetContract(ITariffPlan tariffPlan, int phoneNumber)
        {
            return new Contract(tariffPlan, phoneNumber);
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
           return new SimpleTariffPlan(callCoastPerSec);
        }

        public ITariffPlan GetTariffPlan()
        {
            return new 
        }

        public ITerminal GetTerminal(IPort port)
        {
           return new CallTerminal(port);
        }
    }
}
