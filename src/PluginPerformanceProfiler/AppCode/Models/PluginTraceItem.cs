using System;

namespace PluginPerformanceProfiler.AppCode.Models
{
    public class PluginTraceItem
    {
        public Guid TraceLogId { get; set; }
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
        public string StageName
        {
            get
            {
                switch (Stage)
                {
                    case 10: return "Pre-Validation (10)";
                    case 20: return "Pre-Operation (20)";
                    case 40: return "Post-Operation (40)";
                    case 50: return "Other (50)";
                    default: return $"Stage {Stage}";
                }
            }
        }

        public int Mode { get; set; } // 0 = Sync, 1 = Async
        public string ModeName => Mode == 1 ? "Async" : "Sync";
        public int DurationMs { get; set; }
        public string DurationFormatted => DurationMs >= 1000 ? $"{DurationMs / 1000.0:F2} s" : $"{DurationMs:N0} ms";

        public int Depth { get; set; }
        public DateTime StartTime { get; set; }
        public Guid CorrelationId { get; set; }
        public Guid RequestId { get; set; }

        public bool HasException => !string.IsNullOrWhiteSpace(ExceptionDetails);
        public string Status => HasException ? "✖ FAILED" : "✔ SUCCESS";
        public string ExceptionDetails { get; set; } = string.Empty;
        public string MessageBlock { get; set; } = string.Empty;

        public string PerformanceCategory
        {
            get
            {
                if (DurationMs < 500) return "Fast (<500ms)";
                if (DurationMs < 2000) return "Moderate (0.5s - 2s)";
                if (DurationMs < 5000) return "Slow (2s - 5s)";
                return "Critical (>5s / Timeout Risk)";
            }
        }
    }
}
