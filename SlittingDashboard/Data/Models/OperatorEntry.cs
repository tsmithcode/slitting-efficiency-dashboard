namespace SlittingDashboard.Data.Models;

public record class OperatorEntry
{
    public required int SlitterNumber { get; init; }
    public required int Shift { get; init; }
    public required string OperatorName { get; init; }
    public required Dictionary<TimeOnly, int> HourlyOrders { get; init; }
    public required int DailyGoal { get; init; }
    public string? Comment { get; set; }
}