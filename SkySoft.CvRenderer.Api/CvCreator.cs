using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using System.Text;

namespace SkySoft.CvRenderer.Api
{
    public class CvCreator
    {
        private readonly ILogger<CvCreator> _logger;
        private readonly Deserializer _deserializer;

        public CvCreator(ILogger<CvCreator> logger, Deserializer deserializeInput)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _deserializer = deserializeInput ?? throw new ArgumentNullException(nameof(deserializeInput));
        }

        public async Task<Stream> FromFileAsync(Stream stream, PhotoFile? photoStream, CvOptions options)
        {
            var stringJson = await StreamToString(stream);
            var cv = _deserializer.DeserializeJson<CvModel>(stringJson);

            return FromModel(cv, photoStream, options);
        }

        public Stream FromModel(CvModel cvModel, PhotoFile? photoStream, CvOptions options)
        {
            var stream = new MemoryStream();
            var fileResolver = new FileResolver(photoStream);

            new PdfRenderer(_logger, fileResolver, cvModel).Render(stream, options);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
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
