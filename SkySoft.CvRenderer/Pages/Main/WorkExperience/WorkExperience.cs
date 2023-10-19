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
            _work = value; /*?? throw new NullReferenceException();*/
            _index = index;
            _arraySize = arraySize;

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
                .Row(row =>
                {
                    row.RelativeItem()
                    .Column(column =>
                    {
                        column.Item()
                        .Component( new GrayDot(_work.Name, workNameStyle, 76));

                        column.Item()
                        .Text($"{_work.StartDate} - {_work.EndDate}")
                        .Style(workSummaryStyle);
                    });
                });

                row.AutoItem()
                .PaddingTop(_index == 0 ? 4 : 0)
                .Component(new VerticalLine());
               
                row.RelativeItem()
                .Column(column =>
                {
                    column.Item()
                    .Text($"{_work.Position}").Style(workPositionStyle);

                    column.Item()
                    .PaddingBottom(_arraySize == _index + 1 ? 0 : 13)
                    .Text($"{_work.Summary}").Style(workSummaryStyle);
                });
            });
        }
    }
}
