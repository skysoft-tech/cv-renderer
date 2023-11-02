using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkiaSharp;
using System.Drawing;
using System.Xml;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class TechnologiesElement : IDynamicComponent<int>
    {
        public int State { get; set; }

        private readonly string _technologies;
        public float sizeComponent;

        public TechnologiesElement(string technologies, out float _sizeComponent)
        {
            _technologies = technologies;
            _sizeComponent = sizeComponent;
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            sizeComponent = context.AvailableSize.Width;

            var content = context.CreateElement(container =>
            {
                container.Row(row =>
                {
                    row.RelativeItem().Layers(layer =>
                    {
                        layer.Layer()
                        .AlignCenter()
                        .Canvas((canvas, size) =>
                        {
                            using var paint = new SKPaint
                            {
                                Color = SKColor.Parse("#d20155"),
                                IsStroke = false
                            };

                            canvas.DrawCircle(5, 7.5f, 2, paint);
                        });

                        layer.PrimaryLayer()
                        .PaddingHorizontal(12)
                        .Text(text =>
                        {
                            text.Span($"{sizeComponent}")
                            .FontSize(12)
                            .LineHeight(0.9f)
                            .FontColor("#000000");
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
