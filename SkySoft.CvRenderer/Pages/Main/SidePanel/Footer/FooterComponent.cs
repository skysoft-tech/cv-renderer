using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.SidePanel
{
    internal class FooterComponent : IComponent
    {
        private readonly Basics _basics;

        public FooterComponent(Basics value)
        {
            _basics = value;
        }

        public void Compose(IContainer container)
        {
            var footerStyles = TextStyle
                .Default
                .FontColor(DocumentColors.FooterFontColor)
                .LineHeight(0.8f)
                .FontSize(11);

            container
                .ExtendVertical()
                .AlignBottom()
                .Column(column =>
                {
                    column.Item()
                        .Text(text =>
                        {
                            text.Span($"{_basics.Phone}").Style(footerStyles);
                        });

                    column.Item()
                        .Text(text =>
                        {
                            text.Span($"{_basics.Location?.Address}, {_basics.Location?.PostalCode}").Style(footerStyles);
                        });
                });
        }

    }
}
