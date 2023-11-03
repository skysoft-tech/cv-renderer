using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    public static class AboutMeStyle
    {
        public static TextStyle NameLastNameStyle => TextStyle
            .Default
            .FontColor(DocumentColors.ContrastFontColor)
            .LineHeight(0.7f)
            .FontSize(32);

        public static TextStyle LabelStyle => TextStyle
            .Default
            .FontColor(DocumentColors.ContrastFontColor)
            .LineHeight(0.7f)
            .FontSize(14)
            .Weight(FontWeight.Bold);

        public static TextStyle SummaryStyle => TextStyle
            .Default
            .FontColor(DocumentColors.ContrastFontColor)
            .LineHeight(0.7f)
            .FontSize(11);

        public static TextStyle LanguageStyle => TextStyle
            .Default
            .FontColor(DocumentColors.ContrastFontColor)
            .LineHeight(0.7f)
            .FontSize(12);

        public static TextStyle LocationStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FooterFontColor)
            .LineHeight(0.7f)
            .FontSize(11);
    }
}
