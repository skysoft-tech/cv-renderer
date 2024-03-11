using Microsoft.Extensions.Logging;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Core
{
    public class PdfRenderer
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;

        public PdfRenderer(ILogger logger, CvModel cv)
        {
            _logger = logger;
            _cv = cv;
        }

        public async Task Render(Stream stream, CvOptions options)
        {
            SetupLicense();
            SetupFont();

            var document = new CvDocument(_logger, _cv, options);
            //#if DEBUG
            //            document.ShowInPreviewer();
            //#else
            var pdfData = document.GeneratePdf();
            await stream.WriteAsync(pdfData);
            //#endif
        }

        private void SetupFont()
        {
            var hindFontCollection = new[]
            {
                "Assets/Font/Hind-Bold.ttf",
                "Assets/Font/Hind-Light.ttf",
                "Assets/Font/Hind-Medium.ttf",
                "Assets/Font/Hind-Regular.ttf",
                "Assets/Font/Hind-SemiBold.ttf"
            };

            foreach (var fontName in hindFontCollection)
            {
                var fontStream = AssetsHelper.ReadResourceStream(fontName);
                if (fontStream is null)
                {
                    _logger.LogWarning($"Failed to load font {fontName}");
                    continue;
                }

                FontManager.RegisterFont(fontStream);
            }
        }

        private void SetupLicense()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
    }
}
