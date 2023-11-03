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

        public WorkExperienceComponent(Work value, int index, int arraySize)
        {
            _work = value;
            _index = index;
            _arraySize = arraySize;

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
                        column.Item()
                        .Component( new GrayDot(_work.Name, WorkAcademicStyle.WorkNameStyle, 76));

                        column.Item()
                        .Text($"{_work.StartDate} - {_work.EndDate}")
                        .Style(WorkAcademicStyle.WorkSummaryStyle);
                    });
                });

                row.AutoItem()
                .PaddingTop(_index == 0 ? 4 : 0)
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
