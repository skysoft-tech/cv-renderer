using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    public class WorkAcademicStyle
    {
        public static TextStyle WorkNameStyle => TextStyle
            .Default
            .FontColor(DocumentColors.AccentColor)
            .LineHeight(0.7f)
            .FontSize(12)
            .Weight(FontWeight.SemiBold);

        public static TextStyle WorkStartDateStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(0.7f)
            .FontSize(10);

        public static TextStyle WorkPositionStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.7f)
            .FontSize(12)
            .Weight(FontWeight.SemiBold);

        public static TextStyle StudyTypeStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.7f)
            .FontSize(12)
            .Weight(FontWeight.Normal);

        public static TextStyle WorkSummaryStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(0.7f)
            .FontSize(10);

        public static TextStyle SkillsStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.7f)
            .FontSize(10);
    }
}
