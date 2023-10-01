using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsLogic : IComponent
    {
        public CvModel cvModel { get; }
        public int number { get; }

        public SkillsLogic(CvModel valueList, int EvenUneven)
        {
            CvModel cvModel = valueList;
            number = EvenUneven;
        }

        public void Compose(IContainer container)
        {
            //for (int a = 0; a < skill.Count; a++)
            //{
            //if (a % 2 == number)
            //{
            for (int a = 0; a < cvModel.Skills.Count; a++)
            {
                container.Row(row =>
                {
                    row.RelativeItem()
                   .PaddingRight(42)
                   .Component(new SkillsComponent(cvModel.Skills[a]));

                    row.RelativeItem()
                    .PaddingRight(42)
                    .Component(new SkillsComponent(cvModel.Skills[a]));
                });
            }
        }
    }
}
