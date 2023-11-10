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
        private readonly float _minWidth;
        


        public WorkExperienceComponent(Work work, int index, int arraySize, float minWidth)
        {
            _work = work;
            _index = index;
            _arraySize = arraySize;
            _minWidth = minWidth;

        }
        public void Compose(IContainer container)
        {
            container
            .Row(row =>
            {
                row.AutoItem()
                .MinWidth(50)
                .MaxWidth(50)
                .Row(row =>
                {
                    row.RelativeItem()
                    .Column(column =>
                    {
                        column.Item().Text($"{_work.Name}").Style(WorkAcademicStyle.WorkNameStyle);

                        column.Item()
                        .Text($"{_work.StartDate} - {_work.EndDate}")
                        .Style(WorkAcademicStyle.WorkSummaryStyle);
                    });
                });

                row.AutoItem()
                .Component(new VerticalLine());
               
                row.RelativeItem()
                .Column(column =>
                {
                    column.Item()
                    .Text($"{_work.Position}").Style(WorkAcademicStyle.WorkPositionStyle);

                    column.Item()
                    .PaddingBottom(_arraySize == _index + 1 ? 0 : 13)
                    .Text($"{_work.Summary}").Style(WorkAcademicStyle.WorkSummaryStyle);
                });
            });
        }
    }
}
