using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebApplicationPdf.Pages;

namespace SkySoft.CvRenderer
{
    internal class CvDocument : IDocument
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;

        public CvDocument(ILogger logger, CvModel cv)
        {
            _logger = logger;
            _cv = cv;
        }

        public void Compose(IDocumentContainer document)
        {
            document.Page(page =>
            {
                page.Size(PageSizes.A4);

                page.Content()
                .Component(new PageCover(_cv));
            });

            document.Page(page =>
            {
                page.Size(PageSizes.A4);

                page.Content()
                .Component(new PageProjectsAccomplished(_cv));
            });
        }
    }
}
