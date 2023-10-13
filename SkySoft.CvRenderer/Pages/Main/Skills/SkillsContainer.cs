using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Collections.Generic;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;

        public SkillsContainer(ILogger logger, CvModel cvModel)
        {
            _logger = logger;
            _cvModel = cvModel;
        }

        public void Compose(IContainer container)
        {
            container
                //.StopPaging()
                .Row(row =>
                {
                    row.RelativeItem()
                    .AlignLeft()
                    .PaddingRight(23)
                    .Component(new SkillsLogic(_logger, _cvModel, 0));

                    row.RelativeItem()
                    .AlignRight()
                    .PaddingLeft(23)
                    .Component(new SkillsLogic(_logger, _cvModel, 1));
                });
        }
    }
}
