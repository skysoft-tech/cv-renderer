using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;

namespace WebApplicationPdf.GlobalComponent
{
    public static class HeadTitle
    {
        private static TextStyle Styles(this TextStyle style, string color)
        {
            return style
            .FontSize(20)
            .ExtraBlack()
            .FontFamily(GlobalFontFamily.FontFamilyStyle())
            .FontColor(color);
        }

        public static void BrandTitle(IContainer container)
        {
            var LeftSide = TextStyle.Default.Styles("#1c1e2a");
            var RightSide = TextStyle.Default.Styles("#d40055");

            container
                .Row(row =>
                {
                    row.RelativeItem()
                    .AlignRight()
                    .PaddingTop(6)
                    .PaddingRight(5)
                    .MaxHeight(15)
                    .MaxWidth(15)
                    .Image(AssetsHelper.ReadResourceBytes("Assets/Images/Logo.png"))
                    .FitArea();

                    row.AutoItem()
                    .AlignRight()
                    .Text(text =>
                    {
                        text.Span("SMART")
                        .Style(LeftSide);

                        text.Span("EXE")
                        .Style(RightSide);
                    });
                });
        }
    }
}
