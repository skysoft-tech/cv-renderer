using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;

namespace WebApplicationPdf.ProjectPage
{
    public class ProjectsAccomplished : IComponent
    {
        public Project? project { get; }

        public ProjectsAccomplished(Project? Value)
        {
            project = Value;
        }

        public void Compose(IContainer container)
        {
            TextStyle projectsTitlePink = TextStyle.Default.ProjectsTitlePink();
            TextStyle projectsTitleGray = TextStyle.Default.ProjectsTitleGray();
            TextStyle projectsContentStyle = TextStyle.Default.ProjectsContentStyle();
            TextStyle projectsDataStyle = TextStyle.Default.ProjectsDataStyle();

            container
            .Element(ProjectSize.AspectRatioProject)
            .Row(row =>
            {
                row.AutoItem()
                .Element(ProjectSize.AspectRatioProjectDate)
                .Text(text =>
                {
                    text.Span($"{project.StartDate}\n{project.EndDate}")
                    .Style(projectsDataStyle);
                });

                row.AutoItem()
                .LineVertical(1)
                .LineColor("#dbdbdb");
                
                row.RelativeItem()
                .Element(ProjectSize.AspectRatioProjectRow)
                .Column(column =>
                {
                    column.Item()
                    .Element(ProjectSize.AspectRatioProjectСontent)
                    .Text(text =>
                    {
                        text.Span(project.Name)
                        .Style(projectsTitlePink);
                    });

                    column.Item()
                    .Element(ProjectSize.AspectRatioProjectСontent)
                    .Text(text =>
                    {
                        text.Span(project.Description)
                        .Style(projectsContentStyle);
                    });

                    column.Item()
                    .Text(text =>
                    {

                        text.Span("Duties")
                        .Style(projectsTitleGray);
                    });

                    column.Item()
                    .Element(ProjectSize.AspectRatioProjectСontent)
                    .Text(text =>
                    {
                        project.Highlights.ForEach(highlights =>
                        {
                            text.Span(highlights)
                            .Style(projectsContentStyle);
                        });
                    });

                    column.Item()
                    .Text(text =>
                    {
                        text.Span("Technologies")
                        .Style(projectsTitleGray);
                    });

                    column.Item()
                    .Element(ProjectSize.AspectRatioProjectСontent)
                    .Row(row =>
                    {
                        project.Technologies.ForEach(technologies =>
                        {
                            row.AutoItem()
                            .Component(new TechnologiesElement(technologies));
                        });
                    });
                });
            });
        }
    }
}
