using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class ProjectsAccomplished : IComponent
    {
        private readonly Project _project;

        public ProjectsAccomplished(Project? Value)
        {
            _project = Value;
        }

        public void Compose(IContainer container)
        {
            var projectStartDateStyle = TextStyle.Default.ProjectStartDateStyle();
            var projectNameStyle = TextStyle.Default.ProjectNameStyle();
            var projectDescriptionStyle = TextStyle.Default.ProjectDescriptionStyle();
            var dutiesStyle = TextStyle.Default.DutiesStyle();
            
            container
            .ShowEntire()
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(49)
                .MaxWidth(49)
                .Text(text => text.Span($"{_project.StartDate}\n{_project.EndDate}").Style(projectStartDateStyle));

                row.AutoItem()
                .Element(ComponentsSize.LinesSize)
                .LineVertical(1)
                .LineColor("#dbdbdb");

                row.RelativeItem()
                .Column(column =>
                {
                    column.Item()
                    .PaddingBottom(8)
                    .Text(text =>
                    {
                        text.Span($"{_project.Name}\n").Style(projectNameStyle);

                        text.Span($"{_project.Description}").Style(projectDescriptionStyle);
                    });

                    column.Item()
                    .Text(text => 
                    {
                        text.Span("Duties\n").Style(dutiesStyle);

                        _project.Highlights.ForEach(highlights =>
                        {
                            text.Span($"{highlights}\n").Style(projectDescriptionStyle);
                        });
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span("Technologies").Style(dutiesStyle);
                    });

                    column.Item()
                    .Row(row =>
                    {
                        _project.Technologies.ForEach(technologies =>
                        {
                            row.AutoItem()
                            .Component(new TechnologiesElement(technologies));
                        });
                    });
                });
            });
        }
    }
}
