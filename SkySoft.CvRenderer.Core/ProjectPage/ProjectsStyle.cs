using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using WebApplicationPdf.GlobalComponent;

namespace WebApplicationPdf.ProjectPage
{
    public static class ProjectsStyle
    {
        public static TextStyle ProjectsTitlePink(this TextStyle style)
        {
            return style
                .FontSize(14)
                .LineHeight(0.8f)
                .FontColor("#D50057")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }
        public static TextStyle ProjectsTitleGray(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#666666")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle ProjectsDataStyle(this TextStyle style)
        {
            return style
                .FontSize(10)
                .LineHeight(0.9f)
                .FontColor("#666666")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }

        public static TextStyle ProjectsContentStyle(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.9f)
                .FontColor("#000000")
                .FontFamily(GlobalFontFamily.FontFamilyStyle());
        }
    }
}
