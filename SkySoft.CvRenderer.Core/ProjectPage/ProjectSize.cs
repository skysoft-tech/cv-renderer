using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.ProjectPage
{
    public static class ProjectSize
    {
        public static IContainer AspectRatioProject(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingLeft(20)
                .PaddingRight(20);
        }

        public static IContainer AspectRatioProjectDate(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingRight(40);
        }

        public static IContainer AspectRatioProjectRow(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingLeft(15);
        }

        public static IContainer AspectRatioProjectСontent(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingBottom(8);
        }
    }
}
