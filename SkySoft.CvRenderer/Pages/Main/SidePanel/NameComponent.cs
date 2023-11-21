using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.SidePanel
{
    internal class NameComponent : IComponent
    {
        private readonly Basics _basics;

        public NameComponent(Basics basics)
        {
            _basics = basics;
        }

        public void Compose(IContainer container)
        {
            var style = TextStyle.Default
                .FontColor(DocumentColors.ContrastFontColor)
                .LineHeight(0.7f)
                .FontSize(32);

            container.Text(text =>
            {
                text.Span($"{_basics.Name}").Style(style.Weight(FontWeight.Bold));
                text.Span($"{_basics.LastName}").Style(style.Weight(FontWeight.Light));
            });
        }
    }
}
