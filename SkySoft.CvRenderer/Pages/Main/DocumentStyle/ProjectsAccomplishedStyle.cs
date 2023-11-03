using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    internal class ProjectsAccomplishedStyle
    {
        public static TextStyle ProjectStartDateStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(0.8f)
            .FontSize(10)
            .Weight(FontWeight.Normal);

        public static TextStyle ProjectNameStyle => TextStyle
            .Default
            .FontColor(DocumentColors.AccentColor)
            .LineHeight(0.8f)
            .FontSize(14)
            .Weight(FontWeight.SemiBold);

        public static TextStyle ProjectDescriptionStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.8f)
            .FontSize(12)
            .Weight(FontWeight.Normal);

        public static TextStyle DutiesStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(0.8f)
            .FontSize(12)
            .Weight(FontWeight.SemiBold);
    }
}
