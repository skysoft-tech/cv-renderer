using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Models;
using SkySoft.CvRenderer.Utils;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class WorkExperienceComponent : IComponent
    {
        private readonly Work _work;
        private readonly CvOptions _options;
        private readonly bool _isFirstItem;
        private readonly bool _isLastItem;

        public WorkExperienceComponent(Work work, int index, int count, CvOptions options)
        {
            _work = work;
            _options = options;
            _isFirstItem = index == 0;
            _isLastItem = index + 1 == count;
        }

        public void Compose(IContainer container)
        {
            var start = _work.StartDate.ToYearString();
            var end = _work.EndDate.ToYearString();

            container.Row(row =>
            {
                row.AutoItem()
                    .MinWidth(_options.WorkColumnWidth)
                    .MaxWidth(_options.WorkColumnWidth)
                    .Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text(_work.Name).Style(DocumentFonts.AccentLabelStyle);
                            column.Item().Text($"{start} - {end}").Style(DocumentFonts.MinorLabelStyle);
                        });
                    });

                row.AutoItem().Component(new VerticalLine(26f, 6, _isFirstItem));

                row.RelativeItem()
                    .PaddingBottom(_isLastItem ? 0 : 13)
                    .Column(column =>
                    {
                        column.Item().Text($"{_work.Position}").Style(DocumentFonts.TextBoldStyle);
                        column.Item().Text($"{_work.Summary}").Style(DocumentFonts.MinorTextStyle);
                    });
            });
        }
    }
}
