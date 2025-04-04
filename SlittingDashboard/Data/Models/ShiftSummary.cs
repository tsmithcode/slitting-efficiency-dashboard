namespace SlittingDashboard.Data.Models;

public record class ShiftSummary
{
    public required DateOnly Date { get; init; }
    public required int Shift { get; init; }
    public required string TeamLead { get; init; }
    public required string Supervisor { get; init; }
    public required List<OperatorEntry> Operators { get; init; }
}