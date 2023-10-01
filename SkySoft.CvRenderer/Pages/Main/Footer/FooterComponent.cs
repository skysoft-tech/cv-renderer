using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Pages.Main.AboutMe;

namespace SkySoft.CvRenderer.Pages.Main.Footer
{
    internal class FooterComponent : IComponent
    {
        public Basics? basics { get; }

        public FooterComponent(Basics? value)
        {
            basics = value;
        }

        public void Compose(IContainer container)
        {
            var locationStyle = TextStyle.Default.LocationStyle();

            container
                .Element(AboutMeSize.LocationSize)
                .Column(column =>
                {
                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{basics.Phone}")
                        .Style(locationStyle);
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{basics.Location.Address}")
                        .Style(locationStyle);

                        text.EmptyLine();

                        text.Span($"{basics.Location.PostalCode}")
                        .Style(locationStyle);
                    });
                });
        }

    }
}
