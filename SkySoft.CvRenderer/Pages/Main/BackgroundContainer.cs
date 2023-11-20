using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.Skills;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class BackgroundContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;

        public BackgroundContainer(ILogger logger, CvModel value)
        {
            _logger = logger;
            _cvModel = value;
        }

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem()
                    .Element(ComponentsSize.WorkExperienceComponentSize)
                    .Column(column =>
                    {
                        column.Item().Component(new HeadTitle());

                        column.Item()
                            .ShowEntire()
                            .Column(column =>
                            {
                                column.Item().Component(new CaptionComponent("WORK EXPERIENCE", DocumentColors.FontColor));

                                var workItems = _cvModel.Work ?? new List<Work>();
                                for (var i = 0; i < workItems.Count; i++)
                                {
                                    column.Item().Component(new WorkExperienceComponent(workItems[i], i, workItems.Count));
                                }

                                column.Item().Component(new HorizontalLine());
                            });

                        column.Item()
                            .ShowEntire()
                            .Column(column =>
                            {
                                column.Item().Component(new CaptionComponent("ACADEMIC BACKGROUND", DocumentColors.FontColor));

                                var educationItems = _cvModel.Education ?? new List<Education>();
                                for (var i = 0; i < educationItems.Count; i++)
                                {
                                    column.Item().Component(new AcademicBackgroundComponent(educationItems[i], i, educationItems.Count));
                                }

                                column.Item().Component(new HorizontalLine());
                            });

                        column.Item()
                            .ShowEntire()
                            .Column(column =>
                            {
                                column.Item().Component(new CaptionComponent("SKILLS", DocumentColors.FontColor));

                                column.Item().Component(new SkillsContainer(_logger, _cvModel));
                            });
                    });
            });
        }
    }    
}
