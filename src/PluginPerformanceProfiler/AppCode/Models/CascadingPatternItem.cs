using System;
using System.Collections.Generic;

namespace PluginPerformanceProfiler.AppCode.Models
{
    public class CascadingPatternItem
    {
        public Guid CorrelationId { get; set; }
        public DateTime FirstExecutionTime { get; set; }
        public string TriggerEntity { get; set; } = string.Empty;
        public string TriggerMessage { get; set; } = string.Empty;
        public int TotalStepsInChain { get; set; }
        public int MaxDepth { get; set; }
        public int TotalChainDurationMs { get; set; }
        public bool IsPotentialLoop { get; set; }
        public string LoopReason { get; set; } = string.Empty;
        public List<PluginTraceItem> Steps { get; set; } = new List<PluginTraceItem>();

        public string Severity
        {
            get
            {
                if (IsPotentialLoop || MaxDepth >= 8) return "🔴 HIGH RISK (Loop Detected)";
                if (TotalStepsInChain >= 5 || MaxDepth >= 4) return "🟡 ELEVATED (Cascading Chain)";
                return "🟢 NORMAL";
            }
        }
    }

    public class ProfilerFilterConfig
    {
        public int HoursBack { get; set; } = 24; // 1, 6, 24, 72, 168
        public string MessageFilter { get; set; } = "ALL";
        public string EntityFilter { get; set; } = string.Empty;
        public string TypeNameFilter { get; set; } = string.Empty;
        public bool SlowOnly { get; set; } = false; // > 2000 ms
        public bool ExceptionsOnly { get; set; } = false;
        public bool SyncOnly { get; set; } = false;
        public int MaxRecordsToFetch { get; set; } = 2500;
    }

    public class EnvironmentTraceSetting
    {
        public int SettingCode { get; set; } // 0 = Off, 1 = Exception, 2 = All
        public string SettingName
        {
            get
            {
                switch (SettingCode)
                {
                    case 0: return "Off";
                    case 1: return "Exception";
                    case 2: return "All";
                    default: return $"Code {SettingCode}";
                }
            }
        }

        public string Description
        {
            get
            {
                switch (SettingCode)
                {
                    case 0: return "Plugin trace logging is disabled. No logs are being recorded.";
                    case 1: return "Logging is set to Exceptions only. Only failing plugins record traces.";
                    case 2: return "Logging is set to ALL. Every plugin execution is stored in Dataverse.";
                    default: return "Unknown";
                }
            }
        }

        public string GovernanceAdvice
        {
            get
            {
                if (SettingCode == 2) return "⚠️ WARNING: Trace logging is set to 'All'. This consumes substantial database storage! Switch to 'Exception' after profiling.";
                if (SettingCode == 0) return "ℹ NOTE: Trace logging is currently 'Off'. Enable 'All' temporarily in System Settings to capture execution telemetry.";
                return "✔ RECOMMENDED: 'Exception' logging balances telemetry with database capacity.";
            }
        }
    }
}
