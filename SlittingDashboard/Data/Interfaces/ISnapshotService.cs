using System.Collections.Generic;

namespace SlittingDashboard.Data.Interfaces;

public interface ISnapshotService
{
    /// <summary>
    /// Retrieves daily snapshots between two ISO date strings (YYYY-MM-DD).
    /// </summary>
    IEnumerable<DailyShiftSnapshot> GetSnapshots(string fromIso, string toIso);

    /// <summary>
    /// Computes rolling average efficiency for the past X days.
    /// </summary>
    Dictionary<string, double> GetRollingAverageEfficiency(int days);

    /// <summary>
    /// Retrieves issue trends for a specific issue over X days.
    /// </summary>
    Dictionary<string, int> GetIssueTrends(string issue, int days);
}