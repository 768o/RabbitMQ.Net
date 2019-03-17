using log4net;
using log4net.Config;
using log4net.Repository;
using System.IO;

namespace Rabbit.Net.Helper
{
    public class Logger
    {
        private static readonly ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
        public static ILog Log = GetLog();

        static ILog GetLog()
        {
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            return LogManager.GetLogger(repository.Name, "NETCorelog4net");
        }
    }
}
