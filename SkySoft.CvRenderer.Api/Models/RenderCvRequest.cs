using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using System.ComponentModel.DataAnnotations;

namespace SkySoft.CvRenderer.Api.ModelsApi
{
    public class RenderCvRequest
    {
        public CvOptions? CvOptions { get; set; }

        [Required]
        public required CvModel CvData { get; set; }
    }
}
