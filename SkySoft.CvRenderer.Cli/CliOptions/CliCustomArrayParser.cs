using System;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    internal class CliCustomArrayParser
    {
        private const char ARRAY_ITEMS_SEPARATOR = ',';

        public string[] Parse(ArgumentResult result)
        {
            if (result.Tokens.Count == 0)
            {
                return Array.Empty<string>();
            }

            // we will have multiple tokens in case AllowMultipleArgumentsPerToken is true
            // and multiple arguments are passed with space delimiter
            // --option value1 value2
            // to align this use-case with the comma-delimiter use-case we need to join tokens
            // --option value1,value2
            var tokenValues = result.Tokens.Select(s => s.Value);
            var joinedValue = string.Join(ARRAY_ITEMS_SEPARATOR, tokenValues);

            return joinedValue.Split(new[]
            {
                ARRAY_ITEMS_SEPARATOR
            });
        }
    }
}
