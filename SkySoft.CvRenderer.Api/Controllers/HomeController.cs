using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Api;

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
            var jsonCv = await _createPdfCvFromModel.CreateCv(cvModel);

            return File(jsonCv, "application/pdf", cvModel.Basics.Name ?? "Your cv" + ".pdf");
        }

        [HttpPost("cv/upload-file")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var streamFilePdf = await _createPdfCvFromFile.CreateCv(stream.ToArray());

            return File(streamFilePdf, "application/pdf", file.FileName ?? "Your cv" + ".pdf");
        }
    }
}