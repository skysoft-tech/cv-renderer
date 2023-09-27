using System;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace WebApplicationPdf.TitlePage
{
    public class WorkExperience
    {
        public Work? work { get; }

        public WorkExperience(Work? value)
        {
            work = value;
        }

        public void WorkExperienceContainer(IContainer container)
        {
            TextStyle сontantTitlePink = TextStyle.Default.ContantTitlePink();
            TextStyle сontantTitleBlack = TextStyle.Default.ContantTitleBlack();
            TextStyle rightsContentStyle = TextStyle.Default.RightsContentStyle();

            container
            .Row(row =>
            {
                row.AutoItem()
                .Element(RightSideSize.LeftSidePadding)
                .Text(text =>
                {
                    text.Span(work.Name)
                    .Style(сontantTitlePink);

                    text.EmptyLine();

                    text.Span($"{work.StartDate} - {work.EndDate}")
                    .Style(rightsContentStyle);
                });

                row.AutoItem()
                .LineVertical(1)
                .LineColor("#dbdbdb");

                row.RelativeItem()
                .Element(RightSideSize.RightSidePadding)
                .Text(text =>
                {
                    text.Span(work.Position)
                    .Style(сontantTitleBlack);

                    text.EmptyLine();

                    text.Span(work.Summary)
                    .Style(rightsContentStyle);
                });
            });
        }
    }
}
