using System.Collections.Generic;

namespace ATSCore
{
    public interface IDependancyManager
    {
        IAts GetAts(ICollection<ITerminal> terminals, ICollection<IPort> ports, IBilling billingSystem);
        IBilling GetBillingSystem();
        IPort GetPort(int phoneNumber);
        IClient GetPerson(string firstName, string lastName);
        ITerminal GetTerminal(IPort port);
        ITariffPlan GetRatePlan(decimal callCoastPerSec);
    }
}