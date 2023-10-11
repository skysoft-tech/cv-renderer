using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
namespace SkySoft.CvRenderer.Pages.Main.Languages
{
    public class LanguagesComponent : IComponent
    {
        private readonly string _language;

        public LanguagesComponent(string? value)
        {
            _language = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle languageStyle = TextStyle.Default.LanguageStyle();
            
            container
                .Layers(layer =>
                {
                    layer.Layer()
                    .Canvas((canvas, size) =>
                    {
                        using var paint = new SKPaint
                        {
                            Color = SKColor.Parse("#d20155"),
                            IsStroke = false
                        };

                        canvas.DrawCircle(5, 6, 3, paint);
                    });

                    layer.PrimaryLayer()
                    .PaddingBottom(8)
                    .PaddingHorizontal(12)
                    .Text(text =>
                    {
                        text.Span($"{_language}")
                        .Style(languageStyle);
                    });
                });
        }
    }
}
