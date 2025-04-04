using SlittingDashboard.Data.Interfaces;

namespace SlittingDashboard.Data.Services;

public class ShiftTrackingService : IShiftTrackingService
{
    private readonly Dictionary<(DateOnly, int), ShiftSummary> _shifts = [];

    public void AddShift(ShiftSummary shift)
    {
        var key = (shift.Date, shift.Shift);
        _shifts[key] = shift;
    }

    public ShiftSummary? GetShift(DateOnly date, int shift)
    {
        _shifts.TryGetValue((date, shift), out var summary);
        return summary;
    }

    public IEnumerable<ShiftSummary> GetAllShifts() => _shifts.Values;

    public int CalculateTotalOrders(ShiftSummary shift) =>
        shift.Operators.Sum(op => op.HourlyOrders.Values.Sum());

    public Dictionary<TimeOnly, int> GetHourlyTotals(ShiftSummary shift)
    {
        var totals = new Dictionary<TimeOnly, int>();

        foreach (var op in shift.Operators)
        {
            foreach (var (time, count) in op.HourlyOrders)
            {
                totals.TryAdd(time, 0);
                totals[time] += count;
            }
        }

        return totals;
    }
}