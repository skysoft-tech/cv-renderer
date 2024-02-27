using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    internal class CliParser : ICliParser
    {
        private const int _errorExitCode = 2;
        public ParseResult ParseResult { get; private set; }

        public readonly RootCommand RootCommand = new();

        public CliParser()
        {
            Console.WriteLine("CliParser created");
        }

        public ParseResult ParseArgs(string[] args)
        {
            if (ParseResult != null)
            {
                return ParseResult;
            }

            var instance = new CommandLineBuilder(ConfigureCommandLine(RootCommand))
                .UseParseErrorReporting(_errorExitCode)
                .UseHelp("help", "--help", "-h")
                .UseVersionOption("version", "--version", "-v")
                .UseParseDirective()
                .EnablePosixBundling(false)
                .Build();

            ParseResult = instance.Parse(args);

            if (args.Length == 0)
            {
                return ParseResult;
            }

            // required to run embedded commands like help
            ParseResult.Invoke();

            if (ParseResult.Errors.Any())
            {
                Environment.Exit(_errorExitCode);
            }

            foreach (var child in ParseResult.CommandResult.Children)
            {
                if (child is OptionResult optionResult)
                {
                    if (optionResult.Option.Name == "help" || optionResult.Option.Name == "version")
                    {
                        Environment.Exit(0);
                    }
                }
            }

            return ParseResult;
        }

        protected virtual Command[] GetSubcommands()
        {
            return Array.Empty<Command>();
        }

        protected virtual Option[] GetRootCommandOptions()
        {
            return Array.Empty<Option>();
        }

        private Command ConfigureCommandLine(Command rootCommand)
        {
            var subCommands = GetSubcommands();

            // Add sub-commands
            foreach (var subcommand in subCommands)
            {
                rootCommand.AddCommand(subcommand);
            }

            // Add options
            var options = GetRootCommandOptions();
            foreach (var option in options)
            {
                rootCommand.AddOption(option);
            }

            if (options?.Length != 0)
            {
                // NOTE: The empty handler is needed to activate the root command
                //       in case when we need to parse it's options
                rootCommand.SetHandler(() => { });
            }

            return rootCommand;
        }
    }
}
