using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.MainContentLeftSide
{
    internal static class AboutMeSize
    {
        public static IContainer AboutMeContainerSize(this IContainer element)
        {
            return element
                   .PaddingLeft(40)
                   .PaddingRight(30);
        }

        public static IContainer BrieflyAboutMyselfSize(this IContainer element)
        {
            return element
                .PaddingRight(10)
                .PaddingBottom(30);
        }

        public static IContainer LanguageSize(this IContainer element)
        {
            return element
                .PaddingRight(10)
                .PaddingBottom(4);
        }

        public static IContainer LocationSize(this IContainer element)
        {
            return element
                .PaddingLeft(40)
                .PaddingRight(30)
                .PaddingBottom(30)
                .ExtendVertical()
                .AlignBottom();
        }
    }
}
