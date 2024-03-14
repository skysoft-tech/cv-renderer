using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;


namespace SkySoft.CvRenderer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ILogger<CvController> _logger;
        private readonly CvCreator _ñvCreator;

        public CvController(ILogger<CvController> logger, CvCreator ñvCreator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ñvCreator = ñvCreator ?? throw new ArgumentNullException(nameof(ñvCreator));
        }

        [HttpPost("object")]
        public async Task<IActionResult> Post([FromBody] CvModel cvModel)
        {
            try
            {
                var pdfStream = await _ñvCreator.FromModelAsync(cvModel);
                var fileName = cvModel.Basics?.Name ?? "Your cv" + ".pdf";

                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing CV model upload.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("file")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                using (var fileStream = file.OpenReadStream())
                {

                    var pdfStream = await _ñvCreator.FromFileAsync(fileStream);
                    var fileName = Path.GetFileNameWithoutExtension(file.FileName) ?? "Your cv" + ".pdf";

                    return File(pdfStream, "application/pdf", fileName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing uploaded CV file.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}