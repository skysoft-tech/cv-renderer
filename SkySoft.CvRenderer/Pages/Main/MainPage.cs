using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Pages.Main.SidePanel;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class MainPage : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvOptions _options;

        private readonly CvModel _cvModel;

        public MainPage(ILogger logger, CvModel cvModel, CvOptions options)
        {
            _logger = logger;
            _cvModel = cvModel;
            _options = options;
        }

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.ConstantItem(240)
                  .ExtendVertical()
                  .Background(DocumentColors.PrimaryColor)
                  .Column(column =>
                  {
                      column.Item()
                          .ShowOnce()
                          .Component(new HeaderComponent(_logger, _cvModel));

                      column.Item()
                          .ShowOnce()
                          .Component(new AboutMeComponent(_logger, _cvModel));
                  });

                row.RelativeItem(1)
                  .Column(column =>
                  {
                      column.Item()
                        .Component(new ContentComponent(_logger, _cvModel, _options));
                  });
            });
        }

    }
}
