using Microsoft.Extensions.Logging;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Assets;
using WebApplicationPdf.GlobalComponent;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground
{
    public class AcademicBackgroundContainer(List<Education>? educations, CvOptions options) : IComponent
    {
        private readonly List<Education>? _educations = educations;
        private readonly CvOptions _options = options;

        public void Compose(IContainer container)
        {
            if (_educations == null || _educations.Count == 0)
            {
                return;
            }

            container.Column(column =>
            {
                column.Item().Component(new CaptionComponent("ACADEMIC BACKGROUND", DocumentColors.FontColor));

                for (var i = 0; i < _educations.Count; i++)
                {
                    column.Item().Component(new AcademicBackgroundComponent(_educations[i], i, _educations.Count, _options));
                }

                column.Item().Component(new HorizontalLine());
            });
        }
    }
}
