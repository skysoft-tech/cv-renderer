using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.WorkExperience
{
    public class WorkExperienceContainer(List<Work>? work, CvOptions cvOptions) : IComponent
    {
        private readonly List<Work>? _work = work;
        private readonly CvOptions _options = cvOptions;

        public void Compose(IContainer container)
        {
            if (_work is null || _work.Count == 0)
            {
                return;
            }

            container.Column(column =>
            {
                column.Item().Component(new CaptionComponent("WORK EXPERIENCE", DocumentColors.FontColor));

                for (var i = 0; i < _work.Count; i++)
                {
                    column.Item().Component(new WorkExperienceComponent(_work[i], i, _work.Count, _options));
                }

                column.Item().Component(new HorizontalLine());
            });
        }
    }
}
