using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.MainContent.ContainerComponent
{
    public class WorkExperienceContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly List<Work> _work;
        private readonly CvOptions _options;
        public WorkExperienceContainer(ILogger logger, List<Work> work, CvOptions cvOptions) 
        {
            _logger = logger;
            _work = work;
            _options = cvOptions;
        }

        public void Compose(IContainer container)
        {
            if (_work is null && _work!.Count is 0)
            {
                _logger.LogWarning("List<Work> is not valid");
                return;
            }

            container.Column(column =>
            {
                column.Item().Component(new CaptionComponent("WORK EXPERIENCE", DocumentColors.FontColor));

                var workItems = _work ?? new List<Work>();
                for (var i = 0; i < workItems.Count; i++)
                {
                    column.Item().Component(new WorkExperienceComponent(workItems[i], i, workItems.Count, _options));
                }

                column.Item().Component(new HorizontalLine());
            });
        }
    }
}
