using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils.Deserialization;

namespace SkySoft.CvRenderer.Cli
{
    public class ExecutorCli(ILogger logger, string? input, string? output, int width, bool hideLogo)
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly string _input = input ?? throw new ArgumentNullException(nameof(input));
        private readonly string? _output = output;
        private readonly int _width = width;
        private readonly bool _hideLogo = hideLogo;

        public async Task Run()
        {
            _logger.LogInformation("Render [{input}] to [{output}]", _input, _output);

            var cvJson = await ReadInput(_input);

            _logger.LogDebug("Json: {cvJson}", cvJson);

            var cv = new CvDeserializer().DeserializeCv<CvModel>(cvJson);

            var fileResolver = new FileResolver(_input);

            var outputFileName = GetPdfName(_input, _output);
            using var outputFile = File.OpenWrite(outputFileName);

            new PdfRenderer(_logger, fileResolver, cv).Render(outputFile, GetCvOptions());

            _logger.LogInformation("Created file: {outputFileName}", outputFileName);
        }

        private static Task<string> ReadInput(string input)
        {
            return File.ReadAllTextAsync(input);
        }

        private static string GetPdfName(string input, string? output)
        {
            return output ?? input.Replace(".json", ".pdf");
        }

        private CvOptions GetCvOptions()
        {
            return new CvOptions()
            {
                WorkColumnWidth = _width,
                HideLogo = _hideLogo
            };
        }
    }
}
