using ATSCore.Interfaces;
using System.Collections.Generic;

namespace ATSCore
{
    public interface IDependancyManager
    {
        IAts GetAts(IList<ITerminal> terminals, IList<IPort> ports, IBilling billingSystem);
        IBilling GetBillingSystem(IList<IContract> contracts);
        IPort GetPort();
        IClient GetPerson(string firstName, string lastName);
        ITerminal GetTerminal();
        IContract GetContract(ITariffPlan tariffPlan, int phoneNumber);
        ITariffPlan GetTariffPlan(decimal callCoastPerSecond);
    }
}