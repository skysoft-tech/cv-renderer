﻿using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using WebApplicationPdf.TitlePage;
using WebApplicationPdf.MainContentLeftSide;
using SkySoft.CvRenderer.Core;
using System.Collections.Generic;
using static QuestPDF.Helpers.Colors;

namespace WebApplicationPdf.Pages
{ 
    public class PageCover : IComponent
    {
        public CvModel? cvModel { get; }

        public PageCover(CvModel? Value)
        {
            cvModel = Value;
        }

        public Line line = new Line();

        public void Compose(IContainer container)
        {

            TitleElement workExperience = new TitleElement("WORK EXPERIENCE", "#000000");
            TitleElement academicBackground = new TitleElement("ACADEMIC BACKGROUND", "#000000");
            TitleElement skillsTitle = new TitleElement("SKILLS", "#000000");
            TitleElement language = new TitleElement("LANGUAGE", "#ffffff");

            container.Row(row =>
            {
                row.ConstantItem(240)
                  .ShowOnce()
                  .ExtendVertical()
                  .Background("#1c1f2a")
                  .Column(column =>
                  {
                      column.Item()
                      .Element(ImageCv.ElementImage);

                      column.Item().Component(new AboutMe(cvModel.Basics));

                      cvModel.Basics.Summary.ForEach(summary =>
                      {
                          column.Item().Component(new AboutMeContext(summary));
                      });

                      //Title
                      column.Item()
                      .PaddingTop(20)
                      .PaddingLeft(40)
                      .PaddingRight(30)
                      .Element(language.TitleContainer);

                      cvModel.Languages.ForEach(languages =>
                      {
                          column.Item()
                          .PaddingLeft(40)
                          .PaddingRight(30)
                          .Component(new LanguageContainer(languages.Language));
                      });

                      column.Item()
                      .Component(new DataLocation(cvModel.Basics));
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
                         .Element(workExperience.TitleContainer);

                         cvModel.Work.ForEach(work =>
                         {
                             column.Item().Element(new WorkExperience(work).WorkExperienceContainer);
                         });

                         column.Item()
                         .Element(line.LineContainer);

                         column.Item()
                         .Element(academicBackground.TitleContainer);

                         cvModel.Education.ForEach(education =>
                         {
                             column.Item().Component(new AcademicBackground(education));
                         });

                         column.Item()
                         .Element(line.LineContainer);

                         column.Item()
                        .Element(skillsTitle.TitleContainer);

                         cvModel.Skills.ForEach(skills =>
                         {
                             column.Item()
                                 .Row(row =>
                                 {
                                     row.RelativeItem()
                                     .PaddingRight(42)
                                     .Component(new Skills(skills));

                                     row.RelativeItem()
                                     .PaddingRight(42)
                                     .Component(new Skills(skills));
                                 });
                         });
                     });
            });
        }

    }
}
