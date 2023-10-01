using SkiaSharp;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class TechnologiesElement : IComponent
    {
        public string? technologies { get; }

        public TechnologiesElement(string? Value)
        {
            technologies = Value;
        }
        public void Compose(IContainer container)
        {
            TextStyle projectsContentStyle = TextStyle.Default.ProjectsContentStyle();

            container
                .Layers(layer =>
                {
                    layer.Layer()
                    .AlignCenter()
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
                    .PaddingHorizontal(12)
                    .PaddingBottom(12)
                    .Text(text =>
                    {
                        text.Span(technologies)
                        .FontSize(12)
                        .LineHeight(0.9f)
                        .FontColor("#000000")
                        .Style(projectsContentStyle);
                    });
                });
        }
    }
}
