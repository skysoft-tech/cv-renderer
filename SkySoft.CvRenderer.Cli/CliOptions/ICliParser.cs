using System;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public interface ICliParser
    {
        ParseResult ParseArgs(string[] args);
    }
}
