using SlittingDashboard.Data.Models;

namespace SlittingDashboard.Data.Interfaces;

public interface IShiftTrackingService
{
    void AddShift(ShiftSummary shift);

    ShiftSummary? GetShift(DateOnly date, int shift);

    IEnumerable<ShiftSummary> GetAllShifts();

    int CalculateTotalOrders(ShiftSummary shift);

    Dictionary<TimeOnly, int> GetHourlyTotals(ShiftSummary shift);
}