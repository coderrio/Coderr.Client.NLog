using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coderr.Client;
using NLog;

namespace Coderr.Client.Nlog.Demo.Net452
{
    class Program
    {
        static void Main(string[] args)
        {
            var url  =new Uri("http://localhost:50473/");
            Err.Configuration.Credentials(url,
                "fab233e3492d4cc68f64c7770db795a3",
                "3c28c12d76ad4b5586f216232bd8c7c2");

            var log = LogManager.GetCurrentClassLogger();
            try
            {
                throw new InvalidOperationException("Hoh");
            }
            catch (Exception ex)
            {
               log.Error("Failed", ex);
            }

            Console.ReadLine();
        }
    }
}
