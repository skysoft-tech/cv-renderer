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
            container
                .Element(ComponentsSize.LocationSize)
                .Column(column =>
                {
                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{_basics.Phone}")
                        .Style(AboutMeStyle.LocationStyle);
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span($"{_basics.Location.Address}")
                        .Style(AboutMeStyle.LocationStyle);

                        text.Span($"{_basics.Location.PostalCode}")
                        .Style(AboutMeStyle.LocationStyle);
                    });
                });
        }

    }
}
