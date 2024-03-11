using Microsoft.AspNetCore.Mvc;
using SkySoft.CvRenderer.Core.Models;
using SkySoft.CvRenderer.Utils.Api;
namespace SkySoft.CvRenderer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CreatePdfCvFromModel _createPdfCvFromModel;
        //private readonly DeserializeInputFile _deserializeInputFile;

        public HomeController(ILogger<HomeController> logger, CreatePdfCvFromModel createPdfCvFromModel/*, DeserializeInputFile deserializeInputFile*/)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _createPdfCvFromModel = createPdfCvFromModel ?? throw new ArgumentNullException(nameof(createPdfCvFromModel));
            //_deserializeInputFile = deserializeInputFile ?? throw new ArgumentNullException(nameof(deserializeInputFile));
        }

        [HttpPost("upload-model")]
        public async Task<IActionResult> UploadCvModel([FromBody] CvModel cvModel)
        {
            var jsonCv = await _createPdfCvFromModel.CreateJsonCv(cvModel);

            var a = File(jsonCv, "application/pdf", cvModel.Basics.Name + ".pdf");
            return a;
        }


        //[HttpPost("upload")]
        //public async Task<ActionResult> UploadPdfFile([FromBody] FileUploadModel fileUpload, IFormFile file)
        //{
        //    var inputStream = file.OpenReadStream();

        //    //var deserializeInputFile = new DeserializeInputFile(_logger, fileUpload);
        //    var outputStream = await _deserializeInputFile.DeserializationAsync(inputStream);

        //    return File(outputStream, "application/pdf", "file.pdf" /*Path.GetFileNameWithoutExtension(fileUpload.FilePath) + ".pdf"*/);
        //}
    }

    //[HttpPost("upload")]
    //public async Task<ActionResult> UploadPdfFile([FromBody] IFormFile file)
    //{
    //    CvOptions cvOptions = new CvOptions()
    //    {
    //        WorkColumnWidth = 60,
    //        HideLogo = true
    //    };

    //    var stream = new MemoryStream();

    //    var deserializeInputFile = new DeserializeInputFile(_logger, cvOptions, file);
    //    await deserializeInputFile.DeserializationAsync(stream);

    //    return File(stream.ToArray(), "application/pdf", "file.pdf" /*Path.GetFileNameWithoutExtension(fileUpload.FilePath) + ".pdf"*/);
    //}
}