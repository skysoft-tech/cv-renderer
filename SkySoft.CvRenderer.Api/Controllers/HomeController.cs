using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> ConvertJsonToPdf(
            [FromForm] string filePath,
            [FromForm] int WorkColumnWidth = 60,
            [FromForm] bool HideLogo = false)
        {
            if (!System.IO.File.Exists(filePath))
            {
                _logger.LogError("JSON file does not exist.");
                return NotFound();
            }

            var executor = new Executor(_logger);

            var pdfData = await executor.Run(filePath, WorkColumnWidth, HideLogo);

            return File(pdfData, "application/pdf", Path.GetFileNameWithoutExtension(filePath));
        }
    }
}