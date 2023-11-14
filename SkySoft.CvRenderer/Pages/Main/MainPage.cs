using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.Header;
using SkySoft.CvRenderer.Pages.Main.AboutMe;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class MainPage : IComponent
    {
        private readonly ILogger _logger;
        public CvModel cvModel { get; }

        public MainPage(ILogger logger, CvModel Value)
        {
            _logger = logger;
            cvModel = Value;
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
                      .Component(new HeaderComponent(_logger, cvModel));

                      column.Item()
                      .ShowOnce()
                      .Component(new AboutMeContainer(_logger, cvModel));
                  });


                row.RelativeItem(1)
                  .Column(column =>
                  {
                      column.Item()
                     .Component(new BackgroundContainer(_logger, cvModel));
                  });
            });
        }

    }
}
