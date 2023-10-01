using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.WorkExperience;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground
{
    public class AcademicBackgroundComponent : IComponent
    {
        public Education? education { get; }

        public AcademicBackgroundComponent(Education? value)
        {
            education = value;
        }

        public void Compose(IContainer container)
        {
            TextStyle сontantTitlePink = TextStyle.Default.ContantTitlePink();
            TextStyle сontantTitleBlack = TextStyle.Default.ContantTitleBlack();
            TextStyle rightsContentStyle = TextStyle.Default.RightsContentStyle();

            container
            .Row(row =>
            {
                row.AutoItem()
                .Element(RightSideSize.LeftSidePaddingData)
                .Text(text =>
                {
                    text.Span($"{education.StartDate} - {education.EndDate}")
                    .Style(rightsContentStyle);
                });

                row.AutoItem()
                .LineVertical(1)
                .LineColor("#dbdbdb");

                row.RelativeItem()
                .Element(RightSideSize.RightSidePadding)
                .Text(text =>
                {
                    text.Span(education.Institution)
                    .Style(сontantTitlePink);

                    text.EmptyLine();

                    text.Span($"{education.City}, {education.Country}")
                    .Style(rightsContentStyle);

                    text.EmptyLine();

                    text.Span(education.StudyType)
                    .Style(сontantTitleBlack);

                    text.EmptyLine();

                    text.Span(education.Score)
                    .Style(rightsContentStyle);
                });
            });
        }
    }
}
