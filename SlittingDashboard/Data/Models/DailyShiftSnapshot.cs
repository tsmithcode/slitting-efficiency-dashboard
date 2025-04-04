namespace SlittingDashboard.Data.Models;

public record class DailyShiftSnapshot
{
    public required DateOnly Date { get; set; }
    public required int Shift { get; set; }

    public required int TotalOrders { get; set; }
    public required int TotalGoal { get; set; }
    public double Efficiency => TotalGoal > 0 ? Math.Round((double)TotalOrders / TotalGoal * 100, 1) : 0;

    public required Dictionary<string, int> Issues { get; set; } // e.g. {"Machine down": 3}
    public required List<string> OperatorNames { get; set; }
}