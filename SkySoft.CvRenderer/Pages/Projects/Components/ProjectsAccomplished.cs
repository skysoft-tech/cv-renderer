using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class ProjectsAccomplished : IComponent
    {
        private readonly Project _project;

        public ProjectsAccomplished(Project Value)
        {
            _project = Value;
        }

        public void Compose(IContainer container)
        {
            container
            .ShowEntire()
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(50)
                .MaxWidth(50)
                .Text($"{_project.StartDate}\n{_project.EndDate}").Style(ProjectsAccomplishedStyle.ProjectStartDateStyle);

                row.AutoItem()
                .Component(new VerticalLine(26, 1));

                
                row.RelativeItem()
                .PaddingBottom(24)
                .Column(column =>
                {
                    column.Item()
                    .PaddingBottom(8)
                    .Text(text =>
                    {
                        text.Span($"{_project.Name}\n").Style(ProjectsAccomplishedStyle.ProjectNameStyle);

                        text.Span($"{_project.Description}").Style(ProjectsAccomplishedStyle.ProjectDescriptionStyle);
                    });

                    column.Item()
                    .Text(text => 
                    {
                        text.Span("Duties\n").Style(ProjectsAccomplishedStyle.DutiesStyle);

                        _project.Highlights.ForEach(highlights =>
                        {
                            text.Span($"{highlights}\n").Style(ProjectsAccomplishedStyle.ProjectDescriptionStyle);
                        });
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span("Technologies").Style(ProjectsAccomplishedStyle.DutiesStyle);

                    });

                    column.Item().Component(new TechnologiesComponent(_project));
                });
            });
        }
    }
}
