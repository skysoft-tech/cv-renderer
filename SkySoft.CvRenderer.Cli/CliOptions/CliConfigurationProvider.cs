using Microsoft.Extensions.Configuration;
using System.Collections;
using System.CommandLine;
using System.CommandLine.Parsing;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public class CliConfigurationProvider : ConfigurationProvider
    {
        private readonly string[] _args;
        private readonly ICliParser _parser;

        public CliConfigurationProvider(ICliParser parser, string[] args)
        {
            _args = args;
            _parser = parser;
        }

        public override void Load()
        {
            if (_args.Length == 0)
            {
                return;
            }

            var rootCommand = _parser.ParseArgs(_args);

            foreach (var option in rootCommand.CommandResult.Command.Options)
            {
                if (rootCommand.HasOption(option))
                {
                    var key = GetOptionKey(option);
                    var value = rootCommand.GetValueForOption(option);

                    switch (value)
                    {
                        case string str:
                            Data[key] = str;
                            break;
                        case IEnumerable array:
                            SplitArrayValue(key, array);
                            break;
                        default:
                            Data[key] = value.ToString();
                            break;
                    }
                }
            }
        }

        private static string GetOptionKey(Option option)
        {
            if (option is ICliOption cliOption)
            {
                return OptionKeySelector.GetKey(cliOption.ConfigKey);
            }

            return option.Name;
        }

        private void SplitArrayValue(string key, IEnumerable value)
        {
            var i = 0;
            foreach (var item in value)
            {
                Data[$"{key}:{i}"] = item.ToString();

                i++;
            }
        }


    }
}
