using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;


namespace SkySoft.CvRenderer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ILogger<CvController> _logger;
        private readonly CreateCv _createCv;

        public CvController(ILogger<CvController> logger, CreateCv createCv)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createCv = createCv ?? throw new ArgumentNullException(nameof(createCv));
        }

        [HttpPost("object")]
        public async Task<IActionResult> Post([FromBody] CvModel cvModel)
        {
            try
            {
                var pdfStream = await _createCv.FromModelAsync(cvModel);

                return File(pdfStream, "application/pdf", cvModel.Basics?.Name ?? "Your cv" + ".pdf");
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
                using (var fileStream = new MemoryStream())
                {
                    await file.CopyToAsync(fileStream);

                    var pdfStream = await _createCv.FromFileAsync(fileStream);

                    var a = file.FileName ?? "Your cv" + ".pdf";
                    var b = File(pdfStream, "application/pdf", a);

                    return File(pdfStream, "application/pdf", Path.GetFileNameWithoutExtension(file.FileName) ?? "Your cv" + ".pdf");
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