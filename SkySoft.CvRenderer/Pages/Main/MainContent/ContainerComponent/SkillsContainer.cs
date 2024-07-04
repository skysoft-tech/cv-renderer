using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Assets;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.Skills;

namespace SkySoft.CvRenderer.Pages.Main.MainContent.ContainerComponent
{
    internal class SkillsContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;
        private readonly CvOptions _options;
        public SkillsContainer(ILogger logger, CvModel cvModel, CvOptions cvOptions)
        {
            _logger = logger;
            _cvModel = cvModel;
            _options = cvOptions;
        }

        public void Compose(IContainer container)
        {
            if (_cvModel.Skills is null && _cvModel.Skills!.Count is 0)
            {
                _logger.LogWarning("List<Skill> is not valid");
                return;
            }

            container.Column(column =>
            {
                column.Item()
                   .ShowEntire()
                   .Column(column =>
                   {
                       column.Item().Component(new CaptionComponent("SKILLS", DocumentColors.FontColor));

                       column.Item().Component(new SkillsMain(_logger, _cvModel));
                   });
            });
        }
    }
}
