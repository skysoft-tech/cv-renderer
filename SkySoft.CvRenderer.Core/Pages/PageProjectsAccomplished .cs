﻿using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using WebApplicationPdf.ProjectPage;

namespace WebApplicationPdf.Pages
{
    public class PageProjectsAccomplished : IComponent
    {
        public CvModel? cvModel { get; }

        public PageProjectsAccomplished(CvModel? value)
        {
            cvModel = value;
        }

        public void Compose(IContainer container)
        {
            container
            .Row(row =>
            {
                row.RelativeItem(1)
                 .Padding(10)
                 .ShowOnce()
                     .Column(column =>
                     {
                         //Image
                         column.Item()
                         .Height(40)
                         .Element(HeadTitle.BrandTitle);

                         //Title
                         column.Item()
                         .PaddingLeft(20)
                         .Component(new TitleComponent("PROJECTS ACCOMPLISHED", "#000000"));

                         //Content
                         cvModel.Projects.ForEach( projects =>
                         {
                             column.Item()
                             .Component(new ProjectsAccomplished(projects));
                         });
                     });
            });
        }
    }
}
