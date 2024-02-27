using Serilog;
using System.CommandLine;
﻿using Microsoft.Extensions.Configuration;
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
            await executor.Run(options.InputFile, options.OutputFile, options.Rendering.WorkColumnWidth);
        }
    }
}

