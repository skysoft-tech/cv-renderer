namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    public class GetFileName
    {
        private readonly string _name;
        private readonly string _defaultName;

        public GetFileName(string name, string defaultName)
        {
            _name = name;
            _defaultName = defaultName ?? throw new ArgumentNullException(nameof(defaultName));
        }

        public string GetName()
        {
            string name = !string.IsNullOrEmpty(_name) ? Path.GetFileNameWithoutExtension(_name) : _defaultName;

            return name + ".pdf";
        }
    }
}
