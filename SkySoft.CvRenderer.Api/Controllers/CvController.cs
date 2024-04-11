using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController(ILogger<CvController> logger, CvCreator cvCreator, IOptions<CvOptions> options) : ControllerBase
    {
        private readonly ILogger<CvController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly CvCreator _cvCreator = cvCreator ?? throw new ArgumentNullException(nameof(cvCreator));
        private readonly CvOptions _cvOptions = options.Value;

        [HttpPost("object")]
        public async Task<IActionResult> Post(ObjectModel objectCv)
        {
            try
            {
                objectCv.CvOptions ??= _cvOptions;

                using var photoFile = GetPhotoFile(objectCv.Photo);

                var pdfStream = _cvCreator.FromModel(objectCv.CvModel, photoFile, objectCv.CvOptions);

                var fileName = objectCv.CvModel.Basics?.Name ?? "Your cv";

                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing CV model upload.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("file")]
        public async Task<IActionResult> Post([FromForm] FileModel file)
        {
            try
            {
                using var photo = GetPhotoFile(file.Photo);

                using var fileStream = file.File.OpenReadStream();

                var pdfStream = await _cvCreator.FromFileAsync(fileStream, photo, file.CvOptions);

                var fileName = Path.GetFileNameWithoutExtension(file.File.FileName) ?? "Your cv";

                return File(pdfStream, "application/pdf", fileName);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing uploaded CV file.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        private static PhotoFile GetPhotoFile(IFormFile? photo)
        {
            var photoFile = new PhotoFile();

            if (photo != null)
            {
                photoFile.Name = photo.FileName;
                photoFile.Stream = photo.OpenReadStream();
            }

            return photoFile;
        }
    }
}