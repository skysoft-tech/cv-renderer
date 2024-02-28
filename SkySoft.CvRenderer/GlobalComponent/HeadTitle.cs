using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.GlobalComponent
{
    public class HeadTitle : IComponent
    {
        private readonly bool _hideLogo;
        public HeadTitle(bool hideLogo)
        {
            _hideLogo = hideLogo;
        }
        public void Compose(IContainer container)
        {
            container
            .Column(column =>
            {
                if (_hideLogo)
                {
                    column.Item()
                        .AlignRight()
                        .PaddingBottom(10)
                        .Width(1.5f, Unit.Inch)
                        .Image(AssetsHelper.ReadResourceBytes("Assets/Images/Logo.png"));
                }
            });
        }
    }
}
