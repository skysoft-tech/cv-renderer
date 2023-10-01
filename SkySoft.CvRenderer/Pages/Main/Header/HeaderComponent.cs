using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.Header
{
    public class HeaderComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _model;

        public HeaderComponent(ILogger logger, CvModel model)
        {
            _logger = logger;
            _model = model;
        }

        public void Compose(IContainer container)
        {
            container
                .Layers(layer =>
                {
                    layer.PrimaryLayer()
                      .AlignRight()
                      .Height(170)
                      .Width(212)
                      .Component<PolygonComponent>();

                    layer.Layer()
                        .PaddingTop(34)
                        .PaddingLeft(56)
                        .Height(128)
                        .Width(128)
                        .AlignCenter()
                        .Component(new PhotoComponent(_logger, _model?.Basics?.Image));
                });
        }

    }
}
