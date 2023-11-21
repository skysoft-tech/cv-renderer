using Serilog;
using Serilog.Extensions.Logging;

namespace SkySoft.CvRenderer.Cli
{
    internal class Logger
    {
        public static Microsoft.Extensions.Logging.ILogger SetupLogger()
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
            .CreateLogger();

            var provider = new SerilogLoggerProvider(Log.Logger);

            return provider.CreateLogger("SkySoft.CvRenderer");
        }
    }
}
