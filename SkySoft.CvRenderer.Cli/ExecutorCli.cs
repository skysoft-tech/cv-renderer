using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils.Deserialization;

namespace SkySoft.CvRenderer.Cli
{
    public class ExecutorCli
    {
        private readonly ILogger _logger;
        private readonly string _input;
        private readonly string _output;
        private readonly int _width;
        private readonly bool _hideLogo;

        public ExecutorCli(ILogger logger, string input, string output, int width, bool hideLogo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _output = output;
            _width = width;
            _hideLogo = hideLogo;
        }

        public async Task Run()
        {
            _logger.LogInformation("Render [{input}] to [{output}]", _input, _output);

            var cvJson = await ReadInput(_input);

            _logger.LogDebug("Json: {cvJson}", cvJson);

            var cv = new Deserializer(_logger).DeserializeJson<CvModel>(cvJson);

            var fileResolver = new FileResolver(_input);

            var outputFileName = GetPdfName(_input, _output);

            using var outputFile = File.OpenWrite(outputFileName);

            var options = new CvOptions()
            {
                WorkColumnWidth = 60,
                HideLogo = true,
            };

            new PdfRenderer(_logger, fileResolver, cv).Render(outputFile, options);

            _logger.LogInformation("Created file: {outputFileName}", outputFileName);
        }

        private Task<string> ReadInput(string input)
        {
            return File.ReadAllTextAsync(input);
        }

        private string GetPdfName(string input, string output)
        {
            return output ?? input.Replace(".json", ".pdf");
        }
    }
}
