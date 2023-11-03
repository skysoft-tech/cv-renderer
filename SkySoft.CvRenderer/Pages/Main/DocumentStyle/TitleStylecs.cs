using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    public class TitleStylecs
    {
        public static TextStyle TitleComponentStyle => TextStyle
            .Default
            .Weight(FontWeight.Normal);
    }
}
