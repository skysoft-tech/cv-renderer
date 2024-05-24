using System.Buffers.Text;
using System.Net;

namespace SkySoft.CvRenderer
{

    public interface IFileResolver
    {
        Stream ResolveFile(string path);
    }

    public class DefaultFileResolver : IFileResolver
    {
        public virtual Stream ResolveFile(string path)
        {
            if (IsUrl(path))
            {
                return GetFromUrl(path);
            }

            if (Base64.IsValid(path))
            {
                return GetFromBase64String(path);
            }

            return GetFromFile(path);
        }

        protected virtual Stream GetFromUrl(string url)
        {
            using var client = new WebClient();

            return client.OpenRead(url);
        }

        protected virtual Stream GetFromBase64String(string? base64String)
        {
            var base64ByteArray = Convert.FromBase64String(base64String);

            var stream = new MemoryStream(base64ByteArray);

            return stream;
        }

        protected virtual Stream GetFromFile(string? path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            return File.OpenRead(path);
        }

        protected virtual bool IsUrl(string? photo)
        {
            if (photo == null)
            {
                return false;
            }

            bool result = Uri.TryCreate(photo, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }
}
