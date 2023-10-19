using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class GrayDot : IComponent
    {
        private readonly string _text;
        private readonly TextStyle _style;
        private readonly float _horizontalPosition;
        

        public GrayDot(string text, TextStyle style, float horizontalPosition)
        {
            _text = text;
            _style = style;
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
                .Text(text =>
                {
                    text.Span(_text)
                    .Style(_style);
                });
            });
        }
    }
}
