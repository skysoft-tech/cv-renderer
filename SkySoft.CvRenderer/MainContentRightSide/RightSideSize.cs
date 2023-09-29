using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.TitlePage
{
    public static class RightSideSize
    {
        public static IContainer LeftSidePadding(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingRight(20)
                .MinWidth(55);
        }

        public static IContainer LeftSidePaddingData(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingTop(5)
                .PaddingRight(20)
                .MinWidth(55);
        }

        public static IContainer RightSidePadding(this IContainer element)
        {
            return element
                .AlignLeft()
                .PaddingBottom(3)
                .PaddingLeft(8);
        }
    }
}

