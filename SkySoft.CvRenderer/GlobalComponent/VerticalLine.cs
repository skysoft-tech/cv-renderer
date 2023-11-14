using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class VerticalLine : IComponent
    {
        private readonly float _horizontalPosition;

        public VerticalLine(float horizontalPosition) 
        {
            _horizontalPosition = horizontalPosition;
        }

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
                    canvas.DrawCircle(_horizontalPosition, 6, 2.5f, paint);
                });

                layer.PrimaryLayer()
                    .Element(ComponentsSize.LinesSize)
                    .LineVertical(1)
                    .LineColor(DocumentColors.ElementsBackgroundColor);
            });
        }
    }
}
