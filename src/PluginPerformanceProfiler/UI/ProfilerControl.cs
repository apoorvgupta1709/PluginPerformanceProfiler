using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xrm.Sdk;
using PluginPerformanceProfiler.AppCode.Helpers;
using PluginPerformanceProfiler.AppCode.Models;
using PluginPerformanceProfiler.AppCode.Services;
using XrmToolBox.Extensibility;

namespace PluginPerformanceProfiler.UI
{
    public partial class ProfilerControl : PluginControlBase
    {
        private ProfilerAnalysisReport? _currentReport;
        private EnvironmentTraceSetting? _currentSetting;

        public ProfilerControl()
        {
            InitializeComponent();
        }

        private void ProfilerControl_Load(object sender, EventArgs e)
        {
            cboTimeRange.SelectedIndex = 2; // Last 24 hours
            cboMessage.SelectedIndex = 0;   // ALL
        }

        private void btnRunProfiler_Click(object sender, EventArgs e)
        {
            ExecuteMethod(RunProfiler);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ExecuteMethod(RunProfiler);
        }

        private void RunProfiler()
        {
            if (Service == null)
            {
                MessageBox.Show("Please connect to a Microsoft Dataverse environment first.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hours = 24;
            switch (cboTimeRange.SelectedIndex)
            {
                case 0: hours = 1; break;
                case 1: hours = 6; break;
                case 2: hours = 24; break;
                case 3: hours = 72; break;
                case 4: hours = 168; break;
            }

            var config = new ProfilerFilterConfig
            {
                HoursBack = hours,
                MessageFilter = cboMessage.SelectedItem?.ToString() ?? "ALL",
                EntityFilter = txtEntity.Text.Trim(),
                TypeNameFilter = txtSearch.Text.Trim(),
                SlowOnly = chkSlowOnly.Checked,
                ExceptionsOnly = chkExceptionsOnly.Checked,
                SyncOnly = chkSyncOnly.Checked,
                MaxRecordsToFetch = 3000
            };

            lblStatus.Text = "Querying PluginTraceLog telemetry from Dataverse...";
            progressBar.Visible = true;
            btnApplyFilter.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Analyzing Plugin Telemetry...",
                Work = (worker, args) =>
                {
                    var reader = new TraceLogReaderService(Service);
                    var setting = reader.GetEnvironmentTraceSetting();

                    var traces = reader.FetchTraceLogs(config, msg => worker.ReportProgress(0, msg));

                    var engine = new PerformanceAnalyticsEngine();
                    var report = engine.Analyze(traces);

                    args.Result = new Tuple<ProfilerAnalysisReport, EnvironmentTraceSetting>(report, setting);
                },
                ProgressChanged = args =>
                {
                    if (args.UserState is string msg)
                    {
                        lblStatus.Text = msg;
                    }
                },
                PostWorkCallBack = args =>
                {
                    progressBar.Visible = false;
                    btnApplyFilter.Enabled = true;

                    if (args.Error != null)
                    {
                        MessageBox.Show("Error reading trace logs: " + args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Text = "Error loading trace logs.";
                        return;
                    }

                    if (args.Result is Tuple<ProfilerAnalysisReport, EnvironmentTraceSetting> tuple)
                    {
                        _currentReport = tuple.Item1;
                        _currentSetting = tuple.Item2;

                        RenderReport(_currentReport);
                        lblStatus.Text = $"Analysis complete: {_currentReport.TotalExecutions:N0} plugin traces analyzed across {_currentReport.StepSummaries.Count:N0} unique steps.";
                    }
                }
            });
        }

        private void RenderReport(ProfilerAnalysisReport report)
        {
            // 1. Update KPI Cards
            lblTotalVal.Text = report.TotalExecutions.ToString("N0");
            lblAvgVal.Text = $"{report.OverallAvgDurationMs:F0} ms";
            lblSlowestVal.Text = $"{report.SlowestExecutionMs:N0} ms";
            lblFailureVal.Text = $"{report.OverallFailureRate:F1}%";
            lblLoopsVal.Text = report.PotentialLoopsCount.ToString();

            if (report.PotentialLoopsCount > 0)
            {
                cardLoops.BackColor = Color.FromArgb(254, 242, 242);
                lblLoopsVal.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else
            {
                cardLoops.BackColor = Color.White;
                lblLoopsVal.ForeColor = Color.FromArgb(16, 185, 129);
            }

            // 2. Populate Step Leaderboard
            dgvSteps.DataSource = null;
            dgvSteps.DataSource = report.StepSummaries.Select(s => new
            {
                PluginName = s.ShortTypeName,
                Message = s.MessageName,
                Entity = s.PrimaryEntity,
                Stage = s.StageName,
                Mode = s.ModeName,
                ExecCount = s.ExecutionCount,
                AvgMs = Math.Round(s.AvgDurationMs, 0),
                P90Ms = Math.Round(s.P90DurationMs, 0),
                MaxMs = s.MaxDurationMs,
                Failures = $"{s.FailureCount} ({s.FailureRate:F1}%)",
                MaxDepth = s.MaxDepthEncountered,
                Health = s.HealthStatus,
                Recommendation = s.Recommendation,
                FullType = s.TypeName
            }).ToList();

            // 3. Populate Cascading Chains
            dgvChains.DataSource = null;
            dgvChains.DataSource = report.CascadingChains.Select(c => new
            {
                CorrelationId = c.CorrelationId,
                Trigger = $"{c.TriggerMessage} on {c.TriggerEntity}",
                Steps = c.TotalStepsInChain,
                MaxDepth = c.MaxDepth,
                TotalDuration = $"{c.TotalChainDurationMs:N0} ms",
                LoopDetected = c.IsPotentialLoop ? "⚠ YES" : "No",
                Severity = c.Severity,
                Timestamp = c.FirstExecutionTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList();

            // 4. Populate Raw Traces
            dgvRaw.DataSource = null;
            dgvRaw.DataSource = report.RawTraces.Take(1000).Select(t => new
            {
                Time = t.StartTime.ToString("HH:mm:ss.fff"),
                Plugin = t.ShortTypeName,
                Message = t.MessageName,
                Entity = t.PrimaryEntity,
                Stage = t.StageName,
                Mode = t.ModeName,
                Duration = $"{t.DurationMs:N0} ms",
                Depth = t.Depth,
                Status = t.Status,
                Category = t.PerformanceCategory,
                TraceLogId = t.TraceLogId
            }).ToList();

            // 5. Populate Comparison Dropdowns
            cboStepA.DataSource = null;
            cboStepB.DataSource = null;

            var stepNames = report.StepSummaries
                .Select(s => $"{s.ShortTypeName} [{s.MessageName} on {s.PrimaryEntity}] ({s.ModeName})")
                .ToList();

            if (stepNames.Count > 0)
            {
                cboStepA.DataSource = new List<string>(stepNames);
                cboStepB.DataSource = new List<string>(stepNames);

                if (stepNames.Count > 1) cboStepB.SelectedIndex = 1;
            }
        }

        private void dgvChains_SelectionChanged(object sender, EventArgs e)
        {
            if (_currentReport == null || dgvChains.CurrentRow == null) return;

            treeChainSteps.Nodes.Clear();
            if (dgvChains.CurrentRow.DataBoundItem is null) return;

            // Extract CorrelationId from row
            var cellVal = dgvChains.CurrentRow.Cells["CorrelationId"].Value;
            if (cellVal is Guid corrId)
            {
                var chain = _currentReport.CascadingChains.FirstOrDefault(c => c.CorrelationId == corrId);
                if (chain != null)
                {
                    var root = treeChainSteps.Nodes.Add($"Transaction {chain.CorrelationId} ({chain.Steps.Count} steps, Total: {chain.TotalChainDurationMs} ms)");

                    foreach (var step in chain.Steps)
                    {
                        string icon = step.HasException ? "✖ [FAILED] " : "✔ ";
                        string nodeText = $"{icon}Depth {step.Depth}: {step.ShortTypeName} ({step.MessageName} on {step.PrimaryEntity}, {step.DurationMs} ms)";
                        var stepNode = root.Nodes.Add(nodeText);

                        if (!string.IsNullOrWhiteSpace(step.ExceptionDetails))
                        {
                            stepNode.Nodes.Add($"Error: {step.ExceptionDetails.Split('\n').FirstOrDefault()}");
                        }
                    }

                    root.ExpandAll();
                }
            }
        }

        private void dgvRaw_SelectionChanged(object sender, EventArgs e)
        {
            if (_currentReport == null || dgvRaw.CurrentRow == null) return;

            var idVal = dgvRaw.CurrentRow.Cells["TraceLogId"].Value;
            if (idVal is Guid traceId)
            {
                var trace = _currentReport.RawTraces.FirstOrDefault(t => t.TraceLogId == traceId);
                if (trace != null)
                {
                    var sb = new System.Text.StringBuilder();
                    sb.AppendLine($"--- TRACE EXECUTION METRICS ---");
                    sb.AppendLine($"Plugin: {trace.TypeName}");
                    sb.AppendLine($"Message: {trace.MessageName} | Entity: {trace.PrimaryEntity} | Stage: {trace.StageName} | Mode: {trace.ModeName}");
                    sb.AppendLine($"Duration: {trace.DurationMs} ms ({trace.PerformanceCategory})");
                    sb.AppendLine($"Depth: {trace.Depth} | StartTime: {trace.StartTime:yyyy-MM-dd HH:mm:ss.fff}");
                    sb.AppendLine($"CorrelationId: {trace.CorrelationId} | RequestId: {trace.RequestId}");
                    sb.AppendLine();

                    if (!string.IsNullOrWhiteSpace(trace.ExceptionDetails))
                    {
                        sb.AppendLine($"--- EXCEPTION STACK TRACE ---");
                        sb.AppendLine(trace.ExceptionDetails);
                        sb.AppendLine();
                    }

                    if (!string.IsNullOrWhiteSpace(trace.MessageBlock))
                    {
                        sb.AppendLine($"--- ITracingService LOGS ---");
                        sb.AppendLine(trace.MessageBlock);
                    }
                    else
                    {
                        sb.AppendLine("(No ITracingService message lines recorded in this trace)");
                    }

                    txtTraceLogDetails.Text = sb.ToString();
                }
            }
        }

        private void dgvSteps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || _currentReport == null) return;
            string? typeName = dgvSteps.Rows[e.RowIndex].Cells["FullType"].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(typeName))
            {
                txtSearch.Text = typeName;
                tabControlMain.SelectedTab = tabRaw;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (_currentReport == null || _currentReport.StepSummaries.Count == 0)
            {
                MessageBox.Show("Please run a profiler audit first before comparing steps.", "Data Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idxA = cboStepA.SelectedIndex;
            int idxB = cboStepB.SelectedIndex;

            if (idxA < 0 || idxB < 0 || idxA >= _currentReport.StepSummaries.Count || idxB >= _currentReport.StepSummaries.Count)
            {
                MessageBox.Show("Please select two plugin steps to compare.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var stepA = _currentReport.StepSummaries[idxA];
            var stepB = _currentReport.StepSummaries[idxB];

            var engine = new PerformanceAnalyticsEngine();
            var comp = engine.CompareSteps(stepA, stepB);

            var sb = new System.Text.StringBuilder();
            sb.AppendLine("================================================================================");
            sb.AppendLine("                     STEP PERFORMANCE COMPARISON ANALYSIS                      ");
            sb.AppendLine("================================================================================");
            sb.AppendLine($"ANALYSIS CONCLUSION: {comp.SummaryText}");
            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine($"METRIC                         | STEP A (Baseline)             | STEP B (Comparison)           ");
            sb.AppendLine("--------------------------------------------------------------------------------");
            sb.AppendLine($"Plugin Name                    | {stepA.ShortTypeName.PadRight(30)}| {stepB.ShortTypeName.PadRight(30)}");
            sb.AppendLine($"Message / Entity               | {$"{stepA.MessageName} on {stepA.PrimaryEntity}".PadRight(30)}| {$"{stepB.MessageName} on {stepB.PrimaryEntity}".PadRight(30)}");
            sb.AppendLine($"Mode & Stage                   | {$"{stepA.ModeName} - Stage {stepA.Stage}".PadRight(30)}| {$"{stepB.ModeName} - Stage {stepB.Stage}".PadRight(30)}");
            sb.AppendLine($"Total Executions               | {stepA.ExecutionCount.ToString("N0").PadRight(30)}| {stepB.ExecutionCount.ToString("N0").PadRight(30)}");
            sb.AppendLine($"Average Duration               | {$"{stepA.AvgDurationMs:F1} ms".PadRight(30)}| {$"{stepB.AvgDurationMs:F1} ms".PadRight(30)}");
            sb.AppendLine($"P90 Latency (90th percentile)  | {$"{stepA.P90DurationMs:F1} ms".PadRight(30)}| {$"{stepB.P90DurationMs:F1} ms".PadRight(30)}");
            sb.AppendLine($"P99 Latency (99th percentile)  | {$"{stepA.P99DurationMs:F1} ms".PadRight(30)}| {$"{stepB.P99DurationMs:F1} ms".PadRight(30)}");
            sb.AppendLine($"Max Observed Duration          | {$"{stepA.MaxDurationMs:N0} ms".PadRight(30)}| {$"{stepB.MaxDurationMs:N0} ms".PadRight(30)}");
            sb.AppendLine($"Failure Rate                   | {$"{stepA.FailureRate:F1}% ({stepA.FailureCount})".PadRight(30)}| {$"{stepB.FailureRate:F1}% ({stepB.FailureCount})".PadRight(30)}");
            sb.AppendLine($"Max Call Depth                 | {stepA.MaxDepthEncountered.ToString().PadRight(30)}| {stepB.MaxDepthEncountered.ToString().PadRight(30)}");
            sb.AppendLine($"Health Status                  | {stepA.HealthStatus.PadRight(30)}| {stepB.HealthStatus.PadRight(30)}");
            sb.AppendLine("================================================================================");
            sb.AppendLine("OPTIMIZATION RECOMMENDATION:");
            sb.AppendLine($"• Step A: {stepA.Recommendation}");
            sb.AppendLine($"• Step B: {stepB.Recommendation}");

            txtCompareDetails.Text = sb.ToString();
        }

        private void btnTraceAdvisor_Click(object sender, EventArgs e)
        {
            if (_currentSetting == null)
            {
                if (Service != null)
                {
                    var reader = new TraceLogReaderService(Service);
                    _currentSetting = reader.GetEnvironmentTraceSetting();
                }
                else
                {
                    MessageBox.Show("Please connect to Dataverse first.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show(
                $"CURRENT TRACE LOG SETTING: {_currentSetting.SettingName.ToUpper()}\n\n" +
                $"{_currentSetting.Description}\n\n" +
                $"GOVERNANCE ADVICE:\n{_currentSetting.GovernanceAdvice}\n\n" +
                $"To change this setting in Power Platform:\n" +
                $"1. Open Power Platform Admin Center > Environments > Settings\n" +
                $"2. Expand 'Custom code' > 'Plugin trace log'\n" +
                $"3. Select 'Exception' (recommended) or 'All' (temporary profiling only).",
                "Trace Logging Governance Advisor",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnExportHtml_Click(object sender, EventArgs e)
        {
            if (_currentReport == null || _currentReport.TotalExecutions == 0)
            {
                MessageBox.Show("Please run a profiler audit first before exporting the report.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML Executive Report (*.html)|*.html";
                sfd.FileName = $"Plugin_Performance_Audit_{DateTime.UtcNow:yyyyMMdd_HHmm}.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ProfilerReportExporter.ExportHtmlReport(_currentReport, sfd.FileName);
                    if (MessageBox.Show("Report exported successfully! Open now?", "Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (_currentReport == null || _currentReport.StepSummaries.Count == 0)
            {
                MessageBox.Show("Please run a profiler audit first before exporting CSV data.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"Plugin_Performance_Metrics_{DateTime.UtcNow:yyyyMMdd_HHmm}.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ProfilerReportExporter.ExportCsvReport(_currentReport, sfd.FileName);
                    MessageBox.Show("CSV data saved to:\n" + sfd.FileName, "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSponsor_Click(object sender, EventArgs e)
        {
            SponsorHelper.ShowSponsorDialog(this, "Plugin Performance Profiler");
        }
    }
}
