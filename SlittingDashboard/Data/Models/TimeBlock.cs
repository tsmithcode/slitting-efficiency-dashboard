namespace SlittingDashboard.Data.Models;

public readonly record struct TimeBlock(TimeOnly Start, TimeOnly End)
{
    public override string ToString() => $"{Start:hh\\:mm}–{End:hh\\:mm}";
}