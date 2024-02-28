using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using WebApplicationPdf.GlobalComponent;
using QuestPDF.Elements;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.GlobalComponent
{
    public class HeadTitleDynamic : IDynamicComponent<int>
    {
        public int State { get; set; }

        private readonly bool _hideLogo;
        public HeadTitleDynamic(bool hideLogo)
        {
            _hideLogo = hideLogo;
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            var content = context.CreateElement(container =>
            {
                var pageNumber = context.PageNumber;

                container.Row(row =>
                {
                    row.ConstantItem(240).Background(DocumentColors.PrimaryColor);

                    var c = row.RelativeItem();

                    if (pageNumber == 1)
                    {
                        c = c.SkipOnce();
                    }

                    c.AlignRight()
                    .PaddingTop(12)
                    .PaddingRight(20)
                    .Component(new HeadTitle(_hideLogo));
                });
            });

            return new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false
            };
        }
    }
}
