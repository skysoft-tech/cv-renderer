using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsLogic : IComponent
    {
        private readonly ILogger _logger;
        private readonly CvModel _cvModel;
        private readonly int _skillId;

        public SkillsLogic(ILogger logger, CvModel cvModel, int parityIndex)
        {
            _logger = logger;
            _cvModel = cvModel;
            _skillId = parityIndex;

        }

        public void Compose(IContainer container)
        {
            container.
            Column(column =>
            {
                GetParityIndex(_skillId).ForEach(list =>
                {
                    column.Item()
                    .ShowEntire()
                    .Component(new SkillsComponent(_logger, list));
                });
            });
        }

        private List<Skill> GetParityIndex(int valueNumber)
        {
            var list = new List<Skill>();

            for (int a = 0; a < _cvModel.Skills.Count; a++)
            {
                if (a % 2 == valueNumber)
                {
                    list.Add(_cvModel.Skills[a]);
                }
            }

            return list;
        }
    }
}
