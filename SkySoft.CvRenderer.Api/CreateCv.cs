using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Utils.JsonHelpers;
using System.Text;

namespace SkySoft.CvRenderer.Api
{
    public class CreateCv
    {
        private readonly ILogger<CreateCv> _logger;
        public CreateCv(ILogger<CreateCv> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Stream> FromFileAsync(Stream stream)
        {
            var deserializeInput = new DeserializeInput(_logger, StreamToString(stream));
            var cv = deserializeInput.DeserializeJson();

            return await FromModelAsync(cv);
        }

        public async Task<Stream> FromModelAsync(CvModel cvModel)
        {
            var getCvOptions = new GetCvOptions(60, true);
            var options = getCvOptions.BuildOptions();

            var renderer = new PdfRenderer(_logger, cvModel);
            var outputFile = await renderer.Render(options);

            outputFile.Seek(0, SeekOrigin.Begin);

            return outputFile;
        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
