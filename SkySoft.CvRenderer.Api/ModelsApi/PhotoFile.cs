namespace SkySoft.CvRenderer.Api.ModelsApi
{
    public class PhotoFile : IDisposable
    {
        public Stream? Stream { get; set; }
        public string? Name { get; set; }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }
}
