using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkiaSharp;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using SkySoft.CvRenderer.Pages.Projects.Components;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class MetadataPages : IDynamicComponent<int>
    {
        public int State { get; set; }

        int pageNumber;
        int totalPages;

        public MetadataPages(out int _pageNumber, out int _totalPages)
        {
            _pageNumber = pageNumber;
            _totalPages = totalPages;
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            var content = context.CreateElement(container =>
            {
                pageNumber = context.PageNumber;
                totalPages = context.TotalPages;
            });

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false
            };
        }
    }
}
