using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.Pages;

namespace SkySoft.CvRenderer
{
    internal class CvDocument : IDocument
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;

        public CvDocument(ILogger logger, CvModel cv)
        {
            _logger = logger;
            _cv = cv;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(SetDefaultFont);

                page.Content()
                .Component(new PageCover(_cv));
            });

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(SetDefaultFont);

                page.Content()
                .Component(new PageProjectsAccomplished(_cv));
            });
        }

        private TextStyle SetDefaultFont(TextStyle textStyle)
        {
            return textStyle.FontFamily("Hind");
        }
    }
}
