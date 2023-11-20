using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.WorkExperience
{
    public class WorkExperienceComponent : IComponent
    {
        private readonly Work _work;
        private readonly bool _isFirstItem;
        private readonly bool _isLastItem;

        public WorkExperienceComponent(Work work, int index, int count)
        {
            _work = work;
            _isFirstItem = index == 0;
            _isLastItem = index + 1 == count;
        }

        public void Compose(IContainer container)
        {
            var start = _work.StartDate?.ToString("yyyy");
            var end = _work.EndDate?.ToString("yyyy") ?? "present";

            container.Row(row =>
            {
                row.AutoItem()
                    .MinWidth(50)
                    .MaxWidth(100)
                    .Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            var nameStyle = TextStyle
                                .Default
                                .FontColor(DocumentColors.AccentColor)
                                .LineHeight(0.7f)
                                .FontSize(12)
                                .Weight(FontWeight.SemiBold);

                            column.Item().Text(_work.Name).Style(nameStyle);

                            var workSummaryStyle = TextStyle
                                .Default
                                .FontColor(DocumentColors.HintColor)
                                .LineHeight(0.7f)
                                .FontSize(10);

                            column.Item().Text($"{start} - {end}").Style(workSummaryStyle);
                        });
                    });

                row.AutoItem().Component(new VerticalLine(26f, 6, _isFirstItem));

                row.RelativeItem()
                    .PaddingBottom(PaddingForElement.PadingBottomEltment(_isLastItem, 13))
                    .Column(column =>
                    {
                        column.Item()
                        .Text($"{_work.Position}").Style(WorkAcademicStyle.WorkPositionStyle);

                        column.Item()
                        .Text($"{_work.Summary}").Style(WorkAcademicStyle.WorkSummaryStyle);
                    });
            });
        }
    }
}
