namespace ATSCore
{
    public interface IDependancyManager
    {
        IAts GetAts { get; }
        IBilling GetBillingSystem { get; }
        IPort GetPort { get; }
        ISubscriber GetSubscriber { get; }
        ITariffPlan GetRatePlan { get; }
        ITerminal GetTerminal { get; }
    }
}