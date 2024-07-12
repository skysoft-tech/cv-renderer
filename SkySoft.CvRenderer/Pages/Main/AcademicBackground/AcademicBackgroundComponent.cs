using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground
{
    public class AcademicBackgroundComponent(Education value, int index, int count, CvOptions options) : IComponent
    {
        private readonly Education _education = value;
        private readonly CvOptions _options = options;
        private readonly bool _isFirstItem = index == 0;
        private readonly bool _isLastItem = index + 1 == count;

        public void Compose(IContainer container)
        {
            var start = _education.StartDate.ToYearString();
            var end = _education.EndDate.ToYearString();

            container
            .Row(row =>
            {
                row.AutoItem()
                    .MinWidth(_options.WorkColumnWidth)
                    .MaxWidth(_options.WorkColumnWidth)
                    .Text($"{start} - {end}")
                    .Style(DocumentFonts.MinorLabelStyle);

                row.AutoItem().Component(new VerticalLine(26f, 6, _isFirstItem));

                row.RelativeItem()
                    .PaddingBottom(_isLastItem ? 0 : 13)
                    .Column(column =>
                    {
                        column.Item()
                            .Text(text =>
                            {
                                text.Span($"{_education.Institution}")
                                    .Style(DocumentFonts.AccentLabelStyle);
                            });

                        column.Item()
                            .Text(text =>
                            {
                                text.Span($"{_education.StudyType}")
                                    .Style(DocumentFonts.LabelStyle);

                                text.Span($"\n{_education.Area}")
                                    .Style(DocumentFonts.HintLabelStyle);
                            });
                    });
            });
        }
    }
}

