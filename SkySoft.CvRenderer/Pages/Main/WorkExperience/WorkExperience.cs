using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.WorkExperience
{
    public class WorkExperienceComponent : IComponent
    {
        private readonly Work _work;
        private readonly int _index;
        private readonly int _arraySize;
        
        public WorkExperienceComponent(Work work, int index, int arraySize)
        {
            _work = work;
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
                .Row(row =>
                {
                    row.RelativeItem()
                    .Column(column =>
                    {
                        column.Item().Text($"{_work.Name}")
                        .Style(WorkAcademicStyle.WorkNameStyle);

                        column.Item().Text($"{_work.StartDate} - {_work.EndDate}")
                        .Style(WorkAcademicStyle.WorkSummaryStyle);
                    });
                });

                row.AutoItem()
                .Component(new VerticalLine(26f, 6, _index));

                row.RelativeItem()
                .PaddingBottom(PaddingForElement.PadingBottomEltment(_arraySize, _index, 13))
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
