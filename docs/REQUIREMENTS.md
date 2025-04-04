# 📋 REQUIREMENTS.md

## 📌 Project: Slitting Efficiency Dashboard  
**Author:** Thomas Smith  
**Platform:** Blazor Server (.NET 8) + Recharts  
**Last Updated:** 2025  
**License:** CC BY-NC-ND 4.0 — No commercial or educational use without permission

---

## 🎯 Business Goals

- Improve shift visibility and operator accountability
- Track and analyze production efficiency in real time
- Identify recurring issues to drive training and process improvements
- Empower leadership with actionable, exportable metrics
- Eliminate manual Excel-based tracking workflows
- Support performance-based decision-making (machine investment, staffing, etc.)

---

## ✅ Functional Requirements

### 🔢 Data Input
- [ ] Shift entry form must support:
  - Shift number
  - Team Lead and Supervisor
  - Operator names
  - Slitter number
  - Hourly order counts
  - Daily goal per operator
  - Comment dropdown (issue codes)
- [ ] Ability to add/remove operator rows dynamically
- [ ] Submit button to save the shift snapshot

### 📊 Dashboard Display
- [ ] Live updates from all shift entries
- [ ] Charts must include:
  - Orders vs Goal (LineChart)
  - Issue Frequency (BarChart with color alerts)
  - Pareto of Issues (Bar + Line, sorted by frequency)
- [ ] Visual cues for issue severity (color-coded)
- [ ] Support filtering by:
  - Date range
  - Shift
  - Operator

### 📤 Data Output
- [ ] Export filtered dashboard view to CSV
- [ ] Trigger print/PDF report for dashboard charts
- [ ] All filters must persist through export/print action

---

## ❌ Functional Exclusions
- ❌ No user authentication (roles defined by workflow, not login)
- ❌ No admin config or role-based permissions (static filters only)
- ❌ No real-time server push (data is updated on user action)
- ❌ No direct database or cloud storage integration (initial release uses mock/local data)

---

## 🧠 Non-Functional Requirements

### ⏱️ Performance
- [ ] All dashboard updates should occur within 300ms of filter changes
- [ ] Able to handle 1000+ records across a year of data without freezing
- [ ] Initial load under 1 second for recent data

### 🧩 Scalability
- [ ] App structure must allow future integration with:
  - SQL or NoSQL data backend
  - PTC Windchill or ERP system
  - Power BI or analytics tools
- [ ] Modular components must support swap of charting libraries if needed

### 📱 UX/UI
- [ ] Dashboard must scale to a 70" TV in plant display
- [ ] Shift input form designed for standard desktop entry
- [ ] Charts must adapt to mobile-friendly layout later if needed

### 🔐 Security / Access
- [ ] No personal data is tracked
- [ ] All user interaction is local to browser or private network
- [ ] CSV and PDF exports should not be auto-shared externally

---

## ⚙️ Technical Constraints

- Use **Blazor Server** with **.NET 8**
- Use **Recharts** via interop or embedding (JS with Blazor)
- Follow component-based architecture
- Use TailwindCSS + Bootstrap layout conventions
- Use DI for all services
- Use data annotations for validation

---

## 🗂️ Future Enhancements (Out of Scope for v1)
- Authentication and user roles
- Editable issues/categories from an admin page
- Integration with real-time factory data (sensors, MES)
- Offline Progressive Web App (PWA) support
- Automated PDF summaries emailed on schedule

---

## 📬 Contact
For commercial or educational license inquiries:  
📧 **thomas@tsmithcode.ai**  
🌐 [https://tsmithcode.ai](https://tsmithcode.ai)

