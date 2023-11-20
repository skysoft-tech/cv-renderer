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
                .PaddingTop(18)
                .PaddingBottom(DocumentSpaces.SpaceBetweenSections)
                .LineHorizontal(1)
                .LineColor(DocumentColors.ElementsBackgroundColor);
        }
    }
}