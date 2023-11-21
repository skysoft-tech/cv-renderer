using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.GlobalComponent
{
    internal class CaptionComponent : IComponent
    {
        private readonly string _text;
        private readonly string _color;

        public CaptionComponent(string text, string color)
        {
            _text = text;
            _color = color;
        }

        public void Compose(IContainer container)
        {
            container
                .PaddingBottom(DocumentSpaces.SpaceAfterCaption)
                .AlignLeft()
                .Text(_text)
                .FontColor(_color)
                .FontSize(14);
        }
    }
}
