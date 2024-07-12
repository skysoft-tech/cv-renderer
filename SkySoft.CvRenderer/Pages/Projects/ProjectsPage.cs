using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Projects.Components;

namespace SkySoft.CvRenderer.Pages.Projects
{
    public class ProjectsPage(CvModel value) : IComponent
    {
        private readonly CvModel _cvModel = value;

        public void Compose(IContainer container)
        {
            if (_cvModel.Projects == null)
            {
                return;
            }

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
                        for (int i = 0; i < _cvModel.Projects.Count; i++)
                        {
                            column.Item().Component(
                                new ProjectsAccomplished(_cvModel.Projects[i], i, _cvModel.Projects.Count)
                            );
                        }
                    });
                });
        }
    }
}
