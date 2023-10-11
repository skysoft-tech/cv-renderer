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

        public SkillsLogic(ILogger logger, CvModel value)
        {
            _logger = logger;
            _cvModel = value;
        }

        public void Compose(IContainer container)
        {
            //var couples = GetParityIndex(0);
            //var notCouples = GetParityIndex(1);

            container.Row(row =>
            {
                row.RelativeItem()
                .PaddingRight(42)
                .Component(new SkillsComponent(_logger, GetParityIndex(0)[0]));


                row.RelativeItem()
                .PaddingRight(42)
                .Component(new SkillsComponent(_logger, GetParityIndex(1)[0]));
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
