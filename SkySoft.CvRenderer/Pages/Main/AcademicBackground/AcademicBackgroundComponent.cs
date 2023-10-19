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
            var workStartDateStyle = TextStyle.Default.WorkStartDateStyle();
            var workNameStyle = TextStyle.Default.WorkNameStyle();
            var workSummaryStyle = TextStyle.Default.WorkSummaryStyle();
            var workPositionStyle = TextStyle.Default.WorkPositionStyle();
            var studyTypeStyle = TextStyle.Default.StudyTypeStyle();

            container
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(50)
                .MaxWidth(50)
                .Component(new GrayDot($"{_education.StartDate} - {_education.EndDate}", workStartDateStyle, 76));

                row.AutoItem()
                .PaddingTop(_index == 0 ? 4 : 0)
                .Component(new VerticalLine());

                row.RelativeItem()
                .Column(column =>
                {
                    column.Item()
                    .PaddingBottom(4)
                    .Text(text =>
                    {
                        text.Span($"{_education.Institution}\n")
                        .Style(workNameStyle);

                        text.Span($"{_education.City}, {_education.Country}")
                        .Style(workSummaryStyle);
                    });

                    column.Item()
                    .PaddingBottom(_arraySize == _index + 1 ? 0 : 13)
                    .Text(text =>
                    {
                        text.Span($"{_education.StudyType}\n")
                        .Style(studyTypeStyle);

                        text.Span($"{_education.Score}")
                        .Style(workSummaryStyle);
                    });
                });
            });
        }
    }
}

