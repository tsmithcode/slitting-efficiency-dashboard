using SlittingDashboard.Data.Interfaces;

namespace SlittingDashboard.Data.Services;

public class PerformanceAggregator : IPerformanceAggregator
{
    private readonly List<DailyShiftSnapshot> _snapshots = [];

    public void AddShiftSummary(ShiftSummary summary)
    {
        int orders = summary.Operators.Sum(op => op.HourlyOrders.Values.Sum());
        int goal = summary.Operators.Sum(op => op.DailyGoal);

        _snapshots.Add(new DailyShiftSnapshot
        {
            Date = summary.Date,
            Shift = summary.Shift,
            TotalOrders = orders,
            TotalGoal = goal,
            Issues = new(),
            OperatorNames = summary.Operators.Select(op => op.OperatorName).ToList()
        });
    }

    public void AddIssueLog(string weekLabel, string issue, int count)
    {
        // Convert "Week of MM-DD" to DateOnly
        if (!DateOnly.TryParseExact(weekLabel.Replace("Week of ", ""), "MM-dd", out var weekStart))
            return;

        foreach (var snap in _snapshots.Where(s => s.Date >= weekStart && s.Date <= weekStart.AddDays(6)))
        {
            if (!snap.Issues.ContainsKey(issue))
                snap.Issues[issue] = 0;
            snap.Issues[issue] += count;
        }
    }

    public IEnumerable<DailyShiftSnapshot> GetAllSnapshots() => _snapshots;

    public IEnumerable<DailyShiftSnapshot> GetSnapshots(DateOnly from, DateOnly to) =>
        _snapshots.Where(s => s.Date >= from && s.Date <= to);

    public Dictionary<string, int> GetIssueTrends(string issue, int days)
    {
        var since = DateOnly.FromDateTime(DateTime.Today.AddDays(-days));
        return _snapshots
            .Where(s => s.Date >= since)
            .GroupBy(s => s.Date)
            .ToDictionary(g => g.Key.ToString("MM/dd"), g => g.Sum(s => s.Issues.GetValueOrDefault(issue, 0)));
    }

    public Dictionary<string, double> GetRollingAverageEfficiency(int days)
    {
        var since = DateOnly.FromDateTime(DateTime.Today.AddDays(-days));
        return _snapshots
            .Where(s => s.Date >= since)
            .GroupBy(s => s.Date)
            .ToDictionary(
                g => g.Key.ToString("MM/dd"),
                g => Math.Round(g.Average(s => s.Efficiency), 1)
            );
    }
}