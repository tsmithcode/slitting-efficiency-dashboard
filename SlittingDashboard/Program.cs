using SlittingDashboard.Components;
using SlittingDashboard.Data.Interfaces;
using SlittingDashboard.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services BEFORE building the app
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ✅ Register DI services
builder.Services.AddSingleton<IPerformanceAggregator, PerformanceAggregator>();
builder.Services.AddSingleton<IShiftTrackingService, ShiftTrackingService>();
builder.Services.AddSingleton<ISnapshotService, SnapshotService>();

var app = builder.Build();

// ✅ Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

// ✅ Map Razor components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();