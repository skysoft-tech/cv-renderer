using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using SkySoft.CvRenderer.Core.Models;
using System.ComponentModel;
using System.Text.Json;

namespace WebApplicationPdf.Pages
{
    public class Statement
    {
        public CvModel? cvModel { get; }

        public Statement(CvModel? Value)
        {
            cvModel = Value;
        }

        public void PageContainer()
        {
            Document.Create(document =>
            {
                document
                .Page(page =>
                {
                    page.Size(PageSizes.A4);

                    page.Content()
                    .Component(new PageCover(cvModel));
                });

                document
                .Page(page =>
                {
                    page.Size (PageSizes.A4);

                    page.Content()
                    .Component(new PageProjectsAccomplished(cvModel));
                });

            }).ShowInPreviewer();
        }
    }
}
