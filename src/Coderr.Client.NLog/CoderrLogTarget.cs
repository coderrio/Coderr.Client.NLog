using NLog;
using NLog.Targets;

namespace Coderr.Client.NLog
{
    /// <summary>
    /// Our target which will catch nlog exceptions and report them
    /// </summary>
    [Target("Coderr")]
    public sealed class CoderrLogTarget : Target
    {
        /// <summary>
        /// Writes logging event to the log target. Must be overridden in inheriting
        /// classes.
        /// </summary>
        /// <param name="logEvent">Logging event to be written out.</param>
        protected override void Write(LogEventInfo logEvent)
        {
            if (logEvent.Exception == null)
                return;

            Err.Report(logEvent.Exception, new
            {
                ErrTags = "nlog,level-" + logEvent.Level,
                logEvent.TimeStamp,
                Message = logEvent.FormattedMessage,
            });
        }
    }
}
