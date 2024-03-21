using System.CommandLine;
using System.CommandLine.Parsing;
using System.Linq.Expressions;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public interface ICliOption
    {
        LambdaExpression ConfigKey { get; }
    }

    public class CliOption<T> : Option<T>, ICliOption
    {
        public CliOption(Expression<OptionsPropertyAccessor<T>> key)
            : base(OptionKeySelector.GetAliases(key), OptionKeySelector.GetDescription(key))
        {
            ConfigKey = key;
        }

        public CliOption(string name, Expression<OptionsPropertyAccessor<T>> key, string? description = null)
            : base(name, description)
        {
            ConfigKey = key;
        }

        public CliOption(string[] aliases, Expression<OptionsPropertyAccessor<T>> key, string? description = null)
            : base(aliases, description)
        {
            ConfigKey = key;
        }

        public CliOption(
            string[] aliases,
            Expression<OptionsPropertyAccessor<T>> key,
            ParseArgument<T> parseArgument,
            string? description = null
        )
            : base(aliases, parseArgument, false, description)
        {
            ConfigKey = key;
        }

        public LambdaExpression ConfigKey { get; }
    }

    public class CliArrayOption : CliOption<string[]>, ICliOption
    {
        public CliArrayOption(
            string[] aliases,
            Expression<OptionsPropertyAccessor<string[]>> key,
            string? description = null
        )
            : base(aliases, key, GetCustomParser(), description)
        {
            AllowMultipleArgumentsPerToken = true;
        }

        private static ParseArgument<string[]> GetCustomParser()
        {
            var parser = new CliCustomArrayParser();

            return result => parser.Parse(result);
        }
    }
}
