using System;
using Coderr.Client.NLog;
using NLog;

namespace Coderr.Client.Nlog.Demo.Net461
{
    class Program
    {
        static void Main()
        {
            var url = new Uri("http://localhost:50473/");
            Err.Configuration.Credentials(url,
                "fab233e3492d4cc68f64c7770db795a3",
                "3c28c12d76ad4b5586f216232bd8c7c2");
            Err.Configuration.CatchNlogExceptions();


            var log = LogManager.GetCurrentClassLogger();
            try
            {
                throw new InvalidOperationException("Hoh");
            }
            catch (Exception ex)
            {
                log.Error(ex, "Failed");
            }

            Console.ReadLine();
        }
    }
}
