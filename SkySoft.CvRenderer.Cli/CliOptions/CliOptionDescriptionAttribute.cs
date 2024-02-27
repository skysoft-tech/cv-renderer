namespace SkySoft.CvRenderer.Cli.CliOptions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CliOptionDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public CliOptionDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
