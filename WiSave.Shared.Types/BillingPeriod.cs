using WiSave.Shared.Types.Exceptions;

namespace WiSave.Shared.Types;

public sealed record BillingPeriod
{
    public BillingPeriod() {}

    public BillingPeriod(PeriodUnit unit, int interval)
    {
        if (interval < 0)
        {
            throw new IntervalCannotBeNegativeException();
        }
        
        Unit = unit;
        Interval = interval;
    }
    public PeriodUnit Unit { get; init; }
    public int Interval { get; init; }
}