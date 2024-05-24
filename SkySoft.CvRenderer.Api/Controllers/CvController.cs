using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SkySoft.CvRenderer.Api.ModelsApi;
using SkySoft.CvRenderer.Api.Services;
using SkySoft.CvRenderer.Models;

namespace SkySoft.CvRenderer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        private readonly ILogger<CvController> _logger;
        private readonly IOptions<CvOptions> _cvOptions;
        private readonly ICvRenderingService _cvRenderingService;

        public CvController(
            ILogger<CvController> logger,
            IOptions<CvOptions> options,
            ICvRenderingService cvRenderingService)
        {
            _logger = logger;
            _cvOptions = options;
            _cvRenderingService = cvRenderingService;
        }

        [HttpPost]
        public IActionResult Post(RenderCvRequest request)
        {
            try
            {
                var cvOptions = request.CvOptions ?? _cvOptions.Value;

                _logger.LogTrace("Request body: {@request}", request);

                var pdfStream = _cvRenderingService.RenderPdf(request.CvData, cvOptions);

                var fileName = GetFileName(request);

                return File(pdfStream, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing CV model upload.");

                return StatusCode(500, "Internal Server Error");
            }
        }

        private static string GetFileName(RenderCvRequest request)
        {
            var name = request.CvData?.Basics?.Name;
            var lastName = request.CvData?.Basics?.LastName;

            var fullName = GetFullName(name, lastName) ?? DateTime.Now.ToString("yyyyMMdd_HHmmss");

            return $"CV_{fullName}";
        }

        private static string? GetFullName(string? name, string? lastName)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(lastName))
            {
                return null;
            }

            if (string.IsNullOrEmpty(name))
            {
                return lastName;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                return name;
            }

            return $"{name}_{lastName}";
        }
    }
}