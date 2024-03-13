using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Api;
using SkySoft.CvRenderer.Utils.JsonHelpers;

namespace SkySoft.CvRenderer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreateCvFromModel _createPdfCvFromModel;
        private readonly CreateCvFromFile _createPdfCvFromFile;

        public HomeController(ILogger<HomeController> logger, CreateCvFromModel createPdfCvFromModel, CreateCvFromFile createPdfCvFromFile)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createPdfCvFromModel = createPdfCvFromModel ?? throw new ArgumentNullException(nameof(createPdfCvFromModel));
            _createPdfCvFromFile = createPdfCvFromFile ?? throw new ArgumentNullException(nameof(createPdfCvFromFile));
        }

        [HttpPost("cv/upload-model")]
        public async Task<IActionResult> Post([FromBody] CvModel cvModel)
        {
            try
            {
                var pdfStream = await _createPdfCvFromModel.CreateCvAsync(cvModel);

                var fileName = new GetFileName(cvModel.Basics.Name, "Your cv").GetName();
                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing CV model upload.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("cv/upload-file")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                using (var fileStream = new MemoryStream())
                {
                    await file.CopyToAsync(fileStream);
                    var pdfStream = await _createPdfCvFromFile.CreateCvAsync(fileStream.ToArray());
                    var fileName = new GetFileName(file.FileName, "Your cv").GetName();
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