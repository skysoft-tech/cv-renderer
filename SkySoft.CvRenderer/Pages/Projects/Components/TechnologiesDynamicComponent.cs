using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public struct TechnologiesElemenParameters
    {
        public Project _project { get; set; }
    }

    public class TechnologiesDynamicComponent : IDynamicComponent<TechnologiesElemenParameters>
    {
        public TechnologiesElemenParameters State { get; set; }

        private int maximumStringLength = 40;

        public TechnologiesDynamicComponent(Project project)
        {
            State = new TechnologiesElemenParameters
            {
                _project = project
            };
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            int sumStringLengths = 0;

            var content = context.CreateElement(container =>
            {
                var pageNumber = context.PageNumber;
                var totalPage = context.TotalPages;

                container.Column(column =>
                {
                    column.Item().Text(text =>
                    {
                        State._project.Technologies.ForEach(technologies =>
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

                            text.Span($"{pageNumber} {totalPage}").FontSize(12);

                            //text.Element().Height(11).Width(10);

                            if (sumStringLengths > maximumStringLength)
                            {
                                sumStringLengths = StringLength(technologies);
                            }
                        });
                    });
                });
            });

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false
            };
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
