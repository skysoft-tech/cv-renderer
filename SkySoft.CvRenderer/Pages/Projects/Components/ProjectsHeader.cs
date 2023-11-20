using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class ProjectsHeader : IComponent
    {
        public void Compose(IContainer container)
        {
            container
            .Element(ComponentsSize.ProjectsHeaderSize)
            .Column(column =>
            {
                column.Item()
               .AlignRight()
               .Component(new HeadTitle());

                column.Item()
                .AlignLeft()
                .PaddingBottom(24)
                .Component(new CaptionComponent("PROJECTS ACCOMPLISHED", "#000000"));
            });
        }
    }
}
