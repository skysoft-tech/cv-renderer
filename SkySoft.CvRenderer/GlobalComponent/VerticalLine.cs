using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class VerticalLine : IComponent
    {
        public void Compose(IContainer container)
        {
            container
                .Element(ComponentsSize.LinesSize)
                .LineVertical(1)
                .LineColor("#dbdbdb");
        }
    }
}
