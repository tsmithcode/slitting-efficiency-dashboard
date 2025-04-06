using SlittingDashboard.Data.Models;
using SlittingDashboard.Data.Constants;
using SlittingDashboard.Components.Pages.SlittingV2;

public class SeedDataService
{
    private readonly Random _random = new();

    public List<SlitterShiftEntry> GenerateSeedData()
    {
        var entries = new List<SlitterShiftEntry>();
        var startDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-6));

        for (int day = 0; day < 6; day++)
        {
            var date = startDate.AddDays(day);

            for (int shiftNum = 1; shiftNum <= 2; shiftNum++)
            {
                var shiftName = $"{shiftNum}st";
                var supervisor = Menus.Supervisors[(day + shiftNum) % Menus.Supervisors.Length];
                var teamLead = Menus.TeamLeads[(day + shiftNum) % Menus.TeamLeads.Length];

                var usedOperators = new HashSet<string>();

                for (int i = 0; i < 4; i++)
                {
                    string operatorName;
                    do
                    {
                        operatorName = Menus.Operators[_random.Next(Menus.Operators.Length)];
                    } while (!usedOperators.Add(operatorName));

                    var machine = Menus.SlitterNumbers[_random.Next(Menus.SlitterNumbers.Length)];
                    var hours = _random.Next(6, 10);
                    var goal = _random.Next(35, 45);
                    var orders = goal + _random.Next(-10, 10);
                    var pto = _random.NextDouble() < 0.1; // 10% chance PTO
                    var issue = pto ? "PTO" : Menus.Issues[_random.Next(Menus.Issues.Length)];

                    entries.Add(new SlitterShiftEntry
                    {
                        ShiftDate = date.ToDateTime(TimeOnly.MinValue),
                        ShiftName = shiftName,
                        OperatorName = operatorName,
                        MachineName = machine.ToString(),
                        Supervisor = supervisor,
                        TeamLead = teamLead,
                        HoursWorked = hours,
                        Orders = pto ? 0 : Math.Max(0, orders),
                        Goal = goal,
                        PTO = pto,
                        Comments = pto ? "Paid Time Off" : issue,
                        IssueCategory = pto ? "Absence" : issue
                    });
                }
            }
        }

        return entries;
    }
}