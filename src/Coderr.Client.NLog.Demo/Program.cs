using System;
using System.IO;
using NLog;

namespace Coderr.Client.NLog.Demo
{
    class Program
    {
        static void Main()
        {
            var url = new Uri("https://localhost:44393/");
            Err.Configuration.Credentials(url,
                "5a617e0773b94284bef33940e4bc8384",
                "3fab63fb846c4dd289f67b0b3340fefc");

            LogManager.ThrowConfigExceptions = true;
            Err.Configuration.CatchNlogExceptions();
            var log = LogManager.GetCurrentClassLogger();

            log.Info("Started");

            try
            {
                throw new InvalidDataException("Hoh");
            }
            catch (Exception ex)
            {
                log.Error(ex, "My message");
            }


            Console.WriteLine("Done");
        }
    }
}
