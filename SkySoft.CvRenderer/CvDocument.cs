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
    internal class CvDocument(ILogger logger, IFileResolver fileResolver, CvModel cv, CvOptions options) : IDocument
    {
        private readonly ILogger _logger = logger;
        private readonly IFileResolver _fileResolver = fileResolver;
        private readonly CvModel _cv = cv;
        private readonly CvOptions _options = options;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(SetDefaultFont);

                page.Header().Dynamic(new HeadTitleDynamic(_options.HideLogo));

                page.Content().Component(new MainPage(_logger, _fileResolver, _cv, _options));
            });

            var isAnyProject = _cv.Projects != null && _cv.Projects.Count != 0;
            if (isAnyProject)
            {
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
        }

        private TextStyle SetDefaultFont(TextStyle textStyle) => textStyle.FontFamily("Hind");
    }
}
