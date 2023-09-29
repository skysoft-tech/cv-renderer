using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebApplicationPdf.GlobalComponent
{
    public class Line
    {
        public void LineContainer(IContainer container)
        {
            container
                .PaddingRight(20)
                .PaddingVertical(20)
                .LineHorizontal(1)
                .LineColor("#d8d8d8");
        }
    }
}
