using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Utils;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class ProjectsAccomplished : IComponent
    {
        private readonly Project _project;

        private readonly bool _isFirstItem;
        private readonly bool _isLastItem;

        public ProjectsAccomplished(Project Value, int index, int count)
        {
            _project = Value;

            _isFirstItem = index == 0;
            _isLastItem = index + 1 == count;
        }

        public void Compose(IContainer container)
        {
            container.ShowEntire()
                .Row(row =>
                {
                    row.AutoItem()
                        .MinWidth(50)
                        .MaxWidth(50)
                        .Text($"{_project.StartDate.ToMonthString()}\n{_project.EndDate.ToMonthString()}")
                        .Style(DocumentFonts.MinorLabelStyle);

                    row.AutoItem()
                        .Component(new VerticalLine(26f, 8, _isFirstItem));

                
                    row.RelativeItem()
                        .PaddingBottom(_isLastItem ? 0 : 26)
                        .Column(column =>
                        {
                            column.Item()
                                .Text(text =>
                                {
                                    text.Span($"{_project.Name}\n").Style(DocumentFonts.AccentLabelStyle.FontSize(14));

                                    text.Span($"{_project.Description}").Style(DocumentFonts.LabelStyle);
                                });

                            column.Item()
                                .PaddingTop(8)
                                .Text(text => 
                                {
                                    text.Span("Duties\n").Style(DocumentFonts.MinorLabelStyle.FontSize(12));

                                    _project.Highlights?.ForEach(highlights =>
                                    {
                                        text.Span($"{highlights}").Style(DocumentFonts.LabelStyle);
                                    });
                                });

                            column.Item()
                                .PaddingTop(8)
                                .Text(text =>
                                {
                                    text.Span("Technologies").Style(DocumentFonts.MinorLabelStyle.FontSize(12));

                                });

                            column.Item()
                                .Component(new TechnologiesComponent(_project));
                        });
                });
        }
    }
}
