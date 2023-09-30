using QuestPDF.Infrastructure;
using QuestPDF.Fluent;

namespace WebApplicationPdf.TitlePage
{
    internal static class RightSideStyle
    {
        public static TextStyle ContantTitlePink(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#D50057");
        }
        public static TextStyle ContantTitleBlack(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#000000");
        }

        public static TextStyle RightsContentStyle(this TextStyle style)
        {
            return style
                .FontSize(9)
                .LineHeight(0.9f)
                .FontColor("#666666");
        }

        public static TextStyle RightsSkillsStyle(this TextStyle style)
        {
            return style
                .FontSize(9)
                .LineHeight(0.9f)
                .FontColor("#000000");
        }
    }
}
