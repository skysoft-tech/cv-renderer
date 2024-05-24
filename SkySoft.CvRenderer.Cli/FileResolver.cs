namespace SkySoft.CvRenderer.Cli
{
    public class FileResolver : DefaultFileResolver, IFileResolver
    {
        private readonly string _input;

        public FileResolver(string input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
        }

        protected override Stream GetFromFile(string? path)
        {
            if (TryResolveAbsPhotoPath(path, _input, out var absPhotoPath))
            {
                return base.GetFromFile(absPhotoPath);
            }

            throw new FileNotFoundException();
        }

        private bool TryResolveAbsPhotoPath(string? photoPath, string input, out string? absPhotoPath)
        {
            absPhotoPath = null;
            if (photoPath == null)
            {
                return false;
            }

            if (File.Exists(photoPath))
            {
                absPhotoPath = Path.GetFullPath(photoPath);

                return true;
            }

            var jsonLocation = Path.GetDirectoryName(input);
            if (jsonLocation == null)
            {
                return false;
            }

            var probablePhotoLocation = Path.Combine(jsonLocation, photoPath);
            if (File.Exists(probablePhotoLocation))
            {
                absPhotoPath = Path.GetFullPath(probablePhotoLocation);

                return true;
            }

            return false;
        }
    }
}
