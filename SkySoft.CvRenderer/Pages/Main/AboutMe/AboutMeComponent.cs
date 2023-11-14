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

        public AboutMeComponent(Basics basics)
        {
            _basics = basics;
        }

        public void Compose(IContainer container)
        {
            container
             .Column(column =>
             {
                 column.Item()
                .Element(ComponentsSize.NameLastNameSize)
                .Text(text =>
                {
                    text.Span($"{_basics.Name}")
                    .Style(AboutMeStyle.NameLastNameStyle.Weight(FontWeight.Bold));

                    text.Span($"{_basics.LastName}")
                    .Style(AboutMeStyle.NameLastNameStyle.Weight(FontWeight.Light));
                });

                 column.Item()
                .Element(ComponentsSize.SummarySize)
                .Text(text =>
                {
                    text.Span($"{_basics.Label}")
                   .Style(AboutMeStyle.LabelStyle);
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
                   .Style(AboutMeStyle.SummaryStyle);
                });
             });
        }
    }
}

