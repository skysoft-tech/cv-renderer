using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Utils.Api
{
    public class CreatePdfCvFromModel
    {
        private readonly ILogger<CreatePdfCvFromModel> _logger;
        public CreatePdfCvFromModel(ILogger<CreatePdfCvFromModel> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Stream> CreateJsonCv(CvModel cvModel)
        {
            var outputFile = new MemoryStream();

            var getCvOptions = new GetCvOptions(60, true);
            var options = getCvOptions.BuildOptions();

            var renderer = new PdfRenderer(_logger, cvModel);
            await renderer.Render(outputFile, options);

            outputFile.Seek(0, SeekOrigin.Begin);

            return outputFile;
        }
    }
}
