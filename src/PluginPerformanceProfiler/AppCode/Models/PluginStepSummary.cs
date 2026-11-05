using System;

namespace PluginPerformanceProfiler.AppCode.Models
{
    public class PluginStepSummary
    {
        public string StepKey => $"{TypeName}|{MessageName}|{PrimaryEntity}|{Stage}|{Mode}";
        public string TypeName { get; set; } = string.Empty;
        public string ShortTypeName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TypeName)) return "(Unknown)";
                int lastDot = TypeName.LastIndexOf('.');
                return lastDot >= 0 && lastDot < TypeName.Length - 1 ? TypeName.Substring(lastDot + 1) : TypeName;
            }
        }

        public string MessageName { get; set; } = string.Empty;
        public string PrimaryEntity { get; set; } = string.Empty;
        public int Stage { get; set; }
        public string StageName { get; set; } = string.Empty;
        public int Mode { get; set; }
        public string ModeName => Mode == 1 ? "Async" : "Sync";

        public int ExecutionCount { get; set; }
        public long TotalDurationMs { get; set; }
        public double AvgDurationMs => ExecutionCount > 0 ? (double)TotalDurationMs / ExecutionCount : 0;
        public int MinDurationMs { get; set; }
        public int MaxDurationMs { get; set; }
        public double P90DurationMs { get; set; }
        public double P99DurationMs { get; set; }

        public int FailureCount { get; set; }
        public double FailureRate => ExecutionCount > 0 ? (double)FailureCount / ExecutionCount * 100.0 : 0;
        public int MaxDepthEncountered { get; set; }

        public string HealthStatus
        {
            get
            {
                if (FailureRate > 10 || MaxDurationMs >= 10000 || AvgDurationMs >= 3000) return "🔴 CRITICAL";
                if (FailureRate > 0 || MaxDurationMs >= 3000 || AvgDurationMs >= 1500 || MaxDepthEncountered >= 4) return "🟡 WARNING";
                return "🟢 HEALTHY";
            }
        }

        public string Recommendation
        {
            get
            {
                if (MaxDepthEncountered >= 8) return "High recursion depth! Check for circular updates.";
                if (AvgDurationMs >= 3000) return "Sync execution exceeds 3s. Consider offloading to Async or optimizing queries.";
                if (FailureRate > 20) return "High failure rate. Inspect ExceptionDetails for missing null-checks or permissions.";
                if (ExecutionCount > 1000 && AvgDurationMs >= 1000) return "High volume step consuming Dataverse API quotas.";
                return "Optimal performance within standard Dataverse thresholds.";
            }
        }
    }
}
