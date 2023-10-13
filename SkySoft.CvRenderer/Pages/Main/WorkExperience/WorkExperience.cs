using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.WorkExperience
{
    public class WorkExperienceComponent : IComponent
    {
        private readonly Work _work;

        public WorkExperienceComponent(Work? value)
        {
            _work = value;
        }

        public void Compose(IContainer container)
        {
            var workNameStyle = TextStyle.Default.WorkNameStyle();
            var workStartDateStyle = TextStyle.Default.WorkStartDateStyle();
            var workPositionStyle = TextStyle.Default.WorkPositionStyle();
            var workSummaryStyle = TextStyle.Default.WorkSummaryStyle();

            
            container
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(50)
                .MaxWidth(50)
                .Text(text =>
                {
                    text.Span($"{_work.Name}\n")
                    .Style(workNameStyle);

                    text.Span($"{_work.StartDate} - {_work.EndDate}")
                    .Style(workStartDateStyle);
                });

                row.AutoItem()
                .Element(ComponentsSize.LinesSize)
                .LineVertical(1)
                .LineColor("#dbdbdb");

                row.RelativeItem()
                .Text(text =>
                {
                    text.Span($"{_work.Position}\n")
                    .Style(workPositionStyle);

                    text.Span($"{_work.Summary}\n")
                    .Style(workSummaryStyle);
                });
            });
        }
    }
}
