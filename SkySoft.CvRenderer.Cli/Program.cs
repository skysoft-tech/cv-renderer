using System.CommandLine;

namespace SkySoft.CvRenderer.Cli
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            var inputOption = new Option<string>(
                aliases: new string[] { "--cvJson", "--in", "-f" },
                description: "Path to JSON file with CV data. See more: https://jsonresume.org/schema/");

            var outputOption = new Option<string>(
                aliases: new string[] { "--pdf", "--out", "-p" },
                description: "The way to save CV");

            var rootCommand = new RootCommand("Allow to render PDF based on CV data");
            rootCommand.AddOption(inputOption);
            rootCommand.AddOption(outputOption);

            rootCommand.SetHandler(async (input, output) =>
            {
                var logger = Logger.SetupLogger();
                var executor = new Executor(logger);

                await executor.Run(input, output);
            }, inputOption, outputOption);

            return await rootCommand.InvokeAsync(args);
        }
    }
}

