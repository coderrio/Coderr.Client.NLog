using Coderr.Client.Config;
using NLog;
using NLog.Config;
using NLog.Targets;

// ReSharper disable once CheckNamespace
namespace Coderr.Client.NLog
{
    /// <summary>
    /// Coderr configuration extensions, not working yet. NLog seems to overwrite the config
    /// </summary>
    internal static class ErrConfigurationExtensions
    {
        /// <summary>
        /// Catch exceptions that are logged using NLog.
        /// </summary>
        /// <param name="configuration">this</param>
        /// <param name="minimumLevel">If specified, ignore all logged exceptions where the log level is less than the given one</param>
        public static void CatchNlogExceptions(this CoderrConfiguration configuration, LogLevel minimumLevel = null)
        {
            Target.Register<CoderrLogTarget>("Coderr");
            //            LogManager.Configuration.AddTarget("Coderr",new CoderrLogTarget());

            var target = new CoderrLogTarget();

            if (minimumLevel != null && minimumLevel != LogLevel.Off)
                LogManager.Configuration.AddRule(minimumLevel, LogLevel.Fatal, new CoderrLogTarget());
            else
                LogManager.Configuration.AddRuleForAllLevels(new CoderrLogTarget());

            LogManager.ConfigurationChanged += OnConfigChanged;
        }

        private static void OnConfigChanged(object sender, LoggingConfigurationChangedEventArgs e)
        {
        }
    }
}