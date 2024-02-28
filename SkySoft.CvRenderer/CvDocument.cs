using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Pages.Main;
using SkySoft.CvRenderer.Pages.Projects;
using SkySoft.CvRenderer.Pages.Projects.Components;

namespace SkySoft.CvRenderer
{
    internal class CvDocument : IDocument
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;
        private readonly CvOptions _options;

        public CvDocument(ILogger logger, CvModel cv, CvOptions options)
        {
            _logger = logger;
            _cv = cv;
            _options = options;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(SetDefaultFont);

                page.Header().Dynamic(new HeadTitleDynamic(_options.HideLogo));

                page.Content().Component(new MainPage(_logger, _cv, _options));
            });

            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(SetDefaultFont);

                page.Header()
                .Component(new ProjectsHeader(_options.HideLogo));

                page.Content()
                .Component(new ProjectsPage(_cv));
            });
        }

        private TextStyle SetDefaultFont(TextStyle textStyle)
        {
            return textStyle
                .FontFamily("Hind");
        }
    }
}
