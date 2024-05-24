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
                var (firstName, lastName) = GetNameParts(_basics.Name);

                text.Span($"{firstName}").Style(style.Weight(FontWeight.Bold));
                text.Span($"{lastName}").Style(style.Weight(FontWeight.Light));
            });
        }

        public (string firstName, string lastName) GetNameParts(string? name)
        {
            var firstName = string.Empty;
            var lastName = string.Empty;

            if (name == null)
            {
                return (firstName, lastName);
            }

            if (name.Contains(" "))
            {
                return (firstName: name, lastName: "");
            }
            
            var parts = name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                return 
            }            

            return ()
        }
    }
}
