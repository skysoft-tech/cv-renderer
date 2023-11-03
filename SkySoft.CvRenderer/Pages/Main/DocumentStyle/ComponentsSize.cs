using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    public static class ComponentsSize
    {
        public static IContainer LinesSize(this IContainer element)
        {
            return element
                .PaddingLeft(26)
                .PaddingRight(14);
        }


        //AboutMeComponent
        public static IContainer AboutMeContainerSize(this IContainer element)
        {
            return element
                 .PaddingTop(15)
                 .PaddingBottom(34)
                 .PaddingLeft(40)
                 .PaddingRight(30)
                 .AlignLeft();
        }

        public static IContainer NameLastNameSize(this IContainer element)
        {
            return element
                .PaddingBottom(14);
        }

        public static IContainer LabelSize(this IContainer element)
        {
            return element
                .PaddingBottom(24);
        }

        public static IContainer SummarySize(this IContainer element)
        {
            return element
                .PaddingBottom(27);
        }
        public static IContainer LocationSize(this IContainer element)
        {
            return element
                .ExtendVertical()
                .AlignBottom();
        }
        //AboutMeComponent


        //WorkExperienceContainer
        public static IContainer WorkExperienceComponentSize(this IContainer element)
        {
            return element
                .PaddingTop(12)
                .PaddingLeft(18)
                .PaddingRight(20);
        }
        //WorkExperienceContainer


        //ProjectsAccomplished
        public static IContainer ProjectsAccomplishedSize(this IContainer element)
        {
            return element
                 .PaddingBottom(47)
                 .PaddingLeft(43)
                 .PaddingRight(49)
                 .AlignLeft();
        }

        public static IContainer ProjectsHeaderSize(this IContainer element)
        {
            return element
                 .PaddingTop(12)
                 .PaddingLeft(43)
                 .PaddingRight(20);
        }
        //ProjectsAccomplished
    }
}
