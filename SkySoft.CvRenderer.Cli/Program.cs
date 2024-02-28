using Microsoft.Extensions.Configuration;
using SkySoft.CvRenderer.Cli.CliOptions;

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
            var executor = new Executor(logger);

            await executor.Run(options.InputFile, options.OutputFile, options.Rendering.WorkColumnWidth, options.Rendering.HideLogo);
        }
    }
}

