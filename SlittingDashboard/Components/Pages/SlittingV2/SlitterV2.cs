using System.Text.Json;

namespace SlittingDashboard.Components.Pages.SlittingV2;

public interface IStorageService
{
    Task<List<SlitterShiftEntry>> LoadAsync();

    Task SaveAsync(List<SlitterShiftEntry> entries);
}

public record SlitterShiftEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime ShiftDate { get; set; }
    public string ShiftName { get; set; } = ""; // "1st", "2nd", "3rd"

    public string OperatorName { get; set; } = "";
    public string MachineName { get; set; } = "";

    public string Supervisor { get; set; } = "";
    public string TeamLead { get; set; } = "";

    public int Orders { get; set; }
    public int Goal { get; set; }
    public int HoursWorked { get; set; }

    public bool PTO { get; set; }
    public string Comments { get; set; } = "";
    public string? IssueCategory { get; set; }

    public string ColorCode => Orders > Goal ? "green" : (Orders == Goal ? "yellow" : "red");

    public string ShiftKey => $"{ShiftDate:yyyy-MM-dd}_{ShiftName}";
}

public class SlitterPerformanceService
{
    private readonly List<SlitterShiftEntry> _entries = new();

    public Task<List<SlitterShiftEntry>> GetAllAsync()
        => Task.FromResult(_entries);

    public Task<List<SlitterShiftEntry>> GetByOperatorAsync(string name)
        => Task.FromResult(_entries.Where(e => e.OperatorName == name).ToList());

    public Task AddAsync(SlitterShiftEntry entry)
    {
        _entries.Add(entry);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(SlitterShiftEntry updated)
    {
        var index = _entries.FindIndex(e => e.Id == updated.Id);
        if (index >= 0)
            _entries[index] = updated;

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _entries.RemoveAll(e => e.Id == id);
        return Task.CompletedTask;
    }
}

public class JsonFileStorageService : IStorageService
{
    private readonly string _filePath = "wwwroot/data/slitter-data.json";

    public async Task<List<SlitterShiftEntry>> LoadAsync()
    {
        if (!File.Exists(_filePath))
            return new List<SlitterShiftEntry>();

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<SlitterShiftEntry>>(json) ?? new();
    }

    public async Task SaveAsync(List<SlitterShiftEntry> entries)
    {
        var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, json);
    }
}