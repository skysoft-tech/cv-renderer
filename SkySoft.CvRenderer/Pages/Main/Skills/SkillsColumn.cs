using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsColumn(ILogger logger, CvModel cvModel, int parityIndex) : IComponent
    {
        private readonly ILogger _logger = logger;
        private readonly CvModel _cvModel = cvModel;
        private readonly int _parityIndex = parityIndex;

        public void Compose(IContainer container)
        {
            container.
            Column(column =>
            {
                GetParityIndex(_parityIndex).ForEach(list =>
                {
                    column.Item()
                    .ShowEntire()
                    .Component(new SkillsComponent(_logger, list));
                });
            });
        }

        private List<Skill> GetParityIndex(int parityIndex)
        {
            var list = new List<Skill>();

            for (int i = 0; i < _cvModel.Skills!.Count; i++)
            {
                if (i % 2 == parityIndex)
                {
                    list.Add(_cvModel.Skills[i]);
                }
            }

            return list;
        }
    }
}
