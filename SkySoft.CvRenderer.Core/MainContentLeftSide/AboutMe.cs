using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using WebApplicationPdf.GlobalComponent;
using WebApplicationPdf.MainContentLeftSide;
using WebApplicationPdf.TitlePage;

namespace WebApplicationPdf.MainContentLeftSide
{
    public class AboutMe : IComponent
    {
        public Basics? basics { get; }

        public AboutMe(Basics? value)
        {
            basics = value;
        }

        public void Compose(IContainer container)
        {
            var firstNameStye = TextStyle.Default.FirstNameStyle();
            var surnameStye = TextStyle.Default.SurnameStyle();
            var brieflyAboutMyselfStyle = TextStyle.Default.BrieflyAboutMyselfStyle();

            TitleElement aboutMe = new TitleElement("ABOUT ME", "#ffffff");

            container
             .Element(AboutMeSize.AboutMeContainerSize)
             .Column(column =>
             {
                 column.Item()
                 .AlignTop()
                 .Text(text =>
                 {
                     text.Span($"{basics.Name}")
                     .Style(firstNameStye);
                 });

                 column.Item()
                .AlignTop()
                .PaddingBottom(15)
                .Text(text =>
                {
                    text.Span($"{basics.LastName}")
                    .Style(surnameStye);
                });

                 column.Item()
                 .Element(AboutMeSize.BrieflyAboutMyselfSize)
                 .Text(text =>
                 {
                     text.Span($"{basics.Label}")
                    .Style(brieflyAboutMyselfStyle);
                 });

                 column.Item()
                .AlignLeft()
                .Element(aboutMe.TitleContainer);
             });
        }
    }
}

