﻿using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Assets;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;

namespace SkySoft.CvRenderer.Pages.Main.Skills
{
    public class SkillsComponent : IComponent
    {
        private readonly ILogger _logger;
        private readonly Skill _skill;

        public SkillsComponent(ILogger logger, Skill value)
        {
            _logger = logger;
            _skill = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle rightsSkillsStyle = TextStyle.Default.RightsSkillsStyle();

            container
                 .Column(column =>
                 {
                     column.Item().Row(row =>
                     {
                         row.AutoItem().Text(text =>
                         {
                             text.Span($"{_skill.Name}")
                             .Style(rightsSkillsStyle);
                         });
                     });

                     column.Item().Row(AddSkillLine);
                 });
        }

        private void AddSkillLine(RowDescriptor row)
        {
            row.RelativeItem()
                .PaddingBottom(15)
                .MinHeight(4)
                .Column(part =>
                {
                    part.Item().Row(AddSkillSegments);
                });
        }

        private void AddSkillSegments(RowDescriptor row)
        {
            var maxSkillLevel = GetMaxLevel();
            for (var i = 0; i <= maxSkillLevel; i++)
            {
                var level = GetSkillLevel();

                if (level >= i)
                {
                    row.RelativeItem(1).Height(4).Background(DocumentColors.AccentColor);
                }
                else
                {
                    row.RelativeItem(1).Height(4).Background(DocumentColors.ElementsBackgroundColor);
                }
            }
        }

        private int GetSkillLevel()
        {
            if (_skill.Level.HasValue)
            {
                return (int)_skill.Level.Value;
            }
            else
            {
                _logger.LogWarning("Level for the skill [{skillName}] isn't set", _skill.Name);

                return (int)SkillLevel.Profesional;
            }
        }

        private int GetMaxLevel()
        {
            return Enum.GetValues<SkillLevel>().Cast<int>().Max();
        }
    }


 
}


  