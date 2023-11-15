using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using System.Collections.Generic;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class VerticalLine : IComponent
    {
        private readonly float _horizontalPosition;
        private readonly int _index;
        private readonly float _verticalPosition;
        

        public VerticalLine(float horizontalPosition, float verticalPosition, int index) 
        {
            _horizontalPosition = horizontalPosition;
            _verticalPosition = verticalPosition;
            _index = index;
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
                    .Element(ComponentsSize.LinesSize)
                    .PaddingTop(_index == 0 ? 5 : 0)
                    .LineVertical(1)
                    .LineColor(DocumentColors.ElementsBackgroundColor);
            });
        }
    }
}
