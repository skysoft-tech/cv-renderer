using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.AboutMe
{
    public static class AboutMeStyle
    {
        public static TextStyle FirstNameStyle(this TextStyle style)
        {
            return style
                .FontSize(32)
                .LineHeight(0.8f)
                .FontColor("#FFFFFF");
        }

        public static TextStyle SurnameStyle(this TextStyle style)
        {
            return style
                .FontSize(32)
                .LineHeight(0.8f)
                .FontColor("#FFFFFF");
        }

        public static TextStyle BrieflyAboutMyselfStyle(this TextStyle style)
        {
            return style
                .Thin()
                .FontSize(14)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF");
        }

        public static TextStyle AboutMeContentStyle(this TextStyle style)
        {
            return style
                .FontSize(10)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF");
        }

        public static TextStyle LanguageContentStyle(this TextStyle style)
        {
            return style
                .FontSize(13)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF");
        }

        public static TextStyle LocationStyle(this TextStyle style)
        {
            return style
                .FontSize(11)
                .LineHeight(0.9f)
                .FontColor("#919193");
        }

    }
}
