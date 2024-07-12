using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;
using SkySoft.CvRenderer.Pages.Main.Skills;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class ContentComponent(ILogger logger, CvModel value, CvOptions options) : IComponent
    {
        private readonly ILogger _logger = logger;
        private readonly CvModel _cvModel = value;
        private readonly CvOptions _options = options;

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem()
                    .PaddingTop(12)
                    .PaddingLeft(18)
                    .PaddingRight(20)
                    .Column(column =>
                    {
                        column.Item().Component(new HeadTitle(_options.HideLogo));

                        column.Item()
                           .ShowEntire()
                           .Component(new WorkExperienceContainer(_cvModel.Work, _options));

                        column.Item()
                           .ShowEntire()
                           .Component(new AcademicBackgroundContainer(_cvModel.Education, _options));

                        column.Item()
                           .ShowEntire()
                           .Component(new SkillsContainer(_logger, _cvModel));
                    });
            });
        }
    }
}
