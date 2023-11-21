using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.SidePanel
{
    public class LanguagesComponent : IComponent
    {
        private readonly string _language;

        public LanguagesComponent(string value)
        {
            _language = value;
        }

        public void Compose(IContainer container)
        {
            container
                .Layers(layer =>
                {
                    layer.Layer().Canvas(DrawDot);

                    var languageStyle = TextStyle
                        .Default
                        .FontColor(DocumentColors.ContrastFontColor)
                        .LineHeight(0.7f)
                        .FontSize(11);

                    layer.PrimaryLayer()
                        .PaddingBottom(8)
                        .PaddingHorizontal(12)
                        .Text(text =>
                        {
                            text.Span($"{_language}").Style(languageStyle);
                        });
                });
        }

        private void DrawDot(SKCanvas canvas, Size size)
        {
            using var paint = new SKPaint
            {
                Color = SKColor.Parse(DocumentColors.AccentColor),
                IsStroke = false
            };

            canvas.DrawCircle(5, 6, 2.5f, paint);
        }
    }
}

