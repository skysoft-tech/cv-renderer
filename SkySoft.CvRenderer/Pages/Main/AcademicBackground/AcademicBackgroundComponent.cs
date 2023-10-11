using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Pages.Main.MainComponents;

namespace SkySoft.CvRenderer.Pages.Main.AcademicBackground;
public class AcademicBackgroundComponent : IComponent
{
    private readonly Education _education;

    public AcademicBackgroundComponent(Education? value)
    {
        _education = value;
    }

    public void Compose(IContainer container)
    {
        var workStartDateStyle = TextStyle.Default.WorkStartDateStyle();
        var workNameStyle = TextStyle.Default.WorkNameStyle();
        var workSummaryStyle = TextStyle.Default.WorkSummaryStyle();
        var workPositionStyle = TextStyle.Default.WorkPositionStyle();

        container
        .Row(row =>
        {
            row.AutoItem()
            .MinWidth(50)
            .MaxWidth(50)
            .Text(text =>
            {
                text.Span($"{_education.StartDate} - {_education.EndDate}")
                .Style(workStartDateStyle);
            });

            row.AutoItem()
            .Element(ComponentsSize.LinesSize)
            .LineVertical(1)
            .LineColor("#dbdbdb");

            row.RelativeItem()
            .Column(column =>
            {
                column.Item()
                .PaddingBottom(4)
                .Text(text =>
                {
                    text.Span($"{_education.Institution}\n")
                    .Style(workNameStyle);

                    text.Span($"{_education.City}, {_education.Country}")
                    .Style(workSummaryStyle);
                });

                column.Item()
                .PaddingBottom(14)
                .Text(text =>
                {
                    text.Span($"{_education.StudyType}\n")
                    .Style(workPositionStyle);

                    text.Span($"{_education.Score}")
                    .Style(workSummaryStyle);
                });
            });
        });
    }
}

