using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.Languages;
using SkySoft.CvRenderer.Pages.Main.Footer;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Pages.Main.AboutMe;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main
{
    public class AboutMeContainer : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;

        public AboutMeContainer(ILogger logger, CvModel value)
        {
            _logger = logger;
            _cvModel = value;
        }

        public void Compose(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem()
                .Element(ComponentsSize.AboutMeContainerSize)
                .Column(column =>
                {
                    column.Item()
                    .Component(new AboutMeComponent(_cvModel.Basics));

                    column.Item()
                    .ShowEntire()
                    .Column(column =>
                    {
                        column.Item()
                        .Component(new TitleComponent("LANGUAGE", "#ffffff", 8));

                        _cvModel.Languages.ForEach(languages =>
                        {
                            column.Item()
                            .Component(new LanguagesComponent(languages.Language));
                        });
                    });

                    column.Item()
                    .ShowEntire()
                   .Component(new FooterComponent(_cvModel.Basics));
                });
            });
        }
    }
}
