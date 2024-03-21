using SkySoft.CvRenderer.Models;
using System.ComponentModel.DataAnnotations;

namespace SkySoft.CvRenderer.Api.ModelsApi
{
    public class FileModel
    {
        [Required]
        public IFormFile? File { get; set; }
        public IFormFile? Photo { get; set; }
        public CvOptions? CvOptions { get; set; }
    }
}
