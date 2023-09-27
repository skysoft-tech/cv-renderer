using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using QuestPDF.Fluent;
using WebApplicationPdf.GlobalComponent;

namespace WebApplicationPdf.MainContentLeftSide
{
    internal class DataLocation : IComponent
    {
        public Basics? basics { get; }

        public DataLocation(Basics? value)
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
