using SkiaSharp;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class TechnologiesElement : IComponent
    {
        private readonly string _technologies;

        public TechnologiesElement(string? Value)
        {
            _technologies = Value;
        }
        public void Compose(IContainer container)
        {
            container
                .Layers(layer =>
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
                    .PaddingBottom(12)
                    .Text(text =>
                    {
                        text.Span(_technologies)
                        .FontSize(12)
                        .LineHeight(0.9f)
                        .FontColor("#000000");
                    });
                });
        }
    }
}
