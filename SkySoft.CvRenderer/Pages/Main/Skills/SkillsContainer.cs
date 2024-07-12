using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Assets;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    internal class SkillsContainer(ILogger logger, CvModel cvModel) : IComponent
    {
        private readonly ILogger _logger = logger;
        private readonly CvModel _cvModel = cvModel;

        public void Compose(IContainer container)
        {
            if (_cvModel.Skills == null || _cvModel.Skills.Count == 0)
            {
                return;
            }

            container.Column(column =>
            {
                column.Item()
                   .ShowEntire()
                   .Column(column =>
                   {
                       column.Item().Component(new CaptionComponent("SKILLS", DocumentColors.FontColor));

                       column.Item()
                            .Row(row =>
                            {
                                row.RelativeItem()
                                .AlignLeft()
                                .PaddingRight(23)
                                .Component(new SkillsColumn(_logger, _cvModel, 0));

                                row.RelativeItem()
                                .AlignRight()
                                .PaddingLeft(23)
                                .Component(new SkillsColumn(_logger, _cvModel, 1));
                            });
                   });
            });
        }
    }
}
