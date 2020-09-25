using System;
using Coderr.Client.Config;
using Coderr.Client.NLog.ContextProviders;
using NLog;
using NLog.Config;

// ReSharper disable once CheckNamespace
namespace Coderr.Client.NLog
{
    /// <summary>
    /// Coderr configuration extensions, not working yet. NLog seems to overwrite the config
    /// </summary>
    public static class ErrConfigurationExtensions
    {
        /// <summary>
        /// Catch exceptions that are logged using NLog.
        /// </summary>
        /// <param name="configuration">this</param>
        /// <param name="minimumLevel">If specified, ignore all logged exceptions where the log level is less than the given one</param>
        public static void CatchNlogExceptions(this CoderrConfiguration configuration, LogLevel minimumLevel = null)
        {
            configuration.ContextProviders.Add(LogsProvider.Instance);

            if (LogManager.Configuration.AllTargets.Count == 0)
                throw new InvalidOperationException("NLog have not yet been configured, which means that Coderr cannot catch log entries. Configure NLog first and then Coderr.");

            //Target.Register<CoderrLogTarget>("Coderr");
            //            LogManager.Configuration.AddTarget("Coderr",new CoderrLogTarget());

            var target = new CoderrLogTarget();
            LogManager.Configuration.AddTarget("Coderr", target);

            if (minimumLevel != null && minimumLevel != LogLevel.Off)
                LogManager.Configuration.AddRule(minimumLevel, LogLevel.Fatal, "Coderr");
            else
                LogManager.Configuration.AddRuleForAllLevels("Coderr");
            LogManager.Configuration.Reload();

            LogManager.ConfigurationChanged += OnConfigChanged;
        }

        private static void OnConfigChanged(object sender, LoggingConfigurationChangedEventArgs e)
        {
        }
    }
}