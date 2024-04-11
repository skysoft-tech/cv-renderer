using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils.Deserialization;
using System.Text;

namespace SkySoft.CvRenderer.Api
{
    public class CvCreator(ILogger<CvCreator> logger, Deserializer deserializeInput)
    {
        private readonly ILogger<CvCreator> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly Deserializer _deserializer = deserializeInput ?? throw new ArgumentNullException(nameof(deserializeInput));

        public async Task<Stream> FromFileAsync(Stream stream, PhotoFile? photoStream, CvOptions options)
        {
            var stringJson = await StreamToStringAsync(stream);
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

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }
    }
}
