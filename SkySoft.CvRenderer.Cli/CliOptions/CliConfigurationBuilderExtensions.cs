using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public static class CliConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCommandLineConfiguration(
            this IConfigurationBuilder builder, string[] args
        )
        {
            return builder.Add(new CliConfigurationSource(args));
        }
    }
}
