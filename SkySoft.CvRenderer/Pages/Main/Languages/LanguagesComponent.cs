using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkiaSharp;
using SkySoft.CvRenderer.Pages.Main.AboutMe;

namespace SkySoft.CvRenderer.Pages.Main.Languages
{
    public class LanguagesComponent : IComponent
    {
        public string? language { get; }

        public LanguagesComponent(string? value)
        {
            language = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle languageContentStyle = TextStyle.Default.LanguageContentStyle();

            container
                .Element(AboutMeSize.LanguageSize)
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

                        canvas.DrawCircle(5, 7, 3, paint);
                    });

                    layer.PrimaryLayer()
                    .PaddingBottom(7)
                    .PaddingHorizontal(12)
                    .Text(text =>
                    {
                        text.Span($"{language}")
                        .Style(languageContentStyle);
                    });
                });
        }
    }
}
