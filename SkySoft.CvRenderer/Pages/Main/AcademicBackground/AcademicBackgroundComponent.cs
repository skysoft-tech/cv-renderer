using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground
{
    public class AcademicBackgroundComponent : IComponent
    {
        private readonly Education _education;

        private readonly bool _isFirstItem;
        private readonly bool _isLastItem;

        public AcademicBackgroundComponent(Education? value, int index, int count)
        {
            _education = value;

            _isFirstItem = index == 0;
            _isLastItem = index + 1 == count;
        }

        public void Compose(IContainer container)
        {
            var start = _education.StartDate?.ToString("yyyy");
            var end = _education.EndDate?.ToString("yyyy") ?? "present";

            container
            .Row(row =>
            {
                row.AutoItem()
                    .MinWidth(60)
                    .MaxWidth(60)
                    .Text($"{start} - {end}")
                    .Style(WorkAcademicStyle.WorkStartDateStyle);

                row.AutoItem().Component(new VerticalLine(26f, 6, _isFirstItem));

                row.RelativeItem()
                    .PaddingBottom(PaddingForElement.PadingBottomEltment(_isLastItem, 13))
                    .Column(column =>
                    {
                        column.Item()
                            .PaddingBottom(4)
                            .Text(text =>
                            {
                                text.Span($"{_education.Institution}\n")
                                .Style(WorkAcademicStyle.WorkNameStyle);

                                text.Span($"{_education.City}, {_education.Country}")
                                .Style(WorkAcademicStyle.WorkSummaryStyle);
                            });

                        column.Item()
                            .Text(text =>
                            {
                                text.Span($"{_education.StudyType} {Transfer(_education.Score)}")
                                .Style(WorkAcademicStyle.StudyTypeStyle);

                                text.Span($"{_education.Score}")
                                .Style(WorkAcademicStyle.WorkSummaryStyle);
                            });
                    });
            });
        }

        private string Transfer(string value)
        {
            return value == "" ? "" : "\n";
        }
    }
}

