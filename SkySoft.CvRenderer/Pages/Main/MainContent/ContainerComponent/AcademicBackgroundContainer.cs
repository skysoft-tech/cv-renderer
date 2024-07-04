using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Assets;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;

namespace SkySoft.CvRenderer.Pages.Main.MainContent.ContainerComponent
{
    public class AcademicBackgroundContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly List<Education> _educations;
        private readonly CvOptions _options;

        public AcademicBackgroundContainer(ILogger logger, List<Education> educations, CvOptions options)
        {
            _logger = logger;
            _educations = educations;
            _options = options;
        }

        public void Compose(IContainer container)
        {
            if (_educations is null && _educations!.Count is 0)
            {
                _logger.LogWarning("List<Education> is not valid");
                return;
            }

            container.Column(column =>
            {
                column.Item().Component(new CaptionComponent("ACADEMIC BACKGROUND", DocumentColors.FontColor));

                var educationItems = _educations ?? new List<Education>();
                for (var i = 0; i < educationItems.Count; i++)
                {
                    column.Item().Component(new AcademicBackgroundComponent(educationItems[i], i, educationItems.Count, _options));
                }

                column.Item().Component(new HorizontalLine());
            });
        }
    }
}
