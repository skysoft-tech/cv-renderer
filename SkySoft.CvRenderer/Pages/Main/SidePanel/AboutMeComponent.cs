using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.SidePanel
{
    public class AboutMeComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;

        public AboutMeComponent(ILogger logger, CvModel value)
        {
            _logger = logger;
            _cvModel = value;
        }

        public void Compose(IContainer container)
        {
            if (_cvModel.Basics == null)
            {
                _logger.LogError("Basic information is missed in CV");
                return;
            }

            container.Row(row =>
            {
                row.RelativeItem()
                    .PaddingTop(0)
                    .PaddingBottom(34)
                    .PaddingLeft(40)
                    .PaddingRight(30)
                    .AlignLeft()
                    .Column(column =>
                    {
                        column.Item()
                            .PaddingTop(16)
                            .Component(new NameComponent(_cvModel.Basics));

                        column.Item()
                            .PaddingTop(16)
                            .Text(text =>
                            {
                                var labelStyle = TextStyle
                                    .Default
                                    .FontColor(DocumentColors.AlterContrastFontColor)
                                    .LineHeight(0.7f)
                                    .FontSize(14)
                                    .Weight(FontWeight.Bold);

                                text.Span($"{_cvModel.Basics.Label}").Style(labelStyle);
                            });

                        column.Item()
                            .PaddingTop(DocumentSpaces.SpaceBetweenSections)
                            .Component(new CaptionComponent("ABOUT ME", DocumentColors.ContrastFontColor));

                        column.Item()
                           .Text(text =>
                           {
                               var textStyle = TextStyle
                                   .Default
                                   .FontColor(DocumentColors.ContrastFontColor)
                                   .LineHeight(0.8f)
                                   .FontSize(10);

                               text.ParagraphSpacing(8);

                               text.Span($"{_cvModel.Basics.Summary}").Style(textStyle);
                           });

                        column.Item()
                            .PaddingTop(DocumentSpaces.SpaceBetweenSections)
                            .Component(new CaptionComponent("LANGUAGE", DocumentColors.ContrastFontColor));

                        column.Item()
                            .ShowEntire()
                            .Column(column =>
                            {
                                var languages = _cvModel?.Languages ?? Enumerable.Empty<Languages>();
                                foreach (var lang in languages)
                                {
                                    if (string.IsNullOrEmpty(lang.Language))
                                    {
                                        continue;
                                    }

                                    column.Item().Component(new LanguagesComponent(lang.Language));
                                }
                            });

                        column.Item()
                            .ShowEntire()
                            .Component(new FooterComponent(_cvModel.Basics));
                    });
            });
        }
    }
}
