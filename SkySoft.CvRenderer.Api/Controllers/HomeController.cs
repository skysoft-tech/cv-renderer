using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkySoft.CvRenderer.Api.Controllers
{
    [ApiController]
    [Route("download")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("PostDownloadCv")]
        public async Task<IActionResult> DownloadCv(
            [FromQuery] string filePath,
            [FromQuery] int WorkColumnWidth = 60, 
            [FromQuery] bool HideLogo = false)
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