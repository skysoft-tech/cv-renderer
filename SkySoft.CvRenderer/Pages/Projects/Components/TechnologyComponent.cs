using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    internal class TechnologyComponent : IComponent
    {
        private readonly string _technology;

        public TechnologyComponent(string technology)
        {
            _technology = technology;
        }

        public void Compose(IContainer container)
        {
            container.Layers(layers =>
            {
                layers.PrimaryLayer()
                    .PaddingLeft(12)
                    .Text(_technology)
                    .Style(DocumentFonts.LabelStyle).LineHeight(1);

                layers.Layer()
                    .Canvas((canvas, size) =>
                    {
                        using var paint = new SKPaint
                        {
                            Color = SKColor.Parse("#d20155"),
                            IsStroke = false
                        };

                        canvas.DrawCircle(5, size.Height / 2 - 1, 2, paint);
                    });
            });
        }
    }
}
