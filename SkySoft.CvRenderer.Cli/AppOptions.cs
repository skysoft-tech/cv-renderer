using SkySoft.CvRenderer.Cli.CliOptions;
using System.ComponentModel;

namespace SkySoft.CvRenderer.Cli
{
    public class AppOptions
    {
        [OptionKeyName(nameof(InputFile))]
        [CliOptionName("--cvJson", "--in", "-f")]
        [CliOptionDescription("Path to JSON file with CV data. See more: https://jsonresume.org/schema/")]
        public string? InputFile { get; set; }

        [OptionKeyName(nameof(OutputFile))]
        [CliOptionName("--pdf", "--out", "-p")]
        [CliOptionDescription("Output file path")]
        public string? OutputFile { get; set; }

        public RenderingOptions Rendering { get; set; } = new();
    }

    public class RenderingOptions
    {
        [DefaultValue(60)]
        [OptionKeyName($"Rendering:{nameof(WorkColumnWidth)}")]
        [CliOptionName("--workColumnWidth", "-w")]
        [CliOptionDescription("Allows to change width of the first column in Work Experience section")]
        public int WorkColumnWidth { get; set; } = 60;

        [DefaultValue(false)]
        [OptionKeyName($"Rendering:{nameof(HideLogo)}")]
        [CliOptionName("--hideLogo", "-l")]
        [CliOptionDescription("Allows you to disable the logo in the header")]
        public bool HideLogo { get; set; } = false;
    }
}
