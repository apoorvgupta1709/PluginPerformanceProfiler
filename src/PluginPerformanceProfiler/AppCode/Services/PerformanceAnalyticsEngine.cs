using System;
using System.Collections.Generic;
using System.Linq;
using PluginPerformanceProfiler.AppCode.Models;

namespace PluginPerformanceProfiler.AppCode.Services
{
    public class StepComparisonResult
    {
        public PluginStepSummary StepA { get; set; } = new PluginStepSummary();
        public PluginStepSummary StepB { get; set; } = new PluginStepSummary();
        public double AvgDurationDiffMs => StepB.AvgDurationMs - StepA.AvgDurationMs;
        public double PercentageDiff => StepA.AvgDurationMs > 0 ? ((StepB.AvgDurationMs - StepA.AvgDurationMs) / StepA.AvgDurationMs) * 100.0 : 0;
        public string SummaryText
        {
            get
            {
                if (Math.Abs(PercentageDiff) < 5) return "Both steps perform comparably (under 5% difference).";
                if (AvgDurationDiffMs > 0)
                {
                    return $"Step B is {Math.Abs(PercentageDiff):F1}% SLOWER than Step A (+{AvgDurationDiffMs:F0} ms average latency).";
                }
                return $"Step B is {Math.Abs(PercentageDiff):F1}% FASTER than Step A ({AvgDurationDiffMs:F0} ms average latency).";
            }
        }
    }

    public class ProfilerAnalysisReport
    {
        public List<PluginTraceItem> RawTraces { get; set; } = new List<PluginTraceItem>();
        public List<PluginStepSummary> StepSummaries { get; set; } = new List<PluginStepSummary>();
        public List<CascadingPatternItem> CascadingChains { get; set; } = new List<CascadingPatternItem>();

        public int TotalExecutions => RawTraces.Count;
        public double OverallAvgDurationMs => RawTraces.Count > 0 ? RawTraces.Average(r => r.DurationMs) : 0;
        public int SlowestExecutionMs => RawTraces.Count > 0 ? RawTraces.Max(r => r.DurationMs) : 0;
        public int TotalFailures => RawTraces.Count(r => r.HasException);
        public double OverallFailureRate => RawTraces.Count > 0 ? (double)TotalFailures / RawTraces.Count * 100.0 : 0;
        public int PotentialLoopsCount => CascadingChains.Count(c => c.IsPotentialLoop);
    }

    public class PerformanceAnalyticsEngine
    {
        public ProfilerAnalysisReport Analyze(List<PluginTraceItem> traces)
        {
            var report = new ProfilerAnalysisReport
            {
                RawTraces = traces ?? new List<PluginTraceItem>()
            };

            if (report.RawTraces.Count == 0)
            {
                return report;
            }

            // 1. Group by unique Plugin Step (TypeName, MessageName, PrimaryEntity, Stage, Mode)
            var stepGroups = report.RawTraces
                .GroupBy(t => new { t.TypeName, t.MessageName, t.PrimaryEntity, t.Stage, t.Mode })
                .ToList();

            foreach (var g in stepGroups)
            {
                var durations = g.Select(x => x.DurationMs).OrderBy(x => x).ToList();
                int count = durations.Count;

                var summary = new PluginStepSummary
                {
                    TypeName = g.Key.TypeName,
                    MessageName = g.Key.MessageName,
                    PrimaryEntity = g.Key.PrimaryEntity,
                    Stage = g.Key.Stage,
                    StageName = g.First().StageName,
                    Mode = g.Key.Mode,
                    ExecutionCount = count,
                    TotalDurationMs = durations.Select(d => (long)d).Sum(),
                    MinDurationMs = durations.First(),
                    MaxDurationMs = durations.Last(),
                    P90DurationMs = CalculatePercentile(durations, 0.90),
                    P99DurationMs = CalculatePercentile(durations, 0.99),
                    FailureCount = g.Count(x => x.HasException),
                    MaxDepthEncountered = g.Max(x => x.Depth)
                };

                report.StepSummaries.Add(summary);
            }

            // Sort steps by total impact (TotalDurationMs descending)
            report.StepSummaries = report.StepSummaries.OrderByDescending(s => s.TotalDurationMs).ToList();

            // 2. Analyze Cascading Chains and Loops (Group by CorrelationId)
            var correlationGroups = report.RawTraces
                .Where(t => t.CorrelationId != Guid.Empty)
                .GroupBy(t => t.CorrelationId)
                .Where(g => g.Count() >= 2) // Chains with at least 2 steps
                .ToList();

            foreach (var cg in correlationGroups)
            {
                var orderedSteps = cg.OrderBy(s => s.StartTime).ThenBy(s => s.Depth).ToList();
                var first = orderedSteps.First();
                int maxDepth = orderedSteps.Max(s => s.Depth);
                int totalDuration = orderedSteps.Sum(s => s.DurationMs);

                // Detect recursion / repeated steps in same transaction
                bool isLoop = false;
                string loopReason = string.Empty;

                if (maxDepth >= 6)
                {
                    isLoop = true;
                    loopReason = $"Execution depth reached {maxDepth} (approaching Dataverse 16 depth limit).";
                }

                // Check if any step executed 3+ times in this transaction
                var stepFrequencies = orderedSteps
                    .GroupBy(s => $"{s.TypeName}|{s.MessageName}")
                    .Where(sg => sg.Count() >= 3)
                    .ToList();

                if (stepFrequencies.Count > 0)
                {
                    isLoop = true;
                    var repeated = stepFrequencies.First();
                    loopReason = $"Step '{repeated.Key}' executed {repeated.Count()} times in a single transaction!";
                }

                var chain = new CascadingPatternItem
                {
                    CorrelationId = cg.Key,
                    FirstExecutionTime = first.StartTime,
                    TriggerEntity = first.PrimaryEntity,
                    TriggerMessage = first.MessageName,
                    TotalStepsInChain = orderedSteps.Count,
                    MaxDepth = maxDepth,
                    TotalChainDurationMs = totalDuration,
                    IsPotentialLoop = isLoop,
                    LoopReason = loopReason,
                    Steps = orderedSteps
                };

                report.CascadingChains.Add(chain);
            }

            // Order cascading chains: loops first, then longest chains
            report.CascadingChains = report.CascadingChains
                .OrderByDescending(c => c.IsPotentialLoop)
                .ThenByDescending(c => c.TotalStepsInChain)
                .ToList();

            return report;
        }

        public StepComparisonResult CompareSteps(PluginStepSummary stepA, PluginStepSummary stepB)
        {
            return new StepComparisonResult
            {
                StepA = stepA,
                StepB = stepB
            };
        }

        private static double CalculatePercentile(List<int> sortedValues, double percentile)
        {
            if (sortedValues == null || sortedValues.Count == 0) return 0;
            if (sortedValues.Count == 1) return sortedValues[0];

            double index = percentile * (sortedValues.Count - 1);
            int lower = (int)Math.Floor(index);
            int upper = (int)Math.Ceiling(index);

            if (lower == upper) return sortedValues[lower];
            return sortedValues[lower] + (index - lower) * (sortedValues[upper] - sortedValues[lower]);
        }
    }
}
