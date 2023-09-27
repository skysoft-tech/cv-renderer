using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.GlobalComponent
{
    internal class TitleElement
    {
        public string Title { get; }
        public string TextСolor { get; }

        public TitleElement(string title, string textСolor)
        {
            Title = title;
            TextСolor = textСolor;
        }

        public void TitleContainer(IContainer container)
        {
            container
            .PaddingBottom(15)
            .Text(Title)
            .FontSize(14)
            .NormalWeight()
            .FontColor(TextСolor)
            .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }
    }
}
