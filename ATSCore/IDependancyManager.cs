namespace ATSCore
{
    public interface IDependancyManager
    {
        IAts GetAts { get; }
        IBilling GetBillingSystem { get; }
        IPort GetPort { get; }
        ISubscriber GetSubscriber { get; }
        IRatePlan GetRatePlan { get; }
        ITerminalable GetTerminal { get; }
    }
}