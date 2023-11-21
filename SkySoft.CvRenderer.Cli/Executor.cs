using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Cli
{
    internal class Executor
    {
        ILogger _logger;

        public Executor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Run(string input, string output, int width)
        {
            _logger.LogInformation("Render [{input}] to [{output}]", input, output);

            var cvJson = await ReadInput(input);

            _logger.LogDebug("Json: {cvJson}", cvJson);

            var cv = DeserializeInput(cvJson);

            var isResolved = TryResolveAbsPhotoPath(cv.Basics?.Image, input, out var absPhotoPath);
            if (isResolved)
            {
                cv.Basics!.Image = absPhotoPath;
            }

            var outputFileName = GetPdfName(input, output);
            var outputFile = File.OpenWrite(outputFileName);

            var options = BuildOptions(width);
            var renderer = new PdfRenderer(_logger, cv);
            await renderer.Render(outputFile, options);

            _logger.LogInformation("Created file: {outputFileName}", outputFileName);
        }

        private Task<string> ReadInput(string input)
        {
            return File.ReadAllTextAsync(input);
        }

        private CvModel DeserializeInput(string cvJson)
        {
            var options = new JsonSerializerSettings();

            options.Converters.Add(new StringEnumConverter());
            options.Converters.Add(new MultiFormatDateConverter());

            var cv = JsonConvert.DeserializeObject<CvModel>(cvJson, options);
            if (cv is null)
            {
                _logger.LogError("Failed to deserialize cv");

                throw new Exception();
            }

            return cv;
        }

        private string GetPdfName(string input, string output)
        {
            return output ?? input.Replace(".json", ".pdf");
        }

        private bool TryResolveAbsPhotoPath(string? photoPath, string input, out string? absPhotoPath)
        {
            absPhotoPath = null;
            if (photoPath == null)
            {
                return false;
            }

            if (File.Exists(photoPath))
            {
                absPhotoPath = Path.GetFullPath(photoPath);

                return true;
            }

            var jsonLocation = Path.GetDirectoryName(input);
            if (jsonLocation == null)
            {
                return false;
            }

            var probablePhotoLocation = Path.Combine(jsonLocation, photoPath);
            if (File.Exists(probablePhotoLocation))
            {
                absPhotoPath = Path.GetFullPath(probablePhotoLocation);

                return true;
            }

            return false;
        }

        private CvOptions BuildOptions(int width)
        {
            return new CvOptions
            {
                WorkColumnWidth = width
            };
        }
    }
}
