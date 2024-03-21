using SkySoft.CvRenderer.Api.ModelsApi;

namespace SkySoft.CvRenderer.Api
{
    public class FileResolver : DefaultFileResolver, IFileResolver
    {
        private readonly PhotoFile? _photo = null;
        public FileResolver() { }
        public FileResolver(PhotoFile photo)
        {
            _photo = photo;
        }

        protected override Stream GetFromFile(string? path)
        {
            if (_photo == null || _photo.Name != path || _photo.Stream == null)
            {
                throw new FileNotFoundException();
            }

            return _photo.Stream;
        }
    }
}
