using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class VerticalLine : IComponent
    {
        private readonly float _horizontalPosition;
        private readonly float _verticalPosition;
        private readonly bool _isFirstItem;

        public VerticalLine(float horizontalPosition, float verticalPosition, bool isFirstItem) 
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
            _isFirstItem = isFirstItem;
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

                    canvas.DrawCircle(_horizontalPosition, _verticalPosition, 2.5f, paint);
                });

                layer.PrimaryLayer()
                    .PaddingLeft(26)
                    .PaddingRight(14)
                    .PaddingTop(_isFirstItem ? 5 : 0)
                    .LineVertical(1)
                    .LineColor(DocumentColors.ElementsBackgroundColor);
            });
        }
    }
}
