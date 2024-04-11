using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Models;
using System.ComponentModel.DataAnnotations;

namespace SkySoft.CvRenderer.Api.ModelsApi
{
    public class ObjectModel
    {
        [Required]
        [ModelBinder(BinderType = typeof(FormDataJsonBinder))]
        public CvModel? CvModel { get; set; }
        public IFormFile? Photo { get; set; }
        public CvOptions? CvOptions { get; set; }
    }
}
