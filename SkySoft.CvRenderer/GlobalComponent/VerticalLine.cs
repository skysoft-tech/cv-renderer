using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class VerticalLine : IComponent
    {
        public void Compose(IContainer container)
        {

            container.Layers(layer =>
            {
                layer.Layer()
                .AlignCenter()
                .Canvas((canvas, size) =>
                {
                    using var paint = new SKPaint
                    {
                        Color = SKColor.Parse("#dbdbdb"),
                        IsStroke = false
                    };
                    canvas.DrawCircle(25.5f, 6, 2.5f, paint);
                });

                layer.PrimaryLayer()
                    .Element(ComponentsSize.LinesSize)
                    .LineVertical(1)
                    .LineColor("#dbdbdb");
            });
        }
    }
}
