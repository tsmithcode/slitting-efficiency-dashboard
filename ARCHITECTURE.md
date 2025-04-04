Absolutely — here is your complete `ARCHITECTURE.md` in **clean Markdown format** ready to paste into your GitHub repo:

---

```markdown
# 🧱 ARCHITECTURE.md

## 📌 Project: Slitting Efficiency Dashboard  
**Author:** Thomas Smith  
**Platform:** Blazor Server (.NET 8)  
**Charting:** Recharts (via interop or component integration)  
**UI:** TailwindCSS + Bootstrap grid  
**Architecture Pattern:** Modular, component-driven, DI-powered  

---

## 🧭 Overview

The Slitting Efficiency Dashboard is a modular Blazor Server application for tracking shift-level productivity, issues, and operator performance. It follows a clean separation between:

- 📦 Data Models  
- 🧠 Services (business logic)  
- 🧩 UI Components  
- 📊 Dashboard Visuals  
- 📤 Data Output & Export Tools  

---

## 🗂️ Folder Structure

```
SlittingDashboard/
├── Pages/
│   ├── Input.razor
│   └── Dashboard.razor
├── Components/
│   ├── DateRangePicker.razor
│   └── Select.razor
├── Data/
│   ├── Models/
│   │   ├── ShiftSummary.cs
│   │   ├── OperatorEntry.cs
│   │   └── DailyShiftSnapshot.cs
│   └── Services/
│       ├── IShiftTrackingService.cs
│       ├── IPerformanceAggregator.cs
│       └── MockSnapshotService.cs
├── Services/
│   └── SnapshotService.ts
├── wwwroot/js/
│   └── export.js
└── Shared/
    └── Layout.razor
```

---

## 🧠 Data Models (`/Data/Models`)

### `OperatorEntry.cs`
- Slitter number  
- Operator name  
- HourlyOrders array  
- DailyGoal  
- Comment

### `DailyShiftSnapshot.cs`
- Date  
- Shift  
- Supervisor  
- Team Lead  
- List<OperatorEntry>

### `ShiftSummary.cs`
- Flattened summary for charts  
- TotalOrders, TotalGoal, Efficiency  
- Aggregated Issues dictionary

---

## 🔧 Services (`/Data/Services`)

### `IShiftTrackingService`
- Saves and retrieves shift data (currently in-memory)

### `IPerformanceAggregator`
- Aggregates data for dashboards  
- Computes KPIs and prepares chart series

### `MockSnapshotService`
- Development-only mock data service  
- Replaceable with database-backed provider

> Registered in `Program.cs` using DI:
```csharp
builder.Services.AddSingleton<IShiftTrackingService, ShiftTrackingService>();
builder.Services.AddSingleton<IPerformanceAggregator, PerformanceAggregator>();
```

---

## 📄 Pages

### `Input.razor`
- Shift form with dynamic operator rows  
- Hourly input, daily goal, issue comments  
- Form validation with data annotations

### `Dashboard.razor`
- Filters: DateRange, Shift, Operator  
- Live-updating chart cards:
  - LineChart (Orders vs Goal)
  - BarChart (Issue Counts)
  - ComposedChart (Pareto)

---

## 📊 Charting (via Recharts)

- LineChart – Total Orders vs Goal  
- BarChart – Daily Issue Counts (with colored bars)  
- ComposedChart – Pareto Analysis (bar + cumulative % line)  

> Color Logic:  
- Green: <5 issues  
- Yellow: 5–9  
- Red: ≥10

---

## 📤 Data Output

- `Export CSV` — download filtered dashboard data  
- `Print` — print-ready charts with clean layout  
- Uses `print:hidden` classes for hiding form elements  

---

## 🔁 Data Flow

```
Input.razor ➝ Save Snapshot ➝ Aggregate Data ➝ Dashboard ➝ Charts + Export
```

---

## 🧩 Extensibility Points

| Area         | How to Extend |
|--------------|----------------|
| Data Storage | Replace `MockSnapshotService` with SQL or API |
| Real-time    | Add SignalR for live dashboard push |
| Auth         | Integrate Azure AD or Identity |
| Export       | Schedule automatic CSV or PDF summary |
| BI Tools     | Feed into Power BI or SQL Warehouse |

---

## 🧠 Architectural Principles

- **Single Responsibility** for each class/component  
- **Dependency Injection** for all services  
- **DRY** and reusable filter/chart logic  
- **Loose Coupling** between business logic and UI  
- **Ready for API or database integration**  

---

## 🔒 Security

- No personal data or authentication  
- Internal/private network ready  
- No 3rd party tracking  
- CSV/PDF stored locally only  

---

## 📬 Contact

Built by [Thomas Smith](https://tsmithcode.ai)  
📧 **thomas@tsmithcode.ai**  
License: **CC BY-NC-ND 4.0** — All rights reserved
```

---

Would you like `CHANGELOG.md` or `DEVELOPMENT_PLAN.md` scaffolded next?
