using System;
using System.IO;
using System.Linq;
using System.Text;
using PluginPerformanceProfiler.AppCode.Models;
using PluginPerformanceProfiler.AppCode.Services;

namespace PluginPerformanceProfiler.AppCode.Helpers
{
    public static class ProfilerReportExporter
    {
        public static string ExportHtmlReport(ProfilerAnalysisReport report, string filePath)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang='en'>");
            sb.AppendLine("<head>");
            sb.AppendLine("  <meta charset='utf-8'/>");
            sb.AppendLine("  <title>Dataverse Plugin Performance Profiler — Executive Report</title>");
            sb.AppendLine("  <style>");
            sb.AppendLine("    body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; background: #f8fafc; color: #1e293b; margin: 0; padding: 24px; }");
            sb.AppendLine("    .container { max-width: 1200px; margin: 0 auto; background: #ffffff; border-radius: 12px; box-shadow: 0 4px 6px -1px rgba(0,0,0,0.1); padding: 32px; border: 1px solid #e2e8f0; }");
            sb.AppendLine("    .header { border-bottom: 2px solid #e2e8f0; padding-bottom: 20px; margin-bottom: 24px; display: flex; justify-content: space-between; align-items: center; }");
            sb.AppendLine("    .header h1 { margin: 0; font-size: 24px; color: #0f172a; }");
            sb.AppendLine("    .header p { margin: 4px 0 0; color: #64748b; font-size: 14px; }");
            sb.AppendLine("    .grid-kpis { display: grid; grid-template-columns: repeat(auto-fit, minmax(210px, 1fr)); gap: 16px; margin-bottom: 32px; }");
            sb.AppendLine("    .kpi-card { background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 18px; text-align: center; }");
            sb.AppendLine("    .kpi-val { font-size: 26px; font-weight: 700; color: #2563eb; margin-top: 4px; }");
            sb.AppendLine("    .kpi-title { font-size: 13px; text-transform: uppercase; font-weight: 600; color: #64748b; }");
            sb.AppendLine("    .table-container { margin-bottom: 36px; overflow-x: auto; }");
            sb.AppendLine("    h2 { font-size: 18px; color: #0f172a; margin-bottom: 12px; border-left: 4px solid #2563eb; padding-left: 10px; }");
            sb.AppendLine("    table { width: 100%; border-collapse: collapse; font-size: 13.5px; text-align: left; }");
            sb.AppendLine("    th { background: #f1f5f9; padding: 10px 14px; font-weight: 600; color: #334155; border-bottom: 2px solid #cbd5e1; }");
            sb.AppendLine("    td { padding: 10px 14px; border-bottom: 1px solid #e2e8f0; }");
            sb.AppendLine("    tr:hover { background: #f8fafc; }");
            sb.AppendLine("    .badge { display: inline-block; padding: 3px 8px; border-radius: 6px; font-size: 11.5px; font-weight: 700; }");
            sb.AppendLine("    .badge-healthy { background: #dcfce7; color: #15803d; }");
            sb.AppendLine("    .badge-warning { background: #fef3c7; color: #b45309; }");
            sb.AppendLine("    .badge-critical { background: #fee2e2; color: #b91c1c; }");
            sb.AppendLine("    .sponsor-card { margin-top: 40px; padding: 22px; background: #fdf2f8; border: 1px solid #fbcfe8; border-radius: 12px; text-align: center; }");
            sb.AppendLine("    .sponsor-btn { display: inline-block; background: #db2777; color: #ffffff; font-weight: 700; padding: 10px 24px; border-radius: 8px; text-decoration: none; font-size: 13.5px; margin-top: 10px; }");
            sb.AppendLine("  </style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("  <div class='container'>");

            // Header
            sb.AppendLine("    <div class='header'>");
            sb.AppendLine("      <div>");
            sb.AppendLine("        <h1>⚡ Dataverse Plugin Performance Profiler</h1>");
            sb.AppendLine($"        <p>Execution Telemetry Audit • Generated {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>");
            sb.AppendLine("      </div>");
            sb.AppendLine("    </div>");

            // KPI Cards
            sb.AppendLine("    <div class='grid-kpis'>");
            sb.AppendLine($"     <div class='kpi-card'><div class='kpi-title'>Total Executions</div><div class='kpi-val'>{report.TotalExecutions:N0}</div></div>");
            sb.AppendLine($"     <div class='kpi-card'><div class='kpi-title'>Average Latency</div><div class='kpi-val'>{report.OverallAvgDurationMs:F0} ms</div></div>");
            sb.AppendLine($"     <div class='kpi-card'><div class='kpi-title'>Slowest Execution</div><div class='kpi-val' style='color:#dc2626;'>{report.SlowestExecutionMs:N0} ms</div></div>");
            sb.AppendLine($"     <div class='kpi-card'><div class='kpi-title'>Failure Rate</div><div class='kpi-val' style='color:{(report.OverallFailureRate > 5 ? "#dc2626" : "#2563eb")};'>{report.OverallFailureRate:F1}%</div></div>");
            sb.AppendLine($"     <div class='kpi-card'><div class='kpi-title'>Cascading Loops</div><div class='kpi-val' style='color:{(report.PotentialLoopsCount > 0 ? "#dc2626" : "#16a34a")};'>{report.PotentialLoopsCount}</div></div>");
            sb.AppendLine("    </div>");

            // Top Steps Table
            sb.AppendLine("    <div class='table-container'>");
            sb.AppendLine("      <h2>Top Plugin Steps Performance Ranking</h2>");
            sb.AppendLine("      <table>");
            sb.AppendLine("        <thead>");
            sb.AppendLine("          <tr>");
            sb.AppendLine("            <th>Plugin Type</th><th>Message</th><th>Entity</th><th>Stage</th><th>Mode</th><th>Executions</th><th>Avg (ms)</th><th>P90 (ms)</th><th>Max (ms)</th><th>Failures</th><th>Status</th>");
            sb.AppendLine("          </tr>");
            sb.AppendLine("        </thead>");
            sb.AppendLine("        <tbody>");

            foreach (var s in report.StepSummaries.Take(25))
            {
                string badgeClass = s.HealthStatus.Contains("CRITICAL") ? "badge-critical" : (s.HealthStatus.Contains("WARNING") ? "badge-warning" : "badge-healthy");
                sb.AppendLine("          <tr>");
                sb.AppendLine($"            <td><strong>{Escape(s.ShortTypeName)}</strong><br/><small style='color:#64748b;'>{Escape(s.TypeName)}</small></td>");
                sb.AppendLine($"            <td><code>{Escape(s.MessageName)}</code></td>");
                sb.AppendLine($"            <td>{Escape(s.PrimaryEntity)}</td>");
                sb.AppendLine($"            <td>{Escape(s.StageName)}</td>");
                sb.AppendLine($"            <td>{Escape(s.ModeName)}</td>");
                sb.AppendLine($"            <td>{s.ExecutionCount:N0}</td>");
                sb.AppendLine($"            <td><strong>{s.AvgDurationMs:F0} ms</strong></td>");
                sb.AppendLine($"            <td>{s.P90DurationMs:F0} ms</td>");
                sb.AppendLine($"            <td style='color:{(s.MaxDurationMs > 3000 ? "#dc2626" : "#1e293b")}; font-weight:600;'>{s.MaxDurationMs:N0} ms</td>");
                sb.AppendLine($"            <td>{s.FailureCount} ({s.FailureRate:F1}%)</td>");
                sb.AppendLine($"            <td><span class='badge {badgeClass}'>{Escape(s.HealthStatus)}</span></td>");
                sb.AppendLine("          </tr>");
            }

            sb.AppendLine("        </tbody>");
            sb.AppendLine("      </table>");
            sb.AppendLine("    </div>");

            // Cascading Chains Table
            if (report.CascadingChains.Count > 0)
            {
                sb.AppendLine("    <div class='table-container'>");
                sb.AppendLine("      <h2>Detected Cascading Execution Chains & Potential Recursions</h2>");
                sb.AppendLine("      <table>");
                sb.AppendLine("        <thead>");
                sb.AppendLine("          <tr><th>Correlation ID</th><th>Trigger</th><th>Steps in Chain</th><th>Max Depth</th><th>Total Duration</th><th>Loop Detected?</th><th>Notes</th></tr>");
                sb.AppendLine("        </thead>");
                sb.AppendLine("        <tbody>");

                foreach (var c in report.CascadingChains.Take(15))
                {
                    string loopBadge = c.IsPotentialLoop ? "<span class='badge badge-critical'>YES - RECURSION</span>" : "<span class='badge badge-healthy'>No</span>";
                    sb.AppendLine("          <tr>");
                    sb.AppendLine($"            <td><code>{c.CorrelationId}</code></td>");
                    sb.AppendLine($"            <td><strong>{Escape(c.TriggerMessage)}</strong> on {Escape(c.TriggerEntity)}</td>");
                    sb.AppendLine($"            <td>{c.TotalStepsInChain} steps</td>");
                    sb.AppendLine($"            <td>Depth {c.MaxDepth}</td>");
                    sb.AppendLine($"            <td>{c.TotalChainDurationMs:N0} ms</td>");
                    sb.AppendLine($"            <td>{loopBadge}</td>");
                    sb.AppendLine($"            <td>{Escape(c.LoopReason)}</td>");
                    sb.AppendLine("          </tr>");
                }

                sb.AppendLine("        </tbody>");
                sb.AppendLine("      </table>");
                sb.AppendLine("    </div>");
            }

            // Sponsor Footer
            sb.AppendLine("    <div class='sponsor-card'>");
            sb.AppendLine("      <h3 style='margin:0 0 6px 0; color:#db2777; font-size:16px;'>💖 Support Plugin Performance Profiler Continuous Development</h3>");
            sb.AppendLine("      <p style='margin:0 0 12px 0; color:#64748b; font-size:13px;'>If this tool helped identify bottlenecks and optimize your Dataverse solution performance, please consider backing development on GitHub Sponsors.</p>");
            sb.AppendLine("      <a href='https://github.com/sponsors/apoorvgupta1709' target='_blank' class='sponsor-btn'>Sponsor Apoorv Gupta on GitHub Sponsors →</a>");
            sb.AppendLine("    </div>");

            sb.AppendLine("  </div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            return filePath;
        }

        public static string ExportCsvReport(ProfilerAnalysisReport report, string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("TypeName,ShortName,Message,Entity,Stage,Mode,Executions,AvgDurationMs,MinDurationMs,MaxDurationMs,P90DurationMs,P99DurationMs,Failures,FailureRatePct,MaxDepth,HealthStatus");

            foreach (var s in report.StepSummaries)
            {
                sb.AppendLine($"\"{EscapeCsv(s.TypeName)}\",\"{EscapeCsv(s.ShortTypeName)}\",\"{EscapeCsv(s.MessageName)}\",\"{EscapeCsv(s.PrimaryEntity)}\",\"{EscapeCsv(s.StageName)}\",\"{EscapeCsv(s.ModeName)}\",{s.ExecutionCount},{s.AvgDurationMs:F2},{s.MinDurationMs},{s.MaxDurationMs},{s.P90DurationMs:F2},{s.P99DurationMs:F2},{s.FailureCount},{s.FailureRate:F2},{s.MaxDepthEncountered},\"{EscapeCsv(s.HealthStatus)}\"");
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            return filePath;
        }

        private static string Escape(string? s) => System.Net.WebUtility.HtmlEncode(s ?? string.Empty);
        private static string EscapeCsv(string? s) => s?.Replace("\"", "\"\"") ?? string.Empty;
    }
}
