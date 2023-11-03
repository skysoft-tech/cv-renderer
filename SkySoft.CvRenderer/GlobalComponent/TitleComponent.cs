using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace WebApplicationPdf.GlobalComponent
{
    internal class TitleComponent : IComponent
    {
        private readonly string _title;
        private readonly string _textСolor;
        private readonly int _paddingBottom;

        public TitleComponent(string title, string textСolor, int paddingBottom)
        {
            _title = title;
            _textСolor = textСolor;
            _paddingBottom = paddingBottom;
        }

        public void Compose(IContainer container)
        {
            container
            .PaddingBottom(_paddingBottom)
            .Text(_title).Style(TitleStylecs.TitleComponentStyle)
            .FontSize(14)
            .FontColor(_textСolor);
        }
    }
}
