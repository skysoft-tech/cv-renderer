using Microsoft.Extensions.Logging;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Core
{
    public interface IPdfRenderer
    {
        void Render(Stream stream, CvOptions options);
    }

    public class PdfRenderer : IPdfRenderer
    {
        private readonly ILogger _logger;
        private readonly CvModel _cv;
        private readonly IFileResolver _fileResolver;

        public PdfRenderer(ILogger logger, CvModel cv) : this(logger, new DefaultFileResolver(), cv) { }

        public PdfRenderer(ILogger logger, IFileResolver fileResolver, CvModel cv)
        {
            _logger = logger;
            _fileResolver = fileResolver;
            _cv = cv;
        }

        public void Render(Stream stream, CvOptions options)
        {
            SetupLicense();
            SetupFont();

            var document = new CvDocument(_logger, _fileResolver, _cv, options);

            document.GeneratePdf(stream);

            if (ShowPreview())
            {
                document.ShowInPreviewer();
            }
        }

        private bool ShowPreview()
        {
#if DEBUG && IS_DESKTOP
            return true;
#endif

            return false;
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
