using System.CommandLine;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    internal class AppCliParser : CliParser
    {
        protected override Option[] GetRootCommandOptions()
        {
            return new Option[] 
            {
                new CliOption<string?>(s => s.InputFile),
                new CliOption<string?>(s => s.OutputFile),
                new CliOption<int>(s => s.Rendering.WorkColumnWidth)
            };
        }
    }
}
