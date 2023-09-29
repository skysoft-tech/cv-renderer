using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkySoft.CvRenderer.Core.Models;
using System.ComponentModel;
using System.Text.Json;
using WebApplicationPdf.Pages;

namespace SkySoft.CvRenderer.Core
{
    public class PdfRenderer
    {
        public CvModel? cvModel { get; }

        public PdfRenderer(CvModel? Value)
        {
            cvModel = Value;
        }

        public void Render()
        {
            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(PageSizes.A4);

                    page.Content()
                    .Component(new PageCover(cvModel));
                });

                document.Page(page =>
                {
                    page.Size(PageSizes.A4);

                    page.Content()
                    .Component(new PageProjectsAccomplished(cvModel));
                });

            }).ShowInPreviewer();/*.GeneratePdf("hello.pdf");*/
            QuestPDF.Settings.License = LicenseType.Community;
        }
    }
}
