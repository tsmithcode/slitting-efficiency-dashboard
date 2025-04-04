using SlittingDashboard.Components;
using SlittingDashboard.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var app = builder.Build();

builder.Services.AddSingleton<IPerformanceAggregator, PerformanceAggregator>();
builder.Services.AddSingleton<IShiftTrackingService, ShiftTrackingService>();
builder.Services.AddSingleton<ISnapshotService, SnapshotService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();