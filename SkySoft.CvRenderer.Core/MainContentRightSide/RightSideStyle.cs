using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using WebApplicationPdf.GlobalComponent;

namespace WebApplicationPdf.TitlePage
{
    internal static class RightSideStyle
    {
        public static TextStyle ContantTitlePink(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#D50057")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }
        public static TextStyle ContantTitleBlack(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#000000")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle RightsContentStyle(this TextStyle style)
        {
            return style
                .FontSize(9)
                .LineHeight(0.9f)
                .FontColor("#666666")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle RightsSkillsStyle(this TextStyle style)
        {
            return style
                .FontSize(9)
                .LineHeight(0.9f)
                .FontColor("#000000")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }
    }
}
