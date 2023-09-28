using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.GlobalComponent
{
    internal class TitleComponent : IComponent
    {
        public string Title { get; }
        public string TextСolor { get; }

        public TitleComponent(string title, string textСolor)
        {
            Title = title;
            TextСolor = textСolor;
        }

        public void Compose(IContainer container)
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
