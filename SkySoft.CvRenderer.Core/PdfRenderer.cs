using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace SkySoft.CvRenderer.Core
{
    public class PdfRenderer
    {
        public void Render()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    // page content
                });
            });
            QuestPDF.Settings.License = LicenseType.Community;
            // instead of the standard way of generating a PDF file
            document.GeneratePdf("hello.pdf");

            // use the following invocation
            document.ShowInPreviewer();
        }
    }
}