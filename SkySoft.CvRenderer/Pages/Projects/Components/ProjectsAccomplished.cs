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
        private readonly int _index;
        private readonly int _arraySize;

        public ProjectsAccomplished(Project? Value, int index, int arraySize)
        {
            _project = Value;
            _index = index;
            _arraySize = arraySize;
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
                .Component(new GrayDot($"{_project.StartDate}\n{_project.EndDate}", projectStartDateStyle, 75));

                row.AutoItem()
                .PaddingTop(_index == 0 ? 4 : 0)
                .Component(new VerticalLine());

                
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

                    column.Item().Row(row =>
                    {
                        float sizeComponent;

                        _project.Technologies.ForEach(technologies =>
                        {
                            row.RelativeItem().Dynamic(new TechnologiesElement("a", out sizeComponent));
                        });
                    });

                });
            });
        }
    }
}
