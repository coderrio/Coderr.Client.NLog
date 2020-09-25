using Coderr.Client.Contracts;
using Coderr.Client.NLog.ContextProviders;
using NLog;
using NLog.Targets;

namespace Coderr.Client.NLog
{
    /// <summary>
    ///     Our target which will catch nlog exceptions and report them
    /// </summary>
    [Target("Coderr")]
    public sealed class CoderrLogTarget : Target
    {
        /// <summary>
        ///     Writes logging event to the log target. Must be overridden in inheriting
        ///     classes.
        /// </summary>
        /// <param name="logEvent">Logging event to be written out.</param>
        protected override void Write(LogEventInfo logEvent)
        {
            LogsProvider.Instance.Add(new LogEntryDto(logEvent.TimeStamp.ToUniversalTime(), ConvertLevel(logEvent.Level), logEvent.Message)
            {
                Exception = logEvent.Exception?.ToString(),
                Source = logEvent.LoggerName,
            });

            if (logEvent.Exception == null)
                return;

            Err.Report(logEvent.Exception, new
            {
                ErrTags = "nlog,level-" + logEvent.Level,
                logEvent.TimeStamp,
                Message = logEvent.FormattedMessage
            });
        }

        private int ConvertLevel(LogLevel level)
        {
            if (level == LogLevel.Fatal) return 5;
            if (level == LogLevel.Error) return 4;
            if (level == LogLevel.Warn) return 3;
            if (level == LogLevel.Info) return 2;
            if (level == LogLevel.Debug) return 1;

            return 0;
        }
    }
}