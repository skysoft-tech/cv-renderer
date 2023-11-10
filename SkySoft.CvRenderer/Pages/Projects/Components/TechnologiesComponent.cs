using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class TechnologiesComponent : IComponent
    {
        public Project _project { get; set; }

        private int maximumStringLength = 40;

        public TechnologiesComponent(Project project)
        {
            _project = project;

        }

        public void Compose(IContainer container)
        {
            int sumStringLengths = 0;

            container.Column(column =>
            {
                column.Item().Text(text =>
                {
                    DynamicContext dynamicContext = new DynamicContext();

                    var pageNumber = dynamicContext.PageNumber;
                    var totalPages = dynamicContext.TotalPages;

                    _project.Technologies.ForEach(technologies =>
                    {
                        sumStringLengths = sumStringLengths + StringLength(technologies);

                        text.Span(ActionWithString(sumStringLengths));

                        text.Element().Height(11).Width(10)
                        .Canvas((canvas, size) =>
                        {
                            using var paint = new SKPaint
                            {
                                Color = SKColor.Parse("#d20155"),
                                IsStroke = false
                            };

                            canvas.DrawCircle(5, 7f, 2, paint);
                        });

                        text.Span($"{technologies}").FontSize(12);

                        text.Element().Height(11).Width(10);


                        if (sumStringLengths > maximumStringLength)
                        {
                            sumStringLengths = StringLength(technologies);
                        }
                    });
                });
            });
        }

        private int StringLength(string value)
        {
            return value.Length;
        }

        private string ActionWithString(int totalStringLength)
        {
            string action = "";

            if (totalStringLength > maximumStringLength) return action = "\n";

            return action;
        }

    }
}
