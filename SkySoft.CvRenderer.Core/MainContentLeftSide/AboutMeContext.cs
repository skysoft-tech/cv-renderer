using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.MainContentLeftSide
{
    public class AboutMeContext : IComponent
    {
        public string? basics { get; }

        public AboutMeContext(string? value)
        {
            basics = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle aboutMeContentStyle = TextStyle.Default.AboutMeContentStyle();

            container
             .Element(AboutMeSize.AboutMeContainerSize)
             .Column(column =>
             {
                 column.Item()
                 .PaddingBottom(10)
                 .Text(text =>
                 {
                     text.Span($"{basics}")
                    .Style(aboutMeContentStyle);
                 });
             });
        }
    }
}
