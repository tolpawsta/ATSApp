using System.Collections.Generic;

using ATS;

using ATS.Impl;
using ATSCore;
using ATSCore.Interfaces;
using BillingSystem.Impl;
using BillingSystem;
using Terminal;
using Terminal.Impl;

namespace ATSDemo.Impl
{
    class DependencyManager : IDependancyManager
    {
        public IAts GetAts(IList<ITerminal> terminals, IList<IPort> ports, IBilling billingSystem)
        {
            return new Ats(terminals,ports,billingSystem);
        }

        public IBilling GetBillingSystem(IList<IContract> contracts)
        {
            return new CallBillingSystem(contracts);
        }

        public IContract GetContract(ITariffPlan tariffPlan, int phoneNumber)
        {
            return new Contract(tariffPlan, phoneNumber);
        }

        public IClient GetPerson(string firstName, string lastName)
        {
            return new Person(firstName, lastName);
        }

        public IPort GetPort()
        {
            return new Port();
        }

        
        public ITariffPlan GetTariffPlan(decimal callCoastPerSecond)
        {
            return new SimpleTariffPlan(callCoastPerSecond);
        }

        public ITerminal GetTerminal(IViewable view)
        {
           return new CallTerminal(view);
        }

        public IViewable GetView()
        {
            return new TerminalDisplay();
        }
    }
}
