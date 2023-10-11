using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using System.Data.Common;

namespace WebApplicationPdf.GlobalComponent
{
    public static class Line
    {
        public static void lineHorizontal(IContainer container)
        {
            container
                .PaddingTop(20)
                .PaddingBottom(20)
                .LineHorizontal(1)
                .LineColor("#d8d8d8");
        }
    }
}