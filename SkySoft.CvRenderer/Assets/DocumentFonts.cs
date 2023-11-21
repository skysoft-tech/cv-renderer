using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace SkySoft.CvRenderer.Assets
{
    internal static class DocumentFonts
    {
        public static TextStyle MinorLabelStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(1f)
            .FontSize(10)
            .Weight(FontWeight.Normal);

        public static TextStyle HintLabelStyle => TextStyle
           .Default
           .FontColor(DocumentColors.HintColor)
           .LineHeight(0.6f)
           .FontSize(9)
           .Weight(FontWeight.Normal);

        public static TextStyle AccentLabelStyle => TextStyle
            .Default
            .FontColor(DocumentColors.AccentColor)
            .LineHeight(0.8f)
            .FontSize(12)
            .Weight(FontWeight.SemiBold);

        public static TextStyle LabelStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.8f)
            .FontSize(12)
            .Weight(FontWeight.Normal);

        public static TextStyle MinorTextStyle => TextStyle
            .Default
            .FontColor(DocumentColors.HintColor)
            .LineHeight(0.8f)
            .FontSize(10);

        public static TextStyle TextBoldStyle => TextStyle
            .Default
            .FontColor(DocumentColors.FontColor)
            .LineHeight(0.8f)
            .FontSize(12)
            .Weight(FontWeight.SemiBold);

        public static TextStyle TextStyle => TextStyle
              .Default
              .FontColor(DocumentColors.FontColor)
              .LineHeight(0.8f)
              .FontSize(10);
    }
}
