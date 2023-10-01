using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsComponent : IComponent
    {
        public Skill? skill { get; }

        public SkillsComponent(Skill? value)
        {
            skill = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle rightsSkillsStyle = TextStyle.Default.RightsSkillsStyle();

            float skillLevel = 0;

            switch (skill.Level)
            {
                case "Heard":
                    skillLevel = 25;
                    break;
                case "Low":
                    skillLevel = 50;
                    break;
                case "Medium":
                    skillLevel = 75;
                    break;
                case "Good":
                    skillLevel = 100;
                    break;
                case "Profesional":
                    skillLevel = 125;
                    break;
            }

            container
             .Column(column =>
             {
                 column.Item()
                 .PaddingBottom(5)
                 .Text(text =>
                 {
                     text.Span($"{skill.Name}")
                     .Style(rightsSkillsStyle);
                 });

                 column.Item()
                .PaddingBottom(15)
                .Background("#d8d8d8")
                .Column(column =>
                {
                    column.Item()
                    .MaxWidth(skillLevel)
                    .MinHeight(4)
                    .Background("#d20155");
                });
             });
        }
    }
}
