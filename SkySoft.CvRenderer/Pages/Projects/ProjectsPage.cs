using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;
using SkySoft.CvRenderer.Pages.Projects.Components;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Projects
{
    public class ProjectsPage : IComponent
    {
        private readonly CvModel _cvModel;

        public ProjectsPage(CvModel? value)
        {
            _cvModel = value;
        }

        public void Compose(IContainer container)
        {
            var incrementProjectsAccomplished = 0;

            container
            .Row(row =>
            {
                row.RelativeItem(1)
                .Element(ComponentsSize.ProjectsAccomplishedSize)
                .Column(column =>
                {
                    _cvModel.Projects.ForEach(projects =>
                    {
                        //column.Item().ShowEntire().Dynamic(new ProgectDynamic(projects));

                        column.Item()
                        .Component(new ProjectsAccomplished(projects));

                        incrementProjectsAccomplished++;
                    });
                });
            });
        }
    }
}
