using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http.Tracing;

namespace VechicleWebApp.Helpers
{
    /// <summary>
    /// Wrapper for NLog
    /// </summary>
    public class NLoggerHelper : ITraceWriter
    {
        private static readonly Logger classLogger = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> loggingMap =
            new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>>
                {
                    {TraceLevel.Info, classLogger.Info},
                    {TraceLevel.Debug, classLogger.Debug},
                    {TraceLevel.Error, classLogger.Error},
                    {TraceLevel.Fatal, classLogger.Fatal},
                    {TraceLevel.Warn, classLogger.Warn}
                });

        private Dictionary<TraceLevel, Action<string>> Logger
        {
            get { return loggingMap.Value; }
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                var record = new TraceRecord(request, category, level);
                traceAction(record);
                Log(record);
            }
        }

        private void Log(TraceRecord traceRecord)
        {
            StringBuilder message = new StringBuilder();

            if (traceRecord.Request != null)
            {
                if (traceRecord.Request.Method != null)
                    message.Append(traceRecord.Request.Method);

                if (traceRecord.Request.RequestUri != null)
                    message.Append(" ").Append(traceRecord.Request.RequestUri);
            }

            if (!string.IsNullOrWhiteSpace(traceRecord.Category))
                message.Append(" ").Append(traceRecord.Category);

            if (!string.IsNullOrWhiteSpace(traceRecord.Operator))
                message.Append(" ").Append(traceRecord.Operator).Append(" ").Append(traceRecord.Operation);

            if (!string.IsNullOrWhiteSpace(traceRecord.Message))
                message.Append(" ").Append(traceRecord.Message);

            if (traceRecord.Request!=null)
                message.Append(" ").Append(traceRecord.Request);

            //if (traceRecord.Status != null)
                message.Append(" ").Append(traceRecord.Status);

            if (traceRecord.Exception != null && !string.IsNullOrWhiteSpace(traceRecord.Exception.GetBaseException().Message))
                message.Append(" ").Append(traceRecord.Exception.GetBaseException().Message);

            Logger[traceRecord.Level](message.ToString());
        }

       
    }
}