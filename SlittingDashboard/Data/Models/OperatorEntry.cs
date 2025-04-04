namespace SlittingDashboard.Data.Models;

public record class OperatorEntry
{
    public required int SlitterNumber { get; set; }
    public required int Shift { get; set; }
    public required string OperatorName { get; set; }
    public required Dictionary<TimeOnly, int> HourlyOrders { get; set; }
    public required int DailyGoal { get; set; }
    public string? Comment { get; set; }
}