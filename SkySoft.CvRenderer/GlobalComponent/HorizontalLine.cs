using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.GlobalComponent
{
    public  class HorizontalLine : IComponent
    {
        public void Compose(IContainer container)
        {
            container
                .PaddingTop(20)
                .PaddingBottom(20)
                .LineHorizontal(1)
                .LineColor(DocumentColors.ElementsBackgroundColor);
        }
    }
}