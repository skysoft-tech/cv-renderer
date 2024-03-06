using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SkySoft.CvRenderer.Cli;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Api
{
    internal class Executor
    {
        ILogger _logger;

        public Executor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<byte[]> Run(string input, int width, bool hideLogo)
        {
            _logger.LogInformation("Render [{input}]", input);

            var cvJson = await ReadInput(input);

            _logger.LogDebug("Json: {cvJson}", cvJson);

            var cv = DeserializeInput(cvJson);

            var isResolved = TryResolveAbsPhotoPath(cv.Basics?.Image, input, out var absPhotoPath);
            if (isResolved)
            {
                cv.Basics!.Image = absPhotoPath;
            }

            var options = BuildOptions(width, hideLogo);
            var renderer = new PdfRenderer(_logger, cv);

            return await renderer.ApiRender(options);
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

        private CvOptions BuildOptions(int width, bool hideLogo)
        {
            return new CvOptions
            {
                WorkColumnWidth = width,
                HideLogo = hideLogo,
            };
        }
    }


}
