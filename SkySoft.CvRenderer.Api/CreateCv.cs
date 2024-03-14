using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using SkySoft.CvRenderer.Utils.ModelHelpers;
using System.Text;

namespace SkySoft.CvRenderer.Api
{
    public class CreateCv
    {
        private readonly ILogger<CreateCv> _logger;
        private readonly Deserializer _deserializer;


        public CreateCv(ILogger<CreateCv> logger, Deserializer deserializeInput)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _deserializer = deserializeInput ?? throw new ArgumentNullException(nameof(deserializeInput));
        }

        public async Task<Stream> FromFileAsync(Stream stream)
        {
            var stringJson = await StreamToString(stream);
            var cv = _deserializer.DeserializeJson<CvModel>(stringJson);

            return await FromModelAsync(cv);
        }

        public async Task<Stream> FromModelAsync(CvModel cvModel)
        {
            var options = new GetCvOptions(60, true).BuildOptions();

            var outputFile = await new PdfRenderer(_logger, cvModel).Render(options);

            outputFile.Seek(0, SeekOrigin.Begin);

            return outputFile;
        }

        public async Task<string> StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
