using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Projects.Components;

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
                .PaddingBottom(47)
                .PaddingLeft(43)
                .PaddingRight(49)
                .AlignLeft()
                .Column(column =>
                {
                    _cvModel.Projects.ForEach(projects =>
                    {
                        column.Item()
                        .Component(new ProjectsAccomplished(projects, incrementProjectsAccomplished, _cvModel.Projects.Count));
                        incrementProjectsAccomplished++;
                    });
                });
            });
        }
    }
}
