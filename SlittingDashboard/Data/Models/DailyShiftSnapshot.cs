namespace SlittingDashboard.Data.Models;

public record class DailyShiftSnapshot
{
    public required DateOnly Date { get; init; }
    public required int Shift { get; init; }

    public required int TotalOrders { get; init; }
    public required int TotalGoal { get; init; }
    public double Efficiency => TotalGoal > 0 ? Math.Round((double)TotalOrders / TotalGoal * 100, 1) : 0;

    public required Dictionary<string, int> Issues { get; init; } // e.g. {"Machine down": 3}
    public required List<string> OperatorNames { get; init; }
}