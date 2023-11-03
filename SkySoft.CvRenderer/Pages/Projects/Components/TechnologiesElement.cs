using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public struct TechnologiesElemenParameters
    {
        public Project _Project { get; set; }
    }

    public class TechnologiesElement : IDynamicComponent<TechnologiesElemenParameters>
    {
        public TechnologiesElemenParameters State { get; set; }

        public TechnologiesElement(Project project)
        {
            State = new TechnologiesElemenParameters
            {
                _Project = project
            };
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            //float maximumLengthElement = context.AvailableSize.Width;

            var content = context.CreateElement(container =>
            {
                container.Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        State._Project.Technologies.ForEach(technologies =>
                        {
                            text.Element().Height(11).Width(10)
                            .Canvas((canvas, size) =>
                            {
                                using var paint = new SKPaint
                                {
                                    Color = SKColor.Parse("#d20155"),
                                    IsStroke = false
                                };

                                canvas.DrawCircle(5, 7f, 2, paint);
                            });

                            text.Span($"{technologies}").FontSize(12);

                            text.Element().Height(11).Width(10);
                        });
                    });
                });
            });

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false
            };
        }
    }
}
