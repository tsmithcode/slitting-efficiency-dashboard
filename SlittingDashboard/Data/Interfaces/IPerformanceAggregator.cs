using SlittingDashboard.Data.Models;

namespace SlittingDashboard.Data.Interfaces;

public interface IPerformanceAggregator
{
    void AddShiftSummary(ShiftSummary summary);

    void AddIssueLog(string weekLabel, string issue, int count);

    IEnumerable<DailyShiftSnapshot> GetAllSnapshots();

    IEnumerable<DailyShiftSnapshot> GetSnapshots(DateOnly from, DateOnly to);

    Dictionary<string, int> GetIssueTrends(string issue, int days);

    Dictionary<string, double> GetRollingAverageEfficiency(int days);
}