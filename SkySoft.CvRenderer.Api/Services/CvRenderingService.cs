using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Api.Services
{
    public interface ICvRenderingService
    {
        Stream RenderPdf(CvModel cvModel, CvOptions options);
    }

    public class CvRenderingService : ICvRenderingService
    {
        private readonly ILogger<CvRenderingService> _logger;

        public CvRenderingService(ILogger<CvRenderingService> logger)
        {
            _logger = logger;
        }

        public Stream RenderPdf(CvModel cvModel, CvOptions options)
        {
            var stream = new MemoryStream();

            using var scope = _logger.BeginScope(Guid.NewGuid().ToString());

            _logger.LogDebug("Start pdf rendering...");

            new PdfRenderer(_logger, cvModel).Render(stream, options);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
