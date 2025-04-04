namespace SlittingDashboard.Data.Models;

public record class ShiftSummary
{
    public required DateOnly Date { get; set; }
    public required int Shift { get; set; }
    public required string TeamLead { get; set; }
    public required string Supervisor { get; set; }
    public required List<OperatorEntry> Operators { get; set; }
}