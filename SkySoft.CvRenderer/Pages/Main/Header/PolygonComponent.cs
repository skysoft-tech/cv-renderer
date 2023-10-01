using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.Header
{
    internal class PolygonComponent : IComponent
    {
        public void Compose(IContainer container)
        {
            container.Canvas(DrawPolygon);
        }

        private void DrawPolygon(SKCanvas canvas, Size availableSpace)
        {
            using var paint = new SKPaint
            {
                Color = SKColor.Parse(DocumentColors.AccentColor),
                IsAntialias = true,
                IsStroke = false,

                // it's important to set style to Fill 
                // to besure that stroke doesn't overlap 
                // polygon borders
                Style = SKPaintStyle.Fill 
            };

            var path = GetPolygon(availableSpace);
            canvas.DrawPath(path, paint);
        }

        private SKPath GetPolygon(Size size)
        {
            var startPoint = new SKPoint(0, size.Height / 2);

            var path = new SKPath();

            path.MoveTo(startPoint);
            path.LineTo(size.Width * 9 / 10, size.Height);
            path.LineTo(size.Width, size.Height);
            path.LineTo(size.Width, 0);
            path.LineTo(size.Width / 5.7f, 0);
            path.LineTo(startPoint);
            path.Close();

            return path;
        }
    }
}
