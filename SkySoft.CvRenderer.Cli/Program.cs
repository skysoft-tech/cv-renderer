using Serilog;
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

            var companyColumnWidthOption = new Option<int>(
                aliases: new string[] { "--columnWidth", "-w" },
                description: "Allows to change width of the first column in Work Experience section", 
                getDefaultValue: () => 60);

            var companyHideLogo = new Option<bool>(
                 aliases: new string[] { "--hideLogo", "-h" },
                 description: "Allows you to hide the logo in the header",
                 getDefaultValue: () => false);

            var rootCommand = new RootCommand("Allow to render PDF based on CV data");
            rootCommand.AddOption(inputOption);
            rootCommand.AddOption(outputOption);
            rootCommand.AddOption(companyColumnWidthOption);
            rootCommand.AddOption(companyHideLogo);

            rootCommand.SetHandler(async (input, output, width, hideLogo) =>
            {
                var logger = Logger.SetupLogger();
                var executor = new Executor(logger);

                await executor.Run(input, output, width, hideLogo);
            }, inputOption, outputOption, companyColumnWidthOption, companyHideLogo);

            return await rootCommand.InvokeAsync(args);
        }
    }
}

