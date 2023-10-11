using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.Footer
{
    internal class FooterComponent : IComponent
    {
        private readonly Basics _basics;

        public FooterComponent(Basics? value)
        {
            _basics = value;
        }

        public void Compose(IContainer container)
        {
            var locationStyle = TextStyle.Default.LocationStyle();

            container
                .Element(ComponentsSize.LocationSize)
                .Column(column =>
                {
                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{_basics.Phone}")
                        .Style(locationStyle);
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{_basics.Location.Address}")
                        .Style(locationStyle);

                        text.Span($"{_basics.Location.PostalCode}")
                        .Style(locationStyle);
                    });
                });
        }

    }
}
