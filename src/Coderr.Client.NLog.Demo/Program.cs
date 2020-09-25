using System;
using System.IO;
using NLog;

namespace Coderr.Client.NLog.Demo
{
    class Program
    {
        static void Main()
        {
            var url = new Uri("http://localhost:60473/");
            Err.Configuration.Credentials(url,
                "1a68bc3e123c48a3887877561b0982e2",
                "bd73436e965c4f3bb0578f57c21fde69");


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
