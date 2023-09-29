using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkySoft.CvRenderer.Core.Models;
using System.ComponentModel;
using System.Text.Json;
using WebApplicationPdf.Pages;

namespace SkySoft.CvRenderer.Core
{
    public class PdfRenderer
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;

        public PdfRenderer(ILogger logger, CvModel cv)
        {
            _logger = logger;
            _cv = cv;
        }

        public async Task Render(Stream stream)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = new CvDocument(_logger, _cv);

#if DEBUG
            document.ShowInPreviewer();
#else
            var pdfData = document.GeneratePdf();
            await stream.WriteAsync(pdfData);
#endif
        }
    }
}
