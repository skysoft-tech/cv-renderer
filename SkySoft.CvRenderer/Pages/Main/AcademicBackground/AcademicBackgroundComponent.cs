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
        private readonly int _index;
        private readonly int _arraySize;

        public AcademicBackgroundComponent(Education? value, int index, int arraySize)
        {
            _education = value;
            _index = index;
            _arraySize = arraySize;
        }

        public void Compose(IContainer container)
        {
            container
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(60)
                .MaxWidth(60)
                .Text($"{_education.StartDate} - {_education.EndDate}").Style(WorkAcademicStyle.WorkStartDateStyle);

                row.AutoItem()
                .Component(new VerticalLine(25.5f, _index));

                row.RelativeItem()
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
                    .PaddingBottom(PaddingForElement.PadingBottomEltment(_arraySize, _index, 13))
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

