using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Projects.Components
{
    public class KeywordsComponent : IComponent
    {
        public Project _project { get; set; }

        public KeywordsComponent(Project project)
        {
            _project = project;
        }

        public void Compose(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().Inlined(inline =>
                {
                    inline.HorizontalSpacing(8);
                    inline.VerticalSpacing(0);
                    inline.AlignLeft();

                    _project.Keywords?.ForEach(technology =>
                    {
                        inline.Item().Component(new TechnologyComponent(technology));
                    });
                });
            });
        }
    }
}
