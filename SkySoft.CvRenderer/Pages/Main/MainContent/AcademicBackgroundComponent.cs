using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground
{
    public class AcademicBackgroundComponent : IComponent
    {
        private readonly Education _education;
        private readonly CvOptions _options;
        private readonly bool _isFirstItem;
        private readonly bool _isLastItem;

        public AcademicBackgroundComponent(Education value, int index, int count, CvOptions options)
        {
            _education = value;
            _options = options;
            _isFirstItem = index == 0;
            _isLastItem = index + 1 == count;
        }

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
                            .PaddingBottom(4)
                            .Text(text =>
                            {
                                text.Span($"{_education.Institution}\n")
                                    .Style(DocumentFonts.AccentLabelStyle);

                                text.Span($"{_education.City}, {_education.Country}")
                                    .Style(DocumentFonts.HintLabelStyle);
                            });

                        column.Item()
                            .Text(text =>
                            {
                                text.Span($"{_education.StudyType} {Transfer(_education.Score)}")
                                    .Style(DocumentFonts.LabelStyle);

                                text.Span($"{_education.Score}")
                                    .Style(DocumentFonts.HintLabelStyle);
                            });
                    });
            });
        }

        private string Transfer(string? value)
        {
            return string.IsNullOrEmpty(value) ? "" : "\n";
        }
    }
}

