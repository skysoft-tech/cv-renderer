using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.Skills;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Pages.Main.MainContent.ContainerComponent;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class ContentComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;
        private readonly CvOptions _options;

        public ContentComponent(ILogger logger, CvModel value, CvOptions options)
        {
            _logger = logger;
            _cvModel = value;
            _options = options;
        }

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
                         .Component(new WorkExperienceContainer(_logger, _cvModel.Work!, _options));

                        column.Item()
                           .ShowEntire()
                           .Component(new AcademicBackgroundContainer(_logger, _cvModel.Education!, _options));

                        column.Item()
                           .ShowEntire()
                           .Component(new SkillsContainer(_logger, _cvModel!, _options));
                    });
            });
        }
    }    
}
