using Microsoft.Extensions.Configuration;
using SkySoft.CvRenderer.Cli.CliOptions;
using SkySoft.CvRenderer.Utils;
using SkySoft.CvRenderer.Utils.Cli;

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

            var deserializeCli = new ExecutorCli(logger, options.InputFile, options.OutputFile, options.Rendering.WorkColumnWidth, options.Rendering.HideLogo);
            await deserializeCli.Run();
        }
    }
}