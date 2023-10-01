using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public static class ProjectsStyle
    {
        public static TextStyle ProjectsTitlePink(this TextStyle style)
        {
            return style
                .FontSize(14)
                .LineHeight(0.8f)
                .FontColor("#D50057");
        }
        public static TextStyle ProjectsTitleGray(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.8f)
                .FontColor("#666666");
        }

        public static TextStyle ProjectsDataStyle(this TextStyle style)
        {
            return style
                .FontSize(10)
                .LineHeight(0.9f)
                .FontColor("#666666");
        }

        public static TextStyle ProjectsContentStyle(this TextStyle style)
        {
            return style
                .FontSize(12)
                .LineHeight(0.9f)
                .FontColor("#000000");
        }
    }
}
