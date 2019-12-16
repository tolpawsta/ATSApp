using ATSCore.Interfaces;
using System.Collections.Generic;

namespace ATSCore
{
    public interface IDependancyManager
    {
        IAts GetAts(ICollection<ITerminal> terminals, ICollection<IPort> ports, IBilling billingSystem);
        IBilling GetBillingSystem();
        IPort GetPort();
        IClient GetPerson(string firstName, string lastName);
        ITerminal GetTerminal();
        IContract GetContract(ITariffPlan tariffPlan, int phoneNumber);
        ITariffPlan GetTariffPlan(decimal callCoastPerSecond);
    }
}