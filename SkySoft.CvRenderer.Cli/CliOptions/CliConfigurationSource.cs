using Microsoft.Extensions.Configuration;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public class CliConfigurationSource : IConfigurationSource
    {
        private readonly string[] _args;
        private readonly ICliParser _parser;

        public CliConfigurationSource(string[] args)
        {
            _args = args;
            _parser = new AppCliParser();
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CliConfigurationProvider(_parser, _args);
        }
    }
}
