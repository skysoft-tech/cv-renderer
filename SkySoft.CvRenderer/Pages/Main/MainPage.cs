using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.Header;
using SkySoft.CvRenderer.Pages.Main.AboutMe;
using SkySoft.CvRenderer.Pages.Main.Languages;
using SkySoft.CvRenderer.Pages.Main.Footer;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;
using SkySoft.CvRenderer.Pages.Main.AcademicBackground;
using SkySoft.CvRenderer.Pages.Main.Skills;
using Microsoft.Extensions.Logging;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class MainPage : IComponent
    {
        private readonly ILogger _logger;
        public CvModel cvModel { get; }

        public MainPage(ILogger logger, CvModel Value)
        {
            _logger = logger;
            cvModel = Value;
        }

        public Line line = new Line();

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.ConstantItem(240)
                  .ShowOnce()
                  .ExtendVertical()
                  .Background("#1c1f2a")
                  .Column(column =>
                  {
                      column.Item()
                      .PaddingBottom(20)
                      .Component(new HeaderComponent(_logger, cvModel));

                      column.Item().Component(new AboutMeComponent(cvModel.Basics));

                      cvModel.Basics.Summary.ForEach(summary =>
                      {
                          column.Item().Component(new AboutMeContext(summary));
                      });

                      //Title
                      column.Item()
                      .PaddingTop(20)
                      .PaddingLeft(40)
                      .PaddingRight(30)
                      .Component(new TitleComponent("LANGUAGE", "#ffffff"));

                      cvModel.Languages.ForEach(languages =>
                      {
                          column.Item()
                          .PaddingLeft(40)
                          .PaddingRight(30)
                          .Component(new LanguagesComponent(languages.Language));
                      });

                      column.Item()
                      .Component(new FooterComponent(cvModel.Basics));
                  });


                row.RelativeItem(1)
                 .Padding(10)
                 .ShowOnce()
                     .Column(column =>
                     {
                         column.Item()
                         .Height(40)
                         .Element(HeadTitle.BrandTitle);

                         column.Item()
                         .Component(new TitleComponent("WORK EXPERIENCE", "#000000"));

                         cvModel.Work.ForEach(work =>
                         {
                             column.Item().Element(new WorkExperienceComponent(work).WorkExperienceContainer);
                         });

                         column.Item()
                         .Element(line.LineContainer);

                         column.Item()
                         .Component(new TitleComponent("ACADEMIC BACKGROUND", "#000000"));

                         cvModel.Education.ForEach(education =>
                         {
                             column.Item().Component(new AcademicBackgroundComponent(education));
                         });

                         column.Item()
                         .Element(line.LineContainer);

                         column.Item()
                        .Component(new TitleComponent("SKILLS", "#000000"));

                         column.Item()
                         .Component(new SkillsLogic(_logger, cvModel));

                         //cvModel.Skills.ForEach(skills =>
                         //{
                         //    column.Item()
                         //        .Row(row =>
                         //        {
                         //            row.RelativeItem()
                         //            .PaddingRight(42)
                         //            .Component(new SkillsComponent(_logger, skills));

                         //            row.RelativeItem()
                         //            .PaddingRight(42)
                         //            .Component(new SkillsComponent(_logger, skills));
                         //        });
                         //});
                     });
            });
        }

    }
}
