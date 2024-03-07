using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Api.Models;

namespace SkySoft.CvRenderer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("convertToPdf")]
        public async Task<IActionResult> ConvertJsonToPdf([FromBody] FileUploadModel fileUpload)
        {
            if (!System.IO.File.Exists(fileUpload.FilePath))
            {
                _logger.LogError("JSON file does not exist.");
                return NotFound();
            }

            var executor = new Executor(_logger);

            var pdfData = await executor.Run(fileUpload.FilePath, fileUpload.cvOptions.WorkColumnWidth, fileUpload.cvOptions.HideLogo);

            return File(pdfData, "application/pdf", Path.GetFileNameWithoutExtension(fileUpload.FilePath));
        }
    }
}