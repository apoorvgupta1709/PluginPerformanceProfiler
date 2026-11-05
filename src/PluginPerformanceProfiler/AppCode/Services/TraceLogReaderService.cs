using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using PluginPerformanceProfiler.AppCode.Models;

namespace PluginPerformanceProfiler.AppCode.Services
{
    public class TraceLogReaderService
    {
        private readonly IOrganizationService _service;

        public TraceLogReaderService(IOrganizationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public EnvironmentTraceSetting GetEnvironmentTraceSetting()
        {
            try
            {
                var query = new QueryExpression("organization")
                {
                    ColumnSet = new ColumnSet("plugintracelogsetting")
                };
                var results = _service.RetrieveMultiple(query);
                if (results.Entities.Count > 0 && results.Entities[0].Contains("plugintracelogsetting"))
                {
                    var opt = results.Entities[0].GetAttributeValue<OptionSetValue>("plugintracelogsetting");
                    int val = opt != null ? opt.Value : 0;
                    return new EnvironmentTraceSetting { SettingCode = val };
                }
            }
            catch
            {
                // Fallback if permission restricts organization read
            }

            return new EnvironmentTraceSetting { SettingCode = 1 }; // Default exception
        }

        public List<PluginTraceItem> FetchTraceLogs(ProfilerFilterConfig config, Action<string>? progressCallback = null)
        {
            var list = new List<PluginTraceItem>();
            DateTime cutoff = DateTime.UtcNow.AddHours(-config.HoursBack);

            var query = new QueryExpression("plugintracelog")
            {
                ColumnSet = new ColumnSet(
                    "plugintracelogid",
                    "typename",
                    "messagename",
                    "primaryentity",
                    "stage",
                    "mode",
                    "performanceexecutionduration",
                    "performanceexecutionstarttime",
                    "depth",
                    "correlationid",
                    "requestid",
                    "exceptiondetails",
                    "messageblock",
                    "createdon"
                ),
                PageInfo = new PagingInfo
                {
                    Count = 500,
                    PageNumber = 1,
                    PagingCookie = null
                }
            };

            // Order by createdon descending so we analyze newest traces first
            query.Orders.Add(new OrderExpression("createdon", OrderType.Descending));

            // Filters
            query.Criteria.AddCondition("createdon", ConditionOperator.GreaterEqual, cutoff);

            if (!string.IsNullOrWhiteSpace(config.MessageFilter) && !config.MessageFilter.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                query.Criteria.AddCondition("messagename", ConditionOperator.Equal, config.MessageFilter.Trim());
            }

            if (!string.IsNullOrWhiteSpace(config.EntityFilter))
            {
                query.Criteria.AddCondition("primaryentity", ConditionOperator.Equal, config.EntityFilter.Trim().ToLowerInvariant());
            }

            if (!string.IsNullOrWhiteSpace(config.TypeNameFilter))
            {
                query.Criteria.AddCondition("typename", ConditionOperator.Like, $"%{config.TypeNameFilter.Trim()}%");
            }

            if (config.SlowOnly)
            {
                query.Criteria.AddCondition("performanceexecutionduration", ConditionOperator.GreaterEqual, 2000);
            }

            if (config.ExceptionsOnly)
            {
                query.Criteria.AddCondition("exceptiondetails", ConditionOperator.NotNull);
            }

            if (config.SyncOnly)
            {
                query.Criteria.AddCondition("mode", ConditionOperator.Equal, 0); // 0 = Sync
            }

            progressCallback?.Invoke("Querying Dataverse PluginTraceLog table...");

            int totalRetrieved = 0;
            while (true)
            {
                EntityCollection resp = _service.RetrieveMultiple(query);
                foreach (var entity in resp.Entities)
                {
                    var item = MapEntityToTraceItem(entity);
                    list.Add(item);
                    totalRetrieved++;
                    if (totalRetrieved >= config.MaxRecordsToFetch) break;
                }

                progressCallback?.Invoke($"Retrieved {totalRetrieved:N0} trace records...");

                if (!resp.MoreRecords || totalRetrieved >= config.MaxRecordsToFetch)
                {
                    break;
                }

                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = resp.PagingCookie;
            }

            return list;
        }

        private PluginTraceItem MapEntityToTraceItem(Entity e)
        {
            var item = new PluginTraceItem
            {
                TraceLogId = e.Id,
                TypeName = e.GetAttributeValue<string>("typename") ?? string.Empty,
                MessageName = e.GetAttributeValue<string>("messagename") ?? string.Empty,
                PrimaryEntity = e.GetAttributeValue<string>("primaryentity") ?? string.Empty,
                DurationMs = e.Contains("performanceexecutionduration") ? e.GetAttributeValue<int>("performanceexecutionduration") : 0,
                Depth = e.Contains("depth") ? e.GetAttributeValue<int>("depth") : 1,
                StartTime = e.Contains("performanceexecutionstarttime") ? e.GetAttributeValue<DateTime>("performanceexecutionstarttime").ToLocalTime() : (e.Contains("createdon") ? e.GetAttributeValue<DateTime>("createdon").ToLocalTime() : DateTime.MinValue),
                ExceptionDetails = e.GetAttributeValue<string>("exceptiondetails") ?? string.Empty,
                MessageBlock = e.GetAttributeValue<string>("messageblock") ?? string.Empty
            };

            if (e.Contains("stage"))
            {
                var stageOpt = e.GetAttributeValue<OptionSetValue>("stage");
                item.Stage = stageOpt?.Value ?? 0;
            }

            if (e.Contains("mode"))
            {
                var modeOpt = e.GetAttributeValue<OptionSetValue>("mode");
                item.Mode = modeOpt?.Value ?? 0;
            }

            if (e.Contains("correlationid"))
            {
                item.CorrelationId = e.GetAttributeValue<Guid>("correlationid");
            }

            if (e.Contains("requestid"))
            {
                item.RequestId = e.GetAttributeValue<Guid>("requestid");
            }

            return item;
        }
    }
}
