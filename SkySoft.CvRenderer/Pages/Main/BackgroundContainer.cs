﻿using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.Skills;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

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
                    column.Item()
                    .Component(new HeadTitle());

                    column.Item()
                   .Component(new TitleComponent("WORK EXPERIENCE", "#000000", 20));

                    _cvModel.Work.ForEach(work =>
                    {
                        column.Item().Element(new WorkExperienceComponent(work).WorkExperienceContainer);
                    });

                    column.Item()
                    .Element(Line.lineHorizontal);

                    column.Item()
                    .Component(new TitleComponent("ACADEMIC BACKGROUND", "#000000", 20))
                    ;

                    _cvModel.Education.ForEach(education =>
                    {
                        column.Item().Component(new AcademicBackgroundComponent(education));
                    });

                    column.Item()
                    .Element(Line.lineHorizontal);

                    column.Item()
                   .Component(new TitleComponent("SKILLS", "#000000", 13));

                    column.Item()
                   .Component(new SkillsLogic(_logger, _cvModel));
                });
            });
        }
    }    
}
