using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.GlobalComponent
{
    public class HeadTitle : IComponent
    {
        public void Compose(IContainer container)
        {
            container
            .Column(column =>
            {
                column.Item()
                .AlignRight()
                .PaddingBottom(10)
                .Width(1.5f, Unit.Inch)
                .Image(AssetsHelper.ReadResourceBytes("Assets/Images/Logo.png"));
            });
        }
    }
}
