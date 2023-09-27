using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using System.Xml.Linq;
using WebApplicationPdf.GlobalComponent;

namespace WebApplicationPdf.MainContentLeftSide
{
    public static class AboutMeStyle
    {
        public static TextStyle FirstNameStyle(this TextStyle style)
        {
            return style
                .FontSize(32)
                .LineHeight(0.8f)
                .FontColor("#FFFFFF")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle SurnameStyle(this TextStyle style)
        {
            return style
                .FontSize(32)
                .LineHeight(0.8f)
                .FontColor("#FFFFFF")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle BrieflyAboutMyselfStyle(this TextStyle style)
        {
            return style
                .Thin()
                .FontSize(14)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle AboutMeContentStyle(this TextStyle style)
        {
            return style
                .FontSize(10)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle LanguageContentStyle(this TextStyle style)
        {
            return style
                .FontSize(13)
                .LineHeight(0.9f)
                .FontColor("#FFFFFF")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle LocationStyle(this TextStyle style)
        {
            return style
                .FontSize(11)
                .LineHeight(0.9f)
                .FontColor("#919193")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

    }
}
