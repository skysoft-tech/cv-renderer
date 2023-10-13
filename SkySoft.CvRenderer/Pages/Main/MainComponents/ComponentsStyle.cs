using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Assets;

namespace SkySoft.CvRenderer.Pages.Main.MainComponents
{
    public static class ComponentsStyle
    {
        public static TextStyle TitleComponentStyle(this TextStyle style)
        {
            return style
                .Weight(FontWeight.Normal);
        }

        //AboutMeComponent
        public static TextStyle NameLastNameStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.ContrastFontColor)
                .LineHeight(0.7f)
                .FontSize(32);
        }
        
        public static TextStyle LabelStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.ContrastFontColor)
                .LineHeight(0.7f)
                .FontSize(14)
                .Weight(FontWeight.Bold);
        }

        public static TextStyle SummaryStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.ContrastFontColor)
                .LineHeight(0.7f)
                .FontSize(11);
        }
        public static TextStyle LanguageStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.ContrastFontColor)
                .LineHeight(0.7f)
                .FontSize(12);
        }

        public static TextStyle LocationStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.FooterFontColor)
                .LineHeight(0.7f)
                .FontSize(11);
        }
        //AboutMeComponent


        //WorkExperience/AcademicBackground

        public static TextStyle WorkNameStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.AccentColor)
                .LineHeight(0.7f)
                .FontSize(12)
                .Weight(FontWeight.SemiBold);
        }
        
        public static TextStyle WorkStartDateStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.HintColor)
                .LineHeight(0.7f)
                .FontSize(10);
        }
        
        public static TextStyle WorkPositionStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.FontColor)
                .LineHeight(0.7f)
                .FontSize(12)
                .Weight(FontWeight.SemiBold);
        }
        public static TextStyle StudyTypeStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.FontColor)
                .LineHeight(0.7f)
                .FontSize(12)
                .Weight(FontWeight.Normal);
        }

        public static TextStyle WorkSummaryStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.HintColor)
                .LineHeight(0.7f)
                .FontSize(10);
        }

        public static TextStyle SkillsStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.FontColor)
                .LineHeight(0.7f)
                .FontSize(10);
        }
        //WorkExperience/AcademicBackground

        //ProjectsAccomplished
        public static TextStyle ProjectStartDateStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.HintColor)
                .LineHeight(0.8f)
                .FontSize(10)
                .Weight(FontWeight.Normal);
        }

        public static TextStyle ProjectNameStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.AccentColor)
                .LineHeight(0.8f)
                .FontSize(14)
                .Weight(FontWeight.SemiBold);
        }

        public static TextStyle ProjectDescriptionStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.FontColor)
                .LineHeight(0.8f)
                .FontSize(12)
                .Weight(FontWeight.Normal); ;
        }

        public static TextStyle DutiesStyle(this TextStyle style)
        {
            return style
                .FontColor(DocumentColors.HintColor)
                .LineHeight(0.8f)
                .FontSize(12)
                .Weight(FontWeight.SemiBold); ;
        }
        //ProjectsAccomplished
    }
}

