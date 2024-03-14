using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Cli.CliOptions;
using SkySoft.CvRenderer.Utils;
using SkySoft.CvRenderer.Utils.Deserialization;

namespace SkySoft.CvRenderer.Cli
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true)
                .AddCommandLineConfiguration(args)
                .Build();

            var options = config.Get<AppOptions>();

            var logger = Logger.SetupLogger();

            var deserializerLogger = new LoggerFactory().CreateLogger<Deserializer>();

            var deserializer = new Deserializer(deserializerLogger);

            var deserializeCli = new ExecutorCli(logger, deserializer, options.InputFile, options.OutputFile, options.Rendering.WorkColumnWidth, options.Rendering.HideLogo);
            await deserializeCli.Run();
        }
    }
}