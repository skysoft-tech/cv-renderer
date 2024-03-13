using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Utils.JsonHelpers;
using System.Text;

namespace SkySoft.CvRenderer.Utils.Api
{
    public class CreateCvFromFile
    {
        private readonly ILogger<CreateCvFromFile> _logger;
        public CreateCvFromFile(ILogger<CreateCvFromFile> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Stream> CreateCvAsync(byte[] input)
        {
            var deserializeInput = new DeserializeInput(_logger, Encoding.Default.GetString(input));
            var cv = deserializeInput.DeserializeJson();

            var getCvOptions = new GetCvOptions(60, true);
            var options = getCvOptions.BuildOptions();

            var stream = new MemoryStream();

            var renderer = new PdfRenderer(_logger, cv);
            await renderer.Render(stream, options);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
