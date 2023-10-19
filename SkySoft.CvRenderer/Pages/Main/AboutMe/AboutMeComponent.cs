using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.AboutMe
{
    public class AboutMeComponent : IComponent
    {
        private readonly Basics _basics;

        public AboutMeComponent(Basics value)
        {
            _basics = value;
        }

        public void Compose(IContainer container)
        {
            var nameLastNameStyle = TextStyle.Default.NameLastNameStyle();
            var labelStyle = TextStyle.Default.LabelStyle();
            var summaryStyle = TextStyle.Default.SummaryStyle();

            container
             .Column(column =>
             {
                 column.Item()
                .Element(ComponentsSize.NameLastNameSize)
                .Text(text =>
                {
                    text.Span($"{_basics.Name}")
                    .Style(nameLastNameStyle.Weight(FontWeight.Bold));

                    text.Span($"{_basics.LastName}")
                    .Style(nameLastNameStyle.Weight(FontWeight.Light));
                });

                 column.Item()
                .Element(ComponentsSize.SummarySize)
                .Text(text =>
                {
                    text.Span($"{_basics.Label}")
                   .Style(labelStyle);
                });

                 column.Item()
                .AlignLeft()
                .Component(new TitleComponent("ABOUT ME", "#ffffff", 14));
                 
                 column.Item()
                .Element(ComponentsSize.LabelSize)
                .Text(text =>
                {
                    text.ParagraphSpacing(8);

                    text.Span($"{_basics.Summary}")
                   .Style(summaryStyle);
                });
             });
        }
    }
}

