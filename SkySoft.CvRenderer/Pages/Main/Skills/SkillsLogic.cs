using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsLogic : IComponent
    {
        private readonly CvModel _cvModel;
        private readonly ILogger _logger;
        public SkillsLogic(ILogger logger, CvModel value)
        {
            _cvModel = value;
            _logger = logger;
        }

        public void Compose(IContainer container)
        {
            var couples = GetParityIndex(0);
            var notCouples = GetParityIndex(1);
            container.Row(row =>
            {
                for (int b = 0; b < couples.Count && b < notCouples.Count; b++)
                {
                    row.AutoItem()
                    .PaddingRight(42)
                    .Component(new SkillsComponent(_logger, couples[b]));

                    row.RelativeItem()
                    .PaddingRight(42)
                    .Component(new SkillsComponent(_logger, notCouples[b]));
                }
            });
        }

        private List<Skill> GetParityIndex(int valueNumber)
        {
            List<Skill> list = new List<Skill>();

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
