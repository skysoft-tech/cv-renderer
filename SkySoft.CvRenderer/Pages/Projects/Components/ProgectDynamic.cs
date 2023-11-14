using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Elements;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.GlobalComponent;
using SkySoft.CvRenderer.Pages.Main.MainComponents;
using System.Data.Common;
using QuestPDF.Helpers;
using System.Reflection;
using SkySoft.CvRenderer.Pages.Projects.Components;

namespace SkySoft.CvRenderer.Pages.Main.WorkExperience
{
    public struct ProgectDynamicState
    {
        public Project _project { get; set; }
    }

    public class ProgectDynamic : IDynamicComponent<ProgectDynamicState>
    {
        public ProgectDynamicState State { get; set; }

        public ProgectDynamic(Project project)
        {
            State = new ProgectDynamicState
            {
                _project = project
            };
        }

        public DynamicComponentComposeResult Compose(DynamicContext context)
        {
            var content = context.CreateElement(container =>
            {
                var width = context.AvailableSize.Width;

                var pageNumber = context.PageNumber;
                var totalPages = context.TotalPages;

                container.Column(column =>
                {
                    column.Item()
                    .Component(new ProjectsAccomplished(State._project));
                });

            });

            var dynamicResult = new DynamicComponentComposeResult
            {
                Content = content,
                HasMoreContent = false
            };

            return dynamicResult;
        }
    }
}
