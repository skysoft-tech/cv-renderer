using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Api.Models
{
    public class FileUploadModel
    {
        public string? FilePath { get; set; }
        public CvOptions? CvOptions { get; set; }
    }
}
