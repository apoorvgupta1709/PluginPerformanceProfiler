# ⚡ Dataverse Plugin Performance Profiler for XrmToolBox

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![XrmToolBox](https://img.shields.io/badge/XrmToolBox-Plugin-orange.svg)](https://www.xrmtoolbox.com)
[![GitHub Sponsors](https://img.shields.io/github/sponsors/apoorvgupta1709?color=%23db2777&logo=github)](https://github.com/sponsors/apoorvgupta1709)

> **Identify slow Dataverse plugin steps, eliminate timeouts, detect recursive loops, and compare execution performance from trace data.**

---

## 💥 The Problem
In Microsoft Dataverse and Dynamics 365, plugins run business-critical operations. However:
1. **Unpredictable Latency & Timeouts**: Admins and developers frequently face the dreaded `2-minute sandbox execution timeout` or user complaints of sluggish forms without knowing which plugin step caused it.
2. **Infinite Loops & Recursions**: A plugin updating a record triggers another plugin, which cascades into depth 4, 6, 8, or hits the Dataverse max depth limit (16) and crashes the transaction.
3. **Trace Log Blind Spots**: The `plugintracelog` table contains thousands of rows of raw telemetry, but Dataverse provides no built-in aggregation, P90/P99 latency calculations, or execution chain visualizations.
4. **Governance Bloat**: Environments left with Plugin Trace Logging set to `All` quickly bloat expensive database storage.

---

## 🚀 Key Features

### 1. 🏆 Step Performance Leaderboard
- Aggregates thousands of trace logs into unique plugin steps (`TypeName` + `Message` + `Entity` + `Stage` + `Mode`).
- Computes **Total Executions**, **Average Latency (ms)**, **Min / Max**, and critical **P90 / P99 Percentiles**.
- Auto-evaluates **Health Status** (🟢 Healthy, 🟡 Warning, 🔴 Critical) based on latency and failure thresholds.

### 2. 🔄 Cascading Pattern & Recursion Detector
- Groups executions by transaction `CorrelationId`.
- Maps cascading multi-step chains with execution tree offsets and call depths.
- Automatically flags **potential infinite loops** and circular updates before they crash production.

### 3. 📋 Raw Trace & Exception Deep-Dive
- Inspect individual execution records, timestamps, and durations.
- Instant viewing of full **Exception Stack Traces** and `ITracingService.Trace` logs in a clean viewer.

### 4. ⚖ Step Performance Comparison (A vs B)
- Select any two steps (or the same step across different messages/entities) to view a side-by-side latency comparison, percentage difference, and risk factor.

### 5. ⚙ Trace Logging Governance Advisor
- One-click check of your environment's trace logging setting (`Off`, `Exception`, `All`).
- Provides best practice governance recommendations to prevent database storage bloat.

### 6. 📊 Executive HTML & CSV Reports
- Export audit-ready HTML executive reports with KPI cards, top offending plugins, cascading loop diagnostics, and optimization advice.
- Export raw tabular data to CSV for Excel and Power BI.

---

## 💖 Support Continuous Development & Pro Features
This tool is open-source and free for the community. If it saved your team hours of complex performance troubleshooting, consider supporting development on **GitHub Sponsors**:

👉 **[Sponsor Apoorv Gupta on GitHub Sponsors](https://github.com/sponsors/apoorvgupta1709)**

- ☕ **$5 / month — Community Supporter**: Help cover testing environments and maintenance.
- 💎 **$15 / month — Pro Supporter**: Priority feature requests, latency alert rules, and direct assistance.
- 🏢 **$50 / month — Enterprise Backer**: Sponsor recognition on GitHub repo, custom telemetry adapters, and 1-on-1 support.

---

## 📦 Installation & Setup

### Automatic Build & Local Deployment
The project includes automated deployment targets. When you build with the .NET SDK:
```bash
dotnet build PluginPerformanceProfiler.sln
```
The compiled `PluginPerformanceProfiler.dll` is automatically deployed to:
- `C:\Users\apoorv\Downloads\XrmToolbox\Plugins\`
- `C:\Users\apoorv\Downloads\XrmToolbox\`
- `%AppData%\MscrmTools\XrmToolBox\Plugins\`

Simply restart **XrmToolBox** and search for **Plugin Performance Profiler**!

---

## 📄 License
MIT License. Created by [Apoorv Gupta](https://github.com/apoorvgupta1709).
