using System.Globalization;
using SlittingDashboard.Data.Interfaces;
using SlittingDashboard.Data.Models;

namespace SlittingDashboard.Data.Services;

public class SnapshotService : ISnapshotService
{
    private readonly IShiftTrackingService _shiftTracking;
    private readonly IPerformanceAggregator _aggregator;

    public SnapshotService(
        IShiftTrackingService shiftTracking,
        IPerformanceAggregator aggregator)
    {
        _shiftTracking = shiftTracking;
        _aggregator = aggregator;
    }

    public IEnumerable<DailyShiftSnapshot> GetSnapshots(string fromIso, string toIso)
    {
        if (!DateOnly.TryParseExact(fromIso, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var from))
        {
            from = DateOnly.FromDateTime(DateTime.Today.AddYears(-1));
        }
        if (!DateOnly.TryParseExact(toIso, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var to))
        {
            to = DateOnly.FromDateTime(DateTime.Today);
        }

        var allSnapshots = _aggregator.GetAllSnapshots();
        return allSnapshots.Where(s => s.Date >= from && s.Date <= to).ToList();
    }

    public Dictionary<string, double> GetRollingAverageEfficiency(int days)
    {
        return _aggregator.GetRollingAverageEfficiency(days);
    }

    public Dictionary<string, int> GetIssueTrends(string issue, int days)
    {
        return _aggregator.GetIssueTrends(issue, days);
    }
}